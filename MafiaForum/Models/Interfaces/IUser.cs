using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MafiaForum.Models.Interfaces
{
    public interface IUser
    {
        User GetById(string id);
        IEnumerable<User> GetAll();
        Task SetProfileImage(string id, Uri uri);
        Task UpdateUserRating(string id, Type type);
    }
}
