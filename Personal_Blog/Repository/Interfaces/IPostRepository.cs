using Personal_Blog.Models.Schema;

namespace Personal_Blog.Repository.Interfaces
{
    public interface IPostRepository
    {
        public List<Post> GetAll();
        public Post GetById(int id);
        public bool Create(Post post);
        public bool Update(Post post);
        public bool Delete(Post post);
            

    }
}
