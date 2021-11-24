using Api.CrossCutting.Dtos;
using Api.Domain.Commands;
using Api.Domain.Handlers;
using Api.Services;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Api.CrossCutting.Ioc
{
    public class IocBootstrapper
    {
        public static void RegisterServices(IServiceCollection services, IConfiguration configuration)
        {
            

            services.AddScoped<IUserService, UserService>();


            services.AddScoped<IRequestHandler<CreateUserCommand, CommandReturnDto>, CreateUserCommandHandler>();

        }
    }
}
