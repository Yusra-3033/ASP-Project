using BusinessLogic.AuthorizationCheckers;
using BusinessLogic.Exceptions;
using DataAccessLayer;
using Models;
using System.Collections.Generic;

namespace BusinessLogic
{
    public interface ICustomerSupportGetter
    {
        List<CustomerSupport> GetCustomerSupports(UserViewModel user);

    }
    class CustomerSupportGetter : ICustomerSupportGetter
    {
        IRepository<string, CustomerSupport> _customerSupportRepository;
        IAuthorizationChecker<ICustomerSupportGetter, int> _checker;

        public CustomerSupportGetter(IRepository<string, CustomerSupport> customerSupportRepository, IAuthorizationChecker<ICustomerSupportGetter, int> checker)
        {
            _customerSupportRepository = customerSupportRepository;
            _checker = checker;
        }

        public List<CustomerSupport> GetCustomerSupports(UserViewModel user)
        {
            if (!_checker.IsAuthorized(user, 0))
            {
                throw new NotAuthorizedToExecuteException("the user is trying to execute a request he is not authorized to do");
            }

            return _customerSupportRepository.GetAll();
        }

    }
}
