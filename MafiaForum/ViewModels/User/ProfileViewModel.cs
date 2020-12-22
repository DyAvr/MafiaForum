using System;
using Microsoft.AspNetCore.Http;

namespace MafiaForum.ViewModels.User
{
    public class ProfileViewModel
    {
        public string UserId { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string Nickname { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string UserRating { get; set; }
        public string ProfileImageUrl { get; set; }
        public bool IsAdmin { get; set; }

        public DateTime MemeberSince { get; set; } //Set when user joins
        public IFormFile ImageUpload { get; set; }
    }
}
