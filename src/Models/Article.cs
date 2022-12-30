using System.ComponentModel.DataAnnotations;

namespace Blog.Models
{
    public class Article
    {
        public Article(IEnumerable<ArticleItem> items)
        {
            Items = items;
        }

        [Key]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        public string? Abstract { get; set; }
        public DateTime LastEdition { get; set; }

        IEnumerable<ArticleItem> Items { get; set; }
    }
}
