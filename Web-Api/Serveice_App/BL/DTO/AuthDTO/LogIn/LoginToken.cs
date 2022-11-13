using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BL
{
    public class LoginToken
    {
        public string Token { get; set; }
        public DateTime ExpirOn { get; set; }
        [JsonIgnore]
        public string RefreshToken { get; set; }
        [JsonIgnore]
        public DateTime RefershTokenExpirOn { get; set; }
        public string Message { get; set; }
    }
}
