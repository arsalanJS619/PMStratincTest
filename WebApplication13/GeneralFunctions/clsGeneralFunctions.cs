using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;

namespace WebApplication13.GeneralFunctions
{
    public class clsGeneralFunctions
    {

        public void MessageBox(string pMessage, Page pForm)
        {
            string script = "alert(\"" + pMessage + "\");";
            ScriptManager.RegisterStartupScript(pForm, GetType(), "ServerControlScript", script, true);
        }
    }
}