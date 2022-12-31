﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Blog.Models
{
    public class Article
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        public string Abstract { get; set; }
        public string Text { get; set; }
        public DateTime LastEdition { get; set; }
        public string? ImageUrl { get; set; }

    }
}
