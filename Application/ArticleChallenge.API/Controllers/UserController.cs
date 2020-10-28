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
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        [Route("/api/v1/user/create")]
        public async Task<IActionResult> CreateUser([FromBody]UserDTO userDTO)
        {
            try
            {
                var userCreated = await _userService.Create(userDTO);

                return Ok(new ResultViewModel(
                            message: "Usuário criado com sucesso!",
                            success: true,
                            data: userCreated
                        ));
            }
            catch(DomainException ex)
            {
                return StatusCode(400, ResultTemplates.DomainError(ex.Message));
            }
            catch (Exception)
            {
                return StatusCode(500, ResultTemplates.InternalServerError());
            }
        }

        [HttpPost]
        [Route("/api/v1/user/authenticate")]
        public async Task<IActionResult> AuthenticateUser([FromBody] LoginDTO loginDTO)
        {
            try
            {
                var isAuthenticated = await _userService.Authenticate(loginDTO.Email, loginDTO.Password);

                if (!isAuthenticated)
                    return StatusCode(401, ResultTemplates.Error("Usuário e/ou senha estão inválidos."));

                return Ok(new ResultViewModel(
                                message: "Usuário autenticado com sucesso!",
                                success: true,
                                data: await _userService.GetByEmail(loginDTO.Email)
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
