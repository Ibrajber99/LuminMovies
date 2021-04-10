using MoviesDataBase.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieDataBase.Models
{
    public class FullMovieResponseModel
    {
        public FullMovieResponseModel()
        {
            Movie = new FullMovie();
        }

        public FullMovie Movie { get; set; }
    }
}
