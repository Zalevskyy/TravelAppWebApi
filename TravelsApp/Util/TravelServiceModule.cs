using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TravelsApp.BLL.Interfaces;
using TravelsApp.BLL.Services;

namespace TravelsApp.Util
{
    public class TravelServiceModule : NinjectModule
    {
        public override void Load()
        {
            Bind<ITravelService>().To<TravelService>();
        }
    }
}