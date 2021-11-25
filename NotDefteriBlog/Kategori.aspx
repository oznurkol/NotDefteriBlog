<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="Kategori.aspx.cs" Inherits="NotDefteriBlog.Kategori" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ckeditor" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="updatepanel" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ortakisim" runat="server">
        <div class="row">
    <div class="col-md-9 col-md-offset-1 bg-white main-border-4 mgb-30">
	    <h2>Kategoriler</h2>
		    <hr /><ul>
            <asp:Repeater ID="Repeater1" runat="server" OnItemDataBound="Repeater1_ItemDataBound">
                    <ItemTemplate>
                        <h3><li><%#Eval("kate_adi") %></li></h3>
                        <ul>
                        <asp:Repeater ID="Repeater2" runat="server">
                            <ItemTemplate>
                                <h4><li><a href="YaziGoruntule.aspx?id=<%#Eval("Yazi_ID")%>"><%#Eval("baslik")%></a></li></h4>
                            </ItemTemplate>
                        </asp:Repeater>
                            </ul>
                        <asp:HiddenField ID="hiddenid" runat="server" Value='<%#Eval("KID") %>' />
                    </ItemTemplate>
                </asp:Repeater>
                </ul>
			<hr />
        
		<div class="row">
		    <div class="col-md-3">
                
		    </div>
            <div class="col-md-3">

		    </div>
            <div class="col-md-3 pull-right">
                <asp:Literal ID="yazan" runat="server" ></asp:Literal>
            </div>
	    </div>
    </div>
</div>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="scriptmanager_bitis" runat="server">
</asp:Content>
