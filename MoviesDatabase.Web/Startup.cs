using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MovieDataBase.ClientAPI;
using MoviesDatabase.Web.Models;
using MoviesDatabase.Web.Utils;
using MoviesDatabase.Web.Utils.CookieManager;

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
            var mediaType = Configuration.GetSection("MediaTypeJSON").Value;
            var baseAddress = Configuration.GetSection("BaseAddress").Value;
            var moviePathAddress = Configuration.GetSection("MoviePathAddress").Value;
            var apiKey = Configuration.GetSection("APIkey").Value;
            var autheticationPathAddress = Configuration.GetSection("AuthPathAddress").Value;
            var authenticationRedirectPath = Configuration.GetSection("TokenRedirectPath").Value;
            var authenticationReleaseRedirectPath = Configuration.GetSection("TokenReleaseRedirectPath").Value;
            var accountPathAddress = Configuration.GetSection("AccountPathAddress").Value;

            

            services.AddScoped<IMovieClient>(m => new MovieClient
            (baseAddress, moviePathAddress, apiKey, mediaType));

            
            services.AddScoped<IAuthenticationClient>(m => new AuthenticationClient
            (baseAddress, autheticationPathAddress,
            apiKey, authenticationRedirectPath, mediaType));


            services.AddScoped<IProfileClient>(m => new ProfileClient
            (baseAddress, accountPathAddress, apiKey, mediaType));


            services.AddSingleton<IHttpContextAccessor,
            HttpContextAccessor>();


            services.AddScoped<ICookiesManager, CookiesManager>();


            services.AddScoped(u => new Utilities(Configuration));

            services.AddScoped<MoviesHomeViewModel>();
            services.AddScoped<MovieSearchViewModel>();
            services.AddScoped<MoviesByGenreViewModel>();
            services.AddScoped<MoviesByOptionsViewModel>();
            services.AddScoped<MovieDetailsViewModel>();
            services.AddScoped<ErrorViewModel>();



            services.AddHttpContextAccessor();
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
