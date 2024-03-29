﻿using MafiaForum.ViewModels.Forum;

namespace MafiaForum.ViewModels.Post
{
    public class PostListingViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string AuthorName { get; set; }
        public int AuthorRating { get; set; }
        public string AuthorId { get; set; }
        public string DatePosted { get; set; }

        public ForumListingViewModel Forum { get; set; }

        public int RepliesCount { get; set; }
    }
}