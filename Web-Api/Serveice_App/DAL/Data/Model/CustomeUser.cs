using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL;
public enum UserTypes
{
    Customer = 0,
    Provider = 1
}
public class CustomeUser: IdentityUser 
{
    public UserTypes Type { get; set; }

    public string Fname { get; set; }
    public string Lname { get; set; }
    public string City { get; set; }
    public Customer? customer { get; set; } = null!;

    public Provider? provider { get; set; } = null!;
    public ICollection<RefreshToken> RefreshTokens { get; set; } = new HashSet<RefreshToken>();

}
