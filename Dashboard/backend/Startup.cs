using System.Net;
using System.Threading.Tasks;
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
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.IdentityModel.Tokens;
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
            
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.RequireHttpsMetadata = false; // just for test
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidIssuer = AuthOptions.Issuer,
                        ValidateAudience = true,
                        ValidAudience = AuthOptions.Audience,
                        ValidateLifetime = true,
                        IssuerSigningKey = AuthOptions.GetSymmetricSecurityKey(),
                        ValidateIssuerSigningKey = true
                    };
                });
            
            services.AddControllers(options =>
                {
                    options.Filters.Add(new ValidationFilter());
                    var policy = new AuthorizationPolicyBuilder()
                        .RequireAuthenticatedUser()
                        .Build();
                    options.Filters.Add(new AuthorizeFilter(policy));
                })
                .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<RestrictionValidator>());
        }
        
        private static Task UnAuthorizedResponse(RedirectContext<CookieAuthenticationOptions> context)
        {
            context.Response.StatusCode = (int) HttpStatusCode.Unauthorized;
            return Task.CompletedTask;
        }
        
        private static Task ForbiddenResponse(RedirectContext<CookieAuthenticationOptions> context)
        {
            context.Response.StatusCode = (int) HttpStatusCode.Forbidden;
            return Task.CompletedTask;
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
            
            app.UseSpaStaticFiles();
            
            app.UseAuthentication();
            app.UseAuthorization();
            
            app.UseEndpoints(endpoints =>
            {
                endpoints
                    .MapDefaultControllerRoute();
            });
            
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
