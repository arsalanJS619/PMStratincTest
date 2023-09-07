using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication13
{
    public partial class StuReg : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void CallMe(object sender, EventArgs e)
        {
            string s = Name.Value;
        }
    }
}