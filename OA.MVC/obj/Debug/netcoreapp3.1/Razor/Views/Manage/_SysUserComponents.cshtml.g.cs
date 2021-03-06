#pragma checksum "D:\MyCode\SZCGOA.v2\OA.MVC\Views\Manage\_SysUserComponents.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "54347596bc69eeed69384ca1e116447f10898b32"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Manage__SysUserComponents), @"mvc.1.0.view", @"/Views/Manage/_SysUserComponents.cshtml")]
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
#line 1 "D:\MyCode\SZCGOA.v2\OA.MVC\Views\_ViewImports.cshtml"
using OA.MVC;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\MyCode\SZCGOA.v2\OA.MVC\Views\_ViewImports.cshtml"
using OA.MVC.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "D:\MyCode\SZCGOA.v2\OA.MVC\Views\_ViewImports.cshtml"
using System.Security.Claims;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "D:\MyCode\SZCGOA.v2\OA.MVC\Views\_ViewImports.cshtml"
using OA.MVC.Common.Services;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"54347596bc69eeed69384ca1e116447f10898b32", @"/Views/Manage/_SysUserComponents.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5125b050c3449e63a96ec7879e95a7e32a23da31", @"/Views/_ViewImports.cshtml")]
    public class Views_Manage__SysUserComponents : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"
    <script type=""x-template"" id=""role-modal"">
        <el-dialog :title=""title"" :visible.sync=""dialogvisible""  width=""70%"" :close-on-click-modal=""ModalSetting.modalClickClose"">
            <div class=""row"">
                <div class=""card card-outline card-danger col-6 "">
                    <div class=""card-title"">11</div>
                    <div class=""card-body p-0"">
                        <table id=""extable""></table>
                    </div>
                </div>
                <div class=""card card-outline card-primary col-6 "">
                    <div class=""card-title"">11</div>
                    <div class=""card-body p-0"">
                        <table id=""intable""></table>
                    </div>
                </div>
            </div>
            <span slot=""footer"" class=""dialog-footer"">
                <el-button v-on:click=""$emit('modalcancel')"">取 消</el-button>
                <el-button type=""primary"" v-on:click=""$emit('modalok')"">确 定</el-button>
            <");
            WriteLiteral(@"/span>
        </el-dialog>
    </script>
<script>
    console.log(""comp"");
    Vue.component(""rolemodal"", {
        template: ""#role-modal"",
        props: [""title"",""dialogvisible""],
        data(){
            return {
                ModalSetting: {
                    modalClickClose: false,
                },
            }
        },
        created: function () {
            layui.use(['table'], function () {
                var table = layui.table;
                inTable = table.render({
                    elem: ""#intable"",
                    cols: rolecols,
                    data: [],
                    text: { none: ""该用户未设定角色"" },
                });
                exTable = table.render({
                    elem: ""#extable"",
                    cols: rolecols,
                    data: [],
                    text: { none: ""所有角色已经设定"" },
                });
            });
        },
    });
</script>
");
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
