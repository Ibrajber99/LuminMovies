#pragma checksum "C:\Users\jber5\OneDrive\Desktop\standAlonePorjects\MoviesDatabase.Web\MoviesDatabase.Web\Views\Shared\_CastCard.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "a978619afe24690582ccb1e57d663217ada7272b"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared__CastCard), @"mvc.1.0.view", @"/Views/Shared/_CastCard.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a978619afe24690582ccb1e57d663217ada7272b", @"/Views/Shared/_CastCard.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"dd1d24844ef0820d4b6f043d02593b551dc50748", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared__CastCard : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<MoviesDataBase.Models.Models.Movie_related_models.Cast>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n\r\n<div class=\"card m-2\">\r\n    <p class=\"card-header font-weight-lighter bg-dark text-center text-info\">");
#nullable restore
#line 5 "C:\Users\jber5\OneDrive\Desktop\standAlonePorjects\MoviesDatabase.Web\MoviesDatabase.Web\Views\Shared\_CastCard.cshtml"
                                                                        Write(Model.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n    <p class=\"card-header font-weight-lighter bg-dark text-center\">");
#nullable restore
#line 6 "C:\Users\jber5\OneDrive\Desktop\standAlonePorjects\MoviesDatabase.Web\MoviesDatabase.Web\Views\Shared\_CastCard.cshtml"
                                                              Write(Model.Character);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n    <img class=\"card-img-bottom\"");
            BeginWriteAttribute("src", " src=\"", 306, "\"", 330, 1);
#nullable restore
#line 7 "C:\Users\jber5\OneDrive\Desktop\standAlonePorjects\MoviesDatabase.Web\MoviesDatabase.Web\Views\Shared\_CastCard.cshtml"
WriteAttributeValue("", 312, Model.ProfilePath, 312, 18, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            BeginWriteAttribute("alt", " alt=\"", 331, "\"", 355, 1);
#nullable restore
#line 7 "C:\Users\jber5\OneDrive\Desktop\standAlonePorjects\MoviesDatabase.Web\MoviesDatabase.Web\Views\Shared\_CastCard.cshtml"
WriteAttributeValue("", 337, Model.ProfilePath, 337, 18, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n</div>\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<MoviesDataBase.Models.Models.Movie_related_models.Cast> Html { get; private set; }
    }
}
#pragma warning restore 1591