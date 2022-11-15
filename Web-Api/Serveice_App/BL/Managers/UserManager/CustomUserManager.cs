using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Managers.UserManager
{
    public class CustomUserManager : ICustomUserManager
    {
        private readonly IUserRepo _userRepo;

        public CustomUserManager(IUserRepo userRepo)
        {
            _userRepo = userRepo;
        }

        public List<CustomeUser> UserRefreshToken()
        {
            return _userRepo.UserRefreshToken();
        }
    }
}
