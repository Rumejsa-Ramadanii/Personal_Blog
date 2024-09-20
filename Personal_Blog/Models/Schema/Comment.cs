using System.ComponentModel.DataAnnotations;

namespace Personal_Blog.Models.Schema
{
    public class Comment
    {
        [Key]
        public int Id { get; set; }
        public string? Content { get; set; }
        public DateTime? CreatedAt { get; set; }

        //Relationship with Post Foreign Keys
        public int PostId { get; set; }
        public string? CommenterId { get; set; }

        public Post? Post { get; set; }
        public ApplicationUser? Commenter {get; set;}
}
}
