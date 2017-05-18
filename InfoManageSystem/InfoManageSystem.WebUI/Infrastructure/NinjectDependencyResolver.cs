using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Moq;
using Ninject;
using System.Web.Mvc;
using InfoManageSystem.Domain.Abstract;
using InfoManageSystem.Domain.Entities;
using InfoManageSystem.Domain.Concrete;

namespace InfoManageSystem.WebUI.Infrastructure
{
    public class NinjectDependencyResolver : IDependencyResolver
    {
        private IKernel kernel;
        public NinjectDependencyResolver(IKernel kernelParam)
        {
            kernel = kernelParam;
            AddBindings();
        }
        object IDependencyResolver.GetService(Type serviceType)
        {
            return kernel.TryGet(serviceType);
        }

        IEnumerable<object> IDependencyResolver.GetServices(Type serviceType)
        {
            return kernel.GetAll(serviceType);
        }

        private void AddBindings()
        {
            /*       Mock<IProductsRepository> mock = new Mock<IProductsRepository>();
                   mock.Setup(m => m.Products).Returns(new List<Product>
                   {
                       new Product {Name = "Football",Price=25 }
                   });
                   kernel.Bind<IProductsRepository>().ToConstant(mock.Object);
                   */
            kernel.Bind<IProductsRepository>().To<EFReproductRepository>();
        }
    }
}