<%@ Page Title="" Language="C#" MasterPageFile="~/admin/admin.master" AutoEventWireup="true" CodeFile="add_product.aspx.cs" Inherits="admin_add_product" %>

<asp:Content ID="Content1" ContentPlaceHolderID="c1" runat="Server">
    <h3>Добавить товар</h3>
    <table>
        <tr>
            <td>Имя</td>
            <td>
                <asp:TextBox ID="t1" runat="server"></asp:TextBox></td>
        </tr>
        <tr>
            <td>Описание</td>
            <td>
                <asp:TextBox ID="t2" runat="server"></asp:TextBox></td>
        </tr>
        <tr>
            <td>Цена</td>
            <td>
                <asp:TextBox ID="t3" runat="server"></asp:TextBox></td>
        </tr>
        <tr>
            <td>Валюта</td>
            <td>
                <asp:TextBox ID="t4" runat="server"></asp:TextBox></td>
        </tr>
        <tr>
            <td>Количество</td>
            <td>
                <asp:TextBox ID="t5" runat="server"></asp:TextBox></td>
        </tr>
        <tr>
            <td>Фото</td>
            <td>
                <asp:FileUpload ID="f1" runat="server" /></td>
        </tr>
        <tr>
            <td>Категория</td>
            <td>
                <asp:DropDownList ID="ddl" runat="server"></asp:DropDownList></td>
        </tr>

        <tr>
            <td colspan="2" align="center">
                <asp:Button ID="b1" runat="server" Text="Upload" OnClick="b1_Click" />
            </td>
        </tr>
    </table>


</asp:Content>

