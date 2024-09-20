using Microsoft.AspNetCore.Identity;
using Personal_Blog.Models.Schema;

namespace Personal_Blog.Data
{
    public static class SeedPosts
    {
        public static void Seed(this IServiceProvider serviceProvider, ApplicationDbContext context)
        {
            if(!context.Posts.Any())
            {
                var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();

                var adminUser = userManager.FindByEmailAsync("admin@blog.com").Result;
                if (adminUser == null)
                {
                    adminUser = new ApplicationUser
                    {
                        UserName = "admin@blog.com",
                        Email = "admin@blog.com",
                        EmailConfirmed = true,
                        PhoneNumberConfirmed = true
                    };

                    var result = userManager.CreateAsync(adminUser, "Admin123!").Result;
                    if (!result.Succeeded)
                    {
                        throw new Exception("Failed to create admin user.");
                    }
                }

                var comments = new List<Comment>
                {
                    new Comment
                    {
                        Content = "Comment 1 here.",
                        CreatedAt = DateTime.Now,
                        Commenter = adminUser,
                        CommenterId = adminUser.Id
                    },
                    new Comment
                    {
                        Content = "Comment 2 here.",
                        CreatedAt = DateTime.Now,
                        Commenter = adminUser,
                        CommenterId = adminUser.Id
                    },
                    new Comment
                    {
                        Content = "Comment 3 here.",
                        CreatedAt = DateTime.Now,
                        Commenter = adminUser,
                        CommenterId = adminUser.Id
                    }
                };

                var post = new Post
                {
                    Title = "Test Title",
                    Content = "Lorem ipsum dolor sit amet.",
                    CreatedAt = DateTime.Now,
                    Comments = comments,
                    Author = adminUser
                };

                context.Posts.Add(post);
                context.SaveChanges();
            }
        }
    }
}
