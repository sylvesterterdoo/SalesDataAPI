/**
 * File: Article.cs
 * Models an Article 
 */

using System;
using System.ComponentModel.DataAnnotations;

namespace SalesDataAPI.Models
{
    public class Article
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(32)]
        public string ArticleNumber { get; set; }

        [Required]
        public double SalesPrice { get; set; }

        [Required]
        public DateTime DateOfSale { get; set; }
    }
}