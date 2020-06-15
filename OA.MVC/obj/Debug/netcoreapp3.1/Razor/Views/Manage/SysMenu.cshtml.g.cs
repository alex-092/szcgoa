#pragma checksum "D:\MyCode\SZCGOA.v2\OA.MVC\Views\Manage\SysMenu.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "b85d93cc9b7e26907aa96a7c3ec31f61e0f6c18a"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Manage_SysMenu), @"mvc.1.0.view", @"/Views/Manage/SysMenu.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b85d93cc9b7e26907aa96a7c3ec31f61e0f6c18a", @"/Views/Manage/SysMenu.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5125b050c3449e63a96ec7879e95a7e32a23da31", @"/Views/_ViewImports.cshtml")]
    public class Views_Manage_SysMenu : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/lib/layui/css/layui.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("rel", new global::Microsoft.AspNetCore.Html.HtmlString("stylesheet"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/lib/layui/layui.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/js/Manage/sysmenu.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"
    <div class=""row"" id=""myapp"" v-cloak>
        <el-dialog :title=""menuDialogTitle"" :visible.sync=""dialogVisible""  width=""30%"" :close-on-click-modal=""menuModalSetting.modalClickClose"">
            <el-form :model=""menuModel"" :rules=""rules"" ref=""menuModel"" label-width=""100px""
                     v-on:submit.native.prevent label-position=""left"" >
                <el-form-item label=""菜单标题"" prop=""title"">
                    <el-input v-model=""menuModel.title""></el-input>
                </el-form-item>
                <el-form-item label=""控制器名称"" prop=""controller"">
                    <el-input v-model=""menuModel.controller""></el-input>
                </el-form-item>
                <el-form-item label=""操作名称"" prop=""action"">
                    <el-input v-model=""menuModel.action""></el-input>
                </el-form-item>
                <el-form-item label=""图标css"" prop=""icon"">
                    <el-input v-model=""menuModel.icon""></el-input>
                </el-form-item>
                <");
            WriteLiteral("el-form-item label=\"选择父级菜单\" prop=\"pid\">\r\n                    <el-select v-model=\"menuModel.pid\" placeholder=\"选择上级级菜单\"");
            BeginWriteAttribute("class", " class=\"", 1141, "\"", 1149, 0);
            EndWriteAttribute();
            WriteLiteral(@">
                        <el-option v-for=""item in selectlist"" :value=""item.pid"" :key=""item.pid"" :label=""item.title+'|级别:'+item.level""></el-option>
                    </el-select>
                </el-form-item>
                <el-form-item label=""相对排序编号"" prop=""order"">
                    <el-input v-model=""menuModel.order""></el-input>
                </el-form-item>
                <el-button type=""primary"" plain v-on:click=""doSubmit"">提交</el-button>
            </el-form>
        </el-dialog>
        <div class=""col-12"">
            <div class=""card card-outline card-info"">

                <div class=""card-header"">
                    <h3 class=""card-title"">
                        菜单管理
                        <small>菜单列表</small>
                    </h3>

                    <div class=""card-tools"">
                        <button type=""button"" class=""btn btn-tool btn-sm"" data-card-widget=""collapse"" data-toggle=""tooltip"" data-content=""最小化窗口"">
                            <i class=""fa");
            WriteLiteral(@" fa-minus""></i>
                        </button>
                    </div>
                </div>

                <div class=""card-body"">
                    <button class=""btn btn-sm btn-primary"" v-on:click=""openAddMenu"">添加新菜单</button>
                    <table class=""layui-table"" id=""menulist""></table>
                </div>

            </div>

        </div>
    </div>


");
            DefineSection("TopHtml", async() => {
                WriteLiteral("\r\n\r\n\r\n");
            }
            );
            DefineSection("CSS", async() => {
                WriteLiteral("\r\n\r\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "b85d93cc9b7e26907aa96a7c3ec31f61e0f6c18a7875", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
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
            DefineSection("Scripts", async() => {
                WriteLiteral("\r\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "b85d93cc9b7e26907aa96a7c3ec31f61e0f6c18a9174", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "b85d93cc9b7e26907aa96a7c3ec31f61e0f6c18a10273", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n    <script>\r\n//api\r\nlet AllMenuAPI = \'");
#nullable restore
#line 69 "D:\MyCode\SZCGOA.v2\OA.MVC\Views\Manage\SysMenu.cshtml"
             Write(Url.ActionLink("MenuList"));

#line default
#line hidden
#nullable disable
                WriteLiteral("\';\r\nlet MenuItemAPI = \'");
#nullable restore
#line 70 "D:\MyCode\SZCGOA.v2\OA.MVC\Views\Manage\SysMenu.cshtml"
              Write(Url.ActionLink("MenuItem"));

#line default
#line hidden
#nullable disable
                WriteLiteral(@"';
    </script>
    <script>

        layui.config({
            base: '../lib/tree/js/',
        })
        var treeTable; var tree;
        //col
        let mycol = [
            {
                key: 'menuLevel', title: '菜单组类型', width: '150px', align: 'left',
                template: function (item) {
                    if (item.menuLevel == 0) return '<span class=""text-danger m-0"">侧边菜单标题</span>';
                    if (item.menuLevel == 1) return '<span class=""text-primary m-0"">菜单项目</span>';
                    if (item.menuLevel == 2) return '<span class=""text-info m-0"">系统内部操作</span>';
                }
            },
            { key: 'title', title: '菜单标题', width: '200px', align: 'center', },
            { key: 'controller', title: '控制器名称', width: '150px', align: 'center', },
            { key: 'action', title: '操作名称', width: '120px', align: 'center', },
            { key: 'icon', title: '图标', width: '100px', align: 'center', },
            { key: 'order', title: '排序编号', wi");
                WriteLiteral(@"dth: '100px', align: 'center', },
            {
                title: '操作', align: 'center',
                template: function (item) {
                    return ' <a href=""javascript:void(0)"" lay-filter=""edit"">编辑</a> | <a href=""javascript:void(0)"" lay-filter=""delete"">删除</a>';
                }
            }
        ];
        let myapp = new Vue({
            el: ""#myapp"",
            data: {
                menuModalSetting:{
                    modalClickClose:false,
                },
                menuDialogTitle:"""",                           
                dialogVisible: false,
                tabledata: null, 
                menuModel: {
                    id: 0,
                    pid:0,
                    title: """",
                    icon: """",
                    controller: """",
                    action: """",
                    menuLevel: 0,
                    type: 0,
                    order:0
                },
                rules: {
                ");
                WriteLiteral(@"    title: ValidFormat.required,
                    controller: ValidFormat.required,
                }
            },
            watch: {
                tabledata: function (newval) {
                    if (newval != null && tree != null) { tree.data = newval;treeTable.render(tree);}
                },
            },
            computed: {
                selectlist: function () {
                    return MakeSelectlist(this.tabledata);
                },
            },
            methods: {
                resetData() {
                    this.menuModel = {id: 0, pid: 0, title: """", icon: """",controller: """", action: """",menuLevel: 0,type: 0, order: 0};
                },
                openAddMenu() {
                    this.menuDialogTitle = ""新增菜单"";
                    this.resetData();
                    this.dialogVisible = true;                  
                },
                openEditMenu(item) {
                    this.menuDialogTitle = ""编辑菜单"";
                  ");
                WriteLiteral(@"  this.resetData();
                    this.menuModel = item;
                    this.dialogVisible = true;
                },
                doSubmit() {
                    this.selectlist.forEach(function (item) {
                        if (item.pid == myapp.menuModel.pid) {
                            myapp.menuModel.menuLevel = item.level;
                        }
                    });
                    if (this.menuModel.id == 0) {
                        //add
                        PostPromise(MenuItemAPI, this.menuModel).then(data => {
                            if (data.status) {
                                this.dialogVisible = false;
                                this.$message({
                                    showClose: true,
                                    message: data.message,
                                    type: 'success',
                                });
                            } else {
                                this.$message.err");
                WriteLiteral(@"or(data.message);
                            }
                        });
                    } else {
                        PutPromise(MenuItemAPI, this.menuModel).then(data => {
                            if (data.status) {
                                this.dialogVisible = false;
                                this.$message({
                                    showClose: true,
                                    message: data.message,
                                    type: 'success',
                                });
                            } else {
                                this.$message.error(data.message);
                            }
                        });
                    }
                    GetPromise(AllMenuAPI).then((data) => {
                        myapp.tabledata = data;
                    });
                },
                doDelete(id) {
                    DeletePromise(MenuItemAPI, { id: id }).then(data => {
                     ");
                WriteLiteral(@"   if (data.status) {
                            this.$message({
                                showClose: true,
                                message: data.message,
                                type: 'success',
                            });
                        } else {
                            this.$message.error(data.message);
                        }
                    });
                    GetPromise(AllMenuAPI).then((data) => {
                        myapp.tabledata = data;
                    });
                },
            },
            beforeMount: function () {
                GetPromise(AllMenuAPI).then((data) => {
                    myapp.tabledata = data;
                    layui.use('treeTable', function () {
                        treeTable = layui.treeTable;
                        tree = treeTable.render({
                            elem: ""#menulist"",
                            data: data,
                            icon_key: 'menuLevel',
");
                WriteLiteral(@"                            cols: mycol
                        });
                        treeTable.on('tree(delete)', function (data) {
                            myconfirm(""确定要删除 项目标题:"" + data.item.title + "" 吗?"", function () {
                                myapp.doDelete(data.item.id);
                            });
                        });
                        treeTable.on('tree(edit)', function (data) {
                            myapp.openEditMenu(data.item);
                            console.log(data.item);
                        });
                    });
                });

            },
            mounted: function () {

            },
        });
    </script>

");
            }
            );
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