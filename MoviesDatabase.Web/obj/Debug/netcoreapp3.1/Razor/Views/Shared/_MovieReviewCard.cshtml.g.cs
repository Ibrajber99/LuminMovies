#pragma checksum "C:\Users\jber5\OneDrive\Desktop\standAlonePorjects\MoviesDatabase.Web\MoviesDatabase.Web\Views\Shared\_MovieReviewCard.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "6cf877499babfdaa63f18e1b12d387d268e084e6"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared__MovieReviewCard), @"mvc.1.0.view", @"/Views/Shared/_MovieReviewCard.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "C:\Users\jber5\OneDrive\Desktop\standAlonePorjects\MoviesDatabase.Web\MoviesDatabase.Web\Views\_ViewImports.cshtml"
using MoviesDatabase.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\jber5\OneDrive\Desktop\standAlonePorjects\MoviesDatabase.Web\MoviesDatabase.Web\Views\_ViewImports.cshtml"
using MoviesDatabase.Web.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\jber5\OneDrive\Desktop\standAlonePorjects\MoviesDatabase.Web\MoviesDatabase.Web\Views\_ViewImports.cshtml"
using MovieDataBase.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6cf877499babfdaa63f18e1b12d387d268e084e6", @"/Views/Shared/_MovieReviewCard.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"dd1d24844ef0820d4b6f043d02593b551dc50748", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared__MovieReviewCard : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<MoviesDataBase.Models.Models.Movie_related_models.MovieReview>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n\r\n<div class=\"card text-white bg-dark mb-3\">\r\n    <p class=\"card-header text-info display-4 bg-dark\">");
#nullable restore
#line 5 "C:\Users\jber5\OneDrive\Desktop\standAlonePorjects\MoviesDatabase.Web\MoviesDatabase.Web\Views\Shared\_MovieReviewCard.cshtml"
                                                  Write(Model.AuthorName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n    <div class=\"card-body\">\r\n        <p class=\"card-text\">");
#nullable restore
#line 7 "C:\Users\jber5\OneDrive\Desktop\standAlonePorjects\MoviesDatabase.Web\MoviesDatabase.Web\Views\Shared\_MovieReviewCard.cshtml"
                        Write(Model.Content);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n    </div>\r\n    <div class=\"card-footer\">\r\n        <p>Created on : ");
#nullable restore
#line 10 "C:\Users\jber5\OneDrive\Desktop\standAlonePorjects\MoviesDatabase.Web\MoviesDatabase.Web\Views\Shared\_MovieReviewCard.cshtml"
                   Write(Model.ReviewedCreatedOn);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n        <p>Updated on: ");
#nullable restore
#line 11 "C:\Users\jber5\OneDrive\Desktop\standAlonePorjects\MoviesDatabase.Web\MoviesDatabase.Web\Views\Shared\_MovieReviewCard.cshtml"
                  Write(Model.ReviewedUpdatedOn);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n    </div>\r\n</div>");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<MoviesDataBase.Models.Models.Movie_related_models.MovieReview> Html { get; private set; }
    }
}
#pragma warning restore 1591