﻿using System.Linq;
using MafiaForum.Models;
using MafiaForum.Models.Interfaces;
using MafiaForum.ViewModels.Forum;
using MafiaForum.ViewModels.Post;
using MafiaForum.ViewModels.Search;
using Microsoft.AspNetCore.Mvc;

namespace MafiaForum.Controllers
{
    public class SearchController : Controller
    {
        private readonly IPost _postService;

        public SearchController(IPost postService)
        {
            _postService = postService;
        }

        public IActionResult Results(string searchQuery)
        {
            var posts = _postService.GetFilteredPosts(searchQuery);
            var areNoResults = (!string.IsNullOrEmpty(searchQuery) && !posts.Any());

            var postListings = posts.Select(post => new PostListingViewModel
            {
                Id = post.Id,
                AuthorId = post.User.Id,
                AuthorName = post.User.UserName,
                AuthorRating = post.User.Rating,
                Title = post.Title,
                DatePosted = post.Created.ToString(),
                RepliesCount = post.Replies.Count(),
                Forum = BuildForumListing(post)
            });

            var model = new SearchResultViewModel
            {
                Posts = postListings,
                SearchQuery = searchQuery,
                EmptySearchResults = areNoResults
            };

            return View(model);
        }

        private ForumListingViewModel BuildForumListing(Post post)
        {
            var forum = post.Forum;
            return new ForumListingViewModel
            {
                Id = forum.Id,
                Title = forum.Title,
                ImageUrl = forum.ImageUrl,
                Description = forum.Description
            };
        }

        [HttpPost]
        public IActionResult Search(string searchQuery)
        {
            return RedirectToAction("Results", new { searchQuery });
        }
    }
}