using MovieDataBase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoviesDatabase.Web.Models
{
    public class MovieSearchViewModel
    {
        public MovieSearchViewModel()
        {
            MovieResponse = new MoviesResponseModel();
        }

        public MoviesResponseModel MovieResponse { get; set; }

        public string Query { get; set; }

        public string NextPageDisabled 
        { get =>MovieResponse.CurrentPage >= MovieResponse.TotalPages ? "disabled" : ""; set {; } }

        public string PrevPageDisabled 
        { get => MovieResponse.CurrentPage < 2 ? "disabled" : ""; set {; } }

        public int NextIndex { get => MovieResponse.CurrentPage + 1; set{; } }

        public int PrevIndex { get => MovieResponse.CurrentPage - 1; set {; } }
    }
}
