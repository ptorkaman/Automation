#pragma checksum "D:\Project\WebAutomationSystem\WebAutomationSystem\Areas\UserArea\Views\RecievedNotation\_ReadNotation.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "8210ccebf2ae0770986e8d786a46581c22718f1b"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_UserArea_Views_RecievedNotation__ReadNotation), @"mvc.1.0.view", @"/Areas/UserArea/Views/RecievedNotation/_ReadNotation.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8210ccebf2ae0770986e8d786a46581c22718f1b", @"/Areas/UserArea/Views/RecievedNotation/_ReadNotation.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ca10fe5acc827c9730b3ba0b1f92ea7278ce2e82", @"/Areas/UserArea/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Areas_UserArea_Views_RecievedNotation__ReadNotation : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 2 "D:\Project\WebAutomationSystem\WebAutomationSystem\Areas\UserArea\Views\RecievedNotation\_ReadNotation.cshtml"
  
    Layout = null;

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<div>
    <div class=""modal-header"" style=""background-color:#cbcbcb; color:white; border-radius:5px 5px 0 0;"">
        <button type=""button"" class=""close pull-left"" data-dismiss=""modal"" aria-hidden=""true"">&times;</button>
        <h4 class=""modal-title"">?????????? ??????????????</h4>
    </div>

    <div style=""margin-top:15px;"">

        <div class=""col-md-12 col-xs-12"">
            <span class=""col-md-3 col-xs-12"" style=""font-weight:bold"">?????????? ???????????? ?????????????? :</span>
            <sapn>");
#nullable restore
#line 16 "D:\Project\WebAutomationSystem\WebAutomationSystem\Areas\UserArea\Views\RecievedNotation\_ReadNotation.cshtml"
             Write(ViewBag.NotationDate);

#line default
#line hidden
#nullable disable
            WriteLiteral("</sapn>\r\n        </div>\r\n      \r\n        <div class=\"col-md-12 col-xs-12\">\r\n            <span class=\"col-md-3 col-xs-12\" style=\"font-weight:bold\"> ?????????? ?????????????? :</span>\r\n            <sapn>");
#nullable restore
#line 21 "D:\Project\WebAutomationSystem\WebAutomationSystem\Areas\UserArea\Views\RecievedNotation\_ReadNotation.cshtml"
             Write(ViewBag.NotationTitle);

#line default
#line hidden
#nullable disable
            WriteLiteral("</sapn>\r\n        </div>\r\n\r\n        <div class=\"col-md-12 col-xs-12\">\r\n            <span class=\"col-md-3 col-xs-12\" style=\"font-weight:bold\">?????? ?????????????? :</span>\r\n            <sapn>");
#nullable restore
#line 26 "D:\Project\WebAutomationSystem\WebAutomationSystem\Areas\UserArea\Views\RecievedNotation\_ReadNotation.cshtml"
             Write(ViewBag.NotationContent);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</sapn>
        </div>

    </div>

    <div class=""modal-footer"" style=""text-align:left;"">
        <button class=""btn btn-default"" type=""button"" style=""width:80px; border-radius:px; border:1px solid #cbcbcb;"" data-dismiss=""modal"">????????????</button>
     
    </div>

</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
