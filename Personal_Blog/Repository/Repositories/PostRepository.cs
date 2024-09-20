using Microsoft.EntityFrameworkCore;
using Personal_Blog.Data;
using Personal_Blog.Models.Schema;
using Personal_Blog.Repository.Interfaces;

namespace Personal_Blog.Repository.Repositories
{
    public class PostRepository : IPostRepository
    {
        private readonly ApplicationDbContext _context;
        public PostRepository(ApplicationDbContext context)
        {
            _context = context;
            
        }
        public List<Post> GetAll()
        {
            var data = _context.Posts
                .Include(p => p.Comments)
                .ToList();
            return data;
        }

        public Post GetById(int id)
        {
            var data = _context.Posts
                .Include(p => p.Comments)
                    .ThenInclude(p => p.Commenter)
                .Include(p => p.Author)
                .FirstOrDefault() ?? throw new Exception("Not found");
            return data;

        }
        public bool Create(Post post)
        {
            _context.Posts.Add(post);
            _context.SaveChanges();
            return true;
        }

        public bool Delete(Post post)
        {
            _context.Posts.Remove(post);
            _context.SaveChanges();
            return true;
        }

        public bool Update(Post post)
        {
           _context.Posts.Update(post);
            _context.SaveChanges ();
            return true;
        }
    }
}
