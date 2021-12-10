using Api.Application.Ultilities;
using Api.Application.ViewModels;
using Api.CrossCutting.Dtos;
using Api.Domain.Entities;
using Api.Services;
using Api.Shared.Exceptions;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Api.Application.Controller
{
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userServices;
        private readonly IMapper _mapper;

        public UserController(IUserService clienteServices, IMapper mapper)
        {
            _userServices = clienteServices;
            _mapper = mapper;
        }
        [Route("/api/v1/user/create")]
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateViewModel user)
        {
            try
            {
                var userdto = _mapper.Map<UserDto>(user);
                var userCreated = await _userServices.Create(userdto);

                return Ok(new ResultViewModel
                {
                    Message = "Usuário criado com sucesso!",
                    Success = true,
                    Data = userCreated
                });
            }
            catch (DomainException ex)
            {
                return BadRequest(Responses.DomainErrorMessage(ex.Message, ex.Errors));
            }
            catch (Exception)
            {
                return StatusCode(500, Responses.ApplicationErrorMessage());
            }
        }

        [Route("/api/v1/user/get")]
        [HttpGet]
        public async Task<IActionResult> GetById(string guid)
        {
            var response = await _userServices.GetById(guid);
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
            await _userServices.Delete(id);
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
