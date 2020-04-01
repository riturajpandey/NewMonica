using Autofac;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace MonicaLoanApp
{
    public class AppSetup
    {
        public Autofac.IContainer CreateContainer()
        {
            ContainerBuilder cb = new ContainerBuilder();

            RegisterDepenencies(cb);

            return cb.Build();
        }

        protected virtual void RegisterDepenencies(ContainerBuilder cb)
        {
            // Services
            GalaSoft.MvvmLight.Ioc.SimpleIoc.Default.Register<Providers.IApiProvider, Providers.ApiProvider>();
            //// View Models
            GalaSoft.MvvmLight.Ioc.SimpleIoc.Default.Register<BuisnessCode.IBusinessCode, MonicaLoanApp.BuisnessCode.BuisnessCode>();
        }
    }
}

