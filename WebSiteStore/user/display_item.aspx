<%@ Page Title="" Language="C#" MasterPageFile="~/user/user.master" AutoEventWireup="true" CodeFile="display_item.aspx.cs" Inherits="user_display_item" %>

<asp:Content ID="Content1" ContentPlaceHolderID="c1" runat="Server">
    <asp:Repeater ID="d1" runat="server">
        <HeaderTemplate>
            <ul>
        </HeaderTemplate>
        <ItemTemplate>
            <li class="last">
                <a href="product_description.aspx?id=<%#Eval("id") %>">
                    <img src="../<%#Eval("product_images") %>" alt="" /></a>
                <div class="product-info">
                    <h3><%#Eval("product_name") %></h3>
                    <div class="product-desc">
                        <h4> Доступно<%#Eval("product_quantity") %></h4>
                        <p><%#Eval("product_description") %>
                        </p>
                        <strong class="price"><%#Eval("product_price") %></strong>
                    </div>
                </div>
            </li>
        </ItemTemplate>
        <FooterTemplate>
            </ul>
        </FooterTemplate>
    </asp:Repeater>
</asp:Content>

