#pragma checksum "D:\Udemy\MyUdemyWorks\API-3.1\UdemyIdentityServer\UdemyIdentityServer.FirstClient\Views\Home\AccessDenied.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "ee60d80144a369201ea4887392e1a57532998961"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_AccessDenied), @"mvc.1.0.view", @"/Views/Home/AccessDenied.cshtml")]
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
#line 1 "D:\Udemy\MyUdemyWorks\API-3.1\UdemyIdentityServer\UdemyIdentityServer.FirstClient\Views\_ViewImports.cshtml"
using UdemyIdentityServer.FirstClient;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\Udemy\MyUdemyWorks\API-3.1\UdemyIdentityServer\UdemyIdentityServer.FirstClient\Views\_ViewImports.cshtml"
using UdemyIdentityServer.FirstClient.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ee60d80144a369201ea4887392e1a57532998961", @"/Views/Home/AccessDenied.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3075b8b29975f6286e3266b0ff74efe2d512658c", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_AccessDenied : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 2 "D:\Udemy\MyUdemyWorks\API-3.1\UdemyIdentityServer\UdemyIdentityServer.FirstClient\Views\Home\AccessDenied.cshtml"
  
    ViewData["Title"] = "AccessDenied";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1>AccessDenied</h1>\r\n<h2>Erişmeye çalıştığınız sayfa:");
#nullable restore
#line 7 "D:\Udemy\MyUdemyWorks\API-3.1\UdemyIdentityServer\UdemyIdentityServer.FirstClient\Views\Home\AccessDenied.cshtml"
                           Write(ViewBag.url);

#line default
#line hidden
#nullable disable
            WriteLiteral(" </h2>\r\n\r\n");
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
