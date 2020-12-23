using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MafiaForum.Models;
using MafiaForum.Models.Interfaces;
using MafiaForum.ViewModels.Post;
using MafiaForum.ViewModels.Reply;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace MafiaForum.Controllers
{
    public class PostController : Controller
    {
        //Creating a constructor, so we can use DEPENDENCY INJECTION to pass-in our services to our PostController.
        private readonly IPost _postService; //private readonly field to store our PostService
        private readonly IForum _forumService;
        private readonly IUser _userService;
        
        private static UserManager<User> _userManager;

        public PostController(IPost postService, IForum forumService, UserManager<User> userManager, IUser userService)
        {
            _postService = postService; //Assign the private field in our constructor.
            _forumService = forumService;
            _userManager = userManager;
            _userService = userService;
        }

        public IActionResult Index(int id)
        {
            var post = _postService.GetById(id);
            var replies = BuildPostReplies(post.Replies);

            var model = new PostIndexViewModel
            {
                Id = post.Id,
                Title = post.Title,
                AuthorId = post.User.Id,
                AuthorName = post.User.Nickname,
                AuthorImageUrl = post.User.ProfileImageUrl,
                AuthorRating = post.User.Rating,
                DateCreated = post.Created,
                PostContent = post.Content,
                Replies = replies,
                ForumId = post.Forum.Id,
                ForumName = post.Forum.Title,
                IsAuthorAdmin = IsAuthorAdmin(post.User)
            };

            return View(model);
        }

        [Authorize]
        public IActionResult Create(int id) //id is Forum.Id
        {
            var forum = _forumService.GetById(id);

            var model = new NewPostViewModel
            {
                ForumName = forum.Title,
                ForumId = forum.Id,
                ForumImageUrl = forum.ImageUrl,
                AuthorName = User.Identity.Name //Get logged in user
            };

            return View(model);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> AddPost(NewPostViewModel model)
        {
            var userId = _userManager.GetUserId(User);
            //var user = await _userManager.FindByIdAsync(userId); //There were issues when trying it with await infront.
            var user = _userManager.FindByIdAsync(userId).Result;

            var post = BuildPost(model, user);

            await _postService.Add(post);
            await _userService.UpdateUserRating(userId, typeof(Post));

            return RedirectToAction("Index", "Post", new { id = post.Id });
        }

        private Post BuildPost(NewPostViewModel model, User user)
        {
            var forum = _forumService.GetById(model.ForumId);

            return new Post
            {
                Title = model.Title,
                Content = model.Content,
                Created = DateTime.Now,
                User = user,
                Forum = forum
            };
        }

        private IEnumerable<PostReplyViewModel> BuildPostReplies(IEnumerable<PostReply> replies)
        {
            return replies.Select(reply => new PostReplyViewModel
            {
                Id = reply.Id,
                AuthorName = reply.User.Nickname,
                AuthorId = reply.User.Id,
                AuthorRating = reply.User.Rating,
                AuthorImageUrl = reply.User.ProfileImageUrl,
                DateCreated = reply.Created,
                ReplyContent = reply.Content,
                IsAuthorAdmin = IsAuthorAdmin(reply.User)
            });
        }

        private bool IsAuthorAdmin(User user)
        {
            return _userManager.GetRolesAsync(user)
                .Result.Contains("admin");
        }
    }
}