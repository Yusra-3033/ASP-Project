using BusinessLogic.Getters;
using BusinessLogic.ViewModels;
using CommonLibrary;
using DataAccessLayer;
using BusinessLogic.Converters;
using Unity;
using Models;
using BusinessLogic.Adders;
using BusinessLogic.Updaters;
using BusinessLogic.AuthorizationCheckers;
using BusinessLogic.Deleters;
using BusinessLogic.Validators;
using Unity.Lifetime;
using System.Collections.Generic;

namespace BusinessLogic
{
    public class BusUnityConfig : IUnityConfig
    {
        public static IUnityContainer Container { get; private set; }

        public void ConfigureUnityContainer(IUnityContainer container)
        {
            Container = container;

            Container.RegisterType<ICustomerRegisterer, CustomerRegisterer>();
            Container.RegisterType<ISupplierRegisterer, SupplierRegisterer>();
            Container.RegisterType<IOfferOrderOrgnizer, OfferOrderOrgnizer>();
            Container.RegisterType<IConverter<Models.Brunch, ApiBrunchVm>, ApiBrunchVmConverter>();
            Container.RegisterType<IConverter<Models.Brunch, BrunchDetailsViewModel>, BrunchConverter>();
            Container.RegisterType<IConverter<Models.Brunch, ApiBrunchViewModel>, ApiBrunchConverter>();
            Container.RegisterType<IConverter<Models.Type, TypeViewModel>, TypeConverter>();
            Container.RegisterType<IConverter<Models.Supplier, ApiSupplierViewModel>,ApiSupplierConverter>();
            Container.RegisterType<IConverter<(Models.Offer,float,int), ApiOfferViewModel>, ApiOfferConverter>();
            Container.RegisterType<IConverter<(Models.Offer, float, int, bool, bool), ApiOfferViewModel>, ApiOfferConverter>();
            Container.RegisterType<IConverter<Models.Supplier, ApiSupplierDetailsViewModel>, ApiSupplierDetailsConverter>();
            Container.RegisterType<IConverter<Models.Category, CategoryDetailsViewModel>, CategoryConverter>();
            container.RegisterType<IConverter<Models.Contact,ContactViewModel>,ContactConverter>();
            container.RegisterType<IConverter<AddNewContactViewModel , Models.Contact>, AddNewContactConverter>();
            container.RegisterType<IConverter<Brunch,ApiBrunchDetailsViewModel>,ApiBrunchDetailsConverter>();
            Container.RegisterType<IConverter<Models.Supplier, SupplierDetailsViewModel>, SupplierConverter>();
            Container.RegisterType<IConverter<Models.Offer, OfferViewModel>, OfferConverter>();
            Container.RegisterType<IConverter<BrunchPhoto, PhotoViewModel>, PhotoConverter>();
            Container.RegisterType<IConverter<Models.Type, AddTypeViewModel>, AddTypeViewModelConverter>();
            Container.RegisterType<IConverter<AddBrunchViewModel, Brunch>, AddBranchConverter>();
            
            Container.RegisterType<IConverter<Models.Supplier, SupplierIndexViewModel>, SupplierIndexConverter>();
            Container.RegisterType < IConverter<Models.Brunch, BrunchViewModel>, BrunchViewModelConverter>();
            Container.RegisterType < IConverter<Models.Advertisment, AdvertismentViewModel>, AdvertismentConverter>();
            Container.RegisterType<IConverter<Models.OfferPhoto,OfferPhotoViewModel>, OfferPhotoConverter>();
            Container.RegisterType<IConverter<(Offer, float, int, Category, Supplier, List<Brunch>, bool, bool), ApiOfferDetailsViewModel>, ApiOfferDetailsConverter>();

            
            Container.RegisterType<IBrunchContactViewModelAdder, BrunchContactViewModelAdder>();
            Container.RegisterType<IApiOfferDetailsViewModelGetter, ApiOfferDetailsViewModelGetter>();

            Container.RegisterType<IBrunchViewModelDeleter, BrunchViewModelDeleter>();
            Container.RegisterType<ICustomerBranchOfferViewModelAdder, CustomerBranchOfferViewModelAdder>();
            Container.RegisterType<IBrunchPhotosViewModelAdder, BrunchPhotosViewModelAdder>();
            Container.RegisterType<IBrunchOfferViewModelAdder, BrunchOfferViewModelAdder>();
            Container.RegisterType<IBrunchTypeViewModelAdder, BrunchTypeViewModelAdder>();
            Container.RegisterType<ICategoryViewModelAdder , CategoryViewModelAdder>();
            Container.RegisterType<ITypeViewModelAdder, TypeViewModelAdder>();
            Container.RegisterType<IBranchViewModelAdder, BranchViewModelAdder>();
            Container.RegisterType<IOfferPhotoViewModelAdder, OfferPhotoViewModelAdder>();
            Container.RegisterType<ICustomerBranchOfferViewModelAdder, CustomerBranchOfferViewModelAdder>();
            Container.RegisterType<IOfferPhotosViewModelGetter, OfferPhotosViewModelGetter>(); 
            Container.RegisterType<IContactViewModelGetter, ContactViewModelGetter>();
            Container.RegisterType<ISupplierWithBranchesGetter, SupplierWithBrunchesGetter>();

            Container.RegisterType<ICategoryViewModelUpdater, CategoryViewModelUpdater>();
            Container.RegisterType<ITypeViewModelUpdater, TypeViewModelUpdater>();
        
            Container.RegisterType<IOfferViewModelGetter, OfferViewModelGetter>();
            Container.RegisterType<IBrunchContactDeleter, BrunchContactDeleter>();
            Container.RegisterType<IBrunchPhotoDeleter, BrunchPhotoDeleter>();
            Container.RegisterType<IAuthorizationChecker<IOfferViewModelGetter,int>, OfferGetterChecker>();
            Container.RegisterType<IAuthorizationChecker<ICategoryViewModelGetter, int>, CategoryGetterChecker>();
            Container.RegisterType<IAuthorizationChecker<ICategoryViewModelAdder, int>, CategoryAdderChecker>();
            Container.RegisterType<IAuthorizationChecker<ICategoryViewModelUpdater, int>, CategoryUpdaterChecker>();
            Container.RegisterType<IAuthorizationChecker<IBrunchPhotosViewModelGetter, int>, BrunchPhotosGetterChecker>();
            Container.RegisterType<IAuthorizationChecker<IBrunchContactListViewModelGetter, int>, BrunchContactsGetterChecker>();
            Container.RegisterType<IAuthorizationChecker<IBrunchPhotosViewModelAdder, int>, BrunchPhotoAdderChecker>();
            Container.RegisterType<IAuthorizationChecker<IBrunchViewModelDeleter, int>, BrunchDeleterChecker>();
            Container.RegisterType<IAuthorizationChecker<IBrunchContactViewModelAdder, int>, BrunchContactAdderChecker>();
            Container.RegisterType<IAuthorizationChecker<IBrunchPhotoDeleter, int>, BrunchPhotoDeleterChecker>();
            Container.RegisterType<IAuthorizationChecker<IBrunchContactDeleter, int>, BrunchContactDeleterChecker>();
            Container.RegisterType<IAuthorizationChecker<ICategoryViewModelAdder, int>, CategoryAdderChecker>();
            Container.RegisterType<IAuthorizationChecker<ITypeViewModelAdder, int>, TypeViewModelAdderChecker>();
            Container.RegisterType<IAuthorizationChecker<ITypeViewModelGetter, int>, TypeViewModelGetterChecker>();
            Container.RegisterType<IAuthorizationChecker<ITypesByCategoryGetter, int>, TypeByCategoryGetterChecker>();
            Container.RegisterType<IAuthorizationChecker<IAddBrunchSupplierViewModelGetter, int>,AddBrunchSupplierViewModelGetterChecker>();
            Container.RegisterType<IAuthorizationChecker<IBranchViewModelAdder, int>, BrunchViewModelAdderChecker>();
            Container.RegisterType<IAuthorizationChecker<ISupplierBrunchesGetter, int>, SupplierBrunchesGetterChecker>();
            Container.RegisterType<IAuthorizationChecker<IBrunchOfferViewModelAdder, int>, BrunchOfferAdderChecker>();
            Container.RegisterType<IAuthorizationChecker<IOfferPhotoViewModelAdder, int>, OfferPhotoViewModelAdderChecker>();
            Container.RegisterType<IAuthorizationChecker<IOfferPhotosViewModelGetter, int>, OfferPhotoViewModelGetterChecker>();
            Container.RegisterType<IAuthorizationChecker<IContactViewModelGetter, int>, ContactViewModelGetterChecker>();
            Container.RegisterType<IAuthorizationChecker<ITypeViewModelUpdater, int>, TypeViewModelUpdaterChecker>();
            Container.RegisterType<IAuthorizationChecker<ISupplierViewModelUpdater, string>, SupplierViewModelUpdaterChecker>();
            Container.RegisterType<IAuthorizationChecker<ICustomerBranchOfferViewModelAdder, (int, int)>, CustomerBranchOfferAdderChecker>();
            Container.RegisterType<IAuthorizationChecker<ICustomerSupportGetter, int>, CustomerSupportGetterChecker>();
            Container.RegisterType<IAuthorizationChecker<IAdminGetter, int>, AdminGetterChecker>();
            Container.RegisterType<IAuthorizationChecker<IBranchViewModelUpdater, int>, BranchUpdaterChecker>();

            Container.RegisterType<IApiSupplierDetailsGetter, ApiSupplierDetailsGetter>();
            Container.RegisterType<IApiBrunchDetailsViewModelGetter, ApiBrunchDetailsViewModelGetter>();
            Container.RegisterType<IBrunchDetailsGetter, BrunchDetailsGetter>(); 
            Container.RegisterType<ICategoryViewModelGetter, CategoryViewModelGetter>();
            Container.RegisterType<ISupplierWithBranchesGetter, SupplierWithBrunchesGetter>();
            Container.RegisterType<IBrunchContactListViewModelGetter, BrunchContactViewModelListGetter>();
            Container.RegisterType<IBrunchPhotosViewModelGetter, BrunchPhotosViewModelGetter>();
            Container.RegisterType<IBrunchTypesViewModelGetter, BrunchTypeViewModelGetter>();
            Container.RegisterType<IBrunchOfferListViewModelGetter, BrunchOfferListViewModelGetter>();
            Container.RegisterType<IBrunchCategoryViewModelGetter, BrunchCategoryViewModelGetter>();
            Container.RegisterType<IApiBrunchViewModelGetter, ApiBrunchViewModelGetter>();
            Container.RegisterType<IApiOfferListViewModelGetter, ApiOfferListViewModelGetter>();
            Container.RegisterType<ISupplierBrunchesGetter, SupplierBrunchesGetter>();
            Container.RegisterType<ITypeViewModelGetter, TypeViewModelGetter>();
            Container.RegisterType<ITypesByCategoryGetter, TypesByCategoryGetter>();
            Container.RegisterType<IAddBrunchSupplierViewModelGetter, AddBrunchSupplierViewModelGetter>();
            Container.RegisterType<ICustomerSupportGetter, CustomerSupportGetter>();
            Container.RegisterType<ISupplierViewModelUpdater, SupplierViewModelUpdater>();
            Container.RegisterType<IAdminGetter, AdminGetter>();
            Container.RegisterType<IBranchViewModelUpdater, BranchViewModelUpdater>();
            
            Container.RegisterType<IValidator<AddBrunchViewModel>, AddBrunchVmValidator>();
            Container.RegisterType<ISupplierIndexGetter, SupplierIndexViewModelGetter>();
            new DalUnityConfig().ConfigureUnityContainer(Container);
        }

        public static T Resolve<T>() => Container.Resolve<T>();
    }
}
