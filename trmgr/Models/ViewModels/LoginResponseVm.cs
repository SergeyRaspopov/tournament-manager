using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using trmgr.Models.DatabaseModels;

namespace trmgr.Models.ViewModels
{
    public class LoginResponseVm
    {
        public string AccessToken { get; set; }
        public long ExpiresIn { get; set; }
        public UserVm User { get; set; }
    }
}
