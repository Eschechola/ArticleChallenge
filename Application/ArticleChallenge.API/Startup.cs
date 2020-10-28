using System;
using ArticleChallenge.Domain.Entities;
using ArticleChallenge.Infra.Context;
using ArticleChallenge.Infra.Interfaces;
using ArticleChallenge.Infra.Repositories;
using ArticleChallenge.Services;
using ArticleChallenge.Services.DTO;
using ArticleChallenge.Services.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace ArticleChallenge.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            #region AutoMapper

            var autoMapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<User, UserDTO>().ReverseMap();
                cfg.CreateMap<Article, ArticleDTO>().ReverseMap();
                cfg.CreateMap<ArticleLike, ArticleLikeDTO>().ReverseMap();
            });

            services.AddSingleton(autoMapperConfig.CreateMapper());

            #endregion

            #region Database 

            var connectionString = Configuration["ConnectionStrings:SQLServer"];

            services.AddDbContext<ArticleChallengeContext>(
                options => options.UseSqlServer(connectionString), ServiceLifetime.Scoped);

            #endregion

            #region Services

            services.AddScoped<IUserService, UserService>();

            services.AddScoped<IArticleService, ArticleService>();

            #endregion

            #region Repositories 

            services.AddScoped<IUserRepository, UserRepository>();

            services.AddScoped<IArticleRepository, ArticleRepository>();

            #endregion

            #region Swagger

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Article Challenge",
                    Version = "v1",
                    Description = "API do Article Challenge!",
                    Contact = new OpenApiContact
                    {
                        Name = "Lucas Eschechola",
                        Email = "lucas.eschechola@outlook.com",
                        Url = new Uri("https://eschechola.com.br")
                    },
                });
            });

            #endregion

            #region CORS

            services.AddCors(options =>
            {
                options.AddDefaultPolicy(
                    builder =>
                    {
                        builder.AllowAnyOrigin();
                        builder.AllowAnyMethod();
                        builder.AllowAnyHeader();
                    });
            });

            #endregion
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors();

            app.UseSwagger();

            app.UseSwaggerUI(c => {
                c.SwaggerEndpoint("../swagger/v1/swagger.json", "Article Challenge v1.0");
            });

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
