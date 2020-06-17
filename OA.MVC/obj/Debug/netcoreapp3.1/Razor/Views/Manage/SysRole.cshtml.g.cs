#pragma checksum "D:\MyCode\SZCGOA.v2\OA.MVC\Views\Manage\SysRole.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "e06d3a35c723ebeaecaeaca9c289b9c844e5b6ea"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Manage_SysRole), @"mvc.1.0.view", @"/Views/Manage/SysRole.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e06d3a35c723ebeaecaeaca9c289b9c844e5b6ea", @"/Views/Manage/SysRole.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5125b050c3449e63a96ec7879e95a7e32a23da31", @"/Views/_ViewImports.cshtml")]
    public class Views_Manage_SysRole : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"
    <div class=""row"" id=""myapp"" v-cloak>

        <el-dialog :title=""roleModel.dialogTitle"" :visible.sync=""roleModel.dialogVisible""
                   width=""30%"" :close-on-click-modal=""roleModel.modalClickClose"">
            <el-form :model=""roleModel.roleData"" :rules=""rules"" ref=""roleModel.roleData"" label-width=""130px""
                     v-on:submit.native.prevent label-position=""left"">
                <el-form-item label=""角色名称"" prop=""rolename"">
                    <el-input v-model=""roleModel.roleData.rolename""></el-input>
                </el-form-item>
                <el-form-item label=""角色详细描述"" prop=""roledescript"">
                    <el-input v-model=""roleModel.roleData.roledescript""></el-input>
                </el-form-item>
                <el-form-item label=""选择权限级别"" prop=""level"">
                    <el-select v-model=""roleModel.roleData.level"" placeholder=""选择权限级别""");
            BeginWriteAttribute("class", " class=\"", 908, "\"", 916, 0);
            EndWriteAttribute();
            WriteLiteral(@">
                        <el-option value=""0"" label=""系统超级管理员""></el-option>
                        <el-option value=""1"" label=""系统管理员""></el-option>
                        <el-option value=""2"" label=""系统审核员""></el-option>
                        <el-option value=""3"" label=""未设定""></el-option>
                        <el-option value=""4"" label=""值班长""></el-option>
                        <el-option value=""5"" label=""基本权限""></el-option>

                    </el-select>
                </el-form-item>
                <el-button type=""primary"" plain v-on:click=""doSubmit"">提交</el-button>
            </el-form>
        </el-dialog>
        <el-dialog :title=""roleAccessModel.dialogTitle"" :visible.sync=""roleAccessModel.dialogVisible""
                   width=""20%"" :close-on-click-modal=""roleAccessModel.modalClickClose"">
            <el-tree :data=""roleAccessModel.treeData"" show-checkbox default-expand-all
                     node-key=""id"" ref=""tree"" highlight-current :props=""roleAccessModel.defaultProps"">
 ");
            WriteLiteral(@"           </el-tree>
            <span slot=""footer"" class=""dialog-footer"">
                <el-button v-on:click=""roleAccessModel.dialogVisible = false"">取 消</el-button>
                <el-button type=""primary"" v-on:click=""setAccess"">确 定</el-button>
            </span>
        </el-dialog>



        <div class=""col-12"">
            <div class=""card card-outline card-info"">
                <div class=""card-body"">

                    <el-button type=""primary"" class=""p-2"" v-on:click=""addRole"">新增角色</el-button>
                    <el-table :data=""roleTableData"" style=""width: 100%"">
                        <el-table-column prop=""rolename"" label=""角色名"" width=""180"">
                        </el-table-column>
                        <el-table-column prop=""roledescript"" label=""角色描述""  width=""300"">
                        </el-table-column>
                        <el-table-column prop=""level"" label=""角色权限级别"" width=""180"">
                        </el-table-column>
                        <el-table");
            WriteLiteral(@"-column fixed=""right"" label=""操作"">
                            <template slot-scope=""scope"">
                                <el-button v-on:click=""accessModal(scope.row)"" type=""primary"" plain size=""mini"">权限</el-button>
                                <el-button v-on:click=""editRole(scope.row)"" type=""primary"" plain size=""mini"">修改</el-button>
                                <el-button v-on:click=""deleteRole(scope.row)"" slot=""reference"" type=""danger"" plain size=""mini"">删除</el-button>
                            </template>
                        </el-table-column>
                    </el-table>
                </div>
            </div>
        </div>
    </div>

");
            DefineSection("TopHtml", async() => {
                WriteLiteral("\r\n");
            }
            );
            DefineSection("Scripts", async() => {
                WriteLiteral("\r\n    <script>\r\n        let AllRolesAPI = \'");
#nullable restore
#line 70 "D:\MyCode\SZCGOA.v2\OA.MVC\Views\Manage\SysRole.cshtml"
                      Write(Url.ActionLink("RoleList"));

#line default
#line hidden
#nullable disable
                WriteLiteral("\';\r\n        let RoleItemAPI = \'");
#nullable restore
#line 71 "D:\MyCode\SZCGOA.v2\OA.MVC\Views\Manage\SysRole.cshtml"
                      Write(Url.ActionLink("RoleItem"));

#line default
#line hidden
#nullable disable
                WriteLiteral("\';\r\n        let MenuListAPI = \'");
#nullable restore
#line 72 "D:\MyCode\SZCGOA.v2\OA.MVC\Views\Manage\SysRole.cshtml"
                      Write(Url.ActionLink("MenuList"));

#line default
#line hidden
#nullable disable
                WriteLiteral("\';\r\n        let RoleAccessAPI = \'");
#nullable restore
#line 73 "D:\MyCode\SZCGOA.v2\OA.MVC\Views\Manage\SysRole.cshtml"
                        Write(Url.ActionLink("RoleAccess"));

#line default
#line hidden
#nullable disable
                WriteLiteral(@"';
    </script>
    <script>
    let myapp = new Vue({
        el: ""#myapp"",
        data: {
            roleTableData: null,
            rules: {
                rolename: ValidFormat.required,
                roledescript: ValidFormat.required,
                level: ValidFormat.required,
            },
            roleModel: {
                roleData: null,
                dialogTitle: """",
                dialogVisible: false,
                modalClickClose: false,
            },
            roleAccessModel: {
                treeData: null,
                selectRole: null,
                selectKey:[],
                dialogTitle: ""未设置"",
                dialogVisible: false,
                modalClickClose: false,
                defaultProps: {
                    children: 'children',
                    label: 'label'
                }
            }
        },
        methods: {
            accessModal(row) { 
                this.roleAccessModel.dialogVisible = tru");
                WriteLiteral(@"e;
                let selectKey = [];
                this.roleAccessModel.selectRole = row;
                this.roleAccessModel.dialogTitle = row.rolename + ""-编辑权限"";
                GetPromise(RoleAccessAPI, { roleid: row.id }).then(data => {
                    if (data != null) {
                        selectKey = data.split(',');
                    }
                    this.$refs.tree.setCheckedKeys(selectKey);
                });
                
                
            },
            setAccess() {
                PutPromise(RoleAccessAPI, {
                    roleid: this.roleAccessModel.selectRole.id,
                    access: this.$refs.tree.getCheckedKeys().join("","")
                }).then(data => {
                    if (data.status) {
                        this.$message({
                            showClose: true,
                            message: data.message,
                            type: 'success',
                            duration:1000,
     ");
                WriteLiteral(@"                       onClose: elf => {
                                this.roleAccessModel.dialogVisible = false;
                            }
                        });
                    } else {
                        this.$message.error(data.message);
                    }
                });

            },
            editRole(row) {
                this.resetInput();
                this.roleModel.roleData =row
                this.roleModel.dialogTitle = ""修改角色"";
                this.roleModel.dialogVisible = true;
            },
            addRole() {
                this.resetInput();
                this.roleModel.dialogTitle = ""添加角色"";
                this.roleModel.dialogVisible = true;
            },
            deleteRole(row) {
                if (confirm('是否删除' + row.rolename)) {
                    DeletePromise(RoleItemAPI, { id:row.id }).then(data => {
                        if (data.status) {
                            this.$message({
                    ");
                WriteLiteral(@"            showClose: true,
                                message: data.message,
                                type: 'success',
                            });
                        } else {
                            this.$message.error(data.message);
                        }
                    });
                }
            },
            resetInput() {
                this.roleModel.roleData =  { id:0,level:null,roledescript:"""", rolename:"""" };
            },
            doSubmit() {
                if (this.roleModel.id == 0) {
                    //add
                    PostPromise(RoleItemAPI, this.roleModel.roleData ).then(data => {
                        if (data.status) {
                            this.dialogVisible = false;
                            this.$message({
                                showClose: true,
                                message: data.message,
                                type: 'success',
                            });
          ");
                WriteLiteral(@"              } else {
                            this.$message.error(data.message);
                        }
                    });
                } else {
                    //edit
                    PutPromise(RoleItemAPI, this.roleModel.roleData ).then(data => {
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
            },
        },
        created: function () {
            GetPromise(AllRolesAPI).then(data => {
                this.roleTableData = data;
            });
            GetPromise(MenuListAPI, {type:""tree""}).then(data => {
");
                WriteLiteral("                this.roleAccessModel.treeData = data;\r\n            });\r\n            this.resetInput();\r\n        },\r\n    });\r\n    </script>\r\n\r\n");
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
