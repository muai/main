using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MUAI_personal_cabinet
{
    public partial class Personal_cabinet : System.Web.UI.Page
    {
        MUAI_DBEntities4 MUAI_DBContext = new MUAI_DBEntities4();        
        protected void Page_Load(object sender, EventArgs e)
        {
        }
        protected void Login1_Authenticate(object sender, AuthenticateEventArgs e)
        {
            bool authenticated = false;
            authenticated = correctLogin(Login1.UserName, Login1.Password);
            e.Authenticated = authenticated;
            if (authenticated)
            {
                Response.Redirect("Cabinet.aspx");
            }
        }
        
        private bool correctLogin(string user, string passwd)
        {
            if (user.Equals("user1") && passwd.Equals("123"))
                return true;
            return false;
        }
        protected void LoginButton_Click(object sender, EventArgs e)
        {
        }
    }
}