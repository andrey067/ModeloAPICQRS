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
            return Ok(response);
        }

        [Route("/api/v1/user/get")]
        [HttpGet]
        public async Task<IActionResult> GetById(string guid)
        {
            var response = await _userServices.Get(guid);
            return Ok(response);
        }

        [Route("/api/v1/user/getAll")]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var response = await _userServices.GetAll();
            return Ok(response);
        }
    }
}
