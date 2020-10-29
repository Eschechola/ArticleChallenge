using System;
using System.Threading.Tasks;
using ArticleChallenge.API.Utilities;
using ArticleChallenge.API.ViewModel;
using ArticleChallenge.Infra.CrossCutting.Exceptions;
using ArticleChallenge.Services.DTO;
using ArticleChallenge.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ArticleChallenge.API.Controllers
{
    [ApiController]
    public class ArticleController : ControllerBase
    {
        private readonly IArticleService _articleService;

        public ArticleController(IArticleService articleService)
        {
            _articleService = articleService;
        }


        [HttpGet]
        [Route("/api/v1/articles/get-all")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                return Ok(new ResultViewModel(
                                message: "Artigos encontrados com sucesso!",
                                success: true,
                                data: await _articleService.Get()
                        ));
            }
            catch (DomainException ex)
            {
                return StatusCode(400, ResultTemplates.DomainError(ex.Message));
            }
            catch (Exception)
            {
                return StatusCode(500, ResultTemplates.InternalServerError());
            }
        }

        [HttpGet]
        [Route("/api/v1/articles/get/{id:long}")]
        public async Task<IActionResult> Get(long id)
        {
            try
            {
                return Ok(new ResultViewModel(
                                message: "Artigo encontrado com sucesso!",
                                success: true,
                                data: await _articleService.Get(id)
                        ));
            }
            catch (DomainException ex)
            {
                return StatusCode(400, ResultTemplates.DomainError(ex.Message));
            }
            catch (Exception)
            {
                return StatusCode(500, ResultTemplates.InternalServerError());
            }
        }

        [HttpGet]
        [Route("/api/v1/articles/get-like/{userId:long}/{articleId:long}")]
        public async Task<IActionResult> GetLike(long userId, long articleId)
        {
            try
            {
                return Ok(new ResultViewModel(
                                message: "Like encontrado com sucesso!",
                                success: true,
                                data: await _articleService.GetLike(userId, articleId)
                        ));
            }
            catch (DomainException ex)
            {
                return StatusCode(400, ResultTemplates.DomainError(ex.Message));
            }
            catch (Exception)
            {
                return StatusCode(500, ResultTemplates.InternalServerError());
            }
        }

        [HttpPost]
        [Route("/api/v1/articles/create")]
        public async Task<IActionResult> Create([FromBody]ArticleDTO articleDTO)
        {
            try
            {
                return Ok(new ResultViewModel(
                                message: "Artigo criado com sucesso!",
                                success: true,
                                data: await _articleService.Create(articleDTO)
                        ));
            }
            catch (DomainException ex)
            {
                return StatusCode(400, ResultTemplates.DomainError(ex.Message));
            }
            catch (Exception)
            {
                return StatusCode(500, ResultTemplates.InternalServerError());
            }
        }

        [HttpPost]
        [Route("/api/v1/articles/add-like")]
        public async Task<IActionResult> AddLike([FromBody] ArticleLikeDTO articleLikeDTO)
        {
            try
            {
                return Ok(new ResultViewModel(
                                message: "Like adicionado com sucesso!",
                                success: true,
                                data: await _articleService.AddLike(articleLikeDTO)
                        ));
            }
            catch (DomainException ex)
            {
                return StatusCode(400, ResultTemplates.DomainError(ex.Message));
            }
            catch (Exception)
            {
                return StatusCode(500, ResultTemplates.InternalServerError());
            }
        }

        [HttpPost]
        [Route("/api/v1/articles/remove-like")]
        public async Task<IActionResult> RemoveLike([FromBody] ArticleLikeDTO articleLikeDTO)
        {
            try
            {
                return Ok(new ResultViewModel(
                                message: "Like removido com sucesso!",
                                success: true,
                                data: await _articleService.RemoveLike(articleLikeDTO)
                        ));
            }
            catch (DomainException ex)
            {
                return StatusCode(400, ResultTemplates.DomainError(ex.Message));
            }
            catch (Exception)
            {
                return StatusCode(500, ResultTemplates.InternalServerError());
            }
        }
    }
}
