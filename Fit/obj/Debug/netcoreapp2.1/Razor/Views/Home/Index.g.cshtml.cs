#pragma checksum "D:\Fontys\Semester_3\Individueel\Fit\Fit\Views\Home\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "19183cdd34517980a4659fe033747fec1938914a"
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
using Data.dto;

#line default
#line hidden
#line 2 "D:\Fontys\Semester_3\Individueel\Fit\Fit\Views\Home\Index.cshtml"
using Interfaces;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"19183cdd34517980a4659fe033747fec1938914a", @"/Views/Home/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"beaba63e91e2211ff777d7bb30e79dc595c0180a", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Fit.ViewModels.Article.ArticleListViewModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-primary my-2"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Auth", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Register", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-secondary my-2"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Login", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 4 "D:\Fontys\Semester_3\Individueel\Fit\Fit\Views\Home\Index.cshtml"
  
    ViewData["Title"] = "Home Page";
    var authUser = ViewData["AuthUser"] as IUser;

#line default
#line hidden
#line 8 "D:\Fontys\Semester_3\Individueel\Fit\Fit\Views\Home\Index.cshtml"
 if(authUser == null){

#line default
#line hidden
            BeginContext(208, 291, true);
            WriteLiteral(@"<section class=""jumbotron text-center"">
  <div class=""container"">
    <h1 class=""jumbotron-heading"">Fitness begint met wat je eet.</h1>
    <p class=""lead text-muted"">Neem het heft in eigen handen. Tel calorieën, ontleed ingrediënten en houd activiteiten bij met Fit.</p>
    <p>
      ");
            EndContext();
            BeginContext(499, 95, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "e055b4b5e12843839aea5c6a262fd7e3", async() => {
                BeginContext(575, 15, true);
                WriteLiteral("Begin nu gratis");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(594, 8, true);
            WriteLiteral("\r\n      ");
            EndContext();
            BeginContext(602, 101, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "207c85c06f7649aabc7a4eb1670480e9", async() => {
                BeginContext(677, 22, true);
                WriteLiteral("heb je al een account?");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(703, 34, true);
            WriteLiteral("\r\n    </p>\r\n  </div>\r\n</section>\r\n");
            EndContext();
#line 19 "D:\Fontys\Semester_3\Individueel\Fit\Fit\Views\Home\Index.cshtml"
}

#line default
#line hidden
            BeginContext(740, 68, true);
            WriteLiteral("<h1 class=\"mt-md-5\">Populair eten</h1>\r\n<div class=\"card-columns\">\r\n");
            EndContext();
#line 22 "D:\Fontys\Semester_3\Individueel\Fit\Fit\Views\Home\Index.cshtml"
   foreach (var article in Model.AllArticles)
  {

#line default
#line hidden
            BeginContext(860, 86, true);
            WriteLiteral("    <div class=\"card\">\r\n      <div class=\"card-body\">\r\n        <h5 class=\"card-title\">");
            EndContext();
            BeginContext(947, 12, false);
#line 26 "D:\Fontys\Semester_3\Individueel\Fit\Fit\Views\Home\Index.cshtml"
                          Write(article.Name);

#line default
#line hidden
            EndContext();
            BeginContext(959, 47, true);
            WriteLiteral("</h5>\r\n        <p class=\"card-text\">Calorieën: ");
            EndContext();
            BeginContext(1007, 16, false);
#line 27 "D:\Fontys\Semester_3\Individueel\Fit\Fit\Views\Home\Index.cshtml"
                                   Write(article.Calories);

#line default
#line hidden
            EndContext();
            BeginContext(1023, 106, true);
            WriteLiteral("</p>\r\n        <button class=\"btn btn-primary\" type=\"button\" data-toggle=\"collapse\" data-target=\"#collapse-");
            EndContext();
            BeginContext(1130, 12, false);
#line 28 "D:\Fontys\Semester_3\Individueel\Fit\Fit\Views\Home\Index.cshtml"
                                                                                               Write(article.Name);

#line default
#line hidden
            EndContext();
            BeginContext(1142, 23, true);
            WriteLiteral("\" aria-expanded=\"false\"");
            EndContext();
            BeginWriteAttribute("aria-controls", " aria-controls=\"", 1165, "\"", 1203, 2);
            WriteAttributeValue("", 1181, "collapse-", 1181, 9, true);
#line 28 "D:\Fontys\Semester_3\Individueel\Fit\Fit\Views\Home\Index.cshtml"
WriteAttributeValue("", 1190, article.Name, 1190, 13, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(1204, 72, true);
            WriteLiteral(">\r\n          Nutrients\r\n        </button>\r\n        <div class=\"collapse\"");
            EndContext();
            BeginWriteAttribute("id", " id=\"", 1276, "\"", 1303, 2);
            WriteAttributeValue("", 1281, "collapse-", 1281, 9, true);
#line 31 "D:\Fontys\Semester_3\Individueel\Fit\Fit\Views\Home\Index.cshtml"
WriteAttributeValue("", 1290, article.Name, 1290, 13, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(1304, 55, true);
            WriteLiteral(">\r\n          <ul class=\"list-group list-group-flush\">\r\n");
            EndContext();
#line 33 "D:\Fontys\Semester_3\Individueel\Fit\Fit\Views\Home\Index.cshtml"
             foreach (var nutrient in article.Nutrients)
            {

#line default
#line hidden
            BeginContext(1432, 42, true);
            WriteLiteral("              <li class=\"list-group-item\">");
            EndContext();
            BeginContext(1475, 22, false);
#line 35 "D:\Fontys\Semester_3\Individueel\Fit\Fit\Views\Home\Index.cshtml"
                                     Write(nutrient.Nutrient.Name);

#line default
#line hidden
            EndContext();
            BeginContext(1497, 3, true);
            WriteLiteral(" : ");
            EndContext();
            BeginContext(1501, 15, false);
#line 35 "D:\Fontys\Semester_3\Individueel\Fit\Fit\Views\Home\Index.cshtml"
                                                               Write(nutrient.Amount);

#line default
#line hidden
            EndContext();
            BeginContext(1516, 7, true);
            WriteLiteral("</li>\r\n");
            EndContext();
#line 36 "D:\Fontys\Semester_3\Individueel\Fit\Fit\Views\Home\Index.cshtml"
            }

#line default
#line hidden
            BeginContext(1538, 59, true);
            WriteLiteral("          </ul>\r\n        </div>\r\n      </div>\r\n    </div>\r\n");
            EndContext();
#line 41 "D:\Fontys\Semester_3\Individueel\Fit\Fit\Views\Home\Index.cshtml"
  }

#line default
#line hidden
            BeginContext(1602, 8, true);
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
