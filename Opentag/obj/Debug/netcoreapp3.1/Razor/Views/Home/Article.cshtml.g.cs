#pragma checksum "C:\Users\zack\Documents\GitHub\Opentag\Opentag\Views\Home\Article.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "85d8e9c1660931d3762b2b4597bf56557c9889b2"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Article), @"mvc.1.0.view", @"/Views/Home/Article.cshtml")]
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
#line 1 "C:\Users\zack\Documents\GitHub\Opentag\Opentag\Views\_ViewImports.cshtml"
using Opentag;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\zack\Documents\GitHub\Opentag\Opentag\Views\_ViewImports.cshtml"
using Opentag.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"85d8e9c1660931d3762b2b4597bf56557c9889b2", @"/Views/Home/Article.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d9762176f0034104a395c4f16c22f93bad0e52f1", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Home_Article : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Opentag.ViewModels.DetailsViewModel>
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("w-100 m-0 p-0 shadow"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("style", new global::Microsoft.AspNetCore.Html.HtmlString("border-radius: 25px;"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/images/services/defualt-blog-pic.jpg"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("alt", new global::Microsoft.AspNetCore.Html.HtmlString("First slide"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("d-block w-100"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("alt", new global::Microsoft.AspNetCore.Html.HtmlString("Second slide"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("alt", new global::Microsoft.AspNetCore.Html.HtmlString("Third slide"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\zack\Documents\GitHub\Opentag\Opentag\Views\Home\Article.cshtml"
  
    ViewData["Title"] = "Article";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("<section class=\"container\"  style=\"margin-top: 150px;\">\r\n\r\n    <div class=\"h3\">Article</div>\r\n");
#nullable restore
#line 10 "C:\Users\zack\Documents\GitHub\Opentag\Opentag\Views\Home\Article.cshtml"
      
        if (Model.article != null)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <div class=\"h4\">");
#nullable restore
#line 13 "C:\Users\zack\Documents\GitHub\Opentag\Opentag\Views\Home\Article.cshtml"
                       Write(Model.article.Title);

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n");
#nullable restore
#line 14 "C:\Users\zack\Documents\GitHub\Opentag\Opentag\Views\Home\Article.cshtml"
        }
        else
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <div class=\"h4\">Title of selected article</div>\r\n");
#nullable restore
#line 18 "C:\Users\zack\Documents\GitHub\Opentag\Opentag\Views\Home\Article.cshtml"
        }

    

#line default
#line hidden
#nullable disable
            WriteLiteral(@"




    <div class=""row justify-content-between border-top "">
        <div class=""col-lg-8 "">
            <p class=""text-left text-justify pt-3"">
                Lorem ipsum is simply dummy text of the printing and typesetting industry.
            </p>
            <div class=""m-0 p-0"">
                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "85d8e9c1660931d3762b2b4597bf56557c9889b27632", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
                <div id=""carouselExampleIndicators"" class=""carousel slide"" data-ride=""carousel"">
                    <ol class=""carousel-indicators"">
                        <li data-target=""#carouselExampleIndicators"" data-slide-to=""0"" class=""active""></li>
                        <li data-target=""#carouselExampleIndicators"" data-slide-to=""1""></li>
                        <li data-target=""#carouselExampleIndicators"" data-slide-to=""2""></li>
                    </ol>
                    <div class=""carousel-inner"">
                        <div class=""carousel-item active"">
                            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "85d8e9c1660931d3762b2b4597bf56557c9889b29467", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                        </div>\r\n                        <div class=\"carousel-item\">\r\n                            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "85d8e9c1660931d3762b2b4597bf56557c9889b210865", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_5);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                        </div>\r\n                        <div class=\"carousel-item\">\r\n                            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "85d8e9c1660931d3762b2b4597bf56557c9889b212182", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_6);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
                        </div>
                    </div>
                    <a class=""carousel-control-prev"" href=""#carouselExampleIndicators"" role=""button"" data-slide=""prev"">
                        <span class=""carousel-control-prev-icon"" aria-hidden=""true""></span>
                        <span class=""sr-only"">Previous</span>
                    </a>
                    <a class=""carousel-control-next"" href=""#carouselExampleIndicators"" role=""button"" data-slide=""next"">
                        <span class=""carousel-control-next-icon"" aria-hidden=""true""></span>
                        <span class=""sr-only"">Next</span>
                    </a>
                </div>
");
            WriteLiteral("            </div>\r\n            <div");
            BeginWriteAttribute("class", " class=\"", 3634, "\"", 3642, 0);
            EndWriteAttribute();
            WriteLiteral(">\r\n");
#nullable restore
#line 73 "C:\Users\zack\Documents\GitHub\Opentag\Opentag\Views\Home\Article.cshtml"
              
                if (Model.article != null )
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <p class=\"text-left text-justify pt-3 pb-3\">\r\n                            ");
#nullable restore
#line 77 "C:\Users\zack\Documents\GitHub\Opentag\Opentag\Views\Home\Article.cshtml"
                       Write(Html.Raw(Model.article.Body));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </p>\r\n");
#nullable restore
#line 79 "C:\Users\zack\Documents\GitHub\Opentag\Opentag\Views\Home\Article.cshtml"
            
                }
                else
                {

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                    <p class=""text-left text-justify pt-3 pb-3"">
                        Richard McClintock, a Latin scholar from Hampden-Sydney College, is credited with discovering the source behind the ubiquitous filler text. In seeing a sample of lorem ipsum, his interest was piqued by consectetur—a genuine, albeit rare, Latin word. Consulting a Latin dictionary led McClintock to a passage from De Finibus Bonorum et Malorum (“On the Extremes of Good and Evil”), a first-century B.C. text from the Roman philosopher Cicer.
                        So how did the classical Latin become so incoherent? According to McClintock, a 15th century typesetter likely scrambled part of Cicero's De Finibus in order to provide placeholder text to mockup various fonts for a type specimen book.
                        It's difficult to find examples of lorem ipsum in use before Letraset made it popular as a dummy text in the 1960s, although McClintock says he remembers coming across the lorem ipsum passage in a book of ol");
            WriteLiteral(@"d metal type samples. So far he hasn't relocated where he once saw the passage, but the popularity of Cicero in the 15th century supports the theory that the filler text has been used for centuries.
                        And anyways, as Cecil Adams reasoned, “[Do you really] think graphic arts supply houses were hiring classics scholars in the 1960s?” Perhaps. But it seems reasonable to imagine that there was a version in use far before the age of Letraset.
                    </p>  
");
#nullable restore
#line 89 "C:\Users\zack\Documents\GitHub\Opentag\Opentag\Views\Home\Article.cshtml"
                }

            

#line default
#line hidden
#nullable disable
            WriteLiteral("            \r\n            </div>\r\n\r\n");
#nullable restore
#line 96 "C:\Users\zack\Documents\GitHub\Opentag\Opentag\Views\Home\Article.cshtml"
              
                if (Model.article != null)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <div class=\"font-weight-bold font-italic pb-2\">\r\n                        ");
#nullable restore
#line 100 "C:\Users\zack\Documents\GitHub\Opentag\Opentag\Views\Home\Article.cshtml"
                   Write(Model.article.AuthorAccount);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </div>\r\n");
#nullable restore
#line 102 "C:\Users\zack\Documents\GitHub\Opentag\Opentag\Views\Home\Article.cshtml"
                }
                else
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <div class=\"font-weight-bold font-italic pb-2\">\r\n                        Article by: Auther Name\r\n                    </div>\r\n");
#nullable restore
#line 108 "C:\Users\zack\Documents\GitHub\Opentag\Opentag\Views\Home\Article.cshtml"
                }

            

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        \r\n            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "85d8e9c1660931d3762b2b4597bf56557c9889b218318", async() => {
                WriteLiteral(@"
                <div class=""form-row align-items-center pb-3"">
                    <div class=""col-12 mb-2 "" >
                        <label class=""sr-only"" for=""exampleFormControlTextarea1"">Example textarea</label>
                        <textarea class=""form-control shadow-sm"" id=""exampleFormControlTextarea1"" rows=""3"" style=""border-radius: 5px;"" placeholder=""Write your comment here""></textarea>
                    </div>
                    <div class=""col-12 "">
                        <button type=""submit"" class=""btn btn-primary mb-2 float-right"">Submit</button>
                    </div>
                </div>
            ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
            <div class=""border bg-white p-3 shadow"" style=""border-radius: 5px;"">
                <div class=""row d-flex justify-content-between m-2  pb-3"">
                    <div class=""font-weight-bold "">
                        UserName said:
                    </div>
                    <div class=""text-muted align-content-end align-self-end "">
                        Date:YYYY/DD/MM
                    </div>
                </div>
                <div class=""m-2 text-justify"">
                    So how did the classical Latin become so incoherent? According to McClintock, a 15th century typesetter likely scrambled part of Cicero's De Finibus in order to provide placeholder text to mockup various fonts for a type specimen book.
                </div>
            
            
            </div>
        </div>

        <div class=""col-lg-4 w-100 pt-5"">
            <div class="" w-100 mb-1 border shadow-sm"" style=""border-radius: 25px "">
                <div class=""text-left font-weig");
            WriteLiteral("ht-bold p-2\">\r\n                    Latest articles\r\n                </div>\r\n                <ul class=\"list-group\"");
            BeginWriteAttribute("style", " style=\"", 7905, "\"", 7913, 0);
            EndWriteAttribute();
            WriteLiteral(@">
                    <li class=""list-group-item border-0"" style=""background-color:transparent!important"">
                        <img style=""width:35px; height:35px"" src=""https://via.placeholder.com/150C/O https://placeholder.com/"" />
                        <p class=""d-inline"">Cras justo odio</p>
                    </li>
                    <li class=""list-group-item border-0"" style=""background-color:transparent!important"">
                        <img style=""width:35px; height:35px"" src=""https://via.placeholder.com/150C/O https://placeholder.com/"" />
                        <p class=""d-inline"">Cras justo odio</p>
                    </li>
                    <li class=""list-group-item border-0"" style=""background-color:transparent!important"">
                        <img style=""width:35px; height:35px"" src=""https://via.placeholder.com/150C/O https://placeholder.com/"" />
                        <p class=""d-inline"">Cras justo odio</p>
                    </li>
                    <li class=""lis");
            WriteLiteral(@"t-group-item border-0"" style=""background-color:transparent!important"">
                        <img style=""width:35px; height:35px"" src=""https://via.placeholder.com/150C/O https://placeholder.com/"" />
                        <p class=""d-inline"">Cras justo odio</p>
                    </li>
                    <li class=""list-group-item border-0"" style=""background-color:transparent!important"">
                        <img style=""width:35px; height:35px"" src=""https://via.placeholder.com/150C/O https://placeholder.com/"" />
                        <p class=""d-inline"">Cras justo odio</p>
                    </li>
                </ul>
                <div class=""d-flex align-items-end flex-column pr-2"">
                    <nav aria-label=""Page navigation example"" class=""mt-auto "">
                        <ul class=""pagination justify-content-end align-content-end shadow-sm"">
                            <li class=""page-item""><a class=""page-link text-dark"" href=""#"" tabindex=""-1"">1</a></li>
            ");
            WriteLiteral(@"                <li class=""page-item""><a class=""page-link text-dark"" href=""#"">2</a></li>
                            <li class=""page-item""><a class=""page-link text-dark"" href=""#"">3</a></li>
                        </ul>
                    </nav>
                </div>
            </div>
            <div class=""border w-100 shadow-sm"" style=""border-radius: 25px"">
                <div class=""text-left font-weight-bold p-2"">
                    Latest reviews
                </div>
                <ul class=""list-group "">
                    <li class=""list-group-item border-0"" style=""background-color:transparent!important"">
                        <img style=""width:35px; height:35px"" src=""https://via.placeholder.com/150C/O https://placeholder.com/"" />
                        <p class=""d-inline"">Cras justo odio</p>
                    </li>
                    <li class=""list-group-item border-0"" style=""background-color:transparent!important"">
                        <img style=""width:35px; heig");
            WriteLiteral(@"ht:35px"" src=""https://via.placeholder.com/150C/O https://placeholder.com/"" />
                        <p class=""d-inline"">Cras justo odio</p>
                    </li>
                    <li class=""list-group-item border-0"" style=""background-color:transparent!important"">
                        <img style=""width:35px; height:35px"" src=""https://via.placeholder.com/150C/O https://placeholder.com/"" />
                        <p class=""d-inline"">Cras justo odio</p>
                    </li>
                    <li class=""list-group-item border-0"" style=""background-color:transparent!important"">
                        <img style=""width:35px; height:35px"" src=""https://via.placeholder.com/150C/O https://placeholder.com/"" />
                        <p class=""d-inline"">Cras justo odio</p>
                    </li>
                    <li class=""list-group-item border-0"" style=""background-color:transparent!important"">
                        <img style=""width:35px; height:35px"" src=""https://via.placeholder");
            WriteLiteral(@".com/150C/O https://placeholder.com/"" />
                        <p class=""d-inline"">Cras justo odio</p>
                    </li>
                </ul>
                <div class=""d-flex align-items-end flex-column pr-2"">
                    <nav aria-label=""Page navigation example"" class=""mt-auto"">
                        <ul class=""pagination justify-content-end align-content-end shadow-sm"">
                            <li class=""page-item""><a class=""page-link text-dark"" href=""#"" tabindex=""-1"">1</a></li>
                            <li class=""page-item""><a class=""page-link text-dark"" href=""#"">2</a></li>
                            <li class=""page-item""><a class=""page-link text-dark"" href=""#"">3</a></li>
                        </ul>
                    </nav>
                </div>


            
            </div>
        </div>
    </div>
</section>




");
        }
        #pragma warning restore 1998
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Opentag.ViewModels.DetailsViewModel> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591