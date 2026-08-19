using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using prjMvcCore第四組.Models;
using prjMvcCore第四組.ViewModels;

namespace prjMvcCore第四組.Controllers
{
    public class PostController : Controller
    {

        MidprjDb2Context db = new MidprjDb2Context();

        public PostController(MidprjDb2Context context)
        {
            db = context;
        }
        public IActionResult List(CPostKeywordViewModel vm)
        {
            if (string.IsNullOrEmpty(vm.PostKeyword))
            {
                var posts = db.TPostTables
                .Include(p => p.FUser)
                .Where(p => p.FPostState == 1)
                .OrderByDescending(p => p.FPostDate)
                .ToList();
                return View(posts);
            }
            else
            {
                var posts = db.TPostTables
                .Include(p => p.FUser)
                .Where( p => p.FPostState == 1 && p.FTitle.Contains(vm.PostKeyword))
                .OrderByDescending(p => p.FPostDate)
                .ToList();
                return View(posts);
            }
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
            db.SaveChanges();

            return RedirectToAction(nameof(Detail), new { id = postId });
        }

        public IActionResult DeleteComment(int postId, int? id)
        {
            TMessageTable x = db.TMessageTables.FirstOrDefault(t => t.FMessageId == id);
            if (x != null)
            {
                db.TMessageTables.Remove(x);
                db.SaveChanges();
            }

            return RedirectToAction(nameof(Detail), new { id = postId });
        }
    }
}