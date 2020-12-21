using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MafiaForum.ViewModels
{
    public class CreateUserViewModel
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string Nickname { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
    }
}
