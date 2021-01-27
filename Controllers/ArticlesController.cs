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
    /// <summary>
    ///  Article Controller responsible for managing articles
    /// </summary>
    [Route("api/articles")]
    [ApiController]
    [Produces("application/json")]
    public class ArticlesController : ControllerBase
    {
        private readonly ISalesDataRepository _repository;
        private readonly IMapper _mapper;


        public ArticlesController(ISalesDataRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }


        /// <summary>
        ///  This POST method creates a new Article 
        /// </summary>   
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /api/articles/
        ///     {
        ///        "ArticleNumber": "articleNumber1",
        ///        "SalesPrice": 25.5
        ///     }
        ///
        /// </remarks>
        /// <param name="article"></param>
        /// <returns>A newly created article</returns>
        /// <response code="201">Returns the newly created article</response>
        /// <response code="400">If the article is null</response> 
        // POST api/articles/
        [HttpPost]
        public ActionResult<ArticleReadDto> CreateArticle([FromBody]ArticleCreateDto articleCreateDto)
        {
            try 
            {
                if (articleCreateDto == null)
                {
                    return BadRequest("Article is null");
                }

                if (!ModelState.IsValid)
                {
                    return BadRequest("Invalid model object");
                }

                var articleModel = _mapper.Map<Article>(articleCreateDto);

                _repository.CreateArticle(articleModel);
                _repository.SaveChanges();

                var articleReadDto = _mapper.Map<ArticleReadDto>(articleModel);

                return CreatedAtRoute(nameof(GetArticleById), new { Id = articleReadDto.Id }, articleReadDto);
    
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Logging {ex}");
                return StatusCode(500, "Internal server error");
            }
       }



        /// <summary>
        ///  This Get method returns the number of sold article on a particular day {YY-MM-DD}
        /// </summary>
        /// <returns>Returns the number of sold articles</returns>
        // GET api/articles/{date}
        [HttpGet("{date:datetime?}")]
        public ActionResult GetNumberOfSoldArticlePerDay(DateTime? date)
        {
            try
            {
                var numberOfSoldArticles = _repository.GetNumberOfSoldArticlePerDay(date);

                if (numberOfSoldArticles != null)
                {
                    return Content(numberOfSoldArticles, "application/json");
                }
                return NotFound();     
            }
            catch (Exception ex)
            {

                Console.WriteLine($"Logging {ex}");
                return StatusCode(500, "Internal Server Error");
            }
          
        }

        /// <summary>
        ///  This GET method returns the total revenue generated on a particular day {YY-MM-DD}
        /// </summary>   
        /// <returns>Returns the total revenue of sold articles</returns>
        // GET api/articles/revenue/{data}
        [HttpGet("revenue/{date:datetime?}")]
        public ActionResult GetTotalRevenuePerDay(DateTime? date)
        {
            try
            {
                var totalRevenuePerDay = _repository.GetTotalRevenuePerDay(date);

                if (totalRevenuePerDay != null)
                {
                    return Content(totalRevenuePerDay, "appliction/json");
                }
                return NotFound();
            }
            catch (Exception ex)
            {

                Console.WriteLine($"Logging {ex}");
                return StatusCode(500, "Internal Server Error") ;
            }
        }

        /// <summary>
        ///  This GET method returns the statistics of articles sold between two dates
        /// </summary>   
        /// <returns>Returns the statistics of articles sold</returns>
        // GET api/articles/statistics/{startdata}/{enddate}
        [HttpGet("statistics/{start:datetime}/{end:datetime}")]
        public ActionResult<IEnumerable<ArticleStatsDto>> GetArticleStatistics(DateTime? start, DateTime? end)
        {
            try
            {
                var articlesStatistics = _repository.GetArticlesStatistics(start, end);

                if (articlesStatistics != null)
                {
                    return Ok(_mapper.Map<IEnumerable<ArticleStatsDto>>(articlesStatistics));
                }

                return NoContent();               
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Logging {ex}");
                return StatusCode(500, "Internal Server Error") ;
            }

        }



        /// <summary>
        ///  This GET method returns the article with the specified id 
        /// </summary>   
        /// <returns>A json containing the article with the specified id</returns>
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


        /// <summary>
        /// This GET method returns all the sold articles
        /// </summary>   
        /// <returns>A List containing all sold articles</returns>
        // GET api/articles/
        [HttpGet]
        public ActionResult<IEnumerable<ArticleReadDto>> GetAllArticlesSold()
        {
            var articleItems = _repository.GetAllArticles();

            return Ok(_mapper.Map<IEnumerable<ArticleReadDto>>(articleItems));
        }


    }
}