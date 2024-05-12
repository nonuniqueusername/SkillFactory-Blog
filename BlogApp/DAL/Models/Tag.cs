using System.Collections.Generic;
using System;

namespace BlogApp.DAL.Models
{
    public class Tag
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; } = null!;
        public List<Post> Posts { get; set; } = new();
    }
}
