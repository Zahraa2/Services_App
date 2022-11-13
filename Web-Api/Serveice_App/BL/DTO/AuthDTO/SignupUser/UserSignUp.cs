using BL.DTO.AuthDTO;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class UserSignUp : SignUpBasicProperties
    {
        public string Role { get; set; }
        public UserTypes Type { get; set; }

    }
}
