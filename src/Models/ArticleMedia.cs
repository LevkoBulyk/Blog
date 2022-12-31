using System.ComponentModel.DataAnnotations;

namespace Blog.Models
{
    public class ArticleMedia : ArticleItem
    {
        public string? Title { get; set; }
        [Required]
        public string MediaUrl { get; set; }
    }
}
