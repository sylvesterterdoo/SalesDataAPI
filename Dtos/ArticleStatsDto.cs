/**
 * File : ArticleStatsDto.cs
 */

using System;
using Microsoft.EntityFrameworkCore;

namespace SalesDataAPI.Dtos
{
    [Keyless]
    public class ArticleStatsDto
    {
        public string ArticleNumber { get; set; }

        public int Count { get; set; }

        public double Total { get; set; }

    }

}

