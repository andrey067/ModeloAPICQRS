﻿using Api.CrossCutting.Dtos;
using Api.Domain.Commands;
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
            //services.AddScoped(typeof(IMongoDbClient<>), typeof(MongoDbClient<>));
            
            services.AddScoped<IUserService, UserService>();
            services.AddScoped(typeof(IBaseEntityForQueryRepository<>), typeof(BaseEntityForQueryRepository<>));

            services.AddScoped<IRequestHandler<CreateUserCommand, CommandReturnDto>, CreateUserCommandHandler>();

        }
    }
}
