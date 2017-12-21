<%@ Page Title="" Language="C#" MasterPageFile="~/user/user.master" AutoEventWireup="true" CodeFile="display_order.aspx.cs" Inherits="user_display_order" %>

<asp:Content ID="Content1" ContentPlaceHolderID="c1" Runat="Server">
   <asp:Repeater ID="r1" runat="server">
        <HeaderTemplate>
            <table border="1">
                <tr style="background-color:grey; color:white">
                   <td>Id</td>
                    <td>Имя</td>
                    <td>Фамилия</td>
                    <td>Город</td>
                    <td>Адрес</td>
                    <td>Детально</td>
                </tr>
        </HeaderTemplate>
        <ItemTemplate>
             <tr>
                 <td><%#Eval("id") %></td>
                 <td><%#Eval("firstname") %></td>
                 <td><%#Eval("lastname") %></td>
                 <td><%#Eval("city") %></td>
                 <td><%#Eval("address") %></td>
                 <td><a href="view_full_order.aspx?id=<%#Eval("id") %>">Детально</a></td>
             </tr>
        </ItemTemplate>
        <FooterTemplate>
            </table>
        </FooterTemplate>

    </asp:Repeater>
</asp:Content>

