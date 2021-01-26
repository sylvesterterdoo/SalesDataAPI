/**
 * File: ArticleController.cs
 * Article Controller class
 */

using System;
using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SalesDataAPI.Data;
using SalesDataAPI.Dtos;
using SalesDataAPI.Models;

namespace SalesDataAPI.Controllers
{

    // api/articles
    [Route("api/articles")]
    [ApiController]
    public class ArticlesController : ControllerBase
    {
        private readonly ISalesDataRepository _repository;
        private readonly IMapper _mapper;

        //private readonly MockSalesDataRepository _repository = new MockSalesDataRepository();

        public ArticlesController(ISalesDataRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        // GET api/articles/{date}
        [HttpGet("{date:datetime?}")]
        public ActionResult GetNumberOfSoldArticlePerDay(DateTime? date)
        {
            var numberOfSoldArticles = _repository.GetNumberOfSoldArticlePerDay(date);

            if (numberOfSoldArticles != null)
            {
                return Content(numberOfSoldArticles, "application/json");
            }
            return NotFound();
        }

        // GET api/articles/revenue/{data}
        [HttpGet("revenue/{date:datetime?}")]
        public ActionResult<Article> GetTotalRevenuePerDay(DateTime? date)
        {
            var totalRevenuePerDay = _repository.GetTotalRevenuePerDay(date);

            if (totalRevenuePerDay != null)
            {
                return Content(totalRevenuePerDay, "appliction/json");
            }
            return NotFound();
        }

        // GET api/articles/statistics/{startdata}/{enddate}
        [HttpGet("statistics/{start:datetime}/{end:datetime}")]
        public ActionResult<IEnumerable<ArticleStatsDto>> GetArticleStatistics(DateTime? start, DateTime? end)
        {
            var articlesStatistics = _repository.GetArticlesStatistics(start, end);

            if (articlesStatistics != null)
            {
                return Ok(_mapper.Map<IEnumerable<ArticleStatsDto>>(articlesStatistics));
            }

            return NoContent();
        }

        // POST api/articles/
        [HttpPost]
        public ActionResult<ArticleReadDto> CreateArticle(ArticleCreateDto articleCreateDto)
        {
            var articleModel = _mapper.Map<Article>(articleCreateDto);

            _repository.CreateArticle(articleModel);
            _repository.SaveChanges();

            var articleReadDto = _mapper.Map<ArticleReadDto>(articleModel);

            return CreatedAtRoute(nameof(GetArticleById), new { Id = articleReadDto.Id }, articleReadDto);
        }



        // GET api/articles/
        [HttpGet]
        public ActionResult<IEnumerable<ArticleReadDto>> GetAllArticlesSold()
        {
            var articleItems = _repository.GetAllArticles();

            return Ok(_mapper.Map<IEnumerable<ArticleReadDto>>(articleItems));
        }

        // GET api/articles/{id} 
        [HttpGet("{id}", Name = "GetArticleById")]
        public ActionResult<ArticleReadDto> GetArticleById(int id)
        {

            var articleItem = _repository.GetArticleById(id);

            if (articleItem != null)
            {
                return Ok(_mapper.Map<ArticleReadDto>(articleItem));
            }
            return NotFound();
        }


    }
}