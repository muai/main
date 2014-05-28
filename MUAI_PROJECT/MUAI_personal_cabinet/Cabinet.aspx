<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Cabinet.aspx.cs" Inherits="MUAI_personal_cabinet.Cabinet" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            margin-left: 255px;
            margin-top: 0px;
            margin-bottom: 0px;
            position: absolute;
            left: 150px;
            top: 120px;
            width: 189px;
        }
        .auto-style5 {
            height: 8px;
            width: 915px;
        }
        .auto-style6 {
            right: 406px;
        }
        .auto-style8 {
            text-align:center;
        }

        .auto-style10 {
            text-align: center;
            position: absolute;
            left: 700px;
            top: 177px;
            right: 321px;
        }

        .auto-style12 {
            margin-left: 255px;
            margin-top: 0px;
            margin-bottom: 0px;
            position: absolute;
            left: 150px;
            top: 120px;
            width: 189px;
            right: 460px;
        }
        .auto-style13 {
            margin-left: 255px;
            margin-top: 0px;
            margin-bottom: 0px;
            position: absolute;
            left: 470px;
            top: 120px;
            width: 189px;
            right: 445px;
        }

        .auto-style14 {
            text-align: center;
            position: absolute;
            left: 270px;
            top: 280px;
        }

        .auto-style16 {
            margin-left: 255px;
            margin-top: 0px;
            margin-bottom: 0px;
            position: absolute;
            left: 150px;
            width: 189px;
        }

        .auto-style17 {
            margin-left: 226px;
            margin-top: 42px;
        }

        </style>
    <script lang = "javascript" type = "text/javascript">
        function changeStyMOver(ctl) {
            document.getElementById(ctl).style.backgroundColor = '#CCCCFF';
        }
    </script>
    <script lang = "javascript" type = "text/javascript">
        function returnStyMOut(ctl) {
            document.getElementById(ctl).style.backgroundColor = '#FFFFFF';
        }
    </script>    
    <script lang = "javascript" type = "text/javascript">
        function CloseBrowser() 
        {
            window.close();
        }
    </script>    
</head>
<body style="height: 571px; width: 1136px; margin-right: 0px;">
    <form id="form1" runat="server">
        &nbsp;<asp:Button ID="Button11" runat="server" BackColor="#009999" Text="Выход" style="position:absolute;left:1088px; top:80px" BorderStyle="None" ForeColor="White" OnClick="logout"/>
        <asp:Label ID="Label1" runat="server" Text="Добро пожаловать в личный кабинет!" Font-Names="Verdana" style="position:absolute;left:35px;top:25px" ></asp:Label>
        &nbsp;<p class="auto-style5">            
            
            
            
        </p>
        
        <asp:Button ID="Button1" runat="server" BackColor="White" BorderStyle="None" CssClass="auto-style1" Font-Bold="False" Font-Names="Corbel" Font-Size="Large" Font-Underline="False" ForeColor="Black" Text="Просмотр данных" Width="195px" style="position:absolute;left:-18px;top:120px" OnClick="viewData"/>
        <asp:Button ID="Button2" runat="server" BackColor="White" BorderStyle="None" CssClass="auto-style1" Font-Bold="False" Font-Names="Corbel" Font-Size="Large" Font-Underline="False" ForeColor="Black" Text="Изменение личных данных" Width="220px" style="position:absolute;left:200px;top:120px" OnClick="changePersonalData"/>
        <asp:Button ID="Button3" runat="server" BackColor="White" BorderStyle="None" CssClass="auto-style13" Font-Bold="False" Font-Names="Corbel" Font-Size="Large" Font-Underline="False" ForeColor="Black" Text="Смена тарифа" Width="140px" OnClick="changePlan"/>
        <asp:Button ID="Button4" runat="server" BackColor="White" BorderStyle="None" CssClass="auto-style1" Font-Bold="False" Font-Names="Corbel" Font-Size="Large" Font-Underline="False" ForeColor="Black" Text="Подключение/отключение услуг" Width="265px" style="position:absolute;left:625px;top:120px" OnClick="changeServices"/>            
        <asp:Button ID="Button5" runat="server" BackColor="#0033CC" BorderStyle="None" CssClass="auto-style12" Font-Bold="False" Font-Names="Corbel" Font-Size="Medium" Font-Underline="False" ForeColor="White" Text="Данные договора" Width="145px" style="position:absolute;left:450px;top:170px" Visible = "false" OnClick="showContractInfo"/>            
        <asp:Button ID="Button6" runat="server" BackColor="#0033CC" BorderStyle="None" CssClass="auto-style1" Font-Bold="False" Font-Names="Corbel" Font-Size="Medium" Font-Underline="False" ForeColor="White" Text="Данные тарифа" Width="135px" Visible = "false" OnClick="showPlanInfo" style="position:absolute;left:605px;top:170px"/>            
        <asp:Button ID="Button7" runat="server" BackColor="#0033CC" BorderStyle="None" CssClass="auto-style1" Font-Bold="False" Font-Names="Corbel" Font-Size="Medium" Font-Underline="False" ForeColor="White" Text="Данные услуг" Width="125px" style="position:absolute;left:750px;top:170px" Visible = "false" OnClick="showServicesInfo"/>    
        <asp:Button ID="Button8" runat="server" BackColor="#0033CC" BorderStyle="None" CssClass="auto-style16" Font-Bold="False" Font-Names="Corbel" Font-Size="Medium" Font-Underline="False" ForeColor="White" Text="Изменить личные данные" Width="195px" style="position:absolute;left:650px;top:550px" Visible = "false" OnClick="chgPersDataToDB"/>                        
        <asp:Button ID="Button9" runat="server" BackColor="#0033CC" BorderStyle="None" CssClass="auto-style1" Font-Bold="False" Font-Names="Corbel" Font-Size="Medium" Font-Underline="False" ForeColor="White" Text="Выбрать тариф" Width="170px" style="position:absolute;left:200px;top:400px" Visible = "false" OnClick="chgPlanToDB"/>                                
        <asp:Button ID="Button10" runat="server" BackColor="#0033CC" BorderStyle="None" CssClass="auto-style1" Font-Bold="False" Font-Names="Corbel" Font-Size="Medium" Font-Underline="False" ForeColor="White" Text="Ввести изменения" Width="170px" style="position:absolute;left:200px;top:650px" Visible = "false" OnClick="chgSrvToDB"/>                                

        <asp:TextBox ID="TextBox1" runat="server" style="position:absolute;left:690px;top:212px" Font-Names="Corbel" Font-Size="11pt" Text="абонент" Visible="false" OnTextChanged="TextB1chg"></asp:TextBox>
        <asp:TextBox ID="TextBox2" runat="server" style="position:absolute;left:690px;top:253px" Font-Names="Corbel" Font-Size="11pt" Text="дата рождения" Visible="false" OnTextChanged="TextB2chg"></asp:TextBox>
        <asp:TextBox ID="TextBox3" runat="server" style="position:absolute;left:690px;top:295px" Font-Names="Corbel" Font-Size="11pt" Text="адрес" Visible="false" OnTextChanged="TextB3chg"></asp:TextBox>
        <asp:TextBox ID="TextBox4" runat="server" style="position:absolute;left:690px;top:338px" Font-Names="Corbel" Font-Size="11pt" Text="телефон" Visible="false" OnTextChanged="TextB4chg"></asp:TextBox>
        <asp:TextBox ID="TextBox5" runat="server" style="position:absolute;left:690px;top:376px" Font-Names="Corbel" Font-Size="11pt" Text="эл. почта" Visible="false" OnTextChanged="TextB5chg"></asp:TextBox>
        <asp:TextBox ID="TextBox6" runat="server" style="position:absolute;left:690px;top:415px" Font-Names="Corbel" Font-Size="11pt" Text="документ" Visible="false" OnTextChanged="TextB6chg"></asp:TextBox>
        <asp:TextBox ID="TextBox7" runat="server" style="position:absolute;left:690px;top:459px" Font-Names="Corbel" Font-Size="11pt" Text="номер документа" Visible="false" OnTextChanged="TextB7chg"></asp:TextBox>
        
        <asp:Table ID="Table1" runat="server" style="position:absolute;left:690px;top:200px" Font-Names="Corbel" Font-Size="12pt" Width="750" CellPadding="5" CellSpacing="10">
        </asp:Table>
        <asp:Table ID="Table2" runat="server" style="position:absolute;left:260px;top:200px" Font-Names="Corbel" Font-Size="12pt" Width="400" CellPadding="5" CellSpacing="10" CssClass="auto-style6">
        </asp:Table>
             
        <asp:Label ID="Label2" runat="server" Text="Данные текущего тарифа:" Visible = "False" Font-Names="Corbel" Font-Size="12pt" BackColor="#FF0066" ForeColor="White" Width= "250px" Font-Bold="True" CssClass="auto-style10"></asp:Label>
        <asp:Label ID="Label3" runat="server" Text="Выбор нового тарифа:" Visible = "False" Font-Names="Corbel" Font-Size="12pt" BackColor="#FF0066" ForeColor="White" Width= "180px" style="position:absolute;left:270px;top:177px" Font-Bold="True" CssClass="auto-style8"></asp:Label>
        <asp:Label ID="Label5" runat="server" Text="Описание:" Visible = "False" Font-Names="Corbel" Font-Size="12pt" BackColor="#FF0066" ForeColor="White" Width= "180px" Font-Bold="True" CssClass="auto-style14"></asp:Label>
        <asp:Label ID="Label4" runat="server" Text="" Visible = "False" Font-Names="Corbel" Font-Size="12pt" Width= "220px" style="position:absolute;left:270px;top:320px" ></asp:Label>
        <asp:Label ID="Label6" runat="server" Text="Описание:" Visible = "False" Font-Names="Corbel" Font-Size="12pt" BackColor="#FF0066" ForeColor="White" Width= "180px" style="position:absolute;left:270px;top:380px" Font-Bold="True" CssClass="auto-style8"></asp:Label>
        <asp:Label ID="Label7" runat="server" Text="" Visible = "False" Font-Names="Corbel" Font-Size="12pt" Width= "220px" style="position:absolute;left:270px;top:426px" ></asp:Label>

         
        <asp:DropDownList ID="DropDownList1" runat="server" Font-Names="Corbel" Font-Size="11pt" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" Visible="false" AutoPostBack="True" style="position:absolute;left:270px;top:226px">
        </asp:DropDownList>
        <asp:DropDownList ID="DropDownList2" runat="server" Font-Names="Corbel" Font-Size="11pt" OnSelectedIndexChanged="DropDownList2_SelectedIndexChanged" Visible="false" AutoPostBack="True" style="position:absolute;left:270px;top:226px">
        </asp:DropDownList>
        <asp:DropDownList ID="DropDownList3" runat="server" Font-Names="Corbel" Font-Size="11pt" OnSelectedIndexChanged="DropDownList3_SelectedIndexChanged" Visible="false" AutoPostBack="True" style="position:absolute;left:270px;top:326px">
        </asp:DropDownList> 

    </form>
    </body>
</html>

