
using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AquariumForum.Data;
using AquariumForum.Models;

namespace AquariumForum.Controllers
{
    public class CommentsController : Controller
    {
        private readonly AquariumForumContext _context;

        public CommentsController(AquariumForumContext context)
        {
            _context = context;
        }

        // GET: Comments for a specific Discussion
        public async Task<IActionResult> Index(int? discussionId)
        {
            if (discussionId == null)
            {
                return NotFound();
            }

            var comments = await _context.Comment
                .Where(c => c.DiscussionId == discussionId)
                .Include(c => c.Discussion)
                .OrderByDescending(c => c.CreateDate)
                .ToListAsync();

            ViewData["DiscussionTitle"] = comments.FirstOrDefault()?.Discussion.Title ?? "Discussion";
            ViewData["DiscussionId"] = discussionId;

            return View(comments);
        }

        // GET: Comments/Create
        public IActionResult Create(int discussionId)
        {
            ViewData["DiscussionId"] = discussionId;
            return View();
        }

        // POST: Comments/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Comment comment)
        {
            if (ModelState.IsValid)
            {
                comment.CreateDate = DateTime.Now;
                _context.Add(comment);
                await _context.SaveChangesAsync();

                // Redirect back to the discussion details view
                return RedirectToAction("Details", "Discussions", new { id = comment.DiscussionId });
            }

            // If the model state is invalid, show the form again
            return View(comment);
        }



        private bool CommentExists(int id)
        {
            return _context.Comment.Any(e => e.CommentId == id);
        }
    }
}

