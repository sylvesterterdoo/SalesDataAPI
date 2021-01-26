/**
 * File: ArticleCreateDto.c.
 * A DTO that represent a newly created article.
 */

using System;

namespace SalesDataAPI.Dtos
{
    public class ArticleCreateDto
    {

        public string ArticleNumber { get; set; }

        public double SalesPrice { get; set; }

        public DateTime DateOfSale = DateTime.Now;
       

    }
}