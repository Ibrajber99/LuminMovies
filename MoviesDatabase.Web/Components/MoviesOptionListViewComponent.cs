using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc;
using MoviesDatabase.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoviesDatabase.Web.Components
{
    public class MoviesOptionListViewComponent : ViewComponent
    {
        private const string CONTROLLER_NAME = "Home";
        private const string ACTION_NAME = "GetMoviesByOption";

        public HtmlString Invoke()
        {
            var htmlStringResult = "";
            var optionList = Enum.GetValues(typeof(MoviesOptions));

            foreach (var option in optionList)
            {
                var normalizedValue = option.ToString().Contains('_') ? option.ToString().Replace('_', ' ') : option.ToString();

                htmlStringResult += $"<a class='dropdown-item text-dark' href='/MoviesOp/{option.ToString()}/{normalizedValue}/{1}'>" + normalizedValue
                    + "</a>";
            }

            return new HtmlString(htmlStringResult);
        }


    }
}
