<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Personal_cabinet.aspx.cs" Inherits="MUAI_personal_cabinet.Personal_cabinet" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Mobile User Account Interface</title>
    <style type="text/css">
        bgsound {
        }
        .auto-style2 {
            height: 27px;
        }
        .auto-style3 {
            margin-top: 0px;
        }
        .auto-style4 {
            font-weight: bold;
            color: white;
        }
        .auto-style5 {
            color: red;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server" class="auto-style2">
    <div>
    

        <p>
            Личный кабинет</p>
    

    </div>
        <p>
            &nbsp;</p>
        <asp:Login ID="Login1" runat="server" BackColor="#F7F6F3" BorderColor="#E6E2D8" BorderPadding="4" BorderStyle="Solid" BorderWidth="1px" CssClass="auto-style3" Font-Names="Verdana" Font-Size="0.8em" ForeColor="#333333" Height="133px" OnAuthenticate="Login1_Authenticate" Width="226px">
            <InstructionTextStyle Font-Italic="True" ForeColor="Black" />
            <LayoutTemplate>
                <table cellpadding="4" cellspacing="0" style="border-collapse:collapse;">
                    <tr>
                        <td>
                            <table cellpadding="0" style="height:133px;width:226px;">
                                <tr>
                                    <td align="center" class="auto-style4" colspan="2" style="background-color:#5D7B9D;">Вход в личный кабинет</td>
                                </tr>
                                <tr>
                                    <td align="right">Логин</td>
                                    <td>
                                        <asp:TextBox ID="UserName" runat="server" Font-Size="0.8em"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="UserNameRequired" runat="server" ControlToValidate="UserName" ErrorMessage="User Name is required." ToolTip="User Name is required." ValidationGroup="Login1">*</asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right">Пароль</td>
                                    <td>
                                        <asp:TextBox ID="Password" runat="server" Font-Size="0.8em" TextMode="Password"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="PasswordRequired" runat="server" ControlToValidate="Password" ErrorMessage="Password is required." ToolTip="Password is required." ValidationGroup="Login1">*</asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        <asp:CheckBox ID="RememberMe" runat="server" Text="Запомнить меня" />
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center" class="auto-style5" colspan="2">&quot;Введите логин и пароль для входа в личный кабинет&quot;</td>
                                </tr>
                                <tr>
                                    <td align="right" colspan="2">
                                        <asp:Button ID="LoginButton" runat="server" BackColor="#FFFBFF" BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px" CommandName="Login" Font-Names="Verdana" Font-Size="0.8em" ForeColor="#284775" OnClick="LoginButton_Click" Text="Войти" ValidationGroup="Login1" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </LayoutTemplate>
            <LoginButtonStyle BackColor="#FFFBFF" BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px" Font-Names="Verdana" Font-Size="0.8em" ForeColor="#284775" />
            <TextBoxStyle Font-Size="0.8em" />
            <TitleTextStyle BackColor="#5D7B9D" Font-Bold="True" Font-Size="0.9em" ForeColor="White" />
        </asp:Login>
        <p>
            &nbsp;</p>
    </form>
</body>
</html>
