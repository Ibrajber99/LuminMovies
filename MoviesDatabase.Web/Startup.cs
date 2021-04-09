using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MovieDataBase.ClientAPI;
using MoviesDatabase.Web.Models;
using MoviesDatabase.Web.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoviesDatabase.Web
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
            var baseAddress = Configuration.GetSection("BaseAddress").Value;
            var pathAddress = Configuration.GetSection("PathAddress").Value;
            var apiKey = Configuration.GetSection("APIkey").Value;


            services.AddScoped<IMovieClient>(m => new MovieClient
            (baseAddress, pathAddress, apiKey));

            services.AddScoped(u => new Utilities(Configuration));

            services.AddScoped<MoviesHomeViewModel>();
            services.AddScoped<MovieSearchViewModel>();
            services.AddScoped<MoviesByGenreViewModel>();
            services.AddScoped<MoviesByOptionsViewModel>();
            services.AddScoped<MovieDetailsViewModel>();

            services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "moviesByGenre",
                    pattern: "Movies/{genreID}/{genreName}/{page}",
                    defaults: new {controller="Home",action= "GetMoviesGenre"});

                endpoints.MapControllerRoute(
                    name: "moviesByOption",
                    pattern: "MoviesOp/{optionId}/{optionName}/{page}",
                    defaults: new { controller = "Home", action = "GetMoviesByOption" });

                endpoints.MapControllerRoute(
                    name: "moviesByOption",
                    pattern: "Movie/{id}",
                    defaults: new { controller = "Home", action = "MovieDetails" });




                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
