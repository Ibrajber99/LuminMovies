using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc;
using MovieDataBase.ClientAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoviesDatabase.Web.Components
{
    public class GenresListViewComponent : ViewComponent
    {
        private readonly IMovieClient _client;
        private const string CONTROLLER_NAME = "Home";
        private const string ACTION_NAME = "GetMoviesGenre";

        public GenresListViewComponent(IMovieClient client)
        {
            _client = client;
        }

        public  HtmlString Invoke()
        {
           
            var genres =  _client.GetMovieGenres().Result;

            var tmpString = "";

            foreach (var genre in genres.Genres)
            {
                tmpString  += 
                    $"<a class='dropdown-item text-dark' href='/Movies/{genre.GenreId}/{genre.Name}/{1}'>" 
                    +genre.Name
                    + "</a>";
            }

            return new HtmlString(tmpString);
        }

    }
}
