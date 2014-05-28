using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;


namespace MUAI_personal_cabinet
{
    public partial class Cabinet : System.Web.UI.Page
    {        
        MUAI_DBEntities5 MUAI_DBContext = new MUAI_DBEntities5();
        bool TxtB1chg = false, TxtB2chg = false, TxtB3chg = false, TxtB4chg = false,
            TxtB5chg = false, TxtB6chg = false, TxtB7chg = false;
        static bool otk = false;
        static bool pod = false;
        static int newPlanID;
        static int newServiceID;
        int clientIDPassed = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            clientIDPassed = Convert.ToInt32(Request.QueryString["clientID"]);
            Button1.Attributes.Add("onmouseover", "javascript:changeStyMOver('Button1');");
            Button1.Attributes.Add("onmouseout", "javascript:returnStyMOut('Button1');");
            Button2.Attributes.Add("onmouseover", "javascript:changeStyMOver('Button2');");
            Button2.Attributes.Add("onmouseout", "javascript:returnStyMOut('Button2');");
            Button3.Attributes.Add("onmouseover", "javascript:changeStyMOver('Button3');");
            Button3.Attributes.Add("onmouseout", "javascript:returnStyMOut('Button3');");
            Button4.Attributes.Add("onmouseover", "javascript:changeStyMOver('Button4');");
            Button4.Attributes.Add("onmouseout", "javascript:returnStyMOut('Button4');");            
        }
        protected void viewData(object sender, EventArgs e)
        {
            hideCtrl();
            Button5.Visible = true;
            Button6.Visible = true;
            Button7.Visible = true;
            rebuildTable2();

        }        
        protected void changePersonalData(object sender, EventArgs e)
        {
            hideCtrl();
            Button8.Visible = true;
            TextBox1.Visible = true;
            TextBox2.Visible = true;
            TextBox3.Visible = true;
            TextBox4.Visible = true;
            TextBox5.Visible = true;
            TextBox6.Visible = true;
            TextBox7.Visible = true;
            rebuildTable2();
        }
        protected void changePlan(object sender, EventArgs e)
        {
            hideCtrl();
            Label2.Visible = true;
            Label3.Visible = true;
            Label2.Text = "Данные текущего тарифа:";
            Label3.Text = "Выбор нового тарифа:";
            DropDownList1.Items.Clear();
            DropDownList1.Visible = true;
            insertRow("Тариф", "Описание", "Дата подключения", "");

            var planQuery = from p in MUAI_DBContext.личный_кабинет
                            where p.ИД_клиента == clientIDPassed
                            join q in MUAI_DBContext.тариф on p.ИД_тарифа equals q.ИД_тарифа
                            select new { q.Название, q.Описание, p.Дата_тарифа };

            foreach (var temp in planQuery)
            {
                insertRow(temp.Название.ToString(), temp.Описание.ToString(),
                    temp.Дата_тарифа.ToString(), "");
            }
            var planNames = from s in MUAI_DBContext.тариф
                            select s.Название;
            foreach (var temp1 in planNames)
            {
                DropDownList1.Items.Add(temp1);
            }
        }
        protected void changeServices(object sender, EventArgs e)
        {
            hideCtrl();
            Label2.Visible = true;
            Label3.Visible = true;
            Label2.Text = "Данные подключенных услуг:";
            Label3.Text = "Выбор операции:";
            insertRow("Услуга", "Описание", "Дата подключения", "");
            int numCab = 0;
            List<int> services = new List<int>();
            var cabQuery = from j in MUAI_DBContext.личный_кабинет
                           where j.ИД_клиента == clientIDPassed
                           select j;
            foreach (личный_кабинет result1 in cabQuery)
            {
                numCab = result1.ИД_кабинета;
            }
            var perServQuery = from k in MUAI_DBContext.личн_услуги
                               where k.ИД_кабинета == numCab & k.Состояние
                               select k;
            foreach (личн_услуги result2 in perServQuery)
            {
                services.Add(result2.ИД_услуги);
            }

            foreach (int point in services)
            {
                var servQuery = from p in MUAI_DBContext.личн_услуги
                                where p.ИД_кабинета == numCab & p.ИД_услуги == point & p.Состояние
                                join q in MUAI_DBContext.услуга on p.ИД_услуги equals q.ИД_услуги
                                select new { p.Дата_услуги, q.Название, q.Описание };

                foreach (var temp in servQuery)
                {
                    insertRow(temp.Название.ToString(), temp.Описание.ToString(),
                        temp.Дата_услуги.ToString(), "");
                }
            }
            DropDownList2.Items.Clear();
            DropDownList2.Visible = true;
            DropDownList2.Items.Add(" ");
            DropDownList2.Items.Add("Отключить услугу");
            DropDownList2.Items.Add("Подключить услугу");
        }
        protected void showContractInfo(object sender, EventArgs e)
        {
            rebuildTable2();            
            insertRow("Тип договора", "Номер договора", "Дата договора", "Электронная копия");
            var contractQuery = from f in MUAI_DBContext.договор
                                where f.ИД_клиента == clientIDPassed
                                select f;
            foreach (договор result in contractQuery)
            {
                insertRow(result.Тип.ToString(), result.Номер.ToString(), 
                    result.Дата.ToString(), result.Файл.ToString());
            }            
        }
        protected void showPlanInfo(object sender, EventArgs e)
        {
            rebuildTable2();
            insertRow("Тариф", "Описание", "Дата подключения", "");
            
            var planQuery = from p in MUAI_DBContext.личный_кабинет
                            where p.ИД_клиента == clientIDPassed
                            join q in MUAI_DBContext.тариф on p.ИД_тарифа equals q.ИД_тарифа
                            select new {q.Название, q.Описание, p.Дата_тарифа};
            
            foreach (var temp in planQuery)
            {
                insertRow(temp.Название.ToString(), temp.Описание.ToString(),
                    temp.Дата_тарифа.ToString(), "");
            }
            Table2.Visible = true;
        }
        protected void showServicesInfo(object sender, EventArgs e)
        {
            rebuildTable2();
            insertRow("Услуга", "Описание", "Дата подключения", "");            
            // выбор подключенных услуг
            int numCab = 0;
            List<int> services = new List<int>();
            var cabQuery = from j in MUAI_DBContext.личный_кабинет
                           where j.ИД_клиента == clientIDPassed
                         select j;
            foreach (личный_кабинет result1 in cabQuery)
            {
                numCab = result1.ИД_кабинета;
            }
            var perServQuery = from k in MUAI_DBContext.личн_услуги
                               where k.ИД_кабинета == numCab & k.Состояние
                               select k;
            foreach (личн_услуги result2 in perServQuery)
            {
                services.Add(result2.ИД_услуги);
            }

            foreach (int point in services)
            {
                var servQuery = from p in MUAI_DBContext.личн_услуги
                               where p.ИД_кабинета == numCab & p.ИД_услуги == point & p.Состояние 
                               join q in MUAI_DBContext.услуга on p.ИД_услуги equals q.ИД_услуги
                               select new { p.Дата_услуги, q.Название, q.Описание };

                foreach (var temp in servQuery)
                {
                    insertRow(temp.Название.ToString(), temp.Описание.ToString(),
                        temp.Дата_услуги.ToString(), "");
                }
            }
        }
        protected void chgPersDataToDB(object sender, EventArgs e)
        {
             var updateQuery = from w in MUAI_DBContext.клиент
                               where w.ИД_клиента == clientIDPassed
                              select w;
             foreach (клиент result in updateQuery)
             {
                 try
                 {
                     if (TxtB1chg)
                     {
                         result.ФИО = TextBox1.Text;
                         TxtB1chg = false;
                     }
                     if (TxtB2chg)
                     {
                         result.Дата_рождения = Convert.ToDateTime(TextBox2.Text);
                         TxtB2chg = false;
                     }
                     if (TxtB3chg)
                     {
                         result.Адрес = TextBox3.Text;
                         TxtB3chg = false;
                     }
                     if (TxtB4chg)
                     {
                         result.Телефон = Convert.ToInt64(TextBox4.Text);
                         TxtB4chg = false;
                     }
                     if (TxtB5chg)
                     {
                         result.Эл_почта = TextBox5.Text;
                         TxtB5chg = false;
                     }
                     if (TxtB6chg)
                     {
                         result.Документ_тип = TextBox6.Text;
                         TxtB6chg = false;
                     }
                     if (TxtB7chg)
                     {
                         result.Документ_номер = TextBox7.Text;
                         TxtB7chg = false;
                     }
                     MUAI_DBContext.SaveChanges();
                     rebuildTable2();
                 }
                 catch (Exception exc)
                 {
                     Response.Write(exc);
                 }
             }             
        }
        protected void chgPlanToDB(object sender, EventArgs e)
        {
            Label2.Visible = true;
            var updatePlan = from y in MUAI_DBContext.личный_кабинет
                             where y.ИД_клиента == clientIDPassed
                             select y;
            foreach (личный_кабинет result in updatePlan)
            {
                try
                {
                    result.ИД_тарифа = newPlanID;
                    result.Дата_тарифа = DateTime.Now;
                    MUAI_DBContext.SaveChanges();
                }
                catch (Exception exc)
                {
                    Response.Write(exc);
                }
            }
            insertRow("Тариф", "Описание", "Дата подключения", "");
            var planQuery = from p in MUAI_DBContext.личный_кабинет
                            where p.ИД_клиента == clientIDPassed
                            join q in MUAI_DBContext.тариф on p.ИД_тарифа equals q.ИД_тарифа
                            select new { q.Название, q.Описание, p.Дата_тарифа };
            foreach (var temp in planQuery)
            {
                insertRow(temp.Название.ToString(), temp.Описание.ToString(),
                    temp.Дата_тарифа.ToString(), "");
            }
        }
        protected void chgSrvToDB(object sender, EventArgs e)
        {
            Label2.Visible = true;
            int numCab = 0;
            var updateService = from y in MUAI_DBContext.личный_кабинет
                                where y.ИД_клиента == clientIDPassed
                                select y;
            foreach (личный_кабинет result1 in updateService)
            {
                numCab = result1.ИД_кабинета;
            }
            if (otk)
            {
                var perServDown = from k in MUAI_DBContext.личн_услуги
                                  where k.ИД_кабинета == numCab & k.ИД_услуги == newServiceID
                                  select k;
                foreach (личн_услуги result in perServDown)
                {
                    try
                    {
                        result.Состояние = false;
                        MUAI_DBContext.SaveChanges();
                    }
                    catch (Exception exc)
                    {
                        Response.Write(exc);
                    }
                }
            }
            if (pod)
            {
                try
                {
                    личн_услуги newService = new личн_услуги()
                    {
                        ИД_кабинета = numCab,
                        ИД_услуги = newServiceID,
                        Состояние = true,
                        Дата_услуги = DateTime.Now
                    };
                    MUAI_DBContext.личн_услуги.Add(newService);
                    MUAI_DBContext.SaveChanges();
                }
                catch (Exception exc)
                {
                    Response.Write(exc);
                }
            }
            insertRow("Услуга", "Описание", "Дата подключения", "");
            // выбор подключенных услуг
            List<int> services = new List<int>();
            var perServQuery = from k in MUAI_DBContext.личн_услуги
                               where k.ИД_кабинета == numCab & k.Состояние
                               select k;
            foreach (личн_услуги result2 in perServQuery)
            {
                services.Add(result2.ИД_услуги);
            }
            foreach (int point in services)
            {
                var servQuery = from p in MUAI_DBContext.личн_услуги
                                where p.ИД_кабинета == numCab & p.ИД_услуги == point & p.Состояние
                                join q in MUAI_DBContext.услуга on p.ИД_услуги equals q.ИД_услуги
                                select new { p.Дата_услуги, q.Название, q.Описание };

                foreach (var temp in servQuery)
                {
                    insertRow(temp.Название.ToString(), temp.Описание.ToString(),
                        temp.Дата_услуги.ToString(), "");
                }
            }
        }
        protected void closeWindow(object sender, EventArgs e)
        {

        }                
        protected void TextB1chg(object sender, EventArgs e)
        {
            TxtB1chg = true;
        }        
        protected void TextB2chg(object sender, EventArgs e)
        {
            TxtB2chg = true;
        }
        protected void TextB3chg(object sender, EventArgs e)
        {
            TxtB3chg = true;
        }
        protected void TextB4chg(object sender, EventArgs e)
        {
            TxtB4chg = true;
        }
        protected void TextB5chg(object sender, EventArgs e)
        {
            TxtB5chg = true;
        }
        protected void TextB6chg(object sender, EventArgs e)
        {
            TxtB6chg = true;
        }
        protected void TextB7chg(object sender, EventArgs e)
        {
            TxtB7chg = true;
        }
        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Label2.Visible = false;
            Label4.Visible = true;
            Label5.Visible = true;
            Label5.Text = "Описание:";
            Button9.Visible = true;            
            var planInfo = from q in MUAI_DBContext.тариф
                            where q.Название == DropDownList1.SelectedValue
                            select q;            
            foreach (тариф opisn in planInfo)
            {
                Label4.Text = opisn.Описание;
                newPlanID = opisn.ИД_тарифа;              
            }
            //Response.Write(newPlanID);
        }
        protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
        {
            Label5.Visible = true;
            Label5.Text = "Выбор услуги:";
            DropDownList3.Items.Clear();
            DropDownList3.Visible = true;
            DropDownList3.Items.Add(" ");
            // выбор подключенных услуг
            int numCab = 0;
            List<int> services = new List<int>();
            var cabQuery = from j in MUAI_DBContext.личный_кабинет
                           where j.ИД_клиента == clientIDPassed
                         select j;
            foreach (личный_кабинет result1 in cabQuery)
            {
                numCab = result1.ИД_кабинета;
            }
            var perServQuery = from k in MUAI_DBContext.личн_услуги
                               where k.ИД_кабинета == numCab & k.Состояние
                               select k;
            foreach (личн_услуги result2 in perServQuery)
            {
                services.Add(result2.ИД_услуги);
            }            
            if (DropDownList2.SelectedValue == "Отключить услугу")
            {
                otk = true;
                pod = false;
                foreach (int point in services)
                {
                    var servQuery = from p in MUAI_DBContext.услуга
                                    where p.ИД_услуги == point
                                    select p.Название;
                    foreach (var temp in servQuery)
                    {
                        DropDownList3.Items.Add(temp.ToString());
                    }
                }
            }
            if (DropDownList2.SelectedValue == "Подключить услугу")
            {
                    //Response.Write(point.ToString());
                otk = false;
                pod = true;
                var servQuery = (from q in MUAI_DBContext.услуга
                                 select q.Название
                                 ).Except(from k in MUAI_DBContext.личн_услуги
                                          where k.ИД_кабинета == numCab & k.Состояние
                                          join l in MUAI_DBContext.услуга on k.ИД_услуги equals l.ИД_услуги
                                          select l.Название);
                foreach (var temp in servQuery)
                {
                    DropDownList3.Items.Add(temp.ToString());
                }
            }
        }
        protected void DropDownList3_SelectedIndexChanged(object sender, EventArgs e)
        {
            Button10.Visible = true;
            Label6.Visible = true;
            Label7.Visible = true;
            var serviceInfo = from q in MUAI_DBContext.услуга
                              where q.Название == DropDownList3.SelectedValue
                              select q;
            foreach (услуга opisn in serviceInfo)
            {
                Label7.Text = opisn.Описание;
                newServiceID = opisn.ИД_услуги;
            }
        }
        private void hideCtrl()
        {
            Button5.Visible = false;
            Button6.Visible = false;
            Button7.Visible = false;
            Button8.Visible = false;
            Button9.Visible = false;
            Button10.Visible = false;
            TextBox1.Visible = false;
            TextBox2.Visible = false;
            TextBox3.Visible = false;
            TextBox4.Visible = false;
            TextBox5.Visible = false;
            TextBox6.Visible = false;
            TextBox7.Visible = false;
            Label1.Visible = false;
            Label2.Visible = false;
            Label3.Visible = false;
            Label4.Visible = false;
            Label5.Visible = false;
            Label6.Visible = false;
            Label7.Visible = false;
            DropDownList1.Visible = false;
            DropDownList2.Visible = false;
            DropDownList3.Visible = false;
        }
        private void insertRow(string a, string b, string c, string d)
        {
            TableRow row = new TableRow();
            TableCell cell1 = new TableCell();
            TableCell cell2 = new TableCell();
            TableCell cell3 = new TableCell();
            TableCell cell4 = new TableCell();
            cell1.Text = a;
            row.Cells.Add(cell1);
            cell2.Text = b;
            row.Cells.Add(cell2);
            cell3.Text = c;
            row.Cells.Add(cell3);
            cell4.Text = d;
            row.Cells.Add(cell4);
            Table1.Rows.Add(row);
        }
        private void rebuildTable2()
        {
            string[] text = { "абонент", "дата рождения:", "адрес:", 
                                "телефон:", "эл. почта:", "документ", "номер документа:"};

            List<string> text1 = new List<string>();
            var clientQuery = from d in MUAI_DBContext.клиент
                              where d.ИД_клиента == clientIDPassed
                              select d;
            foreach (клиент result in clientQuery)
            {
                text1.Add(result.ФИО.ToString());
                text1.Add(result.Дата_рождения.ToString());
                text1.Add(result.Адрес.ToString());
                text1.Add(result.Телефон.ToString());
                text1.Add(result.Эл_почта.ToString());
                text1.Add(result.Документ_тип.ToString());
                text1.Add(result.Документ_номер.ToString());
            }
            for (int i = 0; i <= 6; i++)
            {
                TableRow row = new TableRow();
                TableCell cell1 = new TableCell();
                TableCell cell2 = new TableCell();
                row.Cells.Add(cell1);
                row.Cells.Add(cell2);
                cell1.Text = text[i];
                cell2.Text = text1[i];
                Table2.Rows.Add(row);
            }
        }

        protected void logout(object sender, EventArgs e)
        {
            Response.Redirect("Authorization.aspx");
        }
        

        
    }
}