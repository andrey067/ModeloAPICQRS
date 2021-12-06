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
        public Task<IActionResult> Create(UserDto user)
        {
            _userServices.Create(user);
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

        [Route("/api/v1/user/removeuser")]
        [HttpDelete]
        public async Task<IActionResult> RemoveUser(string id)
        {
            var response = await _userServices.Remove(id);
            return Ok(response);
        }

        [Route("/api/v1/user/updateuser")]
        [HttpPut]
        public async Task<IActionResult> UpdateUser(UserDto user)
        {
            var response = await _userServices.Update(user);
            return Ok(response);
        }
    }
}
