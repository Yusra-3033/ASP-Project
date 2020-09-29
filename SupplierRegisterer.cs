using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogic.ViewModels;
using DataAccessLayer;
using Models;

namespace BusinessLogic
{
    public interface ISupplierRegisterer
    {
        RegisterCustomerResult RegisterSupplier(SupplierRegisterViewModel supplierViewModel);
    }

    class SupplierRegisterer : ISupplierRegisterer
    {
        private IRepository<string, Supplier> _supplierRepository;

        public SupplierRegisterer(IRepository<string, Supplier> supplierRepository)
        {
            _supplierRepository = supplierRepository;
        }

        public RegisterCustomerResult RegisterSupplier(SupplierRegisterViewModel supplierViewModel)
        {
            var supplierModel = new Supplier
            {
                Email = supplierViewModel.Email,
                SupplierPhone = supplierViewModel.Phone,
                StoreName = supplierViewModel.StoreName,
                SupplierName = supplierViewModel.Name,
            };
            var addedSupplier= _supplierRepository.Add(supplierModel);
            _supplierRepository.SaveChanges();

            if (addedSupplier.Id == null)
            {
                return RegisterCustomerResult.NotRegistered;
            }

            return RegisterCustomerResult.OK;
        }
    }
}
