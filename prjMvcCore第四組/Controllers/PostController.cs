using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using prjMvcCore第四組.Models;
using prjMvcCore第四組.ViewModels;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace prjMvcCore第四組.Controllers
{
    public class PostController : Controller
    {

        MidprjDb2Context db = new MidprjDb2Context();

        public PostController(MidprjDb2Context context)
        {
            db = context;
        }
        public IActionResult List(CPostKeywordViewModel vm, string sortBy = "latest")
        {
            IQueryable<TPostTable> postsQuery = db.TPostTables.Include(p => p.FUser);
            if (sortBy == "popular")
            {
                if (string.IsNullOrEmpty(vm.PostKeyword))
                {
                    postsQuery = postsQuery
                        .Where(p => p.FPostState == 1)
                        .OrderByDescending(p => (p.FLikes * 10) + p.FViews);
                }
                else
                {
                    postsQuery = postsQuery
                        .Where(p => p.FPostState == 1 && p.FTitle.Contains(vm.PostKeyword))
                        .OrderByDescending(p => (p.FLikes * 10) + p.FViews);
                }
            }
            else
            {
                if (string.IsNullOrEmpty(vm.PostKeyword))
                {
                    postsQuery = postsQuery
                        .Where(p => p.FPostState == 1)
                        .OrderByDescending(p => p.FPostDate);
                }
                else
                {
                    postsQuery = postsQuery
                        .Where( p => p.FPostState == 1 && p.FTitle.Contains(vm.PostKeyword))
                        .OrderByDescending(p => p.FPostDate);
                }
            }
            var posts = postsQuery.ToList();
            ViewBag.CurrentSort = sortBy;

            return View(posts);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]

        public IActionResult Create(string fTitle, string fPostContent)
        {
            if (string.IsNullOrWhiteSpace(fTitle) || string.IsNullOrWhiteSpace(fPostContent))
            {
                ModelState.AddModelError("", "請輸入標題與內容");
                return View();
            }
            var newPost = new TPostTable
            {
                FUserId = 1,
                FTitle = fTitle,
                FPostContent = fPostContent,
                FLikes = 0,
                FViews = 0,
                FPostDate = DateTime.Now,
                FPostState = 1
            };

            db.TPostTables.Add(newPost);
            db.SaveChanges();

            return RedirectToAction("List");
        }
        public IActionResult Detail(int? id)
        {
            var post = db.TPostTables
                .Include(p => p.FUser)
                .FirstOrDefault(p => p.FPostId == id && p.FPostState == 1);

            if (post == null)
            {
                return NotFound();
            }
            post.FViews += 1;
            db.SaveChanges();

            var messages = db.TMessageTables
                .Include(m => m.FUser)
                .Where(m => m.FPostId == id && m.FMessageState == 1)
                .OrderBy(m => m.FMessageDate)
                .ToList();

            var messageUserMap = messages.ToDictionary(
                m => m.FMessageId,
                m => string.IsNullOrEmpty(m.FUser.FNickname) ? m.FUser.FUsername : m.FUser.FNickname
            );

            var messageVmList = messages.Select(m => new MessageViewModel
            {
                Message = m,
                ReplyToUsername = (m.FReplyMessageId.HasValue && messageUserMap.ContainsKey(m.FReplyMessageId.Value))
                    ? messageUserMap[m.FReplyMessageId.Value]
                    : null
            }).ToList();

            var viewModel = new PostViewModel
            {
                Post = post,
                Messages = messageVmList
            };

            return View(viewModel);
        }

        [HttpPost]

        public IActionResult AddComment(int postId, string messageContent)
        {
            if (string.IsNullOrWhiteSpace(messageContent))
            {
                return RedirectToAction(nameof(Detail), new { id = postId });
            }

            int currentUserId = 1;

            var newMessage = new TMessageTable
            {
                FPostId = postId,
                FUserId = currentUserId,
                FMessageContent = messageContent,
                FLikes = 0,
                FMessageDate = DateTime.Now,
                FMessageState = 1,
                FReplyMessageId = null
            };

            db.TMessageTables.Add(newMessage);
            TPostTable correctViews = db.TPostTables.FirstOrDefault(t => t.FPostId == postId);
            if (correctViews != null)
            {
                correctViews.FViews--;
            }
            db.SaveChanges();
            TempData["FocusAction"] = "CommentAdded";

            return RedirectToAction(nameof(Detail), new { id = postId });
        }
        public IActionResult DeletePost(int? id)
        {
            TPostTable postState = db.TPostTables.FirstOrDefault(t => t.FPostId == id);
            if (postState != null)
            {
                postState.FPostState = 0;
                db.SaveChanges();
            }

            return RedirectToAction("List");
        }

        public IActionResult DeleteComment(int postId, int? id)
        {
            TMessageTable messageState = db.TMessageTables.FirstOrDefault(t => t.FMessageId == id);
            if (messageState != null)
            {
                messageState.FMessageState = 0;
                TPostTable correctViews = db.TPostTables.FirstOrDefault(t => t.FPostId == postId);
                if (correctViews != null)
                {
                    correctViews.FViews--;
                }
                db.SaveChanges();
            }

            return RedirectToAction("Detail", new { id = postId });
        }
    }
}