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
        [ForeignKey("Article")]
        public int ArticleId { get; set; }
    }
}
