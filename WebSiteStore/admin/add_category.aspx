﻿<%@ Page Title="" Language="C#" MasterPageFile="~/admin/admin.master" AutoEventWireup="true" CodeFile="add_category.aspx.cs" Inherits="admin_add_caregory" %>

<asp:Content ID="Content1" ContentPlaceHolderID="c1" Runat="Server">
    <table>
        <tr>
            <td>
                Ввести название категории
            </td>
            <td>
                <asp:TextBox ID="t1" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                Ввести отображаемое название категории
            </td>
            <td>
                <asp:TextBox ID="t2" runat="server"></asp:TextBox>
            </td>
        </tr>
              <tr>
            <td colspan="2" align="center">
                <asp:Button ID="Button1" runat="server" Text="Добавить Категорию" OnClick="Button1_Click" />
            </td>
       
        </tr>
    </table>

    <asp:DataList ID="d1" runat="server">
        <HeaderTemplate>
            <table>
        </HeaderTemplate>

        <ItemTemplate>
            <tr>
                <td>
                    <%#Eval("product_category") %>
                </td>
                <td>
                  <a href="delete.aspx?category=<%#Eval("product_category") %>">Удалить</a>
                </td>
            </tr>
        </ItemTemplate>

       <FooterTemplate>
           </table>
       </FooterTemplate>
    </asp:DataList>

</asp:Content>
