#pragma checksum "D:\Project\WebAutomationSystem\WebAutomationSystem\Areas\UserArea\Views\RecievedNotation\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "87f63649cec743400807b50ffd63d465411def20"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_UserArea_Views_RecievedNotation_Index), @"mvc.1.0.view", @"/Areas/UserArea/Views/RecievedNotation/Index.cshtml")]
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
#line 1 "D:\Project\WebAutomationSystem\WebAutomationSystem\Areas\UserArea\Views\_ViewImports.cshtml"
using WebAutomationSystem;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\Project\WebAutomationSystem\WebAutomationSystem\Areas\UserArea\Views\_ViewImports.cshtml"
using WebAutomationSystem.DataModelLayer.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "D:\Project\WebAutomationSystem\WebAutomationSystem\Areas\UserArea\Views\_ViewImports.cshtml"
using WebAutomationSystem.DataModelLayer.ViewModels;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "D:\Project\WebAutomationSystem\WebAutomationSystem\Areas\UserArea\Views\_ViewImports.cshtml"
using WebAutomationSystem.DataModelLayer.Entities;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\Project\WebAutomationSystem\WebAutomationSystem\Areas\UserArea\Views\RecievedNotation\Index.cshtml"
using WebAutomationSystem.CommonLayer.PublicClass;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "D:\Project\WebAutomationSystem\WebAutomationSystem\Areas\UserArea\Views\RecievedNotation\Index.cshtml"
using WebAutomationSystem.DataModelLayer.StaticClassValue;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"87f63649cec743400807b50ffd63d465411def20", @"/Areas/UserArea/Views/RecievedNotation/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ca10fe5acc827c9730b3ba0b1f92ea7278ce2e82", @"/Areas/UserArea/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Areas_UserArea_Views_RecievedNotation_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<WebAutomationSystem.DataModelLayer.ViewModels.RecievedNotationListViewModel>>
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("style", new global::Microsoft.AspNetCore.Html.HtmlString("border:1px solid #cbcbcb; margin-bottom:5px;"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("searchTypeselected"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("name", "searchTypeselected", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "RecievedNotation", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "ReadNotation", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("data-toggle", new global::Microsoft.AspNetCore.Html.HtmlString("modal"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("data-target", new global::Microsoft.AspNetCore.Html.HtmlString("#modal-action"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_7 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("style", new global::Microsoft.AspNetCore.Html.HtmlString("height:30px;  font-size:10px; margin-bottom:3px;"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_8 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-outline-primary"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.SelectTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n\r\n");
#nullable restore
#line 6 "D:\Project\WebAutomationSystem\WebAutomationSystem\Areas\UserArea\Views\RecievedNotation\Index.cshtml"
  
    ViewData["Title"] = "?????????????? ?????? ???????????? ??????";
    int counter = 1;

    //
    RecievedNotationSearchTypeModel RN = new RecievedNotationSearchTypeModel();
    RN.ID = ViewBag.searchTypeselected;
    List<RecievedNotationSearchTypeModel> ListRecivedNotationSearchTypeModel = RN.GetRecievedNotationTypeModel();

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n<div class=\"content\">\r\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "87f63649cec743400807b50ffd63d465411def208956", async() => {
                WriteLiteral(@"
        <div class=""panel panel-heading col-md-12 col-xs-12""
             style=""box-shadow:3px 1px 1px 0 #cbcbcb; border-radius:px;"">

            <span style=""font-weight:bold;"" class=""col-md-6 col-xs-12"">
                <i class=""icon-notebook""></i>
                ?????????????? ?????? ??????????????
            </span>
        </div>

        <div class=""panel col-md-12"" style=""border:1px solid #cbcbcb; background-color:#ebebeb; text-align:center;
                        padding:10px 6px 5px 6px; border-radius:px; margin-bottom:20px;"">

            <span style=""margin-bottom:5px;"">?????????? ???? ???????? :</span>
            ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("select", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "87f63649cec743400807b50ffd63d465411def209854", async() => {
                    WriteLiteral("\r\n            ");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.SelectTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper);
#nullable restore
#line 32 "D:\Project\WebAutomationSystem\WebAutomationSystem\Areas\UserArea\Views\RecievedNotation\Index.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => RN.ID);

#line default
#line hidden
#nullable disable
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-for", __Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
                __Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper.Name = (string)__tagHelperAttribute_2.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
#nullable restore
#line 33 "D:\Project\WebAutomationSystem\WebAutomationSystem\Areas\UserArea\Views\RecievedNotation\Index.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper.Items = (new SelectList(ListRecivedNotationSearchTypeModel,"ID","Title"));

#line default
#line hidden
#nullable disable
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-items", __Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper.Items, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n\r\n            <input type=\"text\" id=\"inputsearch\" name=\"inputsearch\"");
                BeginWriteAttribute("value", " value=\"", 1525, "\"", 1553, 1);
#nullable restore
#line 36 "D:\Project\WebAutomationSystem\WebAutomationSystem\Areas\UserArea\Views\RecievedNotation\Index.cshtml"
WriteAttributeValue("", 1533, ViewBag.inputsearch, 1533, 20, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral("\r\n                   style=\"border:1px solid #cbcbcb; width:300px; height:28px; margin-bottom:5px; text-align:center; font-weight:bold;\" />\r\n\r\n");
                WriteLiteral("            <label style=\"margin-bottom:5px;\">???? ?????????? :</label>\r\n            <input type=\"text\" autocomplete=\"off\" placeholder=\"???? ??????????...\"\r\n                   id=\"fromdate\" name=\"fromdate\"");
                BeginWriteAttribute("value", " value=\"", 1963, "\"", 1988, 1);
#nullable restore
#line 42 "D:\Project\WebAutomationSystem\WebAutomationSystem\Areas\UserArea\Views\RecievedNotation\Index.cshtml"
WriteAttributeValue("", 1971, ViewBag.fromdate, 1971, 17, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(@"
                   style=""border:1px solid #cbcbcb; border-radius:px; width:80px; height:28px; padding-right:3px; margin-bottom:5px;""
                   data-mddatetimepicker=""true""
                   data-placement=""right"" data-mdpersiandatetimepicker="""" data-trigger=""focus""
                   data-enabletimepicker=""false""
                   data-mdpersiandatetimepickerselecteddatetime=""{&quot;Year&quot;:1399,&quot;Month&quot;:1,&quot;Day&quot;:13,&quot;Hour&quot;:0,&quot;Minute&quot;:0,&quot;Second&quot;:0}""
                   data-mdpersiandatetimepickershowing=""true"" aria-describedby=""popover265350"">

            <label style=""margin-bottom:5px;"">???? ?????????? :</label>
            <input type=""text"" autocomplete=""off"" placeholder="" ???? ??????????...""
                   id=""todate"" name=""todate""");
                BeginWriteAttribute("value", " value=\"", 2799, "\"", 2822, 1);
#nullable restore
#line 52 "D:\Project\WebAutomationSystem\WebAutomationSystem\Areas\UserArea\Views\RecievedNotation\Index.cshtml"
WriteAttributeValue("", 2807, ViewBag.todate, 2807, 15, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(@"
                   style=""border:1px solid #cbcbcb; border-radius:px; width:80px; height:28px; padding-right:3px; margin-bottom:5px;""
                   data-mddatetimepicker=""true""
                   data-placement=""right"" data-mdpersiandatetimepicker="""" data-trigger=""focus""
                   data-enabletimepicker=""false""
                   data-mdpersiandatetimepickerselecteddatetime=""{&quot;Year&quot;:1399,&quot;Month&quot;:1,&quot;Day&quot;:13,&quot;Hour&quot;:0,&quot;Minute&quot;:0,&quot;Second&quot;:0}""
                   data-mdpersiandatetimepickershowing=""true"" aria-describedby=""popover265350"">
");
                WriteLiteral("            <button type=\"submit\" class=\"btn btn-outline-info\">\r\n                ??????????\r\n                <i class=\"icon-search4\"></i>\r\n            </button>\r\n        </div>\r\n    ");
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

    <hr style=""width:100%; background-color:#cbcbcb; height:1px;"" />

    <div class=""panel panel-body container-fluid""
         style=""border-radius:px; box-shadow:3px 1px 1px 0 #cbcbcb; background-color:#ebebeb"">

        <div class=""table-responsive""
             style=""border:1px solid #cbcbcb; border-radius:px; box-shadow:3px 3px 1px 0 #cbcbcb; margin-top:10px;"">
            <table class=""table table-bordered"" style=""background-color:white;"">
                <thead>
                    <tr style=""font-size:14px; font-weight:bold; background-color:#cbcbcb;"">
                        <td style=""width:20px;"">????????</td>
                        <td style=""width:250px;"">??????????</td>
                        <td>?????????? ????????????</td>
                        <td>??????????????</td>
                        <td>?????? ??????????????</td>
                        <td style=""width:164px !important; text-align:center;"">????????????</td>
                       
                    </tr>
                </thead>
                ");
            WriteLiteral("<tbody id=\"tabledraftlist\">\r\n");
#nullable restore
#line 87 "D:\Project\WebAutomationSystem\WebAutomationSystem\Areas\UserArea\Views\RecievedNotation\Index.cshtml"
                     foreach (var item in Model)
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <tr style=\"font-size:12px;\">\r\n                        <td style=\"width:20px; text-align:center;\">");
#nullable restore
#line 90 "D:\Project\WebAutomationSystem\WebAutomationSystem\Areas\UserArea\Views\RecievedNotation\Index.cshtml"
                                                              Write(counter);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        <td>");
#nullable restore
#line 91 "D:\Project\WebAutomationSystem\WebAutomationSystem\Areas\UserArea\Views\RecievedNotation\Index.cshtml"
                       Write(item.NotationTitle);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        <td>");
#nullable restore
#line 92 "D:\Project\WebAutomationSystem\WebAutomationSystem\Areas\UserArea\Views\RecievedNotation\Index.cshtml"
                       Write(ConvertDateTime.ConvertMiladiToShamsi(item.NotationDate, "yyyy/MM/dd"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        <td>");
#nullable restore
#line 93 "D:\Project\WebAutomationSystem\WebAutomationSystem\Areas\UserArea\Views\RecievedNotation\Index.cshtml"
                       Write(item.CreatorInfo.FullName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n\r\n                        <td style=\"text-align:right;\">\r\n");
#nullable restore
#line 96 "D:\Project\WebAutomationSystem\WebAutomationSystem\Areas\UserArea\Views\RecievedNotation\Index.cshtml"
                             if (item.NotationContent.Length > 150)
                            {
                                

#line default
#line hidden
#nullable disable
#nullable restore
#line 98 "D:\Project\WebAutomationSystem\WebAutomationSystem\Areas\UserArea\Views\RecievedNotation\Index.cshtml"
                           Write(item.NotationContent.Substring(0, 150));

#line default
#line hidden
#nullable disable
            WriteLiteral(" <span style=\"color:blue;\">(?????????? ???????? ...)</span>\r\n");
#nullable restore
#line 99 "D:\Project\WebAutomationSystem\WebAutomationSystem\Areas\UserArea\Views\RecievedNotation\Index.cshtml"
                            }
                            else
                            {
                                

#line default
#line hidden
#nullable disable
#nullable restore
#line 102 "D:\Project\WebAutomationSystem\WebAutomationSystem\Areas\UserArea\Views\RecievedNotation\Index.cshtml"
                           Write(item.NotationContent);

#line default
#line hidden
#nullable disable
#nullable restore
#line 102 "D:\Project\WebAutomationSystem\WebAutomationSystem\Areas\UserArea\Views\RecievedNotation\Index.cshtml"
                                                     
                            }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </td>\r\n\r\n\r\n                        <td>\r\n                            <div class=\"row\" style=\"width:150px;\">\r\n                                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "87f63649cec743400807b50ffd63d465411def2021251", async() => {
                WriteLiteral("\r\n                                     <i class=\"icon-reading\"></i>\r\n                                        <span style=\"text-align:center\">????????????</span>\r\n                                ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-NotationContent", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 111 "D:\Project\WebAutomationSystem\WebAutomationSystem\Areas\UserArea\Views\RecievedNotation\Index.cshtml"
                                                  WriteLiteral(item.NotationContent);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["NotationContent"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-NotationContent", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["NotationContent"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            BeginWriteTagHelperAttribute();
#nullable restore
#line 112 "D:\Project\WebAutomationSystem\WebAutomationSystem\Areas\UserArea\Views\RecievedNotation\Index.cshtml"
                                                WriteLiteral(item.NotationTitle);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["NotationTitle"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-NotationTitle", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["NotationTitle"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            BeginWriteTagHelperAttribute();
#nullable restore
#line 113 "D:\Project\WebAutomationSystem\WebAutomationSystem\Areas\UserArea\Views\RecievedNotation\Index.cshtml"
                                               WriteLiteral(ConvertDateTime.ConvertMiladiToShamsi(item.NotationDate,"yyyy/MM/dd"));

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["NotationDate"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-NotationDate", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["NotationDate"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
            WriteLiteral("\r\n                            </div>\r\n\r\n                        </td>\r\n                    </tr>\r\n");
#nullable restore
#line 124 "D:\Project\WebAutomationSystem\WebAutomationSystem\Areas\UserArea\Views\RecievedNotation\Index.cshtml"
                        counter++;
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </tbody>\r\n            </table>\r\n        </div>\r\n    </div>\r\n</div>\r\n\r\n\r\n");
#nullable restore
#line 134 "D:\Project\WebAutomationSystem\WebAutomationSystem\Areas\UserArea\Views\RecievedNotation\Index.cshtml"
Write(Html.Partial("_Modal", new BootstrapModel { ID = "modal-action", Size = BootstrapModel.ModalSize.Large }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n");
            DefineSection("UserScripts", async() => {
                WriteLiteral("\r\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "87f63649cec743400807b50ffd63d465411def2026747", async() => {
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<WebAutomationSystem.DataModelLayer.ViewModels.RecievedNotationListViewModel>> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
