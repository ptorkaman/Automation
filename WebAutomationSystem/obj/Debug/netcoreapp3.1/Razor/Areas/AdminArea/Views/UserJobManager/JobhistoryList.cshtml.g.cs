#pragma checksum "D:\Project\WebAutomationSystem\WebAutomationSystem\Areas\AdminArea\Views\UserJobManager\JobhistoryList.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "8c8d1b09cbe07ab3609cf35a2b89ddaca8970612"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_AdminArea_Views_UserJobManager_JobhistoryList), @"mvc.1.0.view", @"/Areas/AdminArea/Views/UserJobManager/JobhistoryList.cshtml")]
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
#line 1 "D:\Project\WebAutomationSystem\WebAutomationSystem\Areas\AdminArea\Views\_ViewImports.cshtml"
using WebAutomationSystem;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\Project\WebAutomationSystem\WebAutomationSystem\Areas\AdminArea\Views\_ViewImports.cshtml"
using WebAutomationSystem.DataModelLayer;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "D:\Project\WebAutomationSystem\WebAutomationSystem\Areas\AdminArea\Views\_ViewImports.cshtml"
using WebAutomationSystem.DataModelLayer.Entities;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "D:\Project\WebAutomationSystem\WebAutomationSystem\Areas\AdminArea\Views\UserJobManager\JobhistoryList.cshtml"
using WebAutomationSystem.CommonLayer.PublicClass;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8c8d1b09cbe07ab3609cf35a2b89ddaca8970612", @"/Areas/AdminArea/Views/UserJobManager/JobhistoryList.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d61d985f03a5801b25e72250f70bb9112086302b", @"/Areas/AdminArea/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Areas_AdminArea_Views_UserJobManager_JobhistoryList : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<WebAutomationSystem.DataModelLayer.Entities.UserJob>>
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "UserJobManager", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "AddJobToUser", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-outline-primary"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("title", new global::Microsoft.AspNetCore.Html.HtmlString("???????????? ??????"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "DelJobFromUser", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("style", new global::Microsoft.AspNetCore.Html.HtmlString("width:100px; font-size:10px; padding:5px;"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("data-toggle", new global::Microsoft.AspNetCore.Html.HtmlString("modal"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_7 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("data-target", new global::Microsoft.AspNetCore.Html.HtmlString("#modal-action"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_8 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-outline-danger"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_9 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/js/modal/modal.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 5 "D:\Project\WebAutomationSystem\WebAutomationSystem\Areas\AdminArea\Views\UserJobManager\JobhistoryList.cshtml"
  
    ViewData["Title"] = "?????????????? ??????????";
    int counter = 1;

    var getuser = _context.userManagerUW.GetById(ViewBag.userId);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<style>
    tr:hover td {
        background-color: #dcd6d6;
    }
</style>

<div class=""content"">

    <div class=""panel panel-heading"" style=""box-shadow:3px 1px 1px 0 #cbcbcb; border-radius:px;"">
        <span style=""font-weight:bold;"">
            <i class=""glyphicon glyphicon-user""></i>
            ?????????????? ?????????? <span style=""color:darkgreen;"">");
#nullable restore
#line 23 "D:\Project\WebAutomationSystem\WebAutomationSystem\Areas\AdminArea\Views\UserJobManager\JobhistoryList.cshtml"
                                                    Write(getuser.FirstName);

#line default
#line hidden
#nullable disable
            WriteLiteral(" ");
#nullable restore
#line 23 "D:\Project\WebAutomationSystem\WebAutomationSystem\Areas\AdminArea\Views\UserJobManager\JobhistoryList.cshtml"
                                                                       Write(getuser.Family);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n        </span>\r\n    </div>\r\n\r\n\r\n    <div class=\"panel panel-body container-fluid\" style=\"border-radius:px; box-shadow:3px 1px 1px 0 #cbcbcb; background-color:#ebebeb;\">\r\n\r\n\r\n");
#nullable restore
#line 31 "D:\Project\WebAutomationSystem\WebAutomationSystem\Areas\AdminArea\Views\UserJobManager\JobhistoryList.cshtml"
         if (ViewBag.CheckJob == null && getuser.IsActive == 1)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <div style=\"margin-bottom:5px;\">\r\n                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "8c8d1b09cbe07ab3609cf35a2b89ddaca89706129401", async() => {
                WriteLiteral("\r\n                    <i class=\"glyphicon glyphicon-plus\"></i>\r\n                    ???????????? ??????\r\n                ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-FirstName", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 35 "D:\Project\WebAutomationSystem\WebAutomationSystem\Areas\AdminArea\Views\UserJobManager\JobhistoryList.cshtml"
                            WriteLiteral(getuser.FirstName);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["FirstName"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-FirstName", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["FirstName"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            BeginWriteTagHelperAttribute();
#nullable restore
#line 35 "D:\Project\WebAutomationSystem\WebAutomationSystem\Areas\AdminArea\Views\UserJobManager\JobhistoryList.cshtml"
                                                                  WriteLiteral(getuser.Family);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["Family"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-Family", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["Family"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            BeginWriteTagHelperAttribute();
#nullable restore
#line 35 "D:\Project\WebAutomationSystem\WebAutomationSystem\Areas\AdminArea\Views\UserJobManager\JobhistoryList.cshtml"
                                                                                                     WriteLiteral(ViewBag.userId);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["userId"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-userId", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["userId"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n            </div>\r\n");
#nullable restore
#line 41 "D:\Project\WebAutomationSystem\WebAutomationSystem\Areas\AdminArea\Views\UserJobManager\JobhistoryList.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"



        <div class=""table-responsive"" style=""border:1px solid #cbcbcb; border-radius:px; box-shadow:3px 3px 1px 0 #cbcbcb;"">
            <table class=""table table-bordered"" style=""background-color:white;"">
                <thead>
                    <tr style=""font-size:14px; font-weight:bold; background-color:#cbcbcb;"">
                        <td>????????</td>
                        <td>?????? ??????</td>
                        <td>?????????? ????????????</td>
                        <td>?????????? ?????? ???? ??????</td>
                        <td>??????????</td>
                        <td>????????????</td>
                    </tr>
                </thead>
                <tbody>
");
#nullable restore
#line 59 "D:\Project\WebAutomationSystem\WebAutomationSystem\Areas\AdminArea\Views\UserJobManager\JobhistoryList.cshtml"
                     foreach (var item in Model)
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <tr");
            BeginWriteAttribute("style", " style=\"", 2241, "\"", 2336, 4);
            WriteAttributeValue("", 2249, "font-size:13px;", 2249, 15, true);
            WriteAttributeValue(" ", 2264, "background-color:", 2265, 18, true);
#nullable restore
#line 61 "D:\Project\WebAutomationSystem\WebAutomationSystem\Areas\AdminArea\Views\UserJobManager\JobhistoryList.cshtml"
WriteAttributeValue("", 2282, item.IsHaveJob == false ? "#ffebfb" : "lightgreen", 2282, 53, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 2335, ";", 2335, 1, true);
            EndWriteAttribute();
            WriteLiteral(">\r\n                            <td style=\"width:60px; text-align:center;\">");
#nullable restore
#line 62 "D:\Project\WebAutomationSystem\WebAutomationSystem\Areas\AdminArea\Views\UserJobManager\JobhistoryList.cshtml"
                                                                  Write(counter);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                            <td style=\"text-align:right;\">");
#nullable restore
#line 63 "D:\Project\WebAutomationSystem\WebAutomationSystem\Areas\AdminArea\Views\UserJobManager\JobhistoryList.cshtml"
                                                     Write(item.Jobs.JobsChartName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                            <td>\r\n                                ");
#nullable restore
#line 65 "D:\Project\WebAutomationSystem\WebAutomationSystem\Areas\AdminArea\Views\UserJobManager\JobhistoryList.cshtml"
                           Write(ConvertDateTime.ConvertMiladiToShamsi(@item.StartJobDate, "yyyy/MM/dd"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                            </td>\r\n\r\n");
#nullable restore
#line 68 "D:\Project\WebAutomationSystem\WebAutomationSystem\Areas\AdminArea\Views\UserJobManager\JobhistoryList.cshtml"
                             if (item.IsHaveJob == false)
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <td>\r\n                                    ");
#nullable restore
#line 71 "D:\Project\WebAutomationSystem\WebAutomationSystem\Areas\AdminArea\Views\UserJobManager\JobhistoryList.cshtml"
                               Write(ConvertDateTime.ConvertMiladiToShamsi(@item.EndJobDate, "yyyy/MM/dd"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                </td>\r\n");
#nullable restore
#line 73 "D:\Project\WebAutomationSystem\WebAutomationSystem\Areas\AdminArea\Views\UserJobManager\JobhistoryList.cshtml"
                            }
                            else
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <td>\r\n                                </td>\r\n");
#nullable restore
#line 78 "D:\Project\WebAutomationSystem\WebAutomationSystem\Areas\AdminArea\Views\UserJobManager\JobhistoryList.cshtml"
                            }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n                            <td>\r\n");
#nullable restore
#line 82 "D:\Project\WebAutomationSystem\WebAutomationSystem\Areas\AdminArea\Views\UserJobManager\JobhistoryList.cshtml"
                                 if (item.IsHaveJob == true)
                                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                    <span>????????</span>\r\n");
#nullable restore
#line 85 "D:\Project\WebAutomationSystem\WebAutomationSystem\Areas\AdminArea\Views\UserJobManager\JobhistoryList.cshtml"
                                }
                                else
                                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                    <span>??????????</span>\r\n");
#nullable restore
#line 89 "D:\Project\WebAutomationSystem\WebAutomationSystem\Areas\AdminArea\Views\UserJobManager\JobhistoryList.cshtml"
                                }

#line default
#line hidden
#nullable disable
            WriteLiteral("                            </td>\r\n\r\n                            <td>\r\n");
#nullable restore
#line 93 "D:\Project\WebAutomationSystem\WebAutomationSystem\Areas\AdminArea\Views\UserJobManager\JobhistoryList.cshtml"
                                 if (item.IsHaveJob == true)
                                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "8c8d1b09cbe07ab3609cf35a2b89ddaca897061219720", async() => {
                WriteLiteral("\r\n                                        <i class=\"glyphicon glyphicon-remove\"></i>\r\n                                        ?????????? ??????\r\n                                    ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-UserJobId", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 96 "D:\Project\WebAutomationSystem\WebAutomationSystem\Areas\AdminArea\Views\UserJobManager\JobhistoryList.cshtml"
                                                WriteLiteral(item.UserJobID);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["UserJobId"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-UserJobId", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["UserJobId"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            BeginWriteTagHelperAttribute();
#nullable restore
#line 97 "D:\Project\WebAutomationSystem\WebAutomationSystem\Areas\AdminArea\Views\UserJobManager\JobhistoryList.cshtml"
                                             WriteLiteral(getuser.Id);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["userId"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-userId", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["userId"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_5);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_6);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_7);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_8);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
#nullable restore
#line 104 "D:\Project\WebAutomationSystem\WebAutomationSystem\Areas\AdminArea\Views\UserJobManager\JobhistoryList.cshtml"
                                }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                            </td>\r\n                        </tr>\r\n");
#nullable restore
#line 108 "D:\Project\WebAutomationSystem\WebAutomationSystem\Areas\AdminArea\Views\UserJobManager\JobhistoryList.cshtml"
                        counter++;
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </tbody>\r\n            </table>\r\n        </div>\r\n\r\n\r\n    </div>\r\n</div>\r\n\r\n\r\n\r\n");
#nullable restore
#line 121 "D:\Project\WebAutomationSystem\WebAutomationSystem\Areas\AdminArea\Views\UserJobManager\JobhistoryList.cshtml"
Write(Html.Partial("_Modal", new BootstrapModel { ID = "modal-action", Size = BootstrapModel.ModalSize.Large }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n");
            DefineSection("AdminScripts", async() => {
                WriteLiteral("\r\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "8c8d1b09cbe07ab3609cf35a2b89ddaca897061224586", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_9);
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
        }
        #pragma warning restore 1998
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public WebAutomationSystem.DataModelLayer.Services.IUnitOfWork _context { get; private set; } = default!;
        #nullable disable
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<WebAutomationSystem.DataModelLayer.Entities.UserJob>> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
