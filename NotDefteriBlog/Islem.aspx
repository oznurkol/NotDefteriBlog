<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="Islem.aspx.cs" Inherits="NotDefteriBlog.kat_islem" %>

<%@ Register Assembly="CKEditor.NET" Namespace="CKEditor.NET" TagPrefix="CKEditor" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    - Üye İşlemleri
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="updatepanel" runat="server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="ckeditor" runat="server">
        <script type="text/javascript" src="../ckfinder/ckfinder.js"></script>
    <script type="text/javascript" src="../ckeditor/ckeditor.js"></script>
            <script type="text/javascript">
                function listgoster() {
                    $("#<%=GridView2.ClientID%>").show();
                    $("#duzenleme").hide();
                };
                function listgizle() {
                    $("#<%=GridView2.ClientID%>").hide();
                    $("#duzenleme").show();
                }
    </script>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ortakisim" runat="server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
    <div class="row">
        <div class="col-md-9 col-md-offset-1 bg-white main-border-4 mgb-30 pd-7">
            <div class="btn-group" role="group" aria-label="...">
                <asp:Button ID="yazilar" runat="server" Text="Size Ait Yazılar" CssClass="btn btn-default" OnClick="yazilar_Click" />
                <asp:Button ID="yaziolustur" runat="server" Text="Yazı Oluştur" CssClass="btn btn-default" OnClick="yaziolustur_Click" />
                <asp:Button ID="favlar" runat="server" Text="Favori Yazılarınız" CssClass="btn btn-default" OnClick="favlar_Click" />
                <asp:Button ID="yorumlar" runat="server" Text="Üyelik İşlemleri" CssClass="btn btn-default" OnClick="yorumlar_Click" />
            </div>
        </div>
		<div class="col-md-9 col-md-offset-1 bg-white main-border-4 mgb-30">
             <div class="row">
                 <div class="col-md-12" id="kayit">
            <asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="0">
                <asp:View ID="View1" runat="server">
                    
                </asp:View>
                <asp:View ID="View2" runat="server">
                   
                </asp:View>
                <asp:View ID="View3" runat="server">
                    <br />
                    <div class="panel panel-default">
                      <!-- Default panel contents -->
                      <div class="panel-heading">Yazılarınız</div>
                        <asp:Literal ID="yazilarltl" runat="server"></asp:Literal>
                      <asp:GridView ID="GridView2" runat="server" CssClass="table" BorderStyle="None" AutoGenerateColumns="False" GridLines="None" DataKeyNames="Yazi_ID" OnSelectedIndexChanged="GridView2_SelectedIndexChanged" OnRowCommand="GridView2_RowCommand">
                          <Columns>
                              <asp:BoundField DataField="baslik" HeaderText="Başlık" />
                              <asp:BoundField DataField="kate" HeaderText="Kategori" />
                              <asp:BoundField DataField="tarih" HeaderText="Tarih" />
                              <asp:BoundField DataField="oykul" HeaderText="Oy Kullanımı" />
                              <asp:BoundField DataField="oy" HeaderText="Oy Sayısı" />
                              <asp:BoundField DataField="yorumkul" HeaderText="Yorum Kullanımı" />
                              <asp:BoundField DataField="yorumsayisi" HeaderText="Yorum Sayısı" />
                              <asp:BoundField DataField="Yazi_ID" ItemStyle-CssClass="hidden" HeaderStyle-CssClass="hidden" >
                              <HeaderStyle CssClass="hidden" />
                              <ItemStyle CssClass="hidden" />
                              </asp:BoundField>
                              <asp:CommandField ShowSelectButton="True" />
                              
                              <asp:ButtonField CommandName="sil" Text="Sil" />
                              
                              <asp:HyperLinkField DataNavigateUrlFields="Yazi_ID" HeaderText="Git" DataNavigateUrlFormatString="YaziGoruntule.aspx?id={0}" Text="Git" />
                              
                          </Columns>
                        </asp:GridView>
                     <div class="panel-heading">Yazılarınızı Düzenleyin</div>
                      <div class="panel-body" id="eskiyazilar">
                          <div class="form-group">
                              <asp:Label ID="Label4" runat="server" Text="Başlık:"></asp:Label><br />
                              <asp:TextBox ID="duzenyazibaslik" runat="server" CssClass="form-control"></asp:TextBox>
                              <br /></br7><asp:RegularExpressionValidator ID="RegularExpressionValidator7" runat="server" ErrorMessage="3-75 karakter arası olabilir!" ValidationExpression = "^[\s\S]{3,75}$" ControlToValidate="duzenyazibaslik" CssClass="alert alert-danger" Display="Dynamic" SetFocusOnError="True"></asp:RegularExpressionValidator>
                          </div>
                          <div class="form-group">
                             <asp:Label ID="Label5" runat="server" Text="Yazıya Ait Kategori Seçiniz"></asp:Label>
                              <br />
                             <asp:DropDownList ID="duzenyazikate" runat="server" CssClass="form-control"></asp:DropDownList>
                         </div>
                          <div class="form-group">
                              <asp:Label ID="Label6" runat="server" Text="İçerik:"></asp:Label><br />
                            <CKEditor:CKEditorControl ID="duzenyaziicerik" runat="server"></CKEditor:CKEditorControl>
                                    <br /><asp:RegularExpressionValidator ID="RegularExpressionValidator8" runat="server" ErrorMessage="Maximum 10000 karakter olabilir." ValidationExpression = "^[\s\S]{0,10000}$" ControlToValidate="duzenyaziicerik" CssClass="alert alert-danger" Display="Dynamic"></asp:RegularExpressionValidator>
                          </div>
                         <div class="form-group">
                             <asp:Label ID="Label15" runat="server" Text="Yazı Yayınlanabilsin Mi? (Eğer evet seçerseniz yazınız yönetici tarafından uygun görülürse yayınlanır.)"></asp:Label>
                             <br />
                             <asp:DropDownList ID="duzenyaziyayin" runat="server" CssClass="form-control">
                                 <asp:ListItem Value="1">Evet</asp:ListItem>
                                 <asp:ListItem Value="0">Hayır</asp:ListItem>
                             </asp:DropDownList>
                         </div>
                         <div class="form-group">
                             <asp:Label ID="Label16" runat="server" Text="Yazınız diğer kullanıcılar tarafından oylanabilsin mi?"></asp:Label>
                             <br />
                             <asp:DropDownList ID="duzenyazioy" runat="server" CssClass="form-control">
                                 <asp:ListItem Value="1">Evet</asp:ListItem>
                                 <asp:ListItem Value="0">Hayır</asp:ListItem>
                             </asp:DropDownList>
                         </div>
                         <div class="form-group">
                             <asp:Label ID="Label17" runat="server" Text="Yorum yapılabilsin mi?"></asp:Label>
                             <br />
                             <asp:DropDownList ID="duzenyaziyorum" runat="server" CssClass="form-control">
                                 <asp:ListItem Value="1">Evet</asp:ListItem>
                                 <asp:ListItem Value="0">Hayır</asp:ListItem>
                             </asp:DropDownList>
                         </div>
                          <asp:Button ID="YaziDuzen" runat="server" Text="Yazıyı Düzenle" CssClass="btn btn-primary pull-right" OnClick="YaziDuzen_Click" />
                      </div>
                    </div>
                </asp:View>
                <asp:View ID="View4" runat="server">
                    <br />
                    <div class="panel panel-default">
                      <!-- Default panel contents -->
                      <div class="panel-heading">Yeni Bir Yazı Ekle</div>
                        <asp:Literal ID="Literal3" runat="server"></asp:Literal>
                      <div class="panel-body" >
                          <div class="form-group">
                              <asp:Label ID="Label7" runat="server" Text="Başlık:"></asp:Label><br />
                              <asp:TextBox ID="yeniyazibaslik" runat="server" CssClass="form-control"></asp:TextBox>
                              <br /></br7><asp:RegularExpressionValidator ID="RegularExpressionValidator10" runat="server" ErrorMessage="3-75 karakter arası olabilir!" ValidationExpression = "^[\s\S]{3,75}$" ControlToValidate="yeniyazibaslik" CssClass="alert alert-danger" Display="Dynamic" SetFocusOnError="True"></asp:RegularExpressionValidator>
                          </div>
                          <div class="form-group">
                             <asp:Label ID="Label13" runat="server" Text="Yazıya Ait Kategori Seçiniz"></asp:Label>
                              <br />
                             <asp:DropDownList ID="yeniyazikat" runat="server" CssClass="form-control"></asp:DropDownList>
                         </div>
                          <div class="form-group">
                              <asp:Label ID="Label8" runat="server" Text="İçerik:"></asp:Label><br />
                            <CKEditor:CKEditorControl ID="yeniyaziicerik" runat="server"></CKEditor:CKEditorControl>
                                    <br /><asp:RegularExpressionValidator ID="RegularExpressionValidator11" runat="server" ErrorMessage="Maximum 10000 karakter olabilir." ValidationExpression = "^[\s\S]{0,10000}$" ControlToValidate="yeniyaziicerik" CssClass="alert alert-danger" Display="Dynamic"></asp:RegularExpressionValidator>
                          </div>
                         <div class="form-group">
                             <asp:Label ID="Label10" runat="server" Text="Yazı Yayınlanabilsin Mi? (Eğer evet seçerseniz yazınız yönetici tarafından uygun görülürse yayınlanır.)"></asp:Label>
                             <br />
                             <asp:DropDownList ID="yeniyayin" runat="server" CssClass="form-control">
                                 <asp:ListItem Value="1">Evet</asp:ListItem>
                                 <asp:ListItem Value="0">Hayır</asp:ListItem>
                             </asp:DropDownList>
                         </div>
                         <div class="form-group">
                             <asp:Label ID="Label11" runat="server" Text="Yazınız diğer kullanıcılar tarafından oylanabilsin mi?"></asp:Label>
                             <br /><asp:DropDownList ID="yenioy" runat="server" CssClass="form-control">
                                 <asp:ListItem Value="1">Evet</asp:ListItem>
                                 <asp:ListItem Value="0">Hayır</asp:ListItem>
                             </asp:DropDownList>
                             
                         </div>
                         <div class="form-group">
                             <asp:Label ID="Label12" runat="server" Text="Yorum yapılabilsin mi?"></asp:Label>
                             <br />
                             <asp:DropDownList ID="yeniyorum" runat="server" CssClass="form-control">
                                 <asp:ListItem Value="1">Evet</asp:ListItem>
                                 <asp:ListItem Value="0">Hayır</asp:ListItem>
                             </asp:DropDownList>
                         </div>
                          <asp:Button ID="yaziEkle" runat="server" Text="Yazıyı Ekle" CssClass="btn btn-primary pull-right" OnClick="yaziEkle_Click" />
                     </div>
                    </div>
                </asp:View>
                <asp:View ID="View5" runat="server">
                    <br />
                    <div class="panel panel-default">

                      <!-- Default panel contents -->
                      <div class="panel-heading">Favori Yazılarınız</div>
                        <div class="panel-body">
                            <asp:Literal ID="favlit" runat="server"></asp:Literal>
                        </div>
                      <asp:GridView ID="GridView3" runat="server" CssClass="table" BorderStyle="None" AutoGenerateColumns="False" GridLines="None" DataKeyNames="Fav_ID" OnRowCommand="GridView3_RowCommand">
                          <Columns>
                              <asp:BoundField DataField="baslik" HeaderText="Başlık" />
                              <asp:BoundField DataField="username" HeaderText="Yazar" />
                              <asp:BoundField DataField="Fav_ID" ItemStyle-CssClass="hidden" HeaderStyle-CssClass="hidden" >
                              <HeaderStyle CssClass="hidden" />
                              <ItemStyle CssClass="hidden" />
                              </asp:BoundField>
                              <asp:ButtonField CommandName="sil" Text="Sil" HeaderText="Sil" />
                              <asp:HyperLinkField DataNavigateUrlFields="Yazi_ID" HeaderText="Git" DataNavigateUrlFormatString="YaziGoruntule.aspx?id={0}" Text="Git" />
                              
                          </Columns>
                        </asp:GridView>
                    </div>
                </asp:View>
                <asp:View ID="View6" runat="server">
                    <br />
                    <div class="panel panel-default">

                      <!-- Default panel contents -->
                      <div class="panel-heading">Şifre Değişikliği</div>
                        <div class="panel-body">
                            <asp:Literal ID="Literal4" runat="server"></asp:Literal>
                            <div class="row">
                                <div class="col-md-4">
                                  <div class="form-group">
                                      <asp:Label ID="Label9" runat="server" Text="Eski Şifre:"></asp:Label><br />
                                      <asp:TextBox ID="eskisifre" runat="server" CssClass="form-control"></asp:TextBox>
                                      <br /><asp:RegularExpressionValidator ID="RegularExpressionValidator9" runat="server" ErrorMessage="3-50 karakter arası olabilir!" ValidationExpression = "^[\s\S]{3,50}$" ControlToValidate="eskisifre" CssClass="alert alert-danger" Display="Dynamic" SetFocusOnError="True"></asp:RegularExpressionValidator>
                                  </div>
                                </div>
                                <div class="col-md-4">
                                  <div class="form-group">
                                      <asp:Label ID="Label14" runat="server" Text="Yeni Şifre:"></asp:Label><br />
                                      <asp:TextBox ID="yenisi" runat="server" CssClass="form-control"></asp:TextBox>
                                      <br /><asp:RegularExpressionValidator ID="RegularExpressionValidator12" runat="server" ErrorMessage="3-50 karakter arası olabilir!" ValidationExpression = "^[\s\S]{3,50}$" ControlToValidate="yenisi" CssClass="alert alert-danger" Display="Dynamic" SetFocusOnError="True"></asp:RegularExpressionValidator>
                                  </div>
                                </div>
                                <div class="col-md-4">
                                  <div class="form-group">
                                      <asp:Label ID="Label18" runat="server" Text="Yeni Şifre Tekrar:"></asp:Label><br />
                                      <asp:TextBox ID="yenisitekrar" runat="server" CssClass="form-control"></asp:TextBox>
                                      <br /><asp:RegularExpressionValidator ID="RegularExpressionValidator13" runat="server" ErrorMessage="3-50 karakter arası olabilir!" ValidationExpression = "^[\s\S]{3,50}$" ControlToValidate="yenisitekrar" CssClass="alert alert-danger" Display="Dynamic" SetFocusOnError="True"></asp:RegularExpressionValidator>
                                  </div>
                                    <asp:Button ID="Button2" runat="server" Text="Şifre Değişikliği" CssClass="btn btn-success pull-right" OnClick="sifrebtn_Click" />
                            
                                </div>
                                </div>
                         </div>
                      <div class="panel-heading">Kişisel Bilgiler</div>
                        <div class="panel-body">
                            <asp:Literal ID="kisiselltr" runat="server"></asp:Literal>
                            <div class="row">
                                <div class="col-md-4">
                                  <div class="form-group">
                                      <asp:Label ID="Label19" runat="server" Text="Ad:"></asp:Label><br />
                                      <asp:TextBox ID="adi" runat="server" CssClass="form-control"></asp:TextBox>
                                      <br /><asp:RegularExpressionValidator ID="RegularExpressionValidator14" runat="server" ErrorMessage="3-50 karakter arası olabilir!" ValidationExpression = "^[\s\S]{3,50}$" ControlToValidate="adi" CssClass="alert alert-danger" Display="Dynamic" SetFocusOnError="True"></asp:RegularExpressionValidator>
                                  </div>
                                </div>
                                <div class="col-md-4">
                                  <div class="form-group">
                                      <asp:Label ID="Label20" runat="server" Text="Soyad:"></asp:Label><br />
                                      <asp:TextBox ID="soyadi" runat="server" CssClass="form-control"></asp:TextBox>
                                      <br /><asp:RegularExpressionValidator ID="RegularExpressionValidator15" runat="server" ErrorMessage="3-50 karakter arası olabilir!" ValidationExpression = "^[\s\S]{3,50}$" ControlToValidate="soyadi" CssClass="alert alert-danger" Display="Dynamic" SetFocusOnError="True"></asp:RegularExpressionValidator>
                                  </div>
                                </div>
                                <div class="col-md-4">
                                  <div class="form-group">
                                      <asp:Label ID="Label21" runat="server" Text="Email:"></asp:Label><br />
                                      <asp:TextBox ID="emails" runat="server" CssClass="form-control"></asp:TextBox>
                                      <br /><asp:RegularExpressionValidator ID="RegularExpressionValidator16" runat="server" ErrorMessage="3-70 karakter arası olabilir!" ValidationExpression = "\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ControlToValidate="emails" CssClass="alert alert-danger" Display="Dynamic" SetFocusOnError="True"></asp:RegularExpressionValidator>
                                  </div>
                                </div>
                          </div>
                            <div class="row">
                                <div class="col-md-4">
                                  <div class="form-group">
                                      <asp:Label ID="Label22" runat="server" Text="Telefon:"></asp:Label><br />
                                      <asp:TextBox ID="telefon" runat="server" CssClass="form-control"></asp:TextBox>
                                      <br /><asp:RegularExpressionValidator ID="RegularExpressionValidator17" runat="server" ErrorMessage="10 karakter olabilir!" ValidationExpression = "^[\s\S]{0,11}$" ControlToValidate="telefon" CssClass="alert alert-danger" Display="Dynamic" SetFocusOnError="True"></asp:RegularExpressionValidator>
                                  </div>
                                </div>
                               <div class="col-md-4">
                                  <div class="form-group">
                                      <asp:Label ID="Label23" runat="server" Text="Hesap Gizliliği:"></asp:Label><br />
                                      <asp:DropDownList ID="hesapgizlilik" runat="server" CssClass="form-control">
                                         <asp:ListItem Value="1">Aktif</asp:ListItem>
                                         <asp:ListItem Value="0">Değil</asp:ListItem>
                                      </asp:DropDownList>
                                  </div>
                                </div>
                               <div class="col-md-4">
                                  <div class="form-group">
                                      <asp:Label ID="Label24" runat="server" Text="Web Site:"></asp:Label><br />
                                      <asp:TextBox ID="webpage" runat="server" CssClass="form-control"></asp:TextBox>
                                      <br /><asp:RegularExpressionValidator ID="RegularExpressionValidator19" runat="server" ErrorMessage="3-50 karakter arası olabilir!" ValidationExpression = "http(s)?://([\w-]+\.)+[\w-]+(/[\w- ./?%&amp;=]*)?" ControlToValidate="webpage" CssClass="alert alert-danger" Display="Dynamic" SetFocusOnError="True"></asp:RegularExpressionValidator>
                                  </div><asp:Button ID="kisiselBtn" runat="server" Text="Bilgileri Güncelle" CssClass="btn btn-success pull-right" OnClick="kisiselBtn_Click" />
                                </div>
                                
                            </div>
                         </div>
                      <div class="panel-heading">Sosyal Medya</div>
                        <div class="panel-body">
                            <asp:Literal ID="Literal5" runat="server"></asp:Literal>
                            <div class="row">
                                <div class="col-md-4">
                                  <div class="form-group">
                                      <asp:Label ID="Label25" runat="server" Text="FaceBook:"></asp:Label><br />
                                      <asp:TextBox ID="facebook" runat="server" CssClass="form-control"></asp:TextBox>
                                      <br /><asp:RegularExpressionValidator ID="RegularExpressionValidator18" runat="server" ErrorMessage="Web site biçiminden olmalıdır." ValidationExpression = "\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ControlToValidate="facebook" CssClass="alert alert-danger" Display="Dynamic" SetFocusOnError="True"></asp:RegularExpressionValidator>
                                  </div>
                                </div>
                                <div class="col-md-4">
                                  <div class="form-group">
                                      <asp:Label ID="Label26" runat="server" Text="Instgram:"></asp:Label><br />
                                      <asp:TextBox ID="instgram" runat="server" CssClass="form-control"></asp:TextBox>
                                      <br /><asp:RegularExpressionValidator ID="RegularExpressionValidator20" runat="server" ErrorMessage="Web site biçiminden olmalıdır." ValidationExpression = "\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ControlToValidate="instgram" CssClass="alert alert-danger" Display="Dynamic" SetFocusOnError="True"></asp:RegularExpressionValidator>
                                  </div>
                                </div>
                                <div class="col-md-4">
                                  <div class="form-group">
                                      <asp:Label ID="Label27" runat="server" Text="Twitter:"></asp:Label><br />
                                      <asp:TextBox ID="twitter" runat="server" CssClass="form-control"></asp:TextBox>
                                      <br /><asp:RegularExpressionValidator ID="RegularExpressionValidator21" runat="server" ErrorMessage="Web site biçiminden olmalıdır." ValidationExpression = "\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ControlToValidate="twitter" CssClass="alert alert-danger" Display="Dynamic" SetFocusOnError="True"></asp:RegularExpressionValidator>
                                  </div>
                                </div>
                          </div>
                            <div class="row">
                                <div class="col-md-12">
                                  <div class="form-group">
                                      <asp:Label ID="Label28" runat="server" Text="Hakkınızda:"></asp:Label><br />
                                      <asp:TextBox ID="hakkinizda" runat="server" CssClass="form-control" Height="100px" TextMode="MultiLine"></asp:TextBox>
                                      <br /><asp:RegularExpressionValidator ID="RegularExpressionValidator22" runat="server" ErrorMessage="160 karakter olabilir!" ValidationExpression = "^[\s\S]{0,160}$" ControlToValidate="hakkinizda" CssClass="alert alert-danger" Display="Dynamic" SetFocusOnError="True"></asp:RegularExpressionValidator>
                                  </div>
                                </div>   
                                </div><asp:Button ID="sosyalBtn" runat="server" Text="Bilgileri Güncelle" CssClass="btn btn-success pull-right" OnClick="sosyalBtn_Click" />                             
                            </div>
                         </div>
                </asp:View>
            </asp:MultiView>
                     </div>
             </div>
		</div>
    </div>
            <script>
                function silme(i) {
                    $("#span" + i).hide(100);
                    $("#ortakisim_" + i).val("#");
                }
                function kayitbasarili(bolge, deger) {
                    $(bolge).html(deger);
                }

                function gizleltr(literalid) {
                        setTimeout(function () {
                            //alert('VIDEO HAS STOPPED');
                            $(literalid).hide(100);
                        }, 5000);
                }
            </script>
        </ContentTemplate>
</asp:UpdatePanel>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="scriptmanager_bitis" runat="server">
</asp:Content>
