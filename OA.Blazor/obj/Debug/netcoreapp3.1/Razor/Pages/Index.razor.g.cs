#pragma checksum "D:\MyCode\SZCGOA.v2\OA.Blazor\Pages\Index.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "bb59823895dfa65ae8957b608d7851aa2e5afd17"
// <auto-generated/>
#pragma warning disable 1591
namespace OA.Blazor.Pages
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
#nullable restore
#line 1 "D:\MyCode\SZCGOA.v2\OA.Blazor\_Imports.razor"
using System.Net.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\MyCode\SZCGOA.v2\OA.Blazor\_Imports.razor"
using Microsoft.AspNetCore.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "D:\MyCode\SZCGOA.v2\OA.Blazor\_Imports.razor"
using Microsoft.AspNetCore.Components.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "D:\MyCode\SZCGOA.v2\OA.Blazor\_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "D:\MyCode\SZCGOA.v2\OA.Blazor\_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "D:\MyCode\SZCGOA.v2\OA.Blazor\_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "D:\MyCode\SZCGOA.v2\OA.Blazor\_Imports.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "D:\MyCode\SZCGOA.v2\OA.Blazor\_Imports.razor"
using OA.Blazor;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "D:\MyCode\SZCGOA.v2\OA.Blazor\_Imports.razor"
using OA.Blazor.Shared;

#line default
#line hidden
#nullable disable
#nullable restore
#line 11 "D:\MyCode\SZCGOA.v2\OA.Blazor\_Imports.razor"
using MatBlazor;

#line default
#line hidden
#nullable disable
#nullable restore
#line 13 "D:\MyCode\SZCGOA.v2\OA.Blazor\_Imports.razor"
using System.ComponentModel.DataAnnotations;

#line default
#line hidden
#nullable disable
#nullable restore
#line 14 "D:\MyCode\SZCGOA.v2\OA.Blazor\_Imports.razor"
using System.IO;

#line default
#line hidden
#nullable disable
#nullable restore
#line 15 "D:\MyCode\SZCGOA.v2\OA.Blazor\_Imports.razor"
using System.Net.Http.Headers;

#line default
#line hidden
#nullable disable
#nullable restore
#line 16 "D:\MyCode\SZCGOA.v2\OA.Blazor\_Imports.razor"
using Microsoft.AspNetCore.Authentication;

#line default
#line hidden
#nullable disable
#nullable restore
#line 17 "D:\MyCode\SZCGOA.v2\OA.Blazor\_Imports.razor"
using Microsoft.AspNetCore.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 18 "D:\MyCode\SZCGOA.v2\OA.Blazor\_Imports.razor"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#nullable disable
#nullable restore
#line 19 "D:\MyCode\SZCGOA.v2\OA.Blazor\_Imports.razor"
using System.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\MyCode\SZCGOA.v2\OA.Blazor\Pages\Index.razor"
           [Authorize]

#line default
#line hidden
#nullable disable
    [Microsoft.AspNetCore.Components.RouteAttribute("/")]
    public partial class Index : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
            __builder.AddMarkupContent(0, "<h1>Hello, world!</h1>\r\n");
            __builder.OpenComponent<MatBlazor.MatButton>(1);
            __builder.AddAttribute(2, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 6 "D:\MyCode\SZCGOA.v2\OA.Blazor\Pages\Index.razor"
                     dowhat

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(3, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment)((__builder2) => {
                __builder2.AddContent(4, "Test");
            }
            ));
            __builder.CloseComponent();
            __builder.AddMarkupContent(5, "\r\nWelcome to your new app.\r\n");
            __builder.OpenComponent<Microsoft.AspNetCore.Components.Authorization.AuthorizeView>(6);
            __builder.AddAttribute(7, "Authorized", (Microsoft.AspNetCore.Components.RenderFragment<Microsoft.AspNetCore.Components.Authorization.AuthenticationState>)((context) => (__builder2) => {
                __builder2.AddMarkupContent(8, "\r\n        ");
                __builder2.AddMarkupContent(9, @"<div class=""dropdown"">
            <button class=""btn btn-secondary dropdown-toggle"" type=""button"" id=""dropdownMenuButton"" data-toggle=""dropdown"" aria-haspopup=""true"" aria-expanded=""false"">
                Dropdown button
            </button>
            <div class=""dropdown-menu"" aria-labelledby=""dropdownMenuButton"">
                <a class=""dropdown-item"" href=""#"">Action</a>
                <a class=""dropdown-item"" href=""#"">Another action</a>
                <a class=""dropdown-item"" href=""#"">Something else here</a>
            </div>
        </div>
");
#nullable restore
#line 20 "D:\MyCode\SZCGOA.v2\OA.Blazor\Pages\Index.razor"
         foreach (var item in context.User.Claims)
        {

#line default
#line hidden
#nullable disable
                __builder2.AddContent(10, "            ");
                __builder2.OpenElement(11, "p");
                __builder2.OpenElement(12, "b");
                __builder2.AddContent(13, 
#nullable restore
#line 22 "D:\MyCode\SZCGOA.v2\OA.Blazor\Pages\Index.razor"
                   item.Type

#line default
#line hidden
#nullable disable
                );
                __builder2.AddContent(14, " ");
                __builder2.CloseElement();
                __builder2.AddContent(15, ":");
                __builder2.AddContent(16, 
#nullable restore
#line 22 "D:\MyCode\SZCGOA.v2\OA.Blazor\Pages\Index.razor"
                                   item.Value

#line default
#line hidden
#nullable disable
                );
                __builder2.CloseElement();
                __builder2.AddMarkupContent(17, "\r\n");
#nullable restore
#line 23 "D:\MyCode\SZCGOA.v2\OA.Blazor\Pages\Index.razor"
        }

#line default
#line hidden
#nullable disable
                __builder2.AddContent(18, "    ");
            }
            ));
            __builder.AddAttribute(19, "NotAuthorized", (Microsoft.AspNetCore.Components.RenderFragment<Microsoft.AspNetCore.Components.Authorization.AuthenticationState>)((context) => (__builder2) => {
                __builder2.AddMarkupContent(20, "\r\n        \r\n    ");
            }
            ));
            __builder.CloseComponent();
            __builder.AddMarkupContent(21, "\r\n");
            __builder.OpenComponent<OA.Blazor.Shared.SurveyPrompt>(22);
            __builder.AddAttribute(23, "Title", "How is Blazor working for you?");
            __builder.CloseComponent();
        }
        #pragma warning restore 1998
#nullable restore
#line 31 "D:\MyCode\SZCGOA.v2\OA.Blazor\Pages\Index.razor"
         


    public void dowhat()
    {
        
        var temp = _httpcontext.HttpContext;
        var t1 = _httpcontext.HttpContext.Request.Path.ToString();
        var t2 = _httpcontext.HttpContext.Connection.RemoteIpAddress.ToString();
    }


#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private HttpContextAccessor _httpcontext { get; set; }
    }
}
#pragma warning restore 1591
