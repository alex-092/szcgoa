#pragma checksum "D:\MyCode\SZCGOA.v2\OA.Blazor\Shared\SignLayout.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "7d2ca50ac23e7a32b72ba64b6285f804354fe337"
// <auto-generated/>
#pragma warning disable 1591
namespace OA.Blazor.Shared
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
    public partial class SignLayout : LayoutComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
            __builder.OpenComponent<MatBlazor.MatAppBarContainer>(0);
            __builder.AddAttribute(1, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment)((__builder2) => {
                __builder2.AddMarkupContent(2, "\r\n        ");
                __builder2.OpenComponent<MatBlazor.MatAppBar>(3);
                __builder2.AddAttribute(4, "Fixed", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Boolean>(
#nullable restore
#line 3 "D:\MyCode\SZCGOA.v2\OA.Blazor\Shared\SignLayout.razor"
                          true

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(5, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment)((__builder3) => {
                    __builder3.AddMarkupContent(6, "\r\n            ");
                    __builder3.OpenComponent<MatBlazor.MatAppBarRow>(7);
                    __builder3.AddAttribute(8, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment)((__builder4) => {
                        __builder4.AddMarkupContent(9, "\r\n                ");
                        __builder4.OpenComponent<MatBlazor.MatAppBarSection>(10);
                        __builder4.AddAttribute(11, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment)((__builder5) => {
                            __builder5.AddMarkupContent(12, "\r\n                    ");
                            __builder5.OpenComponent<MatBlazor.MatIconButton>(13);
                            __builder5.AddAttribute(14, "Icon", "menu");
                            __builder5.CloseComponent();
                            __builder5.AddMarkupContent(15, "\r\n                    ");
                            __builder5.OpenComponent<MatBlazor.MatAppBarTitle>(16);
                            __builder5.AddAttribute(17, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment)((__builder6) => {
                                __builder6.AddContent(18, "MatBlazor - Material Design components for Blazor");
                            }
                            ));
                            __builder5.CloseComponent();
                            __builder5.AddMarkupContent(19, "\r\n                ");
                        }
                        ));
                        __builder4.CloseComponent();
                        __builder4.AddMarkupContent(20, "\r\n                ");
                        __builder4.OpenComponent<MatBlazor.MatAppBarSection>(21);
                        __builder4.AddAttribute(22, "Align", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<MatBlazor.MatAppBarSectionAlign>(
#nullable restore
#line 9 "D:\MyCode\SZCGOA.v2\OA.Blazor\Shared\SignLayout.razor"
                                          MatAppBarSectionAlign.End

#line default
#line hidden
#nullable disable
                        ));
                        __builder4.CloseComponent();
                        __builder4.AddMarkupContent(23, "\r\n            ");
                    }
                    ));
                    __builder3.CloseComponent();
                    __builder3.AddMarkupContent(24, "\r\n        ");
                }
                ));
                __builder2.CloseComponent();
                __builder2.AddMarkupContent(25, "\r\n\r\n        ");
                __builder2.OpenComponent<MatBlazor.MatAppBarContent>(26);
                __builder2.AddAttribute(27, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment)((__builder3) => {
                    __builder3.AddMarkupContent(28, "\r\n            ");
                    __builder3.AddContent(29, 
#nullable restore
#line 16 "D:\MyCode\SZCGOA.v2\OA.Blazor\Shared\SignLayout.razor"
             Body

#line default
#line hidden
#nullable disable
                    );
                    __builder3.AddMarkupContent(30, "\r\n        ");
                }
                ));
                __builder2.CloseComponent();
                __builder2.AddMarkupContent(31, "\r\n    ");
            }
            ));
            __builder.CloseComponent();
        }
        #pragma warning restore 1998
    }
}
#pragma warning restore 1591