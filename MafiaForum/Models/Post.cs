using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MafiaForum.Models
{
    [Table("Post")]
    public class Post
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime Created { get; set; }

        public virtual User User { get; set; }
        public virtual Forum Forum { get; set; }

        public virtual IEnumerable<PostReply> Replies { get; set; }

    }
}
