using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MafiaForum.Models;
using MafiaForum.Models.Interfaces;

namespace MafiaForum.Service
{
    public class UserService : IUser

    {
        private readonly ApplicationContext _context;

        public UserService(ApplicationContext context)
        {
            _context = context;
        }

        public User GetById(string id)
        {
            return GetAll().FirstOrDefault(user => user.Id == id);
        }

        public IEnumerable<User> GetAll()
        {
            return _context.ApplicationUsers;
        }

        public async Task SetProfileImage(string id, Uri uri)
        {
            var user = GetById(id);
            user.ProfileImageUrl = uri.AbsoluteUri;
            _context.Update(user);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateUserRating(string id, Type type)
        {
            var user = GetById(id);
            user.Rating = CalculateUserRating(type, user.Rating);
            await _context.SaveChangesAsync();
            
        }

        private int CalculateUserRating(Type type, int userRating)
        {
            var inc = 0;

            if (type == typeof(Post))
            {
                inc = 1;
            }

            if (type == typeof(PostReply))
            {
                inc = 3;
            }

            return userRating + inc;
        }
    }
}
