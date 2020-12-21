using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MafiaForum.Models.Interfaces
{
    public interface IForum
    {
        Forum GetById(int id);
        IEnumerable<Forum> GetAll();
        IEnumerable<User> GetAllActiveUsers();

        Task Create(Forum forum);
        Task Delete(int forumId);
        Task UpdateForumTitle(int forumId, string newTitle);
        Task UpdateForumDescription(int forumId, string newDescription);
    }
}
