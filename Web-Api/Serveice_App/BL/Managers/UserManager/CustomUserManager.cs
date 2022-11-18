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
        private readonly IUnitOfWork _unitOfWork;

        public CustomUserManager(IUserRepo userRepo, IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public List<CustomeUser> UserRefreshToken()
        {
            return _unitOfWork.userRepo.UserRefreshToken();
        }
    }
}
