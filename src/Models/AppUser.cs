using Blog.Data.Enum;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Blog.Models
{
    public class AppUser : IdentityUser
    {
        public string? PhotoUrl { get; set; }
    }
}
