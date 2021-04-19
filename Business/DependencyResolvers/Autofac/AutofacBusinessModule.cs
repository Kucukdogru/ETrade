using Autofac;
using Autofac.Extras.DynamicProxy;

using Business.CCS;

using Castle.DynamicProxy;
using Core.Utilities.Interceptors;
using Core.Utilities.Security.JWT;

using DataAccess.Concrete.EntityFramework;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using Business.Abstract;
using Business.Concrete;
using DataAccess.Abstract;

namespace Business.DependencyResolvers.Autofac
{
    public class AutofacBusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            // IoC Container
            builder.RegisterType<EfProductDal>().As<IProductDal>();
            builder.RegisterType<ProductManager>().As<IProductService>();

            builder.RegisterType<EfBasketDal>().As<IBasketDal>();
            builder.RegisterType<BasketManager>().As<IBasketService>();

            builder.RegisterType<JwtHelper>().As<ITokenHelper>();

            var assembly = System.Reflection.Assembly.GetExecutingAssembly();

            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
                .EnableInterfaceInterceptors(new ProxyGenerationOptions()
                {
                    Selector = new AspectInterceptorSelector()
                }).SingleInstance();


        }
    }
}
