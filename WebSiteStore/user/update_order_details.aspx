<%@ Page Title="" Language="C#" MasterPageFile="~/user/user.master" AutoEventWireup="true" CodeFile="update_order_details.aspx.cs" Inherits="user_update_order_details" %>

<asp:Content ID="Content1" ContentPlaceHolderID="c1" Runat="Server">
<table>
    <tr>
        <td>
            Имя
        </td>
        <td>
            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        </td>
    </tr>   
    <tr>
        <td>
            Фамилия
        </td>
        <td>
            <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
        </td>
    </tr>
     <tr>
        <td>
            Адрес
        </td>
        <td>
            <asp:TextBox ID="TextBox3" runat="server" TextMode="MultiLine"></asp:TextBox>
        </td>
    </tr>
     <tr>
        <td>
            Город
        </td>
        <td>
            <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
        </td>
    </tr>
     <tr>
        <td>
            Телефон
        </td>
        <td>
            <asp:TextBox ID="TextBox5" runat="server"></asp:TextBox>
        </td>
    </tr>
     <tr>
        <td colspan="2" align="center">
            <asp:Button ID="Button1" runat="server" Text="Обновить и продолжить" OnClick="Button1_Click" />
        </td>
        
    </tr>

</table>
</asp:Content>

