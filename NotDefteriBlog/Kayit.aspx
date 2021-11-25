<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="Kayit.aspx.cs" Inherits="NotDefteriBlog.kayit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    - Kayıt</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="updatepanel" runat="server">
    
    </asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ortakisim" runat="server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
    <div class="row">
			
				<div class="col-md-9 col-md-offset-1 bg-white main-border-4 mgb-30">
                    <div class="row">
                        <div class="col-md-12" id="kayit">
				        <h2>Kayıt Ol</h2>
				        <hr />
                         <div class="form-group">
                          <label>Kullanıcı Adı:</label>
                             <asp:TextBox ID="uname" runat="server" CssClass="form-control" ></asp:TextBox>
                        </div>
                        <div class="form-group">
                          <label>Email:</label>
                            <asp:TextBox ID="email" runat="server" CssClass="form-control" ></asp:TextBox>
                        </div>
                        <div class="form-group">
                          <label>Şifre:</label>
                            <asp:TextBox ID="pass" runat="server" CssClass="form-control" TextMode="Password"></asp:TextBox>
                        </div>
                        <div class="form-group">
                          <label>Şifre Tekrar:</label>
                            <asp:TextBox ID="passr" runat="server" CssClass="form-control" TextMode="Password"></asp:TextBox>
                        </div>
                        <div class="form-group">
                          <label id="detaylarigoster" onclick="goster();">Detaylı Bilgiler</label>
                        </div>
                        <div id="detaylar">
                            <div class="form-group">
                              <label>Ad:</label>
                                <asp:TextBox ID="ad" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                            <div class="form-group">
                              <label>Soyad:</label>
                                <asp:TextBox ID="soyad" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                            <div class="form-group">
                              <label>Telefon:</label>
                                <asp:TextBox ID="telefon" runat="server" CssClass="form-control" TextMode="Phone" MaxLength="10"></asp:TextBox>
                            </div>
                            <div class="form-group">
                              <label>Gizlilik:</label>
                                <asp:DropDownList ID="gizlilik" runat="server" CssClass="form-control">
                                    <asp:ListItem Value="1">Bilgilerim Gizlensin</asp:ListItem>
                                    <asp:ListItem Value="0">Bilgilerim Gözüksün</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            <div class="form-group">
                              <label>Web Site:</label>
                                <asp:TextBox ID="webpage" runat="server" CssClass="form-control" TextMode="Url"></asp:TextBox>
                            </div>
                            <div class="form-group">
                              <label>Hakkımda:</label>
                                <asp:TextBox ID="hakkinda" runat="server" CssClass="form-control" TextMode="MultiLine" placeholder="Hakkınızda kısa bilgiler"></asp:TextBox>
                            </div>
                            <div class="form-group">
                              <label>FaceBook:</label>
                                <asp:TextBox ID="facebook" runat="server" CssClass="form-control" TextMode="Url"></asp:TextBox>
                            </div>
                            <div class="form-group">
                              <label>Twitter:</label>
                                <asp:TextBox ID="twitter" runat="server" CssClass="form-control" TextMode="Url"></asp:TextBox>
                            </div>
                            <div class="form-group">
                              <label>Instagram:</label>
                                <asp:TextBox ID="instagram" runat="server" CssClass="form-control" TextMode="Url"></asp:TextBox>
                            </div>
                            <div class="form-group">
                              <label>LinkedIn:</label>
                                <asp:TextBox ID="linkedin" runat="server" CssClass="form-control" TextMode="Url"></asp:TextBox>
                            </div>
                        </div>
                       <hr />
					        <div class="row">
						        <div class="col-md-9">
						        </div>
						        <div class="col-md-3">
                                    <asp:Button ID="login_btn" runat="server" Text="Ücretsiz Kayıt Ol" CssClass="btn btn-success pull-right" OnClick="login_btn_Click1" />
						        </div>
					        </div>
                            <asp:Literal ID="Literal1" runat="server"></asp:Literal>
                            <br />
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
        function goster() {
            if ($("#detaylar").css("display") == "none") {
                $("#detaylar").show(100);
                } else {
                $("#detaylar").hide(100);
                }
        }
        function kayitbasarili(bolge,deger) {
            $(bolge).html(deger);
        }
</script>
</ContentTemplate>
</asp:UpdatePanel>
    <script>
        $("#detaylar").hide();
    </script>
</asp:Content>


