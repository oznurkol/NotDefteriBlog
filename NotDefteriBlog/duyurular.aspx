<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="Duyurular.aspx.cs" Inherits="NotDefteriBlog.duyurular" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    - Duyurular
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ortakisim" runat="server">
<div class="row">
    <div class="col-md-9 col-md-offset-1 bg-white main-border-4 mgb-30">
        <br />
        <asp:Repeater ID="Repeater1" runat="server">
            <ItemTemplate>
                <ul class="list-group">
                  <li class="list-group-item">
                      <h2><a href="duyurular.aspx?id=<%#Eval("duyuru_id") %>"><%#Eval("baslik") %></a></h2>
                      <span class="badge"><%#Eval("tarih") %></span>
                      <br />
                      
                  </li>
                </ul>
            </ItemTemplate>
        </asp:Repeater>
        <asp:Literal ID="Literal1" runat="server"></asp:Literal>
        <asp:Literal ID="Literal2" runat="server"></asp:Literal>
    </div>
</div>
</asp:Content>
