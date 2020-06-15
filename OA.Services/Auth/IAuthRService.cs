using OA.Entitys.OaAuthDB;
using OA.Entitys.OaCoreDB;
using System;
using System.Collections.Generic;
using System.Text;

namespace OA.Services.Auth
{
    public interface IAuthRService
    {
        bool CheckPath(string path,string uid);
    }
    public class AuthRService: IAuthRService
    {
        private readonly oa_authContext _authDB;
        private readonly oa_coreContext _coredb;
        public AuthRService(oa_authContext authDB, oa_coreContext coredb)
        {
            _authDB = authDB;
            _coredb = coredb;
        }
        public bool CheckPath(string path, string uid)
        {
            throw new NotImplementedException();
        }
    }
     
}
