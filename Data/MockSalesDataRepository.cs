/**
 * File : MockSalesDAtaRepository.cs
 * A mock class that implement the ISalesDataRepository
 */

using System;
using System.Collections.Generic;
using System.Linq;
using SalesDataAPI.Dtos;
using SalesDataAPI.Models;

namespace SalesDataAPI.Data
{
    public class MockSalesDataRepository : ISalesDataRepository
    {

        IEnumerable<ArticleStatsDto> ISalesDataRepository.GetArticlesStatistics(DateTime? start, DateTime? end)
        {
            var articlesStats = new Dictionary<string, int>()
                    {
                        { "article1", 12 },
                        { "article2", 32 },
                        { "article3", 42}
                    };

            var entries = articlesStats.Select(d =>
                string.Format("\"{0}\": {1}", d.Key, string.Join(",", d.Value)));
            return null;
        }

        public string GetNumberOfSoldArticlePerDay(DateTime? date)
        {
            int numberOfSoldArticles = 0;
            if (date != null)
            {
                foreach (Article article in new MockSalesDataRepository().GetSoldArticlesPerDay())
                {
                    if (article.DateOfSale.Date == date?.Date)
                    {
                        numberOfSoldArticles += 1;
                    }
                }
            }
            string result = "{\"Number of sold articles\" : " + numberOfSoldArticles + " }";
            return result;
        }

        private IEnumerable<Article> GetSoldArticlesPerDay()
        {
            var sales = new List<Article>
            {
                 new Article { Id = 0, ArticleNumber = "6702919524", SalesPrice = 20.5, DateOfSale = new DateTime(2018, 3, 15) },
                 new Article { Id = 1, ArticleNumber = "9902919524", SalesPrice = 30.5, DateOfSale = new DateTime(2020, 1, 10) },
                 new Article { Id = 2, ArticleNumber = "8502919524", SalesPrice = 10.5, DateOfSale = new DateTime(2021, 1, 1) },
                 new Article { Id = 3, ArticleNumber = "9202919524", SalesPrice = 50.5, DateOfSale = new DateTime(2020, 12, 25) },
                 new Article { Id = 4, ArticleNumber = "3202919524", SalesPrice = 15.5, DateOfSale = new DateTime(2018, 3, 15) },
            };

            return sales;
        }

        public string GetTotalRevenuePerDay(DateTime? date)
        {
            double totalRevenue = 0;
            foreach (Article article in new MockSalesDataRepository().GetSoldArticlesPerDay())
            {
                if (article.DateOfSale.Date == date?.Date)
                {
                    totalRevenue += article.SalesPrice;
                }
            }

            var articlesStats = new Dictionary<string, object>()
            {
                { "Number of sold articles", totalRevenue },
                { "Date", String.Format("{0:M/d/yyyy}", date) }
            };

            var entries = articlesStats.Select(d =>
                string.Format("\"{0}\": {1}", d.Key, string.Join(",", d.Value)));
                
            return "{" + string.Join(",", entries) + "}";
        }

        public void CreateArticle(Article article)
        {
            throw new NotImplementedException();
        }

        public bool SaveChanges()
        {
            throw new NotImplementedException();
        }

        public Article GetArticleById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Article> GetAllArticles()
        {
            throw new NotImplementedException();
        }

    }
}