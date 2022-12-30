using System.ComponentModel.DataAnnotations;

namespace Blog.Models
{
    public class ArticleText : ArticleItem
    {
        [Required]
        public string text { get; set; }
    }
}
