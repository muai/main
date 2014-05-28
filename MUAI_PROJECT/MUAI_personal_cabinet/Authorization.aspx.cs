using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MUAI_personal_cabinet
{
    public partial class Authorization : System.Web.UI.Page
    {
        MUAI_DBEntities5 MUAI_DBContext = new MUAI_DBEntities5();
        string clientID, clientlvl;
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
                if (Convert.ToInt32(clientlvl) == 3) Response.Redirect("Cabinet.aspx?clientID=" + clientID);
                if (Convert.ToInt32(clientlvl) == 1) Response.Redirect("AdminCabinet.aspx");
            }
            else
            {
                Response.Write("Не правильно введен логин или пароль...");
            }
        }
        
        private bool correctLogin(string user, string passwd)
        {
            string userDB = "";
            string passwdDB = "";
            var loginInfo = from q in MUAI_DBContext.пользователь
                           where q.Логин == user
                           select q;            
            foreach (пользователь validation in loginInfo)
            {
                userDB = validation.Логин;
                passwdDB = validation.Пароль;
                clientID = validation.ИД_клиента.ToString();
                clientlvl = validation.Уровень.ToString();
            }
            if (user.Equals(userDB) && passwd.Equals(passwdDB))
                return true;
            return false;
        }
        protected void LoginButton_Click(object sender, EventArgs e)
        {
        }
    }
}