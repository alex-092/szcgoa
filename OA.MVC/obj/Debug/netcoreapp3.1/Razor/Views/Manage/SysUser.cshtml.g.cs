#pragma checksum "D:\MyCode\SZCGOA.v2\OA.MVC\Views\Manage\SysUser.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "aeddd9843f7e05680f9fa438f81419959898b5fd"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Manage_SysUser), @"mvc.1.0.view", @"/Views/Manage/SysUser.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"aeddd9843f7e05680f9fa438f81419959898b5fd", @"/Views/Manage/SysUser.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5125b050c3449e63a96ec7879e95a7e32a23da31", @"/Views/_ViewImports.cshtml")]
    public class Views_Manage_SysUser : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/lib/layui/css/layui.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("rel", new global::Microsoft.AspNetCore.Html.HtmlString("stylesheet"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/lib/layui/layui.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/js/Manage/sysuser.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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

        <el-dialog :title=""RoleModal.dialogTitle"" :visible.sync=""RoleModal.visable"" width=""70%"" :close-on-click-modal=""RoleModal.modalClickClose"">
            <div class=""row"">
                <div class=""card card-outline card-danger col-6 "">
                    <div class=""card-title"">未设定的角色</div>
                    <div class=""card-body p-0"">
                        <el-table  :data=""UserRoleModel.roleExData"" style=""width: 100%"">
                            <el-table-column prop=""rolename"" label=""角色名称"" width=""120"">
                            </el-table-column>
                            <el-table-column prop=""roledescript"" label=""描述"" width=""180"">
                            </el-table-column>
                            <el-table-column prop=""level"" label=""级别"" width=""70"" >
                            </el-table-column>
                            <el-table-column fixed=""right"" label=""操作"">
                                <template slot-scope=""sco");
            WriteLiteral(@"pe"">
                                    <el-button v-on:click=""editRole(scope.row)"" type=""text"" size=""mini"">增加该角色</el-button>
                                </template>
                            </el-table-column>
                        </el-table>
                    </div>
                </div>
                <div class=""card card-outline card-primary col-6 "">
                    <div class=""card-title"">已拥有的角色</div>
                    <div class=""card-body p-0"">
                        <el-table  :data=""UserRoleModel.roleInData"" style=""width: 100%"">
                            <el-table-column prop=""rolename"" label=""角色名称"" width=""120"">
                            </el-table-column>
                            <el-table-column prop=""roledescript"" label=""描述"" width=""180"">
                            </el-table-column>
                            <el-table-column prop=""level"" label=""级别"" width=""70"">
                            </el-table-column>
                            <el-table-colum");
            WriteLiteral(@"n fixed=""right"" label=""操作"">
                                <template slot-scope=""scope"">
                                    <el-button v-on:click=""editRole(scope.row)"" type=""text"" size=""mini"">删除该角色</el-button>
                                </template>
                            </el-table-column>
                        </el-table>
                    </div>
                </div>
            </div>
            <span slot=""footer"" class=""dialog-footer"">
                <el-button v-on:click=""RoleModal.visable = false"">取 消</el-button>
                <el-button type=""primary"" v-on:click=""RoleModal.visable = false"">确 定</el-button>
            </span>
        </el-dialog>

        


        <div class=""col-12"">
            <div class=""card card-outline card-info"">
                <div class=""card-body"">
                    <el-table :data=""userTableData"" style=""width: 100%"">
                        <el-table-column prop=""displayName"" label=""姓名"" width=""180"">
                        </");
            WriteLiteral(@"el-table-column>
                        <el-table-column prop=""account"" label=""账号"" width=""180"">
                        </el-table-column>
                        <el-table-column prop=""phone"" label=""电话"">
                        </el-table-column>
                        <el-table-column prop=""email"" label=""邮件"">
                        </el-table-column>
                        <el-table-column prop=""lockType"" label=""锁定"">
                        </el-table-column>
                        <el-table-column prop=""createTime"" label=""创建时间"">
                        </el-table-column>
                        <el-table-column fixed=""right"" label=""操作"" width=""150"">
                            <template slot-scope=""scope"">
                                <el-button v-on:click=""setRolesBtn(scope.row)"" type=""text"" size=""mini"">设定角色</el-button>
                                <el-button v-on:click=""handleClick(scope.row)"" type=""text"" size=""mini"">查看</el-button>
                                <el-button type=");
            WriteLiteral("\"text\" size=\"mini\">编辑</el-button>\r\n                            </template>\r\n                        </el-table-column>\r\n                    </el-table>\r\n                </div>\r\n            </div>\r\n        </div>\r\n    </div>\r\n");
            DefineSection("CSS", async() => {
                WriteLiteral("\r\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "aeddd9843f7e05680f9fa438f81419959898b5fd9497", async() => {
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
            DefineSection("TopHtml", async() => {
                WriteLiteral("\r\n");
            }
            );
            DefineSection("Scripts", async() => {
                WriteLiteral("\r\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "aeddd9843f7e05680f9fa438f81419959898b5fd10917", async() => {
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
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "aeddd9843f7e05680f9fa438f81419959898b5fd12017", async() => {
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
                WriteLiteral("\r\n    <script>\r\n        let AllUsersAPI = \'");
#nullable restore
#line 89 "D:\MyCode\SZCGOA.v2\OA.MVC\Views\Manage\SysUser.cshtml"
                      Write(Url.ActionLink("UserList"));

#line default
#line hidden
#nullable disable
                WriteLiteral("\';\r\n        let UserItemAPI = \'");
#nullable restore
#line 90 "D:\MyCode\SZCGOA.v2\OA.MVC\Views\Manage\SysUser.cshtml"
                      Write(Url.ActionLink("UserItem"));

#line default
#line hidden
#nullable disable
                WriteLiteral("\';\r\n        let UserRolesAPI = \'");
#nullable restore
#line 91 "D:\MyCode\SZCGOA.v2\OA.MVC\Views\Manage\SysUser.cshtml"
                       Write(Url.ActionLink("UserRoles"));

#line default
#line hidden
#nullable disable
                WriteLiteral("\';\r\n        let RoleListAPI = \'");
#nullable restore
#line 92 "D:\MyCode\SZCGOA.v2\OA.MVC\Views\Manage\SysUser.cshtml"
                      Write(Url.ActionLink("RoleList"));

#line default
#line hidden
#nullable disable
                WriteLiteral(@"';
    </script>
    <script>
        let myapp = new Vue({
            el: ""#myapp"",
            data: {
                userTableData: null,    
                rolesList:null,
                RoleModal: {
                    modalClickClose: false,
                    dialogTitle: ""未取值"",
                    visable: false
                },
                UserRoleModel: {
                    selectUser: null,
                    roleInData: null,
                    roleExData:null
                },
            },
            methods: {
                setRolesBtn(row) {
                    this.RoleModal.visable = true;
                    this.RoleModal.dialogTitle = ""设定角色-用户：""+row.displayName;
                    this.refreshRolesModel(row);
                },
                editRole(row) {
                    PutPromise(UserRolesAPI, { uid: this.UserRoleModel.selectUser.uid, roleid: row.id }).then(data => {
                        this.$message(data.message);
            ");
                WriteLiteral(@"            this.refreshRolesModel(this.UserRoleModel.selectUser);                       
                    });
                },
                handleClick(row) {
                    this.RoleModal.visable = true;
                    this.refreshRolesModel(row);
                    console.log(row);
                },
                refreshRolesModel(user) {
                    this.UserRoleModel.selectUser = user;
                    GetPromise(UserRolesAPI, {uid:user.uid}).then(data => {
                        this.UserRoleModel.roleInData = data;
                        if (this.rolesList != null) {
                            this.UserRoleModel.roleExData = GetExclude(this.rolesList, data);
                        }
                    });

                }
            },
            created: function () {
                GetPromise(AllUsersAPI).then(data => {
                    this.userTableData = data;
                });
                GetPromise(RoleListAPI).then(data");
                WriteLiteral(@" => {
                    this.rolesList = data;
                });
                
            },
            mounted: function () {
                
                //this.RoleModal.visable = false;
                
            }
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
