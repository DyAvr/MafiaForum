using System.Collections.Generic;
using MafiaForum.ViewModels.Post;

namespace MafiaForum.ViewModels.Forum
{
    public class ForumTopicViewModel
    {
        public ForumListingViewModel Forum { get; set; }
        public IEnumerable<PostListingViewModel> Posts { get; set; }
        public string SearchQuery { get; set; }
    }
}
