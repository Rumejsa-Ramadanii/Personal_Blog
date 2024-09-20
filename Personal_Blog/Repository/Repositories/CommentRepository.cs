using Personal_Blog.Data;
using Personal_Blog.Models.Schema;
using Personal_Blog.Repository.Interfaces;

namespace Personal_Blog.Repository.Repositories
{
    public class CommentRepository : ICommentRepository

    {
        private readonly ApplicationDbContext _context;
        public CommentRepository(ApplicationDbContext context)
        {
            _context = context;
            
        }
        public List<Comment> GetAll()
        {
            var data = _context.Comments.ToList();
            return data;

        }

        public Comment GetById(int id)
        {
            var data = _context.Comments.FirstOrDefault() ?? throw new KeyNotFoundException();
            return data;
        }
        public bool Create(Comment comment)
        {
            _context.Comments.Add(comment);
            _context.SaveChanges();
            return true;
        }

        public bool Delete(Comment comment)
        {
            _context.Remove(comment);
            _context.SaveChanges();
            return true;
        }

        public bool Update(Comment comment)
        {
            _context.Comments.Update(comment);
            _context.SaveChanges();
            return true;

            
        }
    }
}
