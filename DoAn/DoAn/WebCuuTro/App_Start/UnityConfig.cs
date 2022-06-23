using Application.DistrictServices;

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

            // e.g. container.RegisterType<ITestService, TestService>();

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}