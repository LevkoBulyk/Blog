using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Blog.Models
{
    public class Article
    {
        public Article()
        {
            TextItems = new List<ArticleText>();
            MediaItems = new List<ArticleMedia>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        public string? Abstract { get; set; }
        public DateTime LastEdition { get; set; }

        public List<ArticleText> TextItems { get; set; }
        public List<ArticleMedia> MediaItems { get; set; }
    }
}
