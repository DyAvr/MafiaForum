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

        public async Task Create(Forum forum)
        {
            _context.Add(forum);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int forumId)
        {
            var forum = GetById(forumId);
            _context.Add(forum);
            await _context.SaveChangesAsync();
        }

        public Task UpdateForumTitle(int forumId, string newTitle)
        {
            throw new NotImplementedException();
        }

        public Task UpdateForumDescription(int forumId, string newDescription)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<User> GetActiveUsers(int id)
        {
            var posts = GetById(id).Posts;
            if (posts != null || !posts.Any())
            {
                var postUsers = posts.Select(p=>p.User);
                var replyUsers = posts.SelectMany(p => p.Replies).Select(r=>r.User);

                return postUsers.Union(replyUsers).Distinct();
            }

            return new List<User>();
        }

        public bool HasRecentPost(int id)
        {
            const int hoursAgo = 12;
            var window = DateTime.Now.AddHours(-hoursAgo);
            return GetById(id).Posts.Any(post => post.Created > window);
        }
    }
}
