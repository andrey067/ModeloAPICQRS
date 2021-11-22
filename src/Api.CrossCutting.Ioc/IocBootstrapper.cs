using Api.CrossCutting.Dtos;
using Api.Domain.Commands;
using Api.Domain.Entities;
using Api.Domain.Handlers;
using Api.Domain.Interfaces;
using Api.Infrastructure.Context;
using Api.Repositories;
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
            services.AddScoped<IMongoDbClient<BaseEntity>, MongoDbClient<BaseEntity>>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IBaseEntityForQueryRepository<BaseEntity>, BaseEntityForQueryRepository<BaseEntity>>();

            services.AddScoped<IRequestHandler<CreateUserCommand, CommandReturnDto>, CreateUserCommandHandler>();

        }
    }
}
