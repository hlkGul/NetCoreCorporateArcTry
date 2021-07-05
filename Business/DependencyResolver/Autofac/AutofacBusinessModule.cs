using Autofac;
using Business.Abstract;
using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DependencyResolver.Autofac
{
    public class AutofacBusinessModule:Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            //bu yapıyla aynı işlemi yapıyor _--> services.AddSingleton<IProductService,ProductManager>();
            builder.RegisterType<ProductManager>().As<IProductService>().SingleInstance();

            //services.AddSingleton<IProductDal, EfProductDal>();->> same business ->IoC of .netcore 
            builder.RegisterType<EfProductDal>().As<IProductDal>().SingleInstance();

        }
    }
}
