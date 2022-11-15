using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class RefreshToken
    {
        public Guid Id { get; set; }
        public string Token { get; set; }
        public DateTime CreationOn { get; set; }
        public DateTime ExpirationOn { get; set; }
        public DateTime? RevokedOn { get; set; }
        public bool IsExpired => DateTime.Now >= ExpirationOn;
        public bool IsActive => RevokedOn == null && !IsExpired;
        [ForeignKey("user")]
        public string UserId { get; set; }
        public CustomeUser user { get; set; }

    }
}
