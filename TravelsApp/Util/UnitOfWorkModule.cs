using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TravelsApp.DAL.Interfaces;

namespace TravelsApp.Util
{
    public class UnitOfWorkModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IUnitOfWork>().To<IUnitOfWork>();
        }
    }
}