using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class UserRepo : IUserRepo
    {
        private readonly DatabaseContext _context;
        public UserRepo(DatabaseContext context)
        {
            _context = context;
        }

        public CustomeUser GetUserById(string Id)
        {
            return _context.customeUsers.First(a => a.Id == Id);
        }

        public List<CustomeUser> UserRefreshToken()
        {
            var RefreshTokens = _context.customeUsers.Include(r => r.RefreshTokens).ToList();
            return RefreshTokens;
        }
    }
}
