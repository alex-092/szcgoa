using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OA.MVC.Common.Base
{
    public static class ModelStateExtension
    {

        public static List<string> GetErrMsgList(this ModelStateDictionary msDictionary)
        {
            var list = new List<string>();
            if (msDictionary.IsValid) return list;
            //获取所有错误的Key
            foreach (string key in msDictionary.Keys)
            {
                var tempModelState = msDictionary[key];
                if (tempModelState.Errors.Any())
                {
                    var errorList = tempModelState.Errors.ToList();
                    foreach (var item in errorList)
                    {
                        list.Add(item.ErrorMessage);
                    }
                }
            }
            return list;
        }
        public static string GetFirstErrMsg(this ModelStateDictionary msDictionary)
        {
            if (msDictionary.IsValid || !msDictionary.Any()) return "";
            foreach (string key in msDictionary.Keys)
            {
                var tempModelState = msDictionary[key];
                if (tempModelState.Errors.Any())
                {
                    var firstOrDefault = tempModelState.Errors.FirstOrDefault();
                    if (firstOrDefault != null)
                        return firstOrDefault.ErrorMessage;
                }
            }
            return "ModelStateExtension模块未获取错误";
        }
    }
}
