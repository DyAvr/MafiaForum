using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace MafiaForum.ViewModels.Forum
{
    public class ForumIndexViewModel
    {
        public IEnumerable<ForumListingViewModel> ForumList { get; set; }
    }
}
