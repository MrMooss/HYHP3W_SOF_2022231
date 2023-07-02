using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Kliens.ViewModel
{
    public class UserInfo
    {
        public string Id { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string PhotoUrl { get; set; }
        public List<string> Roles { get; set; }
    }
}
