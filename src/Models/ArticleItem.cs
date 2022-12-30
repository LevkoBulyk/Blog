using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Blog.Models
{
    public class ArticleItem
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int LocationOrder { get; set; }
        [Required]
        [ForeignKey("Article")]
        public int ArticleId { get; set; }
        public Article? Article { get; set; }
    }
}
