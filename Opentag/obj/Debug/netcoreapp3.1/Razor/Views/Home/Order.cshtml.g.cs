#pragma checksum "E:\Amir\developer\GitHub\Opentag\Opentag\Views\Home\Order.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "4220acbe1f147c7800496879d8e58a39465c6a8d"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Order), @"mvc.1.0.view", @"/Views/Home/Order.cshtml")]
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
#line 1 "E:\Amir\developer\GitHub\Opentag\Opentag\Views\_ViewImports.cshtml"
using Opentag;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "E:\Amir\developer\GitHub\Opentag\Opentag\Views\_ViewImports.cshtml"
using Opentag.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4220acbe1f147c7800496879d8e58a39465c6a8d", @"/Views/Home/Order.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d9762176f0034104a395c4f16c22f93bad0e52f1", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Order : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/images/order/Standard-vec.png"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("w-75 h-75 mx-auto my-auto d-block"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/images/order/Premium-vec.png"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/images/order/Gold-vec.png"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("type", new global::Microsoft.AspNetCore.Html.HtmlString("submit"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Home", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "AddOrder", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_7 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-dark OrderNowBtn"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormActionTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 2 "E:\Amir\developer\GitHub\Opentag\Opentag\Views\Home\Order.cshtml"
  
    ViewData["Title"] = "Order";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"<section class=""d-none CurrenPageTitle"">3</section>
<section class=""container OrderCol""  style=""margin-top: 150px;"">
    <h1 class=""OrderHeader"">Order</h1>
    <h4 class=""OrderHeader2"">Contact us through this form</h4>
    <hr />

    <p class=""mb-5 OrderDscription"">We will provide different order plan for your business. It's our reponsibility to make our customers satisfied. At the time we have two order plans:</p>


    <div class=""row mt-5"">

        <div class=""col-lg-4 mt-5"">
            <div class=""card mb-5"" style=""position: relative;"">

                <div class=""rounded-circle align-self-center shadow""
                     style=""background-color: white; width: 130px; height: 130px; position: absolute; top: -15.5%; display: flex;"">
                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "4220acbe1f147c7800496879d8e58a39465c6a8d7328", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
                </div>

                <div class=""card-body mt-5 shadow"" style=""position: relative;"">
                    <div class=""card-title pb-5 pt-3"">
                        <h3 class=""font-weight-bold text-center PlantHeaderStandard"">
                            Standard
                        </h3>
                        <h1 class=""font-weight-bolder text-center PlantPriceStandard"">
                            599$
                        </h1>
                    </div>
                    <div class=""card-text pt-5 align-bottom"">
                        <ul>
                            <li class=""PlantText1Standard"">
                                6 month support
                            </li>
                            <li class=""PlantText2Standard"">
                                UI/UX design
                            </li>
                            <li class=""PlantText3Standard"">
                                Logo designing
                            </li>");
            WriteLiteral(@"
                            <li class=""PlantText4Standard"">
                                Administrator panel
                            </li>
                        </ul>
                    </div>
                </div>
            </div>
        </div>

        <div class=""col-lg-4 mt-5"">
            <div class=""card mb-5"" style=""position: relative;"">

                <div class=""rounded-circle align-self-center shadow""
                     style=""background-color: white; width: 130px; height: 130px; position: absolute; top: -15.5%; display: flex;"">
                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "4220acbe1f147c7800496879d8e58a39465c6a8d10124", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
                </div>

                <div class=""card-body mt-5 shadow"" style=""position: relative;"">
                    <div class=""card-title pb-5 pt-3"">
                        <h3 class=""font-weight-bold text-center PlantHeaderPremium"">
                            Premium
                        </h3>
                        <h1 class=""font-weight-bolder text-center PlantPricePremium"">
                            999$
                        </h1>
                    </div>
                    <div class=""card-text align-bottom"">
                        <ul>
                            <li class=""PlantText1Premium "">
                                1 year support
                            </li>
                            <li class=""PlantText2Premium"">
                                UI/UX design (3 samples)
                            </li>
                            <li class=""PlantText3Premium"">
                                Logo designing
                            </li");
            WriteLiteral(@">
                            <li class=""PlantText4Premium"">
                                Administrator panel
                            </li>
                            <li class=""PlantText5Premium"">
                                Host & domain
                            </li>
                            <li class=""PlantText6Premium"">
                                Premium images
                            </li>
                        </ul>
                    </div>
                </div>
            </div>
        </div>

        <div class=""col-lg-4 mt-5"">
            <div class=""card mb-5"" style=""position: relative;"">

                <div class=""rounded-circle align-self-center shadow""
                     style=""background-color: white; width: 130px; height: 130px; position: absolute; top: -15.5%; display: flex;"">
                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "4220acbe1f147c7800496879d8e58a39465c6a8d13210", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
                </div>

                <div class=""card-body mt-5 shadow"" style=""position: relative;"">
                    <div class=""card-title pb-5 pt-3"">
                        <h3 class=""font-weight-bold text-center PlantHeaderGold"">
                            GOLD
                        </h3>
                        <h1 class=""font-weight-bolder text-center PlantPriceGold"">
                            1499$
                        </h1>
                    </div>
                    <div class=""card-text pt-5"">
                        <ul>
                            <li class=""PlantText1Gold"">
                                6 month support
                            </li>
                            <li class=""PlantText2Gold"">
                                UI/UX design
                            </li>
                            <li class=""PlantText3Gold"">
                                Logo designing
                            </li>
                            <li cl");
            WriteLiteral(@"ass=""PlantText4Gold"">
                                Administrator panel
                            </li>
                        </ul>
                    </div>
                </div>
            </div>
        </div>

    </div>

    <div class=""row"">
        <div class=""col-lg-12"">
            <table class=""table"">
                <thead>
                    <tr>
                        <th");
            BeginWriteAttribute("class", " class=\"", 6098, "\"", 6106, 0);
            EndWriteAttribute();
            WriteLiteral(@" scope=""col"">#</th>
                        <th class=""Plan1"" scope=""col"">Standard</th>
                        <th class=""Plan2"" scope=""col"">Premium</th>
                        <th class=""Plan3"" scope=""col"">GOLD</th>
                    </tr>
                </thead>
                <tbody>
                    <tr>
                        <th scope=""row"">1</th>
                        <td >
                            <svg xmlns=""http://www.w3.org/2000/svg"" width=""16"" height=""16"" fill=""currentColor"" class=""bi bi-check"" viewBox=""0 0 16 16"">
                                <path d=""M10.97 4.97a.75.75 0 0 1 1.07 1.05l-3.99 4.99a.75.75 0 0 1-1.08.02L4.324 8.384a.75.75 0 1 1 1.06-1.06l2.094 2.093 3.473-4.425a.267.267 0 0 1 .02-.022z"" />
                            </svg>
                            <section class=""Plan1Text1 d-inline"">
                                6 month support
                            </section>
                        </td>
                        <td");
            BeginWriteAttribute("class", " class=\"", 7113, "\"", 7121, 0);
            EndWriteAttribute();
            WriteLiteral(@">
                            <svg xmlns=""http://www.w3.org/2000/svg"" width=""16"" height=""16"" fill=""currentColor"" class=""bi bi-check"" viewBox=""0 0 16 16"">
                                <path d=""M10.97 4.97a.75.75 0 0 1 1.07 1.05l-3.99 4.99a.75.75 0 0 1-1.08.02L4.324 8.384a.75.75 0 1 1 1.06-1.06l2.094 2.093 3.473-4.425a.267.267 0 0 1 .02-.022z"" />
                            </svg>
                            <section class=""Plan2Text1 d-inline"">
                                1 year support
                            </section>
                        </td>
                        <td");
            BeginWriteAttribute("class", " class=\"", 7724, "\"", 7732, 0);
            EndWriteAttribute();
            WriteLiteral(@">
                            <svg xmlns=""http://www.w3.org/2000/svg"" width=""16"" height=""16"" fill=""currentColor"" class=""bi bi-check"" viewBox=""0 0 16 16"">
                                <path d=""M10.97 4.97a.75.75 0 0 1 1.07 1.05l-3.99 4.99a.75.75 0 0 1-1.08.02L4.324 8.384a.75.75 0 1 1 1.06-1.06l2.094 2.093 3.473-4.425a.267.267 0 0 1 .02-.022z"" />
                            </svg>
                            <section class=""Plan3Text1 d-inline"">
                                1 year support
                            </section>
                        </td>
                    </tr>
                    <tr>
                        <th scope=""row"">2</th>
                        <td>
                            <svg xmlns=""http://www.w3.org/2000/svg"" width=""16"" height=""16"" fill=""currentColor"" class=""bi bi-check"" viewBox=""0 0 16 16"">
                                <path d=""M10.97 4.97a.75.75 0 0 1 1.07 1.05l-3.99 4.99a.75.75 0 0 1-1.08.02L4.324 8.384a.75.75 0 1 1 1.06-1.06l2.094 2.093 3.473-4.42");
            WriteLiteral(@"5a.267.267 0 0 1 .02-.022z"" />
                            </svg>
                            <section class=""Plan1Text2 d-inline"">
                                UI/UX design
                            </section>
                        </td>
                        <td>
                            <svg xmlns=""http://www.w3.org/2000/svg"" width=""16"" height=""16"" fill=""currentColor"" class=""bi bi-check"" viewBox=""0 0 16 16"">
                                <path d=""M10.97 4.97a.75.75 0 0 1 1.07 1.05l-3.99 4.99a.75.75 0 0 1-1.08.02L4.324 8.384a.75.75 0 1 1 1.06-1.06l2.094 2.093 3.473-4.425a.267.267 0 0 1 .02-.022z"" />
                            </svg>
                            <section class=""Plan2Text2 d-inline"">
                                UI/UX design (3 samples)
                            </section>
                            
                        </td>
                        <td>
                            <svg xmlns=""http://www.w3.org/2000/svg"" width=""16"" height=""16"" fill=""cur");
            WriteLiteral(@"rentColor"" class=""bi bi-check"" viewBox=""0 0 16 16"">
                                <path d=""M10.97 4.97a.75.75 0 0 1 1.07 1.05l-3.99 4.99a.75.75 0 0 1-1.08.02L4.324 8.384a.75.75 0 1 1 1.06-1.06l2.094 2.093 3.473-4.425a.267.267 0 0 1 .02-.022z"" />
                            </svg>
                            <section class=""Plan3Text2 d-inline"">
                                UI/UX design (3 samples)
                            </section>
                        </td>
                    </tr>
                    <tr>
                        <th scope=""row"">3</th>
                        <td>
                            <svg xmlns=""http://www.w3.org/2000/svg"" width=""16"" height=""16"" fill=""currentColor"" class=""bi bi-check"" viewBox=""0 0 16 16"">
                                <path d=""M10.97 4.97a.75.75 0 0 1 1.07 1.05l-3.99 4.99a.75.75 0 0 1-1.08.02L4.324 8.384a.75.75 0 1 1 1.06-1.06l2.094 2.093 3.473-4.425a.267.267 0 0 1 .02-.022z"" />
                            </svg>
                         ");
            WriteLiteral(@"   <section class=""Plan1Text3 d-inline"">
                                Logo designing
                            </section>
                        </td>
                        <td>
                            <svg xmlns=""http://www.w3.org/2000/svg"" width=""16"" height=""16"" fill=""currentColor"" class=""bi bi-check"" viewBox=""0 0 16 16"">
                                <path d=""M10.97 4.97a.75.75 0 0 1 1.07 1.05l-3.99 4.99a.75.75 0 0 1-1.08.02L4.324 8.384a.75.75 0 1 1 1.06-1.06l2.094 2.093 3.473-4.425a.267.267 0 0 1 .02-.022z"" />
                            </svg>
                            <section class=""Plan2Text3 d-inline"">
                                Logo designing
                            </section>
                        </td>
                        <td>
                            <svg xmlns=""http://www.w3.org/2000/svg"" width=""16"" height=""16"" fill=""currentColor"" class=""bi bi-check"" viewBox=""0 0 16 16"">
                                <path d=""M10.97 4.97a.75.75 0 0 1 1.07 1.05l-3");
            WriteLiteral(@".99 4.99a.75.75 0 0 1-1.08.02L4.324 8.384a.75.75 0 1 1 1.06-1.06l2.094 2.093 3.473-4.425a.267.267 0 0 1 .02-.022z"" />
                            </svg>
                            <section class=""Plan3Text3 d-inline"">
                                Logo designing
                            </section>
                        </td>
                    </tr>
                    <tr>
                        <th scope=""row"">4</th>
                        <td>
                            <svg xmlns=""http://www.w3.org/2000/svg"" width=""16"" height=""16"" fill=""red"" class=""bi bi-x"" viewBox=""0 0 16 16"">
                                <path d=""M4.646 4.646a.5.5 0 0 1 .708 0L8 7.293l2.646-2.647a.5.5 0 0 1 .708.708L8.707 8l2.647 2.646a.5.5 0 0 1-.708.708L8 8.707l-2.646 2.647a.5.5 0 0 1-.708-.708L7.293 8 4.646 5.354a.5.5 0 0 1 0-.708z"" />
                            </svg>
                            <del class=""text-danger Plan1Text4"">Administrator panel</del>
                        </td>
                ");
            WriteLiteral(@"        <td>
                            <svg xmlns=""http://www.w3.org/2000/svg"" width=""16"" height=""16"" fill=""currentColor"" class=""bi bi-check"" viewBox=""0 0 16 16"">
                                <path d=""M10.97 4.97a.75.75 0 0 1 1.07 1.05l-3.99 4.99a.75.75 0 0 1-1.08.02L4.324 8.384a.75.75 0 1 1 1.06-1.06l2.094 2.093 3.473-4.425a.267.267 0 0 1 .02-.022z"" />
                            </svg>
                            <section class=""Plan2Text4 d-inline"">
                                Administrator panel
                            </section>
                        </td>
                        <td>
                            <svg xmlns=""http://www.w3.org/2000/svg"" width=""16"" height=""16"" fill=""currentColor"" class=""bi bi-check"" viewBox=""0 0 16 16"">
                                <path d=""M10.97 4.97a.75.75 0 0 1 1.07 1.05l-3.99 4.99a.75.75 0 0 1-1.08.02L4.324 8.384a.75.75 0 1 1 1.06-1.06l2.094 2.093 3.473-4.425a.267.267 0 0 1 .02-.022z"" />
                            </svg>
                 ");
            WriteLiteral(@"           <section class=""Plan3Text4 d-inline"">
                                Administrator panel
                            </section>
                        </td>
                    </tr>
                    <tr>
                        <th scope=""row"">5</th>
                        <td>
                            <svg xmlns=""http://www.w3.org/2000/svg"" width=""16"" height=""16"" fill=""red"" class=""bi bi-x"" viewBox=""0 0 16 16"">
                                <path d=""M4.646 4.646a.5.5 0 0 1 .708 0L8 7.293l2.646-2.647a.5.5 0 0 1 .708.708L8.707 8l2.647 2.646a.5.5 0 0 1-.708.708L8 8.707l-2.646 2.647a.5.5 0 0 1-.708-.708L7.293 8 4.646 5.354a.5.5 0 0 1 0-.708z"" />
                            </svg>
                            <del class=""Plan1Text5 text-danger"">Host & domain</del>
                        </td>
                        <td>
                            <svg xmlns=""http://www.w3.org/2000/svg"" width=""16"" height=""16"" fill=""currentColor"" class=""bi bi-check"" viewBox=""0 0 16 16"">
      ");
            WriteLiteral(@"                          <path d=""M10.97 4.97a.75.75 0 0 1 1.07 1.05l-3.99 4.99a.75.75 0 0 1-1.08.02L4.324 8.384a.75.75 0 1 1 1.06-1.06l2.094 2.093 3.473-4.425a.267.267 0 0 1 .02-.022z"" />
                            </svg>
                            <section class=""Plan2Text5 d-inline"">
                                Host & domain
                            </section>
                        </td>
                        <td>
                            <svg xmlns=""http://www.w3.org/2000/svg"" width=""16"" height=""16"" fill=""currentColor"" class=""bi bi-check"" viewBox=""0 0 16 16"">
                                <path d=""M10.97 4.97a.75.75 0 0 1 1.07 1.05l-3.99 4.99a.75.75 0 0 1-1.08.02L4.324 8.384a.75.75 0 1 1 1.06-1.06l2.094 2.093 3.473-4.425a.267.267 0 0 1 .02-.022z"" />
                            </svg>
                            <section class=""Plan3Text5 d-inline"">
                                Host & domain
                            </section>
                        </td>
           ");
            WriteLiteral(@"         </tr>
                    <tr>
                        <th scope=""row"">6</th>
                        <td>
                            <svg xmlns=""http://www.w3.org/2000/svg"" width=""16"" height=""16"" fill=""red"" class=""bi bi-x"" viewBox=""0 0 16 16"">
                                <path d=""M4.646 4.646a.5.5 0 0 1 .708 0L8 7.293l2.646-2.647a.5.5 0 0 1 .708.708L8.707 8l2.647 2.646a.5.5 0 0 1-.708.708L8 8.707l-2.646 2.647a.5.5 0 0 1-.708-.708L7.293 8 4.646 5.354a.5.5 0 0 1 0-.708z"" />
                            </svg>
                            <del class=""Plan1Text6 text-danger"">Premium images</del>
                        </td>
                        <td>
                            <svg xmlns=""http://www.w3.org/2000/svg"" width=""16"" height=""16"" fill=""currentColor"" class=""bi bi-check"" viewBox=""0 0 16 16"">
                                <path d=""M10.97 4.97a.75.75 0 0 1 1.07 1.05l-3.99 4.99a.75.75 0 0 1-1.08.02L4.324 8.384a.75.75 0 1 1 1.06-1.06l2.094 2.093 3.473-4.425a.267.267 0 0 1 .02-.022");
            WriteLiteral(@"z"" />
                            </svg>
                            <section class=""Plan2Text6 d-inline"">
                                Premium images
                            </section>
                        </td>
                        <td>
                            <svg xmlns=""http://www.w3.org/2000/svg"" width=""16"" height=""16"" fill=""currentColor"" class=""bi bi-check"" viewBox=""0 0 16 16"">
                                <path d=""M10.97 4.97a.75.75 0 0 1 1.07 1.05l-3.99 4.99a.75.75 0 0 1-1.08.02L4.324 8.384a.75.75 0 1 1 1.06-1.06l2.094 2.093 3.473-4.425a.267.267 0 0 1 .02-.022z"" />
                            </svg>
                            <section class=""Plan3Text6 d-inline"">
                                Premium images
                            </section>
                        </td>
                    </tr>
                </tbody>
            </table>
        </div>

    </div>

    <div class=""row"">
        <div class=""col-12 mb-4"">
            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "4220acbe1f147c7800496879d8e58a39465c6a8d28686", async() => {
                WriteLiteral("\r\n                ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("button", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "4220acbe1f147c7800496879d8e58a39465c6a8d28961", async() => {
                    WriteLiteral("\r\n                    Order now\r\n                ");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormActionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
                __Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper.Controller = (string)__tagHelperAttribute_5.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_5);
                __Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper.Action = (string)__tagHelperAttribute_6.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_6);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_7);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n            ");
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
            WriteLiteral("\r\n        </div>\r\n    </div>\r\n\r\n</section>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591