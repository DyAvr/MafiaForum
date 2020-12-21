using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MafiaForum.Models;
using MafiaForum.Models.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MafiaForum.Service
{
    public class ForumService : IForum
    {
        private readonly ApplicationContext _context;

        public ForumService(ApplicationContext context)
        {
            _context = context;
        }

        public Forum GetById(int id)
        {
            var forum = _context.Forums.Where(f => f.Id == id)
                .Include(f => f.Posts).ThenInclude(p => p.User)
                .Include(f => f.Posts).ThenInclude(p => p.Replies).ThenInclude(r => r.User)
                .FirstOrDefault();
            return forum;
            //throw new NotImplementedException();
        }

        public IEnumerable<Forum> GetAll()
        {
            return _context.Forums
                .Include(forum => forum.Posts);
        }

        public IEnumerable<User> GetAllActiveUsers()
        {
            throw new NotImplementedException();
        }

        public Task Create(Forum forum)
        {
            throw new NotImplementedException();
        }

        public Task Delete(int forumId)
        {
            throw new NotImplementedException();
        }

        public Task UpdateForumTitle(int forumId, string newTitle)
        {
            throw new NotImplementedException();
        }

        public Task UpdateForumDescription(int forumId, string newDescription)
        {
            throw new NotImplementedException();
        }
    }
}
