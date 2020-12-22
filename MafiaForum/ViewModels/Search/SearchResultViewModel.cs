using System.Collections.Generic;
using MafiaForum.ViewModels.Post;

namespace MafiaForum.ViewModels.Search
{
    public class SearchResultViewModel
    {
        public IEnumerable<PostListingViewModel> Posts { get; set; }
        public string SearchQuery { get; set; }
        public bool EmptySearchResults { get; set; }
    }
}
