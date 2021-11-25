<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="YaziGoruntule.aspx.cs" Inherits="NotDefteriBlog.YaziGoruntule" EnableEventValidation="false" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ckeditor" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="updatepanel" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ortakisim" runat="server">
<div class="row">
    <div class="col-md-9 col-md-offset-1 bg-white main-border-4 mgb-30">
	    <h2><asp:Literal ID="baslik" runat="server"></asp:Literal></h2>
		    <hr />
                <asp:Literal ID="icerik" runat="server"></asp:Literal>
			<hr />
        
		<div class="row">
		    <div class="col-md-3">
                <asp:LinkButton ID="Like" runat="server" CssClass="glyphicon glyphicon-plus fontgreen" OnClick="LinkButton3_Click"></asp:LinkButton>
                <asp:LinkButton ID="Arti" runat="server" CssClass="glyphicon glyphicon-plus fontgreen" OnClick="Arti_Click"></asp:LinkButton>
                <asp:LinkButton ID="Eksi" runat="server" CssClass="glyphicon glyphicon-minus fontorange" OnClick="Eksi_Click"></asp:LinkButton>
		    </div>
            <div class="col-md-3">

		    </div>
            <div class="col-md-3 pull-right">
                <asp:Literal ID="yazan" runat="server" ></asp:Literal>
            </div>
	    </div>
    </div>
    <div class="col-md-9 col-md-offset-1 bg-white main-border-4 mgb-30">
        <br />
        <asp:Repeater ID="Repeater1" runat="server">
            <ItemTemplate>
                <ul class="list-group">
                  <li class="list-group-item">
                    <span class="badge"><%#Eval("tarih") %></span>
                      <%if(aktif){ %>
                      <asp:Button ID="btnSil" runat="server" Text="Sil" CssClass="btn btn-danger btn-xs" OnClick="yorum_sil" CommandArgument = '<%# Eval("yorumid") %>' />
                      <%} %>
                      <%#Eval("yorum_icerik") %>
                      <span class="badge"><%#Eval("yazar") %></span>
                      <br />
                      
                  </li>
                </ul>
            </ItemTemplate>
        </asp:Repeater>
    </div>
    <div class="col-md-9 col-md-offset-1 bg-white main-border-4 mgb-30" id="yorumkayit" runat="server">
	    <h2>Yeni Bir Yorum Yaz</h2>
		    <hr />
        <div class="row" id="yorumyaz">
            <asp:Literal ID="Literal1" runat="server"></asp:Literal>
            <div class="col-md-4">
                <div class="form-group">
                    <asp:Label ID="ad" runat="server" Text="Ad Soyad:"></asp:Label><br />
                    <asp:TextBox ID="adsoyad" runat="server" CssClass="form-control"></asp:TextBox>
                    <br /><asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="3-75 karakter arası olabilir ve sadece harf içerebilir!" ValidationExpression = "^[a-zA-Z''-'\s]{1,50}$" ControlToValidate="adsoyad" CssClass="alert alert-danger" Display="Dynamic" SetFocusOnError="True"></asp:RegularExpressionValidator>
                </div>
            </div>
            <div class="col-md-4">
                <div class="form-group">
                    <asp:Label ID="eposta" runat="server" Text="E-Posta:"></asp:Label><br />
                    <asp:TextBox ID="email" runat="server" CssClass="form-control"></asp:TextBox>
                    <br /><asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ErrorMessage="3-75 karakter arası olabilir!" ControlToValidate="email" CssClass="alert alert-danger" Display="Dynamic" SetFocusOnError="True" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                </div>
            </div>
            <div class="col-md-4">
                <div class="form-group">
                    <asp:Label ID="web" runat="server" Text="Web Site:"></asp:Label><br />
                    <asp:TextBox ID="webpage" runat="server" CssClass="form-control"></asp:TextBox>
                    <br /><asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ErrorMessage="Maximum 75 karakter arası olabilir!" ValidationExpression = "http(s)?://([\w-]+\.)+[\w-]+(/[\w- ./?%&amp;=]*)?" ControlToValidate="webpage" CssClass="alert alert-danger" Display="Dynamic" SetFocusOnError="True"></asp:RegularExpressionValidator>
                </div>
            </div>
            <div class="col-md-12">
                <div class="form-group">
                    <asp:Label ID="ic" runat="server" Text="Yorum:"></asp:Label><br />
                    <asp:TextBox ID="yorum" runat="server" CssClass="form-control" TextMode="MultiLine" Columns="5"></asp:TextBox>
                    <br /><asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ErrorMessage="3-500 karakter arası olabilir!" ValidationExpression = "^[\s\S]{3,500}$" ControlToValidate="yorum" CssClass="alert alert-danger" Display="Dynamic" SetFocusOnError="True"></asp:RegularExpressionValidator>
                </div>
            </div>
			<hr />
        <div class="col-md-12">
          <asp:Button ID="gonder" runat="server" Text="Yorumunu Gönder" CssClass="btn btn-primary pull-right" OnClick="gonder_Click" />
            <br />
        </div>
    </div>
    </div>

</div>
    <script>
        function yorumgizle() {
            $("#yorumyaz").hide();
        }
        function silme(i) {
          $("#span" + i).hide(100);
          $("#ortakisim_" + i).val("#");
        }
        function kayitbasarili(bolge, deger) {
          $(bolge).html(deger);
        }
            </script>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="scriptmanager_bitis" runat="server">
</asp:Content>
