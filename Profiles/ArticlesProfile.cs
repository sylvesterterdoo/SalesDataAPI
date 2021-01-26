/**
 * File: ArticlesProfile.cs
 */

using AutoMapper;
using SalesDataAPI.Dtos;
using SalesDataAPI.Models;

namespace SalesDataAPI.Profiles
{
    public class ArticlesProfile : Profile
    {
        public ArticlesProfile()
        {
            // Source -> Target
            CreateMap<Article, ArticleReadDto>();
            CreateMap<ArticleCreateDto, Article>();
        }
    }
}