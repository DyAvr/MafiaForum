using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace MafiaForum.Models
{
    [Table("PostReply")]
    public class PostReply
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public DateTime Created { get; set; }

        public virtual User User { get; set; }
        public virtual Post Post { get; set; }
    }
}
