;

//Element UI From validateFormat
let ValidFormat ={
    account: [
        { required: true, message: '账号不能留空', trigger: 'blur' },
        { min: 2, max: 15, message: '长度在 2 到 15 个字符', trigger: 'blur' }
    ],
    password: [
        { required: true, message: '密码不能留空', trigger: 'blur' },
        { min: 8, max: 20, message: '长度在 8 到 20 个字符', trigger: 'blur' }
    ],
    required: [
        { required: true, message: '该项目不能为空', trigger: 'blur' },
    ],
    selectRequired: [
        { required: true, message: '请选择一个项目', trigger: 'change' }
    ],
}

//layui default function 先加载layui再使用
function myconfirm(tips, func) {
    layui.use(['layer'], function () {
        layer = layui.layer;
        layer.confirm(tips, { icon: 3, title: '确认操作?' }, function (index) {
            func();
            layer.close(index);
        });
    });
}


//pormise RestFul AJAX func
function GetPromise(url, data = null) {
    var deferred = $.Deferred();
    $.get({
        url: url,
        data: data,
        success: function (data) {
            deferred.resolve(data)
        },
        error: function (err) {
            alert("ajax出现问题");
            deferred.reject(err);
        }
    });
    return deferred;
}
function PostPromise(url, data) {
    var deferred = $.Deferred();
    $.post({
        url: url,
        data: data,
        success: function (data) {
            deferred.resolve(data)
        },
        error: function (err) {
            alert("ajax出现问题");
            deferred.reject(err);
        }
    });
    return deferred;
}
function PutPromise(url, data) {
    var deferred = $.Deferred();
    $.ajax({
        type:"PUT",
        url: url,
        data: data,
        success: function (data) {
            deferred.resolve(data)
        },
        error: function (err) {
            alert("ajax出现问题");
            deferred.reject(err);
        }
    });
    return deferred;
}
function DeletePromise(url, data) {
    var deferred = $.Deferred();
    $.ajax({
        type:"DELETE",
        url: url,
        data: data,
        success: function (data) {
            deferred.resolve(data)
        },
        error: function (err) {
            alert("ajax出现问题");
            deferred.reject(err);
        }
    });
    return deferred;
}