using BusinessLogic.AuthorizationCheckers;
using BusinessLogic.Exceptions;
using DataAccessLayer;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public interface IAdminGetter
    {
        List<Admin> GetAdmins(UserViewModel user);
    }
    class AdminGetter : IAdminGetter
    {
        IRepository<string, Admin> _adminRepository;
        IAuthorizationChecker<IAdminGetter, int> _checker;

        public AdminGetter(IRepository<string, Admin> adminRepository , IAuthorizationChecker<IAdminGetter, int> checker)
        {
            _adminRepository = adminRepository;
            _checker = checker;
        }

        public List<Admin> GetAdmins(UserViewModel user)
        {
            if (!_checker.IsAuthorized(user, 0))
            {
                throw new NotAuthorizedToExecuteException("the user is trying to execute a request he is not authorized to do");
            }

            return _adminRepository.GetAll();
        }
    }
}
