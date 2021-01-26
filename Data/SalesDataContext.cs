/**
 * File: SalesDataContext.cs
 */ 

using Microsoft.EntityFrameworkCore;
using SalesDataAPI.Dtos;
using SalesDataAPI.Models;

namespace SalesDataAPI.Data
{
    public class SalesDataContext : DbContext
    {
        public SalesDataContext(DbContextOptions<SalesDataContext> opt) : base(opt)
        {

        }

        public DbSet<Article> Articles { get; set; }
        public DbSet<ArticleStatsDto> ArticleStats { get; set; }

    }
}