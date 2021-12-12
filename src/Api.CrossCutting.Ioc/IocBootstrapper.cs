using Api.Infrastructure.Context;
using Api.Infrastructure.Interfaces;
using Api.Infrastructure.Persistence;
using Api.Infrastructure.Repositories;
using Api.Services.Commands;
using Api.Services.Dtos;
using Api.Services.Handlers;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Api.CrossCutting.Ioc
{
    public class IocBootstrapper
    {
        public static void RegisterServices(IServiceCollection services, IConfiguration configuration)
        {
            MongoDbPersistence.Configure();
            services.AddScoped<IMongoDbClient, MongoDbClient>();
            services.AddScoped<IUserRepository, UserRepository>();
            
            services.AddScoped<IRequestHandler<CreateUserCommand, UserDto>, CreateUserCommandHandler>();
        }
    }
}
