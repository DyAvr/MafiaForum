using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace MafiaForum.Models
{
    public class User : IdentityUser
    {
        public string Nickname { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
    }
}
