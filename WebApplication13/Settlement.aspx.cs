using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace WebApplication13
{
    public partial class Settlement : System.Web.UI.Page
    {
        
        
        protected void Page_Load(object sender, EventArgs e)
        {
        //    liSettlement.Visible = true;
           
            if (!CalendarExtender1.SelectedDate.HasValue)
            {
                CalendarExtender1.StartDate = DateTime.Now;// string.Empty
            }
            //Cal11.StartDate = Cal11.SelectedDate.Value.ToString() == ""?  DateTime.Now: Cal11.SelectedDate.Value;

        }
    }
}