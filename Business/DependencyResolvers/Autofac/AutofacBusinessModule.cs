using Autofac;
using Autofac.Extras.DynamicProxy;
using Business.Abstract;
using Business.CCS;
using Business.Concrete;
using Castle.DynamicProxy;
using Core.Utilities.Interceptors;
using DataAccess.Abstract;
using DataAccess.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DependencyResolvers.AutoFac
{
    public class AutofacBusinessModule:Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ItemManager>().As<IItemService>().SingleInstance();
            builder.RegisterType<ItemRepository>().As<IItem>().SingleInstance();
            builder.RegisterType<CategoryManager>().As<ICategoryService>().SingleInstance();
            builder.RegisterType<CategoryRepository>().As<ICategory>().SingleInstance();
            builder.RegisterType<CustomerManager>().As<ICustomerService>().SingleInstance();
            builder.RegisterType<CustomerRepository>().As<ICustomer>().SingleInstance();
            builder.RegisterType<OrderManager>().As<IOrderService>().SingleInstance();
            builder.RegisterType<OrderRepository>().As<IOrder>().SingleInstance();
            builder.RegisterType<OrderStateManager>().As<IOrderStateService>().SingleInstance();
            builder.RegisterType<OrderStateRepository>().As<IOrderState>().SingleInstance();
            builder.RegisterType<OrderItemManager>().As<IOrderItemService>().SingleInstance();
            builder.RegisterType<OrderItemRepository>().As<IOrderItem>().SingleInstance();
            builder.RegisterType<FileLogger>().As<ILogger>().SingleInstance();
            var assembly = System.Reflection.Assembly.GetExecutingAssembly();

            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
                .EnableInterfaceInterceptors(new ProxyGenerationOptions()
                {
                    Selector = new AspectInterceptorSelector()
                }).SingleInstance();

        }
    }
}
