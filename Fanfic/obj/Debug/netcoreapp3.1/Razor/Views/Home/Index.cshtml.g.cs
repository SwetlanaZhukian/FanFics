#pragma checksum "D:\Trainy\Курсовой\Fanfic\Fanfic\Views\Home\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "b5105a7a3e0ea229bf904e284b12fafafa1a124e"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Index), @"mvc.1.0.view", @"/Views/Home/Index.cshtml")]
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
#line 1 "D:\Trainy\Курсовой\Fanfic\Fanfic\Views\_ViewImports.cshtml"
using Fanfic;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\Trainy\Курсовой\Fanfic\Fanfic\Views\_ViewImports.cshtml"
using Fanfic.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b5105a7a3e0ea229bf904e284b12fafafa1a124e", @"/Views/Home/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"27b19f495c6ff2a2fcfafe119c108a0516a755ec", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<Fanfic.Models.ViewModels.CompositionViewModel>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/lib/jquery/dist/jquery.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/lib/bootstrap-star-rating/js/star-rating.min.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/lib/bootstrap-star-rating/themes/krajee-fa/theme.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "ReadComposition", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Composition", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("style", new global::Microsoft.AspNetCore.Html.HtmlString("color:black; "), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "GetAllCompositions", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_7 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Home", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("<!DOCTYPE html>\r\n<html>\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "b5105a7a3e0ea229bf904e284b12fafafa1a124e6236", async() => {
                WriteLiteral(@"
    <style>
        ul.hr {
            margin: 0;
            padding: 4px;
        }

            ul.hr li {
                display: inline-block;
                margin-right: 5px;
                border-radius: 5px;
                background-color:lightsteelblue
            }
    </style>
    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "b5105a7a3e0ea229bf904e284b12fafafa1a124e6806", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "b5105a7a3e0ea229bf904e284b12fafafa1a124e7905", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "b5105a7a3e0ea229bf904e284b12fafafa1a124e9004", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "b5105a7a3e0ea229bf904e284b12fafafa1a124e10807", async() => {
                WriteLiteral("\r\n\r\n    <div class=\"row  align-items-center justify-content-center\" style=\"padding:0px \" id=\"demo\"></div>\r\n    <hr />\r\n");
#nullable restore
#line 26 "D:\Trainy\Курсовой\Fanfic\Fanfic\Views\Home\Index.cshtml"
     foreach (var composition in Model)
    {


#line default
#line hidden
#nullable disable
                WriteLiteral("        <div class=\"card mb-3 w-100 h-25\">\r\n\r\n            ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "b5105a7a3e0ea229bf904e284b12fafafa1a124e11482", async() => {
                    WriteLiteral(" <h5 class=\"card-header\">");
#nullable restore
#line 31 "D:\Trainy\Курсовой\Fanfic\Fanfic\Views\Home\Index.cshtml"
                                                                                                                              Write(composition.Name);

#line default
#line hidden
#nullable disable
                    WriteLiteral("</h5>");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_3.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_4.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
                if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
                {
                    throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
                }
                BeginWriteTagHelperAttribute();
#nullable restore
#line 31 "D:\Trainy\Курсовой\Fanfic\Fanfic\Views\Home\Index.cshtml"
                                                                            WriteLiteral(composition.Id);

#line default
#line hidden
#nullable disable
                __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n            <div class=\"card-body\">\r\n\r\n                <dl class=\"row\">\r\n                    <dt class=\"col-sm-4\">\r\n                        ");
#nullable restore
#line 36 "D:\Trainy\Курсовой\Fanfic\Fanfic\Views\Home\Index.cshtml"
                   Write(Html.DisplayNameFor(model => model.AuthorName));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                    </dt>\r\n\r\n                    <dd class=\"col-sm-8 card-text\">\r\n                        ");
#nullable restore
#line 40 "D:\Trainy\Курсовой\Fanfic\Fanfic\Views\Home\Index.cshtml"
                   Write(Html.DisplayFor(model => composition.AuthorName));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                    </dd>\r\n                    <dt class=\"col-sm-4\">\r\n                        ");
#nullable restore
#line 43 "D:\Trainy\Курсовой\Fanfic\Fanfic\Views\Home\Index.cshtml"
                   Write(Html.DisplayNameFor(model => model.Genre));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                    </dt>\r\n                    <dd class=\"col-sm-8 card-text\">\r\n                        ");
#nullable restore
#line 46 "D:\Trainy\Курсовой\Fanfic\Fanfic\Views\Home\Index.cshtml"
                   Write(Html.DisplayFor(model => composition.Genre));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                    </dd>\r\n                    <dt class=\"col-sm-4\">\r\n                        ");
#nullable restore
#line 49 "D:\Trainy\Курсовой\Fanfic\Fanfic\Views\Home\Index.cshtml"
                   Write(Html.DisplayNameFor(model => model.Tags));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                    </dt>\r\n                    <dd class=\"col-sm-8\">\r\n                        <ul class=\"hr\">\r\n");
#nullable restore
#line 53 "D:\Trainy\Курсовой\Fanfic\Fanfic\Views\Home\Index.cshtml"
                             foreach (var tag in composition.Tags)
                            {


#line default
#line hidden
#nullable disable
                WriteLiteral("                                <li>");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "b5105a7a3e0ea229bf904e284b12fafafa1a124e16575", async() => {
                    WriteLiteral(" ");
#nullable restore
#line 56 "D:\Trainy\Курсовой\Fanfic\Fanfic\Views\Home\Index.cshtml"
                                                                                                                                               Write(tag.Name);

#line default
#line hidden
#nullable disable
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_5);
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_6.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_6);
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_7.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_7);
                if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
                {
                    throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-tagName", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
                }
                BeginWriteTagHelperAttribute();
#nullable restore
#line 56 "D:\Trainy\Курсовой\Fanfic\Fanfic\Views\Home\Index.cshtml"
                                                                                                                           WriteLiteral(tag.Name);

#line default
#line hidden
#nullable disable
                __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["tagName"] = __tagHelperStringValueBuffer;
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-tagName", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["tagName"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("</li>\r\n");
#nullable restore
#line 57 "D:\Trainy\Курсовой\Fanfic\Fanfic\Views\Home\Index.cshtml"

                            }

#line default
#line hidden
#nullable disable
                WriteLiteral("                        </ul>\r\n                    </dd>\r\n\r\n                    <dt class=\"col-sm-4\">\r\n                        ");
#nullable restore
#line 63 "D:\Trainy\Курсовой\Fanfic\Fanfic\Views\Home\Index.cshtml"
                   Write(Html.DisplayNameFor(model => model.Rating));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                    </dt>\r\n                    <dd class=\"col-sm-8\">\r\n                        <input name=\"star\"");
                BeginWriteAttribute("value", " value=\'", 2485, "\'", 2512, 1);
#nullable restore
#line 66 "D:\Trainy\Курсовой\Fanfic\Fanfic\Views\Home\Index.cshtml"
WriteAttributeValue("", 2493, composition.Rating, 2493, 19, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(@" class=""theme-krajee-fa"">
                        <script>

                            $(""input.theme-krajee-fa"").each(function (index) {
                                $(this).attr('id', 'item-' + index);

                            });

                            $(""input[name = 'star']"").rating({
                                clearCaption: 'No stars yet',
                                hoverOnClear: false,
                                theme: 'krajee-fa',
                                step: 1,
                                size: 'xs',
                                displayOnly: true,
                            });



                        </script>
                    </dd>
                    <dt class=""col-sm-4"">
                        ");
#nullable restore
#line 88 "D:\Trainy\Курсовой\Fanfic\Fanfic\Views\Home\Index.cshtml"
                   Write(Html.DisplayNameFor(model => model.DateOfCreation));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                    </dt>\r\n                    <dd class=\"col-sm-8\">\r\n                        ");
#nullable restore
#line 91 "D:\Trainy\Курсовой\Fanfic\Fanfic\Views\Home\Index.cshtml"
                   Write(Html.DisplayFor(model => composition.DateOfCreation));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                    </dd>\r\n                    <dt class=\"col-sm-4\">\r\n                        ");
#nullable restore
#line 94 "D:\Trainy\Курсовой\Fanfic\Fanfic\Views\Home\Index.cshtml"
                   Write(Html.DisplayNameFor(model => model.Description));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                    </dt>\r\n                    <dd class=\"col-sm-8 \">\r\n                        ");
#nullable restore
#line 97 "D:\Trainy\Курсовой\Fanfic\Fanfic\Views\Home\Index.cshtml"
                   Write(Html.DisplayFor(model => composition.Description));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                    </dd>\r\n                </dl>\r\n            </div>\r\n        </div>\r\n");
#nullable restore
#line 102 "D:\Trainy\Курсовой\Fanfic\Fanfic\Views\Home\Index.cshtml"

    }

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n");
                DefineSection("Scripts", async() => {
                    WriteLiteral(@"
        <script>
            $(document).ready(function () {
                var tags = [];
                $.get(""/Composition/GetTag"", function (response) {
                    $.each(response.data, function (i, v) {
                        tags.push({
                            text: v,
                            link: ""/Home/GetAllCompositions?tagName="" + v

                        });
                        console.log(v);
                    });




                    $('#demo').jQCloud(tags,
                        {
                            autoResize: true,
                            delay: 50,
                            width: 930,
                            height: 100,
                            classPattern: null,

                        });
                });

            });


        </script>

    ");
                }
                );
                WriteLiteral("\r\n");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n</html>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<Fanfic.Models.ViewModels.CompositionViewModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591
