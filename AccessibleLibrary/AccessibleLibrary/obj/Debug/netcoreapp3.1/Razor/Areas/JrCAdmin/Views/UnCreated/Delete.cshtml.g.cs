#pragma checksum "C:\Users\TOSHIBA\Desktop\developback\AccessibleLibrary\AccessibleLibrary\Areas\JrCAdmin\Views\UnCreated\Delete.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "189f0041336e9bd19fff1facbc0083ce57d7039e"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_JrCAdmin_Views_UnCreated_Delete), @"mvc.1.0.view", @"/Areas/JrCAdmin/Views/UnCreated/Delete.cshtml")]
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
#line 1 "C:\Users\TOSHIBA\Desktop\developback\AccessibleLibrary\AccessibleLibrary\Areas\JrCAdmin\Views\_ViewImports.cshtml"
using AccessibleLibrary;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\TOSHIBA\Desktop\developback\AccessibleLibrary\AccessibleLibrary\Areas\JrCAdmin\Views\_ViewImports.cshtml"
using AccessibleLibrary.ViewModels;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\TOSHIBA\Desktop\developback\AccessibleLibrary\AccessibleLibrary\Areas\JrCAdmin\Views\_ViewImports.cshtml"
using AccessibleLibrary.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"189f0041336e9bd19fff1facbc0083ce57d7039e", @"/Areas/JrCAdmin/Views/UnCreated/Delete.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"eda97dcbfc84c8fc0e9307b4e1cd8d426791a32d", @"/Areas/JrCAdmin/Views/_ViewImports.cshtml")]
    public class Areas_JrCAdmin_Views_UnCreated_Delete : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Book>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("style", new global::Microsoft.AspNetCore.Html.HtmlString("height: 150px !important;width: 200px !important; object-fit:cover;"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "TrueCreated", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-success  "), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("style", new global::Microsoft.AspNetCore.Html.HtmlString("cursor:pointer;"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\TOSHIBA\Desktop\developback\AccessibleLibrary\AccessibleLibrary\Areas\JrCAdmin\Views\UnCreated\Delete.cshtml"
  
    ViewData["Title"] = "Delete";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<div class=""row d-flex flex-column align-items-center"">
    <div class=""col-md-8 grid-margin stretch-card bg-dark text-light"">
        <div class=""card d-flex flex-row flex-wrap bg-dark"">

            <div class=""col-12 card-body  d-flex justify-content-center"">
");
#nullable restore
#line 11 "C:\Users\TOSHIBA\Desktop\developback\AccessibleLibrary\AccessibleLibrary\Areas\JrCAdmin\Views\UnCreated\Delete.cshtml"
                 foreach (BookImage img in Model.BookImages.Where(b => b.IsMain == true))
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "189f0041336e9bd19fff1facbc0083ce57d7039e6542", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "src", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 465, "~/src/img/books/", 465, 16, true);
#nullable restore
#line 13 "C:\Users\TOSHIBA\Desktop\developback\AccessibleLibrary\AccessibleLibrary\Areas\JrCAdmin\Views\UnCreated\Delete.cshtml"
AddHtmlAttributeValue("", 481, img.Image, 481, 10, false);

#line default
#line hidden
#nullable disable
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
#nullable restore
#line 14 "C:\Users\TOSHIBA\Desktop\developback\AccessibleLibrary\AccessibleLibrary\Areas\JrCAdmin\Views\UnCreated\Delete.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("            </div>\r\n            <div class=\"col-6 card-body \">\r\n                <h5 style=\"font-weight:600 !important\"> Adı : <span style=\"font-weight:200 !important\"> ");
#nullable restore
#line 17 "C:\Users\TOSHIBA\Desktop\developback\AccessibleLibrary\AccessibleLibrary\Areas\JrCAdmin\Views\UnCreated\Delete.cshtml"
                                                                                                   Write(Model.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral(" </span></h5>\r\n            </div>\r\n            <div class=\"col-6 card-body\">\r\n                <h5 style=\"font-weight:600 !important\">Müəllifi : <span style=\"font-weight:200 !important\"> ");
#nullable restore
#line 20 "C:\Users\TOSHIBA\Desktop\developback\AccessibleLibrary\AccessibleLibrary\Areas\JrCAdmin\Views\UnCreated\Delete.cshtml"
                                                                                                       Write(Model.Auhtor);

#line default
#line hidden
#nullable disable
            WriteLiteral(" </span></h5>\r\n            </div>\r\n            <div class=\"col-6 card-body \">\r\n                <h5 style=\"font-weight:600 !important\">Dili : <span style=\"font-weight:200 !important\"> ");
#nullable restore
#line 23 "C:\Users\TOSHIBA\Desktop\developback\AccessibleLibrary\AccessibleLibrary\Areas\JrCAdmin\Views\UnCreated\Delete.cshtml"
                                                                                                   Write(Model.BookLanguage.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral(" </span></h5>\r\n            </div>\r\n            <div class=\"col-6 card-body \">\r\n                <h5 style=\"font-weight:600 !important\">Qiyməti : <span style=\"font-weight:200 !important\"> ");
#nullable restore
#line 26 "C:\Users\TOSHIBA\Desktop\developback\AccessibleLibrary\AccessibleLibrary\Areas\JrCAdmin\Views\UnCreated\Delete.cshtml"
                                                                                                      Write(Model.Price);

#line default
#line hidden
#nullable disable
            WriteLiteral(" </span></h5>\r\n            </div>\r\n\r\n");
#nullable restore
#line 29 "C:\Users\TOSHIBA\Desktop\developback\AccessibleLibrary\AccessibleLibrary\Areas\JrCAdmin\Views\UnCreated\Delete.cshtml"
             foreach (BookCategory bc in Model.BookCategories)
            {
                

#line default
#line hidden
#nullable disable
#nullable restore
#line 31 "C:\Users\TOSHIBA\Desktop\developback\AccessibleLibrary\AccessibleLibrary\Areas\JrCAdmin\Views\UnCreated\Delete.cshtml"
                 if (bc.Category.IsMain)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <div class=\"col-6 card-body \">\r\n                        <h5 style=\"font-weight:600 !important\">Kateqori : <span style=\"font-weight:200 !important\"> ");
#nullable restore
#line 34 "C:\Users\TOSHIBA\Desktop\developback\AccessibleLibrary\AccessibleLibrary\Areas\JrCAdmin\Views\UnCreated\Delete.cshtml"
                                                                                                               Write(bc.Category.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral(" </span></h5>\r\n                    </div>\r\n");
#nullable restore
#line 36 "C:\Users\TOSHIBA\Desktop\developback\AccessibleLibrary\AccessibleLibrary\Areas\JrCAdmin\Views\UnCreated\Delete.cshtml"
                }
                else
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <div class=\"col-6 card-body \">\r\n                        <h5 style=\"font-weight:600 !important\">Kateqori : <span style=\"font-weight:200 !important\"> ");
#nullable restore
#line 40 "C:\Users\TOSHIBA\Desktop\developback\AccessibleLibrary\AccessibleLibrary\Areas\JrCAdmin\Views\UnCreated\Delete.cshtml"
                                                                                                               Write(bc.Category.Parent.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral(" </span></h5>\r\n                    </div>\r\n                    <div class=\"col-6 card-body \">\r\n                        <h5 style=\"font-weight:600 !important\">Alt Kateqori : <span style=\"font-weight:200 !important\"> ");
#nullable restore
#line 43 "C:\Users\TOSHIBA\Desktop\developback\AccessibleLibrary\AccessibleLibrary\Areas\JrCAdmin\Views\UnCreated\Delete.cshtml"
                                                                                                                   Write(bc.Category.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral(" </span></h5>\r\n                    </div>\r\n");
#nullable restore
#line 45 "C:\Users\TOSHIBA\Desktop\developback\AccessibleLibrary\AccessibleLibrary\Areas\JrCAdmin\Views\UnCreated\Delete.cshtml"
                }

#line default
#line hidden
#nullable disable
#nullable restore
#line 45 "C:\Users\TOSHIBA\Desktop\developback\AccessibleLibrary\AccessibleLibrary\Areas\JrCAdmin\Views\UnCreated\Delete.cshtml"
                 
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            <div class=\"col-6 card-body \">\r\n                <h5 style=\"font-weight:600 !important\">Email : <span style=\"font-weight:200 !important\"> ");
#nullable restore
#line 49 "C:\Users\TOSHIBA\Desktop\developback\AccessibleLibrary\AccessibleLibrary\Areas\JrCAdmin\Views\UnCreated\Delete.cshtml"
                                                                                                    Write(Model.Email);

#line default
#line hidden
#nullable disable
            WriteLiteral(" </span></h5>\r\n            </div>\r\n            <div class=\"col-6 card-body\">\r\n                <h5 style=\"font-weight:600 !important\">Əlaqə Nömrəsi : <span style=\"font-weight:200 !important\"> ");
#nullable restore
#line 52 "C:\Users\TOSHIBA\Desktop\developback\AccessibleLibrary\AccessibleLibrary\Areas\JrCAdmin\Views\UnCreated\Delete.cshtml"
                                                                                                            Write(Model.Phone);

#line default
#line hidden
#nullable disable
            WriteLiteral(" </span></h5>\r\n            </div>\r\n            <div class=\"col-6 card-body\">\r\n                <h5 style=\"font-weight:600 !important\">Əlaqədar Şəxs : <span style=\"font-weight:200 !important\"> ");
#nullable restore
#line 55 "C:\Users\TOSHIBA\Desktop\developback\AccessibleLibrary\AccessibleLibrary\Areas\JrCAdmin\Views\UnCreated\Delete.cshtml"
                                                                                                            Write(Model.SalerName);

#line default
#line hidden
#nullable disable
            WriteLiteral(" </span></h5>\r\n            </div>\r\n            <div class=\"col-6 card-body\">\r\n                <h5 style=\"font-weight:600 !important\">Şəhər : <span style=\"font-weight:200 !important\"> ");
#nullable restore
#line 58 "C:\Users\TOSHIBA\Desktop\developback\AccessibleLibrary\AccessibleLibrary\Areas\JrCAdmin\Views\UnCreated\Delete.cshtml"
                                                                                                    Write(Model.BookDetail.BookCity.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral(" </span></h5>\r\n            </div>\r\n            <div class=\"col-6 card-body\">\r\n                <h5 style=\"font-weight:600 !important\">Yaranma Vaxtı : <span style=\"font-weight:200 !important\"> ");
#nullable restore
#line 61 "C:\Users\TOSHIBA\Desktop\developback\AccessibleLibrary\AccessibleLibrary\Areas\JrCAdmin\Views\UnCreated\Delete.cshtml"
                                                                                                            Write(Model.BookDetail.CreateTime.ToString("d"));

#line default
#line hidden
#nullable disable
            WriteLiteral(" </span></h5>\r\n            </div>\r\n        </div>\r\n    </div>\r\n    <div class=\"d-flex my-2 justify-content-center\">\r\n        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "189f0041336e9bd19fff1facbc0083ce57d7039e16703", async() => {
                WriteLiteral("Elanı Təsdiqlə");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 66 "C:\Users\TOSHIBA\Desktop\developback\AccessibleLibrary\AccessibleLibrary\Areas\JrCAdmin\Views\UnCreated\Delete.cshtml"
                                      WriteLiteral(Model.Id);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "189f0041336e9bd19fff1facbc0083ce57d7039e19073", async() => {
                WriteLiteral("\r\n            <button type=\"submit\" class=\"btn btn-secondary  \" style=\"cursor:pointer; margin: 0 30px\">Elanı Sil</button>\r\n        ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n\r\n    </div>\r\n</div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Book> Html { get; private set; }
    }
}
#pragma warning restore 1591
