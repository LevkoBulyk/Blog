using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Blog.Models
{
    public class Article
    {
        public Article()
        {
            Items = new List<ArticleItem>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        public string? Abstract { get; set; }
        public DateTime LastEdition { get; set; }
        public string? ImageUrl { get; set; }

        public List<ArticleItem> Items { get; set; }
    }
}
