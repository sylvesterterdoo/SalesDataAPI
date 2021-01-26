/**
 * File: ArticleReadDto.cs
 * A DTO that represent a read article.
 */

using System;

namespace SalesDataAPI.Dtos
{
    public class ArticleReadDto
    {
        public int Id { get; set; }

        public string ArticleNumber { get; set; }

        public double SalesPrice { get; set; }

    }


}
