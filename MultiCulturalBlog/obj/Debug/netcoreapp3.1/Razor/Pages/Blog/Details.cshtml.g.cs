#pragma checksum "C:\Users\Mostafa Elomda\source\repos\MultiCulturalBlog\MultiCulturalBlog\Pages\Blog\Details.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "199cb5910abc79b33a9144cb4f3230b9538031da"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(MultiCulturalBlog.Pages.Blog.Pages_Blog_Details), @"mvc.1.0.razor-page", @"/Pages/Blog/Details.cshtml")]
namespace MultiCulturalBlog.Pages.Blog
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
#line 1 "C:\Users\Mostafa Elomda\source\repos\MultiCulturalBlog\MultiCulturalBlog\Pages\_ViewImports.cshtml"
using MultiCulturalBlog;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemMetadataAttribute("RouteTemplate", "{Id}")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"199cb5910abc79b33a9144cb4f3230b9538031da", @"/Pages/Blog/Details.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"639be29c52ca945a0ab07e61f9876105ae851f6f", @"/Pages/_ViewImports.cshtml")]
    public class Pages_Blog_Details : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/js/blog-index.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 3 "C:\Users\Mostafa Elomda\source\repos\MultiCulturalBlog\MultiCulturalBlog\Pages\Blog\Details.cshtml"
  
    ViewData["Title"] = "Details";
    Layout = "~/Pages/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<style>\r\n    .post ul.apply-ink a {\r\n        font-size: 18px;\r\n    }\r\n</style>\r\n\r\n<!-- Sidebar -->\r\n<aside class=\"col-md-3\">\r\n    <div class=\"side-widget\">\r\n        <div id=\"tree\"></div>\r\n    </div>\r\n    <input type=\"hidden\"");
            BeginWriteAttribute("value", " value=\"", 370, "\"", 425, 1);
#nullable restore
#line 19 "C:\Users\Mostafa Elomda\source\repos\MultiCulturalBlog\MultiCulturalBlog\Pages\Blog\Details.cshtml"
WriteAttributeValue("", 378, Json.Serialize(Model.ArchiveModels).ToString(), 378, 47, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" id=\"hdfArchive\" />\r\n\r\n</aside>\r\n<!-- Sidebar -->\r\n<!-- Blog content -->\r\n<div class=\"col-md-7 blogpost\">\r\n    <a class=\"btn btn-success\" href=\"/Blog/Create\">Create New</a>\r\n    <div class=\"space10\"></div>\r\n    <article class=\"post\">\r\n        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "199cb5910abc79b33a9144cb4f3230b9538031da5240", async() => {
                WriteLiteral("\r\n");
                WriteLiteral("            <h3><a href=\"#\">");
#nullable restore
#line 32 "C:\Users\Mostafa Elomda\source\repos\MultiCulturalBlog\MultiCulturalBlog\Pages\Blog\Details.cshtml"
                       Write(Model.Blog.Title);

#line default
#line hidden
#nullable disable
                WriteLiteral("</a></h3>\r\n            <div class=\"blog-meta\">\r\n                <span><i class=\"fa fa-user\"></i> Admin</span> <span><i class=\"fa fa-clock-o\"></i> ");
#nullable restore
#line 34 "C:\Users\Mostafa Elomda\source\repos\MultiCulturalBlog\MultiCulturalBlog\Pages\Blog\Details.cshtml"
                                                                                             Write(Model.Blog.CreationDate.ToString("dddd, dd MMMM yyyy hh:mm tt"));

#line default
#line hidden
#nullable disable
                WriteLiteral(@"</span>
                <span>
                    <button class=""btn btn-primary btn-xs btn-brown uppercase"" type=""button"" id=""btnDelete""><span><i class=""fa fa-times""></i> Delete</span></button>
                </span>
                <span>
                    <button class=""btn btn-primary btn-xs btn-blue uppercase"" id=""btnEdit"" type=""button"" data-id=""");
#nullable restore
#line 39 "C:\Users\Mostafa Elomda\source\repos\MultiCulturalBlog\MultiCulturalBlog\Pages\Blog\Details.cshtml"
                                                                                                             Write(Model.Id);

#line default
#line hidden
#nullable disable
                WriteLiteral("\">\r\n                        <span><i class=\"fa fa-pencil\"></i> Edit</span>\r\n                    </button>\r\n                </span>\r\n\r\n            </div>\r\n");
#nullable restore
#line 49 "C:\Users\Mostafa Elomda\source\repos\MultiCulturalBlog\MultiCulturalBlog\Pages\Blog\Details.cshtml"
             if (Model.Blog.BodyHtml != null)
            {

#line default
#line hidden
#nullable disable
                WriteLiteral("                <div class=\"space20\"></div>\r\n                <div>\r\n                    ");
#nullable restore
#line 53 "C:\Users\Mostafa Elomda\source\repos\MultiCulturalBlog\MultiCulturalBlog\Pages\Blog\Details.cshtml"
               Write(Html.Raw(Model.Blog.BodyHtml.Replace("\r\n", "<br />")));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                </div>\r\n");
#nullable restore
#line 55 "C:\Users\Mostafa Elomda\source\repos\MultiCulturalBlog\MultiCulturalBlog\Pages\Blog\Details.cshtml"
            }

            

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n");
#nullable restore
#line 71 "C:\Users\Mostafa Elomda\source\repos\MultiCulturalBlog\MultiCulturalBlog\Pages\Blog\Details.cshtml"
             if (Model.Blog.Attachments != null && Model.Blog.Attachments.Length > 0)
            {

#line default
#line hidden
#nullable disable
                WriteLiteral("                <h3>Attachments</h3>\r\n                <div class=\"space30\"></div>\r\n");
                WriteLiteral("                <div class=\"row\">\r\n                    <div class=\"file-preview-thumbnails\">\r\n");
#nullable restore
#line 78 "C:\Users\Mostafa Elomda\source\repos\MultiCulturalBlog\MultiCulturalBlog\Pages\Blog\Details.cshtml"
                         for (var i = 0; i < Model.Blog.Attachments.Length; i++)
                        {

#line default
#line hidden
#nullable disable
                WriteLiteral("                            <a");
                BeginWriteAttribute("href", " href=\"", 3079, "\"", 3120, 1);
#nullable restore
#line 80 "C:\Users\Mostafa Elomda\source\repos\MultiCulturalBlog\MultiCulturalBlog\Pages\Blog\Details.cshtml"
WriteAttributeValue("", 3086, Model.Blog.Attachments[i].FileUrl, 3086, 34, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" target=\"_blank\">\r\n                                <div class=\"file-preview-frame attachment-dv\"");
                BeginWriteAttribute("id", " id=\"", 3217, "\"", 3263, 1);
#nullable restore
#line 81 "C:\Users\Mostafa Elomda\source\repos\MultiCulturalBlog\MultiCulturalBlog\Pages\Blog\Details.cshtml"
WriteAttributeValue("", 3222, Model.Blog.Attachments[i].ServerFileName, 3222, 41, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" data-fileindex=\"1\"");
                BeginWriteAttribute("title", " title=\"", 3283, "\"", 3334, 1);
#nullable restore
#line 81 "C:\Users\Mostafa Elomda\source\repos\MultiCulturalBlog\MultiCulturalBlog\Pages\Blog\Details.cshtml"
WriteAttributeValue("", 3291, Model.Blog.Attachments[i].OriginalFileName, 3291, 43, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(@" style=""width:160px;height:160px;"">
                                    <div class=""file-preview-other-frame"">
                                        <div class=""file-preview-other"">
                                            <span class=""file-icon-4x""><i class=""glyphicon glyphicon-file""></i></span>
                                        </div>
                                    </div>
                                    <input type=""hidden""");
                BeginWriteAttribute("name", " name=\"", 3790, "\"", 3834, 3);
                WriteAttributeValue("", 3797, "Entity.Attachments[", 3797, 19, true);
#nullable restore
#line 87 "C:\Users\Mostafa Elomda\source\repos\MultiCulturalBlog\MultiCulturalBlog\Pages\Blog\Details.cshtml"
WriteAttributeValue("", 3816, i, 3816, 2, false);

#line default
#line hidden
#nullable disable
                WriteAttributeValue("", 3818, "].ServerFileName", 3818, 16, true);
                EndWriteAttribute();
                BeginWriteAttribute("value", " value=\"", 3835, "\"", 3884, 1);
#nullable restore
#line 87 "C:\Users\Mostafa Elomda\source\repos\MultiCulturalBlog\MultiCulturalBlog\Pages\Blog\Details.cshtml"
WriteAttributeValue("", 3843, Model.Blog.Attachments[i].ServerFileName, 3843, 41, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" />\r\n                                    <div class=\"file-preview-other-footer\">\r\n                                        <div class=\"file-thumbnail-footer\">\r\n                                            <div class=\"file-footer-caption\"");
                BeginWriteAttribute("title", " title=\"", 4120, "\"", 4171, 1);
#nullable restore
#line 90 "C:\Users\Mostafa Elomda\source\repos\MultiCulturalBlog\MultiCulturalBlog\Pages\Blog\Details.cshtml"
WriteAttributeValue("", 4128, Model.Blog.Attachments[i].OriginalFileName, 4128, 43, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(">");
#nullable restore
#line 90 "C:\Users\Mostafa Elomda\source\repos\MultiCulturalBlog\MultiCulturalBlog\Pages\Blog\Details.cshtml"
                                                                                                                            Write(Model.Blog.Attachments[i].OriginalFileName);

#line default
#line hidden
#nullable disable
                WriteLiteral(" </div>\r\n\r\n                                        </div>\r\n                                    </div>\r\n                                </div>\r\n                            </a>\r\n");
#nullable restore
#line 96 "C:\Users\Mostafa Elomda\source\repos\MultiCulturalBlog\MultiCulturalBlog\Pages\Blog\Details.cshtml"
                        }

#line default
#line hidden
#nullable disable
                WriteLiteral("                    </div>\r\n                </div>\r\n");
                WriteLiteral("                <div class=\"space20\"></div>\r\n");
#nullable restore
#line 101 "C:\Users\Mostafa Elomda\source\repos\MultiCulturalBlog\MultiCulturalBlog\Pages\Blog\Details.cshtml"
            }

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n            <div class=\"clear\"></div>\r\n            <div class=\"space30\"></div>\r\n        ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n\r\n    </article>\r\n\r\n</div>\r\n<!-- Blog content -->\r\n<div class=\"col-md-2\"></div>\r\n\r\n\r\n");
            DefineSection("Scripts", async() => {
                WriteLiteral("\r\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "199cb5910abc79b33a9144cb4f3230b9538031da15235", async() => {
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
                WriteLiteral(@"
    <script type=""text/javascript"">
        var $j = jQuery.noConflict();
        $j(document).ready(function () {
            $j('#btnDelete').on('click', function (e) {
                var isOkay = confirm(""Are you sure?"");
                if (isOkay == true) {
                    var $form = $j(this).closest('form');
                    $form.trigger('submit');
                }
            });
            $j('#btnEdit').click(function () {
                document.location.href = '/Blog/Update/' + $j(this).data('id');
            });
        });
    </script>
");
            }
            );
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<MultiCulturalBlog.DetailsModel> Html { get; private set; }
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<MultiCulturalBlog.DetailsModel> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<MultiCulturalBlog.DetailsModel>)PageContext?.ViewData;
        public MultiCulturalBlog.DetailsModel Model => ViewData.Model;
    }
}
#pragma warning restore 1591
