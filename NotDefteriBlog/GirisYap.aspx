<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="GirisYap.aspx.cs" Inherits="NotDefteriBlog.girisyap" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    - Kullanıcı Girişi
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="updatepanel" runat="server">
    
    </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ortakisim" runat="server">
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
<ContentTemplate>
<div class="row">
            <div class="col-md-9 col-md-offset-1 bg-white main-border-4 mgb-30">
                <div class="row">
                    <div class="col-md-12" id="giris">
                        <h2>Giriş Yap</h2>
                        <hr />
                         <div class="form-group">
                          <label>Kullanıcı Adı:</label>
                             <asp:TextBox ID="username" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                        <div class="form-group">
                          <label>Şifre:</label>
                            <asp:TextBox ID="password" runat="server" CssClass="form-control" TextMode="Password"></asp:TextBox>
                        </div>
                        <hr />
					        <div class="form-group pull-right">
                                    <asp:Button ID="giris_yap" runat="server" Text="Giriş Yap" CssClass="btn btn-info" OnClick="giris_yap_Click" />
					        </div>
                    </div>
                    </div>
                
                </div>
    <asp:Timer ID="Timer1" runat="server" Interval="5000" OnTick="Timer1_Tick" Enabled="False"></asp:Timer>
        <div class="alert mesaj" id="mesaj"></div>
    </div>
<script>
        function mesaj(type1,mesaj){
            $("#mesaj").addClass(type1);
            $("#mesaj").append(mesaj);
            $("#mesaj").append('<div class="bar" id="bar"></div>');
            $("#mesaj").css("visibility", "visible");
            $("#bar").css("width","0px");
            $("#bar").animate({
                width: "220px"
            }, 3500, function () {
                $("#mesaj").hide(100);
            });
        };
        function kayitbasarili(bolge,deger) {
            $(bolge).html(deger);
        }
</script>
</ContentTemplate>
</asp:UpdatePanel>
</asp:Content>