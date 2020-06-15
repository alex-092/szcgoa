using OA.Entitys.OaCoreDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OA.MVC.Models
{
    public class SysRoleViewModel
    {
        public static List<MenuTopModel> MakeMenuTreeData(List<SysMenu> list)
        {
            if (list == null)
                return null;
            var result = new List<MenuTopModel>();
            //第一层
            foreach (var item in list)
            {
                if (item.MenuLevel == 0)
                {
                    result.Add(new MenuTopModel { Id=item.Id,Label=item.Title});
                }
            }
            //第二层
            foreach (var item in list)
            {
                if (item.MenuLevel == 1)
                {
                    for (int i = 0; i < result.Count; i++)
                    {
                        if (result[i].Id == item.Pid)
                        {
                            result[i].Children.Add(new MenuSubModel { Id = item.Id, Label = item.Title });
                        }
                    }
                }
            }
            //第三层
            foreach (var item in list)
            {
                if (item.MenuLevel == 2)
                {
                    for (int i = 0; i < result.Count; i++)
                    {
                        for (int j = 0; j < result[i].Children.Count; j++)
                        {
                            if (item.Pid == result[i].Children[j].Id)
                            {
                                result[i].Children[j].Children.Add(new MenuActionModel { Id = item.Id, Label = item.Title });
                            }
                        }
                    }
                }
            }
            return result;
        }
    }
    public class SysRoleInputModel
    {
        public string Rolename { get; set; }
        public string Roledescript { get; set; }
        public sbyte? Level { get; set; }
    }
    public class MenuTopModel
    {
        public MenuTopModel()
        {
            Children = new List<MenuSubModel>();
        }
        public int Id { get; set; }
        public string Label { get; set; }
        public List<MenuSubModel> Children { get; set; }

    }
    public class MenuSubModel
    {
        public MenuSubModel()
        {
            Children = new List<MenuActionModel>();
        }
        public int Id { get; set; }
        public string Label { get; set; }
        public List<MenuActionModel> Children { get; set; }
    }
    public class MenuActionModel
    {
        public int Id { get; set; }
        public string Label { get; set; }
    }

}
