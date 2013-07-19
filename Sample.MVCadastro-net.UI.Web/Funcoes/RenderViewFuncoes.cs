using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.Mvc;
using System.Text;

namespace Sample.MVCadastro_net.UI.Web.Funcoes
{
    public class RenderViewFuncoes
    {
        public static string RenderPartialToString(string controlName, object viewData)
        {
            ViewDataDictionary vd = new ViewDataDictionary(viewData);
            ViewPage vp = new ViewPage { ViewData = vd };
            Control control = vp.LoadControl(controlName);

            vp.Controls.Add(control);

            StringBuilder sb = new StringBuilder();
            using (StringWriter sw = new StringWriter(sb))
            {
                using (HtmlTextWriter tw = new HtmlTextWriter(sw))
                {
                    vp.RenderControl(tw);
                }
            }

            return sb.ToString();
        }
    }
}