#pragma checksum "D:\Fontys\Semester_3\Individueel\Fit\Fit\Views\Home\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "006002ab36548816f866c6c5b8857d9e02aea19a"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Index), @"mvc.1.0.view", @"/Views/Home/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Home/Index.cshtml", typeof(AspNetCore.Views_Home_Index))]
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
#line 1 "D:\Fontys\Semester_3\Individueel\Fit\Fit\Views\_ViewImports.cshtml"
using Fit;

#line default
#line hidden
#line 1 "D:\Fontys\Semester_3\Individueel\Fit\Fit\Views\Home\Index.cshtml"
using Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"006002ab36548816f866c6c5b8857d9e02aea19a", @"/Views/Home/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"beaba63e91e2211ff777d7bb30e79dc595c0180a", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Fit.ViewModels.Article.ArticleListViewModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 3 "D:\Fontys\Semester_3\Individueel\Fit\Fit\Views\Home\Index.cshtml"
  
    ViewData["Title"] = "Home Page";
    var authUser = ViewData["AuthUser"] as IUser;

#line default
#line hidden
#line 7 "D:\Fontys\Semester_3\Individueel\Fit\Fit\Views\Home\Index.cshtml"
 if(authUser == null){

#line default
#line hidden
#line 17 "D:\Fontys\Semester_3\Individueel\Fit\Fit\Views\Home\Index.cshtml"
                
}

#line default
#line hidden
            BeginContext(779, 68, true);
            WriteLiteral("<h1 class=\"mt-md-5\">Populair eten</h1>\r\n<div class=\"card-columns\">\r\n");
            EndContext();
#line 21 "D:\Fontys\Semester_3\Individueel\Fit\Fit\Views\Home\Index.cshtml"
   foreach (var article in Model.AllArticles)
  {

#line default
#line hidden
            BeginContext(899, 86, true);
            WriteLiteral("    <div class=\"card\">\r\n      <div class=\"card-body\">\r\n        <h5 class=\"card-title\">");
            EndContext();
            BeginContext(986, 12, false);
#line 25 "D:\Fontys\Semester_3\Individueel\Fit\Fit\Views\Home\Index.cshtml"
                          Write(article.Name);

#line default
#line hidden
            EndContext();
            BeginContext(998, 47, true);
            WriteLiteral("</h5>\r\n        <p class=\"card-text\">Calorieën: ");
            EndContext();
            BeginContext(1046, 16, false);
#line 26 "D:\Fontys\Semester_3\Individueel\Fit\Fit\Views\Home\Index.cshtml"
                                   Write(article.Calories);

#line default
#line hidden
            EndContext();
            BeginContext(1062, 38, true);
            WriteLiteral("</p>      \r\n      </div>\r\n    </div>\r\n");
            EndContext();
#line 29 "D:\Fontys\Semester_3\Individueel\Fit\Fit\Views\Home\Index.cshtml"
  }

#line default
#line hidden
            BeginContext(1105, 8, true);
            WriteLiteral("</div>\r\n");
            EndContext();
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Fit.ViewModels.Article.ArticleListViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
