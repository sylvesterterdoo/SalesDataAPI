/**
 * File: ArticleCreateDto.c.
 * A DTO that represent a newly created article.
 */

using System;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SalesDataAPI.Dtos
{
    public class ArticleCreateDto
    {

        [Required(ErrorMessage = "ArticleNumber is required")]
        [StringLength(32, ErrorMessage = "Name can't be longer than 60 characters")]
        public string ArticleNumber { get; set; }

        [Required(ErrorMessage = "SalesPrice is required")]
        public double SalesPrice { get; set; }

        public DateTime DateOfSale = DateTime.Now;
       

    }
}