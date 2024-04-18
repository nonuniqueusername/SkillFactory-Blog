using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace BlogApp.DAL.Models
{
    public class Role : IdentityRole
    {
        public string? Description { get; set; }
        public List<User> Users { get; set; } = new();
    }
}
