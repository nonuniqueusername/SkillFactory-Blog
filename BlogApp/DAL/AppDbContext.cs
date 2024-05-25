using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using BlogApp.DAL.Models;
using System.Collections.Generic;

namespace BlogApp.DAL
{
    public class AppDbContext : IdentityDbContext<User>
    {
        /// Ссылка на таблицу Posts
        public DbSet<Post>? Posts { get; set; }
        /// Ссылка на таблицу Tags
        public DbSet<Tag>? Tags { get; set; }
        /// Ссылка на таблицу Comments
        public DbSet<Comment>? Comments { get; set; }
        /// Ссылка на таблицу Users
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            Database.EnsureDeleted();
            Database.EnsureCreated();
        }
    }
}
