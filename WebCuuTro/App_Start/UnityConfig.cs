using Application.CategoryServices;
using Application.DistrictServices;
using Application.IIdentityServices;
using Application.ProductServices;
using Application.ReceiptServices;
using Application.ReliefServices;

using Models.BaseRepository;

using System.Web.Mvc;
using Unity;
using Unity.Mvc5;

namespace WebCuuTro
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();
            container.RegisterType<IRepository, Repository>();
            container.RegisterType<IDistrictService, DistrictService>();
            container.RegisterType<IReliefService, ReliefService>();
            container.RegisterType<ICategoryService, CategoryService>();
            container.RegisterType<IProductService, ProductService>();
            container.RegisterType<IReceiptService, ReceiptService>();
            container.RegisterType<IIdentityService, IdentityService>();


            // e.g. container.RegisterType<ITestService, TestService>();

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}