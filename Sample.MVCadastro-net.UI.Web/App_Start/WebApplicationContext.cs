using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.Practices.Unity;
using Unity.Mvc3;

namespace Sample.MVCadastro_net.UI.Web.App_Start
{
    public class WebApplicationContext
    {
        public WebApplicationContext() { }

        public string Login { get; set; }
    }
}