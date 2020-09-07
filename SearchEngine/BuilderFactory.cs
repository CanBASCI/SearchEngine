using Autofac;
using SearchEngine.Business.Impl;
using SearchEngine.Business.Interface;
using SearchEngine.DataAccess.EntityFramework.Base;
using SearchEngine.DataAccess.Interface;

namespace SearchEngine.Builder
{
    public class BuilderFactory : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ProductService>().As<IProductService>();
            builder.RegisterType<EntityFrameworkProductDataAccess>().As<IProductDataAccess>();

            builder.RegisterType<ProductTypePriorityService>().As<IProductTypePriorityService>();
            builder.RegisterType<EntityFrameworkProductTypePriorityDataAccess>().As<IProductTypePriorityDataAccess>();
        }
    }
}
