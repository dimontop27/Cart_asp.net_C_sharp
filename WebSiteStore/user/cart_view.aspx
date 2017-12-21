<%@ Page Title="" Language="C#" MasterPageFile="~/user/user.master" AutoEventWireup="true" CodeFile="cart_view.aspx.cs" Inherits="user_cart_view" %>

<asp:Content ID="Content1" ContentPlaceHolderID="c1" runat="Server">
    <div>
        <asp:DataList ID="d1" runat="server">
            <HeaderTemplate>
                <table border="1">
                    <tr style="background-color: slategray; color: white; font-weight: bold">
                        <td>product images</td>
                        <td>product name</td>
                        <td>product description</td>
                        <td>product price</td>
                        <td>product quantity</td>
                        <td>Удалить </td>
                    </tr>
            </HeaderTemplate>
            <ItemTemplate>
                <tr>
                    <td>
                        <img src="../<%#Eval("product_images") %>" height="100" width="100" /></td>
                    <td><%# Eval("product_name") %></td>
                    <td><%# Eval("product_description") %></td>
                    <td><%# Eval("product_price") %></td>
                    <td><%# Eval("product_quantity") %></td>
                    <td>
                        <a href="cart_delete.aspx?id=<%#Eval("id") %>">Удалить</a>
                    </td>
                </tr>
            </ItemTemplate>
            <FooterTemplate>
                </table>
            </FooterTemplate>
        </asp:DataList>
        <br />
        <p align="center">
            <asp:Label ID="l1" runat="server"></asp:Label>    <br />
            <asp:Button ID="b1" runat="server" Text="Оформить заказ" OnClick="b1_Click"  />
        </p>
    </div>
</asp:Content>

