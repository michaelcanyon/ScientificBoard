using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Mvc;
using System.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Configuration;
using Coursal_IT_2020_spring.Infrastructures;
using Coursal_IT_2020_spring.IRepositories;
using Coursal_IT_2020_spring.Infrastructures.Repositories;
using Coursal_IT_2020_spring.Services.Interfaces;
using Coursal_IT_2020_spring.Services;
using Microsoft.OpenApi.Models;
using Coursal_IT_2020_spring.EF;
using Microsoft.EntityFrameworkCore;

namespace Coursal_IT_2020_spring
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public IConfiguration Configuration { get; }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(); // добавляем сервисы CORS
            //services.AddTransient<IBlogRepository, BlogRepository>();
            services.AddTransient<IPostRepository, PostRepository>();
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<ITagRepository, TagRepository>();
            services.AddTransient<IPostTagRepository, PostTagRepository>();
            services.AddTransient<IAccountService, AccountService>();
            services.AddTransient<IPostService, PostService>();
            services.AddTransient<IPostTagService, PostTagServce>();
            IConfigurationSection connString = Configuration.GetSection("ConnectionString");
            string connection = connString.GetSection("DefaultConnection").Value;
            // добавляем контекст MobileContext в качестве сервиса в приложение
            services.AddDbContext<BoardContext>(options =>
                options.UseSqlServer(connection));
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseRouting();
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });
            app.UseCors(builder => builder.WithOrigins("http://localhost:5006", "https://localhost:5005").AllowAnyMethod().AllowAnyHeader());
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
