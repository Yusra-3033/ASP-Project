using BusinessLogic.ViewModels;
using DataAccessLayer;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public interface ICustomerRegisterer
    {
        RegisterCustomerResult RegisterCustomer(CustomerRegisterViewModel registerCustomerViewModel);
    }

    public class CustomerRegisterer : ICustomerRegisterer
    {
        private IRepository<string, Customer> _customerRepository;

        public CustomerRegisterer(IRepository<string,Customer> customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public RegisterCustomerResult RegisterCustomer(CustomerRegisterViewModel registerCustomerViewModel)
        {
            var customerModel = new Customer()
            {
                Gender = (int)registerCustomerViewModel.Gender,
                Name = registerCustomerViewModel.Name,
                Phone = registerCustomerViewModel.Phone,
                PhotoUrl = registerCustomerViewModel.PhotoUrl,
            };

            _customerRepository.Add(customerModel);
            _customerRepository.SaveChanges();
            return RegisterCustomerResult.OK;
        }
    }
}
