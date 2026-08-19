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
        public async Task<IActionResult> List(CPostKeywordViewModel vm)
        {
            if (string.IsNullOrEmpty(vm.PostKeyword))
            {
                var posts = await db.TPostTables
                .Include(p => p.FUser)
                .Where(p => p.FPostState == 1)
                .OrderByDescending(p => p.FPostDate)
                .ToListAsync();
                return View(posts);
            }
            else
            {
                var posts = await db.TPostTables
                .Include(p => p.FUser)
                .Where( p => p.FPostState == 1 && p.FTitle.Contains(vm.PostKeyword))
                .OrderByDescending(p => p.FPostDate)
                .ToListAsync();
                return View(posts);
            }
        }

        public async Task<IActionResult> Detail(int id)
        {
            var post = await db.TPostTables
                .Include(p => p.FUser)
                .FirstOrDefaultAsync(p => p.FPostId == id && p.FPostState == 1);

            if (post == null)
            {
                return NotFound();
            }
            post.FViews += 1;
            await db.SaveChangesAsync();

            var messages = await db.TMessageTables
                .Include(m => m.FUser)
                .Where(m => m.FPostId == id && m.FMessageState == 1)
                .OrderBy(m => m.FMessageDate)
                .ToListAsync();

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
     
        public async Task<IActionResult> AddComment(int postId, string messageContent)
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
            await db.SaveChangesAsync();

            return RedirectToAction(nameof(Detail), new { id = postId });
        }
    }
}