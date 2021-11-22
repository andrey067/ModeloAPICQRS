using Api.CrossCutting.Dtos;
using Api.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Api.Application.Controller
{
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userServices;

        public UserController(IUserService clienteServices)
        {
            _userServices = clienteServices;
        }
        [Route("/api/v1/user/create")]
        [HttpPost]
        public async Task<IActionResult> Create(UserDto user)
        {
            var response = await _userServices.Create(user);
            return Ok(response.Data);
        }
    }
}
