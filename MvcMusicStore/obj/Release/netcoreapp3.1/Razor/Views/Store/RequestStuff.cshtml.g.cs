#pragma checksum "D:\GithubRepos\ASP_NET_Core_MVC_MusicStore\MvcMusicStore\Views\Store\RequestStuff.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "d36aaf3dd049c08d5c2faf61dbb82ce604effc22"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Store_RequestStuff), @"mvc.1.0.view", @"/Views/Store/RequestStuff.cshtml")]
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
#line 1 "D:\GithubRepos\ASP_NET_Core_MVC_MusicStore\MvcMusicStore\Views\_ViewImports.cshtml"
using MvcMusicStore;

#line default
#line hidden
#nullable disable
#nullable restore
#line 1 "D:\GithubRepos\ASP_NET_Core_MVC_MusicStore\MvcMusicStore\Views\Store\RequestStuff.cshtml"
using MvcMusicStore.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\GithubRepos\ASP_NET_Core_MVC_MusicStore\MvcMusicStore\Views\Store\RequestStuff.cshtml"
using Microsoft.AspNetCore.Http;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d36aaf3dd049c08d5c2faf61dbb82ce604effc22", @"/Views/Store/RequestStuff.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7f3d7d6c215ab91880cc81299f2cd15c4126a9bd", @"/Views/_ViewImports.cshtml")]
    public class Views_Store_RequestStuff : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<Generic2String>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 5 "D:\GithubRepos\ASP_NET_Core_MVC_MusicStore\MvcMusicStore\Views\Store\RequestStuff.cshtml"
  
    ViewData["Title"] = "RequestStuff";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1>RequestStuff</h1>\r\n\r\n<h2>Displaying the Request object</h2>\r\n<table>\r\n    <tr><th>Key</th><th>Value</th></tr>\r\n");
#nullable restore
#line 15 "D:\GithubRepos\ASP_NET_Core_MVC_MusicStore\MvcMusicStore\Views\Store\RequestStuff.cshtml"
     foreach (Generic2String item in Model)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <tr>\r\n            <td>");
#nullable restore
#line 18 "D:\GithubRepos\ASP_NET_Core_MVC_MusicStore\MvcMusicStore\Views\Store\RequestStuff.cshtml"
           Write(item.key);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            <td>");
#nullable restore
#line 19 "D:\GithubRepos\ASP_NET_Core_MVC_MusicStore\MvcMusicStore\Views\Store\RequestStuff.cshtml"
           Write(item.value);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n        </tr>\r\n");
#nullable restore
#line 21 "D:\GithubRepos\ASP_NET_Core_MVC_MusicStore\MvcMusicStore\Views\Store\RequestStuff.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    <tr>\r\n        <td>Adding in the View</td>\r\n    </tr>\r\n\r\n    <tr>\r\n        <td>Artist Id</td>\r\n        <td>");
#nullable restore
#line 29 "D:\GithubRepos\ASP_NET_Core_MVC_MusicStore\MvcMusicStore\Views\Store\RequestStuff.cshtml"
       Write(Context.Session.GetInt32("ArtistId"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n    </tr>\r\n</table>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<Generic2String>> Html { get; private set; }
    }
}
#pragma warning restore 1591
