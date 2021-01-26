/**
 * File: PrepDB.cs 
 */

using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using SalesDataAPI.Data;

namespace SalesDataAPI.Models
{
    public static class PrepDB
    {
        public static void PrepPopulation(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                SeedData(serviceScope.ServiceProvider.GetService<SalesDataContext>());
            }
        }

        public static void SeedData(SalesDataContext context)
        {
            System.Console.WriteLine("Applying Migrations...");
            context.Database.Migrate();

            System.Console.WriteLine("Adding data - seeding");
            context.Articles.AddRange(
            new Article() { ArticleNumber = "articleNumber1", SalesPrice = 20.5, DateOfSale = new DateTime(2021, 1, 1) },
            new Article() { ArticleNumber = "articleNumber2", SalesPrice = 30.5, DateOfSale = new DateTime(2020, 1, 10) },
            new Article() { ArticleNumber = "articleNumber3", SalesPrice = 10.5, DateOfSale = new DateTime(2021, 1, 1) },
            new Article() { ArticleNumber = "articleNumber4", SalesPrice = 50.5, DateOfSale = new DateTime(2020, 12, 25) },
            new Article() { ArticleNumber = "articleNumber5", SalesPrice = 15.5, DateOfSale = new DateTime(2021, 1, 1) }
            );
            context.SaveChanges();
        

        }
    }
}