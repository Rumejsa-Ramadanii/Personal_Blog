using Personal_Blog.Models.Schema;

namespace Personal_Blog.Repository.Interfaces
{
    public interface ICommentRepository
    {
        public List<Comment> GetAll();
        public Comment GetById(int id);
        public bool Create(Comment comment);
        public bool Update(Comment comment);
        public bool Delete(Comment comment);
    }
}
