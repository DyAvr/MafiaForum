using System.Collections.Generic;
using MafiaForum.ViewModels.Post;

namespace MafiaForum.ViewModels.Home
{
    public class HomeIndexViewModel
    {
        public string SearchQuery { get; set; }
        public IEnumerable<PostListingViewModel> LatestPosts { get; set; }
    }
}
