/**
 * File: ISalesDataRepository.cs
 * The SalesData Interfaces, it exposes to clients the supported API actions.
 */

using System;
using System.Collections.Generic;
using SalesDataAPI.Dtos;
using SalesDataAPI.Models;

namespace SalesDataAPI.Data
{
    public interface ISalesDataRepository
    {

        /** Creates new Article */
        void CreateArticle(Article article);

        /**  Saves changes */
        bool SaveChanges();

        /** Returns the number of sold articles on the given date */
        string GetNumberOfSoldArticlePerDay(DateTime? date);

        /** Returns the revenue generated on the given date */
        string GetTotalRevenuePerDay(DateTime? date);

        /** Returns the statistics of sold articles between the start and end date */
        IEnumerable<ArticleStatsDto> GetArticlesStatistics(DateTime? start, DateTime? end);

        /** Returns the article with the given id */
        Article GetArticleById(int id);

        /** Returns all the saved articles */
        IEnumerable<Article> GetAllArticles();

    }
}