#pragma checksum "D:\Project\WebAutomationSystem\WebAutomationSystem\Areas\UserArea\Views\LeaveListRequest\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "f5f899282e88f818b8c389c2e0ac50710bb47438"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_UserArea_Views_LeaveListRequest_Index), @"mvc.1.0.view", @"/Areas/UserArea/Views/LeaveListRequest/Index.cshtml")]
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
#line 2 "D:\Project\WebAutomationSystem\WebAutomationSystem\Areas\UserArea\Views\LeaveListRequest\Index.cshtml"
using WebAutomationSystem.CommonLayer.PublicClass;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f5f899282e88f818b8c389c2e0ac50710bb47438", @"/Areas/UserArea/Views/LeaveListRequest/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ca10fe5acc827c9730b3ba0b1f92ea7278ce2e82", @"/Areas/UserArea/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Areas_UserArea_Views_LeaveListRequest_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<WebAutomationSystem.DataModelLayer.ViewModels.LeaveListViewModel>>
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "LeaveListRequest", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "DeleteLeave", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("data-toggle", new global::Microsoft.AspNetCore.Html.HtmlString("modal"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("data-target", new global::Microsoft.AspNetCore.Html.HtmlString("#modal-action"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("style", new global::Microsoft.AspNetCore.Html.HtmlString("height:30px; width:80px; font-size:9px; margin-bottom:3px;"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn customRed1"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "PrintLeave", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_7 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("target", new global::Microsoft.AspNetCore.Html.HtmlString("_blank"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_8 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("style", new global::Microsoft.AspNetCore.Html.HtmlString("height:30px; width:80px; font-size:10px; margin-bottom:3px;"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_9 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn customGreen1"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_10 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/js/modal/modal.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n\r\n");
#nullable restore
#line 5 "D:\Project\WebAutomationSystem\WebAutomationSystem\Areas\UserArea\Views\LeaveListRequest\Index.cshtml"
  
    ViewData["Title"] = "لیست مرخصی های درخواستی";
    int counter = 1;

#line default
#line hidden
#nullable disable
            WriteLiteral(@"

<div class=""content"">

    <div class=""panel panel-heading col-md-12 col-xs-12""
         style=""box-shadow:3px 1px 1px 0 gray; border-radius:2px;"">

        <span style=""font-weight:bold;"" class=""col-md-6 col-xs-12"">
            <i class=""glyphicon glyphicon-leaf""></i>
            لیست درخواست های مرخصی
        </span>
    </div>


    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "f5f899282e88f818b8c389c2e0ac50710bb474389015", async() => {
                WriteLiteral(@"
        <div class=""panel col-md-12"" style=""border:1px solid gray; background-color:#e6e2e2; text-align:center;
                        padding:10px 6px 5px 6px; border-radius:2px; margin-bottom:20px;"">


            <label style=""margin-bottom:5px;"">نام تایید کننده :</label>
            <input type=""text"" id=""confirmname"" name=""confirmname""");
                BeginWriteAttribute("value", " value=\"", 933, "\"", 961, 1);
#nullable restore
#line 29 "D:\Project\WebAutomationSystem\WebAutomationSystem\Areas\UserArea\Views\LeaveListRequest\Index.cshtml"
WriteAttributeValue("", 941, ViewBag.confirmname, 941, 20, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral("\r\n                   style=\"border:1px solid gray; width:300px; height:28px; margin-bottom:5px; text-align:center; font-weight:bold;\" />\r\n\r\n");
                WriteLiteral("            <label style=\"margin-bottom:5px;\">از تاریخ :</label>\r\n            <input type=\"text\" autocomplete=\"off\" placeholder=\"از تاریخ...\"\r\n                   id=\"fromdate\" name=\"fromdate\"");
                BeginWriteAttribute("value", " value=\"", 1368, "\"", 1393, 1);
#nullable restore
#line 35 "D:\Project\WebAutomationSystem\WebAutomationSystem\Areas\UserArea\Views\LeaveListRequest\Index.cshtml"
WriteAttributeValue("", 1376, ViewBag.fromdate, 1376, 17, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(@"
                   style=""border:1px solid gray; border-radius:2px; width:80px; height:28px; padding-right:3px; margin-bottom:5px;""
                   data-mddatetimepicker=""true""
                   data-placement=""right"" data-mdpersiandatetimepicker="""" data-trigger=""focus""
                   data-enabletimepicker=""false""
                   data-mdpersiandatetimepickerselecteddatetime=""{&quot;Year&quot;:1399,&quot;Month&quot;:1,&quot;Day&quot;:13,&quot;Hour&quot;:0,&quot;Minute&quot;:0,&quot;Second&quot;:0}""
                   data-mdpersiandatetimepickershowing=""true"" aria-describedby=""popover265350"">

            <label style=""margin-bottom:5px;"">تا تاریخ :</label>
            <input type=""text"" autocomplete=""off"" placeholder="" تا تاریخ...""
                   id=""todate"" name=""todate""");
                BeginWriteAttribute("value", " value=\"", 2202, "\"", 2225, 1);
#nullable restore
#line 45 "D:\Project\WebAutomationSystem\WebAutomationSystem\Areas\UserArea\Views\LeaveListRequest\Index.cshtml"
WriteAttributeValue("", 2210, ViewBag.todate, 2210, 15, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(@"
                   style=""border:1px solid gray; border-radius:2px; width:80px; height:28px; padding-right:3px; margin-bottom:5px;""
                   data-mddatetimepicker=""true""
                   data-placement=""right"" data-mdpersiandatetimepicker="""" data-trigger=""focus""
                   data-enabletimepicker=""false""
                   data-mdpersiandatetimepickerselecteddatetime=""{&quot;Year&quot;:1399,&quot;Month&quot;:1,&quot;Day&quot;:13,&quot;Hour&quot;:0,&quot;Minute&quot;:0,&quot;Second&quot;:0}""
                   data-mdpersiandatetimepickershowing=""true"" aria-describedby=""popover265350"">
");
                WriteLiteral(@"            <button type=""submit"">
                جستجو
                <i class=""icon-search4""></i>
            </button>
            <hr style=""width:100%; background-color:gray; height:1px;"" />

            <div class=""row"" style=""margin-top:10px; text-align:center;"">
                <span class=""col-md-6 col-xs-12"" style=""font-size:11px;"">
                    <span class=""col-md-2"" style=""margin-bottom:5px; font-weight:bold;"">نوع :</span>
                    <span class=""col-md-2"">
                        ساعتی
                        <input type=""radio"" name=""leaveType"" id=""leaveType"" value=""1"" ");
#nullable restore
#line 64 "D:\Project\WebAutomationSystem\WebAutomationSystem\Areas\UserArea\Views\LeaveListRequest\Index.cshtml"
                                                                                 Write(ViewBag.leaveType_1);

#line default
#line hidden
#nullable disable
                WriteLiteral(" />\r\n                    </span>\r\n                    <span class=\"col-md-2\">\r\n                        استحقاقی\r\n                        <input type=\"radio\" name=\"leaveType\" id=\"leaveType\" value=\"2\" ");
#nullable restore
#line 68 "D:\Project\WebAutomationSystem\WebAutomationSystem\Areas\UserArea\Views\LeaveListRequest\Index.cshtml"
                                                                                 Write(ViewBag.leaveType_2);

#line default
#line hidden
#nullable disable
                WriteLiteral(" />\r\n                    </span>\r\n                    <span class=\"col-md-2\">\r\n                        استعلاجی\r\n                        <input type=\"radio\" name=\"leaveType\" id=\"leaveType\" value=\"3\" ");
#nullable restore
#line 72 "D:\Project\WebAutomationSystem\WebAutomationSystem\Areas\UserArea\Views\LeaveListRequest\Index.cshtml"
                                                                                 Write(ViewBag.leaveType_3);

#line default
#line hidden
#nullable disable
                WriteLiteral(" />\r\n                    </span>\r\n                    <span class=\"col-md-2\">\r\n                        بی حقوق\r\n                        <input type=\"radio\" name=\"leaveType\" id=\"leaveType\" value=\"4\" ");
#nullable restore
#line 76 "D:\Project\WebAutomationSystem\WebAutomationSystem\Areas\UserArea\Views\LeaveListRequest\Index.cshtml"
                                                                                 Write(ViewBag.leaveType_4);

#line default
#line hidden
#nullable disable
                WriteLiteral(" />\r\n                    </span>\r\n                    <span class=\"col-md-2\">\r\n                        همه \r\n                        <input type=\"radio\" name=\"leaveType\" id=\"leaveType\" value=\"0\" ");
#nullable restore
#line 80 "D:\Project\WebAutomationSystem\WebAutomationSystem\Areas\UserArea\Views\LeaveListRequest\Index.cshtml"
                                                                                 Write(ViewBag.leaveType_0);

#line default
#line hidden
#nullable disable
                WriteLiteral(@" />
                    </span>
                </span>

                <span class=""col-md-6 col-xs-12"" style=""font-size:11px;"">
                    <span class=""col-md-4"" style=""margin-bottom:5px; font-weight:bold;"">وضعیت :</span>
                    <span class=""col-md-2"">
                        بررسی
                        <input type=""radio"" name=""leaveAccept"" id=""leaveAccept"" value=""1"" ");
#nullable restore
#line 88 "D:\Project\WebAutomationSystem\WebAutomationSystem\Areas\UserArea\Views\LeaveListRequest\Index.cshtml"
                                                                                     Write(ViewBag.leaveAccept_1);

#line default
#line hidden
#nullable disable
                WriteLiteral(" />\r\n                    </span>\r\n                    <span class=\"col-md-2\">\r\n                        تایید شده\r\n                        <input type=\"radio\" name=\"leaveAccept\" id=\"leaveAccept\" value=\"2\" ");
#nullable restore
#line 92 "D:\Project\WebAutomationSystem\WebAutomationSystem\Areas\UserArea\Views\LeaveListRequest\Index.cshtml"
                                                                                     Write(ViewBag.leaveAccept_2);

#line default
#line hidden
#nullable disable
                WriteLiteral(" />\r\n                    </span>\r\n                    <span class=\"col-md-2\">\r\n                        رد شده\r\n                        <input type=\"radio\" name=\"leaveAccept\" id=\"leaveAccept\" value=\"3\" ");
#nullable restore
#line 96 "D:\Project\WebAutomationSystem\WebAutomationSystem\Areas\UserArea\Views\LeaveListRequest\Index.cshtml"
                                                                                     Write(ViewBag.leaveAccept_3);

#line default
#line hidden
#nullable disable
                WriteLiteral(" />\r\n                    </span>\r\n                    <span class=\"col-md-2\">\r\n                        همه\r\n                        <input type=\"radio\" name=\"leaveAccept\" id=\"leaveAccept\" value=\"0\" ");
#nullable restore
#line 100 "D:\Project\WebAutomationSystem\WebAutomationSystem\Areas\UserArea\Views\LeaveListRequest\Index.cshtml"
                                                                                     Write(ViewBag.leaveAccept_0);

#line default
#line hidden
#nullable disable
                WriteLiteral(" />\r\n                    </span>\r\n                </span>\r\n            </div>\r\n        </div>\r\n    ");
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

    <hr style=""width:100%; background-color:gray; height:1px;"" />

    <div class=""panel panel-body container-fluid""
         style=""border-radius:2px; box-shadow:3px 1px 1px 0 gray; background-color:#e6e2e2"">

        <div class=""table-responsive""
             style=""border:1px solid gray; border-radius:2px; box-shadow:3px 3px 1px 0 gray; margin-top:10px;"">
            <table class=""table table-bordered"" style=""background-color:white;"">
                <thead>
                    <tr style=""font-size:14px; font-weight:bold; background-color:#c4bdbd;"">
                        <td style=""width:20px;"">ردیف</td>
                        <td>تاریخ ثبت درخواست</td>
                        <td>نوع درخواست</td>
                        <td>از تاریخ</td>
                        <td>تا تاریخ</td>
                        <td>از ساعت</td>
                        <td>تا ساعت</td>
                        <td>وضعیت درخواست</td>
                        <td>ناظر</td>
                        <td style=""wi");
            WriteLiteral("dth:164px !important; text-align:center;\">عملیات</td>\r\n                        \r\n                    </tr>\r\n                </thead>\r\n                <tbody id=\"tabledraftlist\">\r\n");
#nullable restore
#line 131 "D:\Project\WebAutomationSystem\WebAutomationSystem\Areas\UserArea\Views\LeaveListRequest\Index.cshtml"
                     foreach (var item in Model)
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <tr style=\"font-size:12px;\">\r\n                        <td style=\"width:20px; text-align:center;\">");
#nullable restore
#line 134 "D:\Project\WebAutomationSystem\WebAutomationSystem\Areas\UserArea\Views\LeaveListRequest\Index.cshtml"
                                                              Write(counter);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        <td>\r\n                            ");
#nullable restore
#line 136 "D:\Project\WebAutomationSystem\WebAutomationSystem\Areas\UserArea\Views\LeaveListRequest\Index.cshtml"
                       Write(ConvertDateTime.ConvertMiladiToShamsi(item.LeaveRequestDate, "yyyy/MM/dd"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </td>\r\n                        <td>");
#nullable restore
#line 138 "D:\Project\WebAutomationSystem\WebAutomationSystem\Areas\UserArea\Views\LeaveListRequest\Index.cshtml"
                       Write(item.LeaveTypeDesc);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        <td>");
#nullable restore
#line 139 "D:\Project\WebAutomationSystem\WebAutomationSystem\Areas\UserArea\Views\LeaveListRequest\Index.cshtml"
                        Write(item.LeaveType != 1 ? ConvertDateTime.ConvertMiladiToShamsi(item.FromDate_Day, "yyyy/MM/dd"): "");

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        <td>");
#nullable restore
#line 140 "D:\Project\WebAutomationSystem\WebAutomationSystem\Areas\UserArea\Views\LeaveListRequest\Index.cshtml"
                        Write(item.LeaveType != 1 ? ConvertDateTime.ConvertMiladiToShamsi(item.ToDate_Day, "yyyy/MM/dd"): "");

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        <td>");
#nullable restore
#line 141 "D:\Project\WebAutomationSystem\WebAutomationSystem\Areas\UserArea\Views\LeaveListRequest\Index.cshtml"
                        Write(item.LeaveType == 1 ? ConvertDateTime.ConvertMiladiToShamsi(item.FromTime_Saati, "yyyy/MM/dd HH:mm"): "");

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        <td>");
#nullable restore
#line 142 "D:\Project\WebAutomationSystem\WebAutomationSystem\Areas\UserArea\Views\LeaveListRequest\Index.cshtml"
                        Write(item.LeaveType == 1 ? ConvertDateTime.ConvertMiladiToShamsi(item.ToTime_Saati, "yyyy/MM/dd HH:mm"): "");

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        <td");
            BeginWriteAttribute("style", " style=\"", 7835, "\"", 7998, 3);
            WriteAttributeValue("", 7843, "text-align:center;", 7843, 18, true);
            WriteAttributeValue(" ", 7861, "background-color:", 7862, 18, true);
#nullable restore
#line 143 "D:\Project\WebAutomationSystem\WebAutomationSystem\Areas\UserArea\Views\LeaveListRequest\Index.cshtml"
WriteAttributeValue(" ", 7879, item.LeaveAccept == 1 ? "Yellow" : item.LeaveAccept == 2 ? "LightGreen" : item.LeaveAccept == 3 ? "lightcoral" : "", 7880, 118, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">");
#nullable restore
#line 143 "D:\Project\WebAutomationSystem\WebAutomationSystem\Areas\UserArea\Views\LeaveListRequest\Index.cshtml"
                                                                                                                                                                                           Write(item.LeaveAcceptDesc);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        <td>");
#nullable restore
#line 144 "D:\Project\WebAutomationSystem\WebAutomationSystem\Areas\UserArea\Views\LeaveListRequest\Index.cshtml"
                       Write(item.FullName_Confirm);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        <td>\r\n");
#nullable restore
#line 146 "D:\Project\WebAutomationSystem\WebAutomationSystem\Areas\UserArea\Views\LeaveListRequest\Index.cshtml"
                             if (item.LeaveAccept == 1)
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "f5f899282e88f818b8c389c2e0ac50710bb4743825433", async() => {
                WriteLiteral("\r\n                                    <i class=\"glyphicon glyphicon-remove\"></i>\r\n                                    حذف\r\n                                ");
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
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-LeaveID", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 149 "D:\Project\WebAutomationSystem\WebAutomationSystem\Areas\UserArea\Views\LeaveListRequest\Index.cshtml"
                                          WriteLiteral(item.LeaveID);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["LeaveID"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-LeaveID", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["LeaveID"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_5);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
#nullable restore
#line 156 "D:\Project\WebAutomationSystem\WebAutomationSystem\Areas\UserArea\Views\LeaveListRequest\Index.cshtml"
                            }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
#nullable restore
#line 158 "D:\Project\WebAutomationSystem\WebAutomationSystem\Areas\UserArea\Views\LeaveListRequest\Index.cshtml"
                             if (item.LeaveAccept == 2)
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "f5f899282e88f818b8c389c2e0ac50710bb4743828914", async() => {
                WriteLiteral("\r\n                                    <i class=\"glyphicon glyphicon-print\"></i>\r\n                                    پرینت\r\n                                ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_6.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_6);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_7);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-LeaveID", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 161 "D:\Project\WebAutomationSystem\WebAutomationSystem\Areas\UserArea\Views\LeaveListRequest\Index.cshtml"
                                          WriteLiteral(item.LeaveID);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["LeaveID"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-LeaveID", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["LeaveID"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_8);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_9);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
#nullable restore
#line 167 "D:\Project\WebAutomationSystem\WebAutomationSystem\Areas\UserArea\Views\LeaveListRequest\Index.cshtml"
                            }

#line default
#line hidden
#nullable disable
            WriteLiteral("                        </td>\r\n                    </tr>\r\n");
#nullable restore
#line 170 "D:\Project\WebAutomationSystem\WebAutomationSystem\Areas\UserArea\Views\LeaveListRequest\Index.cshtml"
                        counter++;
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </tbody>\r\n            </table>\r\n        </div>\r\n    </div>\r\n</div>\r\n\r\n\r\n");
#nullable restore
#line 180 "D:\Project\WebAutomationSystem\WebAutomationSystem\Areas\UserArea\Views\LeaveListRequest\Index.cshtml"
Write(Html.Partial("_Modal", new BootstrapModel { ID = "modal-action", Size = BootstrapModel.ModalSize.Large }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n");
            DefineSection("UserScripts", async() => {
                WriteLiteral("\r\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "f5f899282e88f818b8c389c2e0ac50710bb4743832856", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_10);
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<WebAutomationSystem.DataModelLayer.ViewModels.LeaveListViewModel>> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591