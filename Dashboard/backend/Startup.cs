using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using MovieApp.Application.Interfaces;
using MovieApp.Infrastructure.Data;
using MovieApp.Infrastructure.Data.Repositories;
using MovieApp.Infrastructure.Services;
using FluentValidation.AspNetCore;
using MovieApp.Application.DTO;
using MovieApp.Application.Filters;
using MovieApp.Application.Validators;

namespace MovieApp.backend
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

         public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAutoMapper(typeof(Startup));

            services.AddDbContext<ApplicationContext>(options =>
                options.UseNpgsql(Configuration.GetConnectionString("PgsConnection")));


            services.AddTransient<IFileManager, FileManager>();
            services.AddTransient<IMovieRepository, MovieRepository>();
            services.AddTransient<ICategoryRepository, CategoryRepository>();
            services.AddTransient<IMovieService, MovieService>();
            
            // services.AddSwaggerGen();
            services.AddSpaStaticFiles(config => {
                config.RootPath = "dist";
            });
            
            services.AddControllers(options =>
                {
                    options.Filters.Add(new ValidationFilter());
                })
                .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<RestrictionValidator>());
        }

        public static void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                // app.UseSwagger();
                // app.UseSwaggerUI();


                // app.UseCors(builder => builder.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute();
            });

            app.UseSpaStaticFiles();

            app.UseSpa(builder =>
            {
                if (env.IsDevelopment())
                {
                    builder.UseProxyToSpaDevelopmentServer("http://localhost:3000/");
                }
            });
        }
    }
}
