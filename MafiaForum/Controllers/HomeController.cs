using MafiaForum.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Linq;
using MafiaForum.Models.Interfaces;
using MafiaForum.ViewModels.Forum;
using MafiaForum.ViewModels.Home;
using MafiaForum.ViewModels.Post;

namespace MafiaForum.Controllers
{
    public class HomeController : Controller
    {
        private readonly IPost _postService;

        public HomeController(IPost postService)
        {
            _postService = postService;
        }

        public IActionResult Index()
        {
            var model = BuildHomeIndexViewModel();
            return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        private HomeIndexViewModel BuildHomeIndexViewModel()
        {
            var latestPosts = _postService.GetLatestPosts(5);

            var posts = latestPosts.Select(post => new PostListingViewModel
            {
                Id = post.Id,
                Title = post.Title,
                AuthorName = post.User.Nickname,
                AuthorId = post.User.Id,
                AuthorRating = post.User.Rating,
                DatePosted = post.Created.ToString(),
                RepliesCount = post.Replies.Count(),
                Forum = GetForumListingForPost(post)
            });

            return new HomeIndexViewModel
            {
                LatestPosts = posts,
                SearchQuery = ""
            };
        }

        private ForumListingViewModel GetForumListingForPost(Post post)
        {
            var forum = post.Forum;

            return new ForumListingViewModel
            {
                Id = forum.Id,
                Title = forum.Title,
                ImageUrl = forum.ImageUrl
            };
        }
    }
}
