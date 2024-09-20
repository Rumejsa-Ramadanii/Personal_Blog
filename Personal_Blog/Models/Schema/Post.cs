using System.ComponentModel.DataAnnotations;

namespace Personal_Blog.Models.Schema
{
    public class Post
    {
        [Key]
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Content { get; set; } 
        public DateTime? CreatedAt { get; set; }

        //Foreign Key
        public string? AuthorId { get; set; }


        //Navigation property
        public ApplicationUser? Author { get; set; }

        public ICollection<Comment>? Comments { get; set; }
    }
}
