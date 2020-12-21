using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace MafiaForum.Models
{
    [Table("Forum")]
    public class Forum
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Created { get; set; }
        public string ImageUrl { get; set; }

        public IEnumerable<Post> Posts { get; set; } //virtual allows to lazy load the property into Ent.Framework
    }
}
