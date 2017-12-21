<%@ Page Title="" Language="C#" MasterPageFile="~/user/user.master" AutoEventWireup="true" CodeFile="product_description.aspx.cs" Inherits="user_product_description" %>

<asp:Content ID="Content1" ContentPlaceHolderID="c1" runat="Server">


    <asp:Repeater ID="d1" runat="server">
        <HeaderTemplate>
        </HeaderTemplate>
        <ItemTemplate>
            <div style="height: 300px; width: 600px; border-style: solid; border-width: 1px">

                <div style="height: 300px; width: 200px; float: left; border-style: solid; border-width: 1px">
                    <img src="../<%#Eval("product_images") %>" height="300" width="200" alt="" />
                </div>
                <div style="height: 300px; width: 395px; float: left; border-style: solid; border-width: 1px">
                    item name =<%#Eval("product_name") %>
                    <br />
                    product description=<%# Eval("product_description") %>
                    <br />
                    product price=<%#Eval("product_price") %>
                    <br />
                    product quantity = <%#Eval("product_quantity") %>
                    <br />
                </div>

            </div>
        </ItemTemplate>
        <FooterTemplate>
        </FooterTemplate>
    </asp:Repeater>
    <br />

    <table>
        <tr>
            <td><asp:Label ID="l2" runat="server" Text="Введите количество"></asp:Label></td>
            <td>
                <asp:TextBox ID="t1" runat="server" Text="1"></asp:TextBox></td>
            <td>
                <asp:Button ID="b1" runat="server" Text="Добавить в корзину" OnClick="b1_Click" />
            </td>
        </tr>
        <tr>
            
            <td colspan="2">
                <asp:Label ID="l1" runat="server" ForeColor="Red" Text=""></asp:Label>
            </td>
        </tr>
    </table>
</asp:Content>

