<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="Yonetim.aspx.cs" Inherits="NotDefteriBlog.yonetim" %>

<%@ Register Assembly="CKEditor.NET" Namespace="CKEditor.NET" TagPrefix="CKEditor" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    - Yönetim Paneli</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="updatepanel" runat="server">
    
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ortakisim" runat="server">
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <div class="row">
                   <div class="col-md-9 col-md-offset-1 bg-white main-border-4 mgb-30 pd-7">
                    <div class="btn-group" role="group" aria-label="...">
                        <asp:Button ID="bilgiler" runat="server" Text="Genel Bilgiler" CssClass="btn btn-default" OnClick="bilgiler_Click" />
                        <asp:Button ID="uyeler" runat="server" Text="Üyeler" CssClass="btn btn-default" OnClick="btnolstur_Click" />
                        <asp:Button ID="yazilar" runat="server" Text="Yazılar" CssClass="btn btn-default" OnClick="yazilar_Click" />
                        <asp:Button ID="kateler" runat="server" Text="Kategoriler" CssClass="btn btn-default" OnClick="kateler_Click" />
                        <asp:Button ID="duyurular" runat="server" Text="Duyurular" CssClass="btn btn-default" OnClick="duyurular_Click" />
                        <asp:Button ID="galeri" runat="server" Text="Galeri" CssClass="btn btn-default" OnClick="galeri_Click" />
                        <asp:Button ID="Button4" runat="server" Text="Slider Resimleri" CssClass="btn btn-default" OnClick="Button4_Click" />
                    </div>
                </div>
		    <div class="col-md-9 col-md-offset-1 bg-white main-border-4 mgb-30">
                <div class="row">
                    <div class="col-md-12" id="kayit">
                        <asp:MultiView ID="MultiView1" runat="server">
                            <asp:View ID="View1" runat="server">
                    <br />
                    <asp:Literal ID="ltrView1" runat="server"></asp:Literal>
                    <div class="panel panel-default">
                      <!-- Default panel contents -->
                      <div class="panel-heading">Genel İşlemler 1</div>
                      <div class="panel-body">
                          <asp:Literal ID="genel1" runat="server"></asp:Literal>
                          <div class="form-group">
                              <asp:Label ID="kyt" runat="server" Text="Üye Kayıt Olabilir Mi:"></asp:Label><br />
                              <asp:DropDownList ID="uyekayit" runat="server" CssClass="form-control">
                                  <asp:ListItem Value="true">Evet</asp:ListItem>
                                  <asp:ListItem Value="false">Hayır</asp:ListItem>
                              </asp:DropDownList>
                          </div>
                          <div class="form-group">
                            <asp:Label ID="Label1" runat="server" Text="Üye Giriş Yapabilir Mi:"></asp:Label><br />
                              <asp:DropDownList ID="uyegirisi" runat="server" CssClass="form-control">
                                  <asp:ListItem Value="true">Evet</asp:ListItem>
                                  <asp:ListItem Value="false">Hayır</asp:ListItem>
                              </asp:DropDownList>
                         </div>
                          <asp:Button ID="btnDzn" runat="server" Text="İşlemi Gerçekleştir" CssClass="btn btn-primary pull-right" OnClick="btnDzn_Click" />
                      </div>
                    <div class="panel-heading">Genel İşlemler 2</div>
                      <div class="panel-body">
                          <asp:Literal ID="genel2" runat="server"></asp:Literal>
                          <div class="form-group">
                              <asp:Label ID="Label2" runat="server" Text="Site Başlığı:"></asp:Label><br />
                              <asp:TextBox ID="sitebaslik" runat="server" CssClass="form-control"></asp:TextBox>
                          </div>
                          <div class="form-group">
                            <asp:Label ID="Label21" runat="server" Text="Banner Resim Yolu:"></asp:Label><br />
                              <asp:TextBox ID="bannerresim" runat="server" CssClass="form-control"></asp:TextBox>
                         </div>
                          <div class="form-group">
                            <asp:Label ID="Label3" runat="server" Text="Keyword:"></asp:Label><br />
                              <asp:TextBox ID="sitekeys" runat="server" CssClass="form-control"></asp:TextBox>
                         </div>
                          <div class="form-group">
                            <asp:Label ID="Label4" runat="server" Text="Description:"></asp:Label><br />
                              <asp:TextBox ID="description" runat="server" CssClass="form-control"></asp:TextBox>
                         </div>
                          <div class="form-group">
                            <asp:Label ID="Label5" runat="server" Text="Footer:"></asp:Label><br />
                              <asp:TextBox ID="sitecopy" runat="server" CssClass="form-control"></asp:TextBox>
                         </div>
                          <div class="form-group">
                            <asp:Label ID="Label17" runat="server" Text="Hakkımızda:"></asp:Label><br />
                              <CKEditor:CKEditorControl ID="hakkimizda" runat="server"></CKEditor:CKEditorControl>
                         </div>
                          <asp:Button ID="Button1" runat="server" Text="İşlemi Gerçekleştir" CssClass="btn btn-primary pull-right" OnClick="Button1_Click" />
                      </div>
                    </div>
                    <div class="panel panel-default">
                    <div class="panel-heading">Dinamik Menüler</div>
                        <asp:Literal ID="dinamikltr" runat="server"></asp:Literal>
                      <div class="panel-body">
                          <asp:GridView ID="GridView6" runat="server" BorderStyle="None" AutoGenerateColumns="False" GridLines="None" CssClass="table" OnSelectedIndexChanged="GridView6_SelectedIndexChanged" DataKeyNames="menuID">

                              <Columns>
                                  <asp:BoundField DataField="menuID" HeaderText="ID" />
                                  <asp:BoundField DataField="baslik" HeaderText="Başlığı" />
                                  <asp:BoundField DataField="menuYol" HeaderText="Yolu" />
                                  <asp:BoundField DataField="normal" HeaderText="Normal Sayfa" />
                                  <asp:CommandField ShowSelectButton="True" />
                                  <asp:CommandField ShowDeleteButton="True" />
                              </Columns>

                          </asp:GridView>
                          <hr />
                          <div class="form-group">
                              <asp:Label ID="Label15" runat="server" Text="Site Başlığı:"></asp:Label><br />
                              <asp:TextBox ID="dinamikbaslik" runat="server" CssClass="form-control"></asp:TextBox>
                          </div>
                          <div class="form-group">
                              <asp:Label ID="Label13" runat="server" Text="Menü Yolu:"></asp:Label><br />
                              <asp:TextBox ID="dinamikyol" runat="server" CssClass="form-control"></asp:TextBox>
                          </div>
                          <div class="form-group">
                              <asp:Label ID="Label16" runat="server" Text="Normal Sayfa Mı:"></asp:Label><br />
                              <asp:CheckBox ID="chknormal" runat="server" />
                          </div>
                          <div class="form-group">
                              <asp:Label ID="Label14" runat="server" Text="Sayfa İçeriği:"></asp:Label><br />
                              <CKEditor:CKEditorControl ID="dinamikicerik" runat="server"></CKEditor:CKEditorControl>
                          </div>
                          <asp:Button ID="Button2" runat="server" Text="Güncelle" CssClass="btn btn-primary pull-left" OnClick="Button2_Click" />
                          <asp:Button ID="Button3" runat="server" Text="Ekle" CssClass="btn btn-primary pull-right" OnClick="Button3_Click" />
                      </div>
                    </div>
                  </asp:View>
                            <asp:View ID="View2" runat="server">
                    <br />
                    <asp:Literal ID="uyelerLtr" runat="server"></asp:Literal>
                    <div class="panel panel-default">
                      <!-- Default panel contents -->
                      <div class="panel-heading">Üyeler</div>
                        <br />
                        <asp:Literal ID="ltruyeler" runat="server"></asp:Literal>
                          <asp:GridView ID="GridView2" runat="server" BorderStyle="None" AutoGenerateColumns="False" GridLines="None" CssClass="table" DataKeyNames="ID" OnSelectedIndexChanged="GridView2_SelectedIndexChanged">
                    <Columns>
                       <asp:TemplateField HeaderText="Kullanıcı Adı">
                       <ItemTemplate >
                          <asp:Label runat="server" Text='<%# Eval("username") %>' ID="users"></asp:Label>
                       </ItemTemplate>
                      </asp:TemplateField>
                       <asp:TemplateField HeaderText="Email">
                       <ItemTemplate>
                           <asp:Label ID="emx" runat="server" Text='<%# Eval("email") %>'></asp:Label>
                       </ItemTemplate>
                       </asp:TemplateField>
                       <asp:TemplateField HeaderText="Ad Soyad">
                       <ItemTemplate>
                           <asp:Label ID="adsyx" runat="server" Text='<%# string.Concat(Eval("ad"), " ", Eval("soyad")) %>'></asp:Label>
                       </ItemTemplate>
                       </asp:TemplateField>
                       <asp:TemplateField HeaderText="Y\G">
                       <ItemTemplate>
                           <asp:Label ID="admxx" runat="server" Text='<%# string.Concat((bool)Eval("adminmi")==true?"Evet":"Hayır","\\", (bool)Eval("gizlimi")==true?"Evet":"Hayır") %>'></asp:Label>
                       </ItemTemplate>
                       </asp:TemplateField>
                       <asp:TemplateField HeaderText="Web Site">
                       <ItemTemplate>
                           <asp:Label ID="webxx" runat="server" Text='<%# Eval("webpage") %>'></asp:Label>
                       </ItemTemplate>
                       </asp:TemplateField>
                        <asp:CommandField HeaderText="Seçme" ShowSelectButton="True" ControlStyle-CssClass="btn btn-primary btn-sm" />
                   </Columns>
                          </asp:GridView>
                        <div class="panel-heading">Üye Düzenle</div>
                        <div class="panel-body">
                        <div class="form-group">
                            Email:<asp:TextBox ID="uemail" runat="server" Text="" CssClass="form-control"></asp:TextBox>

                        </div>
                        <div class="form-group">
                            Telefon:<asp:TextBox ID="utelefon" runat="server" Text="" CssClass="form-control"></asp:TextBox>
                        </div>
                        <div class="form-group">
                            Ad:<asp:TextBox ID="uad" runat="server" Text="" CssClass="form-control"></asp:TextBox><br />
                           Soyad:<asp:TextBox ID="usoyad" runat="server" Text="" CssClass="form-control"></asp:TextBox>
                        </div>
                        <div class="form-group">
                           Yönetici:<asp:CheckBox ID="adminmi" runat="server" CssClass="form-control"/>
                           Gizli:<asp:CheckBox ID="gizlimi" runat="server" CssClass="form-control"/>
                       
                        </div>
                        <div class="form-group">
                           Web Site:<asp:TextBox ID="webpage" runat="server" Text="" CssClass="form-control"></asp:TextBox>
                        </div>
                        <div class="form-group">
                           Facebook:<br /><asp:TextBox ID="facebook" runat="server" Text="" CssClass="form-control"></asp:TextBox><br />
                           Instgram:<br /><asp:TextBox ID="inst" runat="server" Text="" CssClass="form-control"></asp:TextBox><br />
                           Twitter:<br /><asp:TextBox ID="twitter" runat="server" Text="" CssClass="form-control"></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <asp:Button ID="uyeduzen" runat="server" Text="Üyeyi Düzenle" CssClass="btn btn-primary pull-right" OnClick="uyeduzen_Click" />

                        </div>
                            </div>
                    </div>
                            </asp:View>
                            <asp:View ID="View3" runat="server">
                                <br />
                    <div class="panel panel-default">
                      <!-- Default panel contents -->
                      <div class="panel-heading">Yazılar</div>
                        <br />
                        <asp:Literal ID="yazilarltr" runat="server"></asp:Literal>
                          <asp:GridView ID="GridView1" runat="server" BorderStyle="None" AutoGenerateColumns="False" GridLines="None" CssClass="table" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" DataKeyNames="yazi_ID" OnRowCommand="GridView1_RowCommand">
                    <Columns>
                        <asp:BoundField DataField="yazi_ID" HeaderText="Yazı ID" />
                       <asp:TemplateField HeaderText="Oluşturan User">
                       <ItemTemplate >
                          <asp:Label runat="server" Text='<%# Eval("username") %>' ID="usersx"></asp:Label>
                       </ItemTemplate>
                      </asp:TemplateField>
                       <asp:TemplateField HeaderText="Başlık">
                       <ItemTemplate>
                           <a href="YaziGoruntule.aspx?id=<%# Eval("yazi_ID") %>"><asp:Label ID="yazi_adi_lbl" runat="server" Text='<%# Eval("baslik") %>'></asp:Label></a>
                       </ItemTemplate>
                       </asp:TemplateField>
                       <asp:TemplateField HeaderText="Açıklama">
                       <ItemTemplate>
                           <asp:Label ID="yazi_acikla_lbl" runat="server" Text='<%# Eval("icerik").ToString().Substring(0, Eval("icerik").ToString().Length>15? 15:Eval("icerik").ToString().Length) %>'></asp:Label>
                       </ItemTemplate>

                       </asp:TemplateField>
                       <asp:TemplateField HeaderText="Kategori">
                       <ItemTemplate>
                           <asp:Label ID="yazi_kate_lbl" runat="server" Text='<%# Eval("kategorisi") %>'></asp:Label>
                       </ItemTemplate>
                       </asp:TemplateField>
                       <asp:TemplateField HeaderText="Tarih">
                           <ItemTemplate>
                               <asp:Label ID="yazi_tarih" runat="server" Text='<%# Eval("tarih") %>'></asp:Label>
                           </ItemTemplate>
                       </asp:TemplateField>
                       <asp:TemplateField HeaderText="Oy Sayısı">
                           <ItemTemplate>
                               <asp:Label ID="oyadet" runat="server" Text='<%# Eval("oy") %>'></asp:Label>
                           </ItemTemplate>
                       </asp:TemplateField>
                        <asp:ButtonField ControlStyle-CssClass="btn btn-primary btn-sm" CommandName="sil" Text="Sil" HeaderText="Sil" >
                        <ControlStyle CssClass="btn btn-primary btn-sm" />
                        </asp:ButtonField>
                        <asp:CommandField ShowSelectButton="True" ControlStyle-CssClass="btn btn-primary btn-sm" HeaderText="Seçme" >
                        
                        <ControlStyle CssClass="btn btn-primary btn-sm" />
                        </asp:CommandField>
                        
                   </Columns>
                          </asp:GridView>
                        <div class="panel-heading">Yazı Düzenle</div>
                        <div class="panel-body">
                        <div class="form-group">
                                  <asp:Label ID="Label7" runat="server" Text="Yazı Başlık:"></asp:Label><br />
                                  <asp:TextBox ID="yazibaslik" runat="server" CssClass="form-control"></asp:TextBox>
                                  </div><div class="form-group">
                           Onay:<asp:CheckBox ID="yazi_onay" runat="server" CssClass="form-control"/>&nbsp;&nbsp;&nbsp;
                           Gizli Mi:<asp:CheckBox ID="yazi_gizli" runat="server" CssClass="form-control"/>&nbsp;&nbsp;&nbsp;
                           Oylama:<asp:CheckBox ID="yazi_oylama" runat="server" CssClass="form-control"/>&nbsp;&nbsp;&nbsp;
                           Yorumlama:<asp:CheckBox ID="yazi_yorum" runat="server" CssClass="form-control"/><br />
                        </div>
                        
                        <div class="form-group">
                            <asp:Label ID="Label18" runat="server" Text="Yazı Kategorisi:"></asp:Label><br />
                            <asp:DropDownList ID="yazi_kate" runat="server" DataTextField="kate_adi" DataValueField="KID" CssClass="form-control"></asp:DropDownList>
                        </div>
                        <div class="form-group">
                            <asp:Label ID="Label19" runat="server" Text="Yazı İçeriği:"></asp:Label><br />
                           <CKEditor:CKEditorControl ID="yazi_acikla" Text='' runat="server"></CKEditor:CKEditorControl>
                        </div>
                        <div class="form-group">
                            <asp:Button ID="yaziduzen" runat="server" Text="Yazıyı Düzenle" CssClass="btn btn-primary pull-right" OnClick="yaziduzen_Click" />
                        </div> 
                            </div>
                        <br /><br />
                    </div>
                            </asp:View>
                            <asp:View ID="View4" runat="server">
                    <br />
                    <div class="panel panel-default">
                      <!-- Default panel contents -->
                      <div class="panel-heading">Kategoriler</div>
                        <br />
                        <asp:Literal ID="ltrkategori" runat="server"></asp:Literal>
                          <asp:GridView ID="GridView3" runat="server" BorderStyle="None" AutoGenerateColumns="False" GridLines="None" CssClass="table" DataKeyNames="KID" OnSelectedIndexChanged="GridView3_SelectedIndexChanged" OnRowCommand="GridView3_RowCommand">
                    <Columns>
                        <asp:BoundField DataField="KID" HeaderText="Kategori ID" />
                       <asp:TemplateField HeaderText="Başlık">
                       <ItemTemplate>
                           <asp:Label runat="server" Text='<%# Eval("KID") %>' ID="kate_ID" Visible="false"></asp:Label>
                           <asp:Label ID="kate_adi_lbl" runat="server" Text='<%# Eval("kate_adi") %>'></asp:Label>
                       </ItemTemplate>
                       </asp:TemplateField>
                       <asp:TemplateField HeaderText="Açıklama">
                       <ItemTemplate>
                           <asp:Label ID="kate_acikla_lbl" runat="server" Text='<%# Eval("kate_acikla") %>'></asp:Label>
                       </ItemTemplate>
                       </asp:TemplateField>
                       <asp:TemplateField HeaderText="Title">
                       <ItemTemplate>
                           <asp:Label ID="kate_title_lbl" runat="server" Text='<%# Eval("kate_title") %>'></asp:Label>
                       </ItemTemplate>
                       </asp:TemplateField>
                       <asp:TemplateField HeaderText="Yazı Sayısı">
                           <ItemTemplate>
                               <asp:Label ID="kate_yaz_adet" runat="server" Text='<%# Eval("yazisayisi") %>'></asp:Label>
                           </ItemTemplate>
                       </asp:TemplateField>
                        <asp:CommandField ControlStyle-CssClass="btn btn-primary btn-sm" ShowSelectButton="True" HeaderText="Seçme">
                        <ControlStyle CssClass="btn btn-primary btn-sm" />
                        </asp:CommandField>

                        <asp:HyperLinkField HeaderText="Yazılar" Text="Yazılar" ControlStyle-CssClass="btn btn-primary btn-sm" DataNavigateUrlFields="KID" DataNavigateUrlFormatString="Kategori.aspx?kid={0}" >
                        <ControlStyle CssClass="btn btn-primary btn-sm" />
                        </asp:HyperLinkField>
                        <asp:ButtonField ControlStyle-CssClass="btn btn-primary btn-sm" CommandName="sil" HeaderText="Sil" Text="Sil" />
                   </Columns>
                          </asp:GridView>

                    </div>

                    <div class="panel panel-default">
                      <div class="panel-heading">Yeni Bir Kategori Ekle/Düzenle</div>
                        <br />
                        <asp:Literal ID="yenikate" runat="server"></asp:Literal>
                          <div class="panel-body">
                              <div class="form-group">
                                  <asp:Label ID="Label6" runat="server" Text="Kategori Adı:"></asp:Label><br />
                                  <asp:TextBox ID="kateadi" runat="server" CssClass="form-control"></asp:TextBox>
                                  <br />
                                  
                                  <asp:RegularExpressionValidator ID="RegularExpressionValidator7" runat="server" ControlToValidate="kateadi" CssClass="alert alert-danger" Display="Dynamic" ErrorMessage="3-75 karakter arası olabilir!" SetFocusOnError="True" ValidationExpression="^[\s\S]{3,75}$"></asp:RegularExpressionValidator>
                              </div>
                              <div class="form-group">
                                  <asp:Label ID="Label8" runat="server" Text="Kategori Açıklama:"></asp:Label><br />
                                  <asp:TextBox ID="kate_acik" runat="server" CssClass="form-control" TextMode="MultiLine"></asp:TextBox>
                                  <br />
                                  
                                  <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="kate_acik" CssClass="alert alert-danger" Display="Dynamic" ErrorMessage="3-75 karakter arası olabilir!" SetFocusOnError="True" ValidationExpression="^[\s\S]{0,160}$"></asp:RegularExpressionValidator>
                                
                              </div>
                              <div class="form-group">
                                  <asp:Label ID="Label9" runat="server" Text="Kategori Title:"></asp:Label><br />
                                  <asp:TextBox ID="kate_tit" runat="server" CssClass="form-control" TextMode="MultiLine"></asp:TextBox>
                                  <br />
                                  
                                  <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="kate_tit" CssClass="alert alert-danger" Display="Dynamic" ErrorMessage="3-75 karakter arası olabilir!" SetFocusOnError="True" ValidationExpression="^[\s\S]{0,160}$"></asp:RegularExpressionValidator>
                                  
                              </div>
                            <div class="form-group">
                                <asp:Button ID="kate_ekle" runat="server" Text="Kategori Ekle" CssClass="btn btn-primary pull-right" OnClick="kate_ekle_Click" />
                                <asp:Button ID="kate_duzen" runat="server" Text="Kategori Düzenle" CssClass="btn btn-primary pull-left" OnClick="kate_duzen_Click" />

                              </div>
                          </div>
                    </div>
                            </asp:View>
                            <asp:View ID="View5" runat="server">
                    <br />
                    <div class="panel panel-default">
                      <!-- Default panel contents -->
                      <div class="panel-heading">Duyurular</div>
                        <br />
                        <asp:Literal ID="duyurultr" runat="server"></asp:Literal>
                          <asp:GridView ID="GridView5" runat="server" BorderStyle="None" AutoGenerateColumns="False" GridLines="None" CssClass="table" DataKeyNames="duyuru_id" OnSelectedIndexChanged="GridView5_SelectedIndexChanged" OnRowCommand="GridView5_RowCommand">
                    <Columns>
                        
                        <asp:BoundField DataField="duyuru_id" HeaderText="Duyuru ID" />
                        
                       <asp:TemplateField HeaderText="Başlık">
                       <ItemTemplate>
                           <asp:Label ID="duyuru_lbl" runat="server" Text='<%# Eval("baslik") %>'></asp:Label>
                       </ItemTemplate>
                       </asp:TemplateField>
                       <asp:TemplateField HeaderText="Açıklama">
                       <ItemTemplate>
                           <asp:Label ID="duyuru_acikla_lbl" runat="server" Text='<%# Eval("icerik") %>'></asp:Label>
                       </ItemTemplate>
                       </asp:TemplateField>

                        <asp:CommandField HeaderText="Seçme" ShowSelectButton="True" ControlStyle-CssClass="btn btn-primary btn-sm">
                        <ControlStyle CssClass="btn btn-primary btn-sm" />
                        </asp:CommandField>
                        <asp:ButtonField ControlStyle-CssClass="btn btn-primary btn-sm" CommandName="sil" HeaderText="Sil" Text="Sil" >
                        <ControlStyle CssClass="btn btn-primary btn-sm" />
                        </asp:ButtonField>
                        <asp:HyperLinkField HeaderText="Görüntüle" Text="Görüntüle" ControlStyle-CssClass="btn btn-primary btn-sm" DataNavigateUrlFields="duyuru_id" DataNavigateUrlFormatString="duyurular.aspx?id={0}" >
                        <ControlStyle CssClass="btn btn-primary btn-sm" />
                        </asp:HyperLinkField>
                   </Columns>
                          </asp:GridView>
                    </div>

                    <div class="panel panel-default">
                      <!-- Default panel contents -->
                      <div class="panel-heading">Yeni Bir Duyuru Ekle/Düzenle</div>
                        <br />
                        <asp:Literal ID="yeniduyrultr" runat="server"></asp:Literal>
                          <div class="panel-body" id="duyurucu">
                              <div class="form-group">
                                  <asp:Label ID="Label10" runat="server" Text="Başlık:"></asp:Label><br />
                                  <asp:TextBox ID="duyurubaslik" runat="server" CssClass="form-control"></asp:TextBox>
                                  <br />
                                  <asp:RegularExpressionValidator ID="RegularExpressionValidator56" runat="server" ControlToValidate="duyurubaslik" CssClass="alert alert-danger" Display="Dynamic" ErrorMessage="3-75 karakter arası olabilir!" SetFocusOnError="True" ValidationExpression="^[\s\S]{3,75}$"></asp:RegularExpressionValidator>
                              </div>
                              <div class="form-group">
                                  <asp:Label ID="Label11" runat="server" Text="İçerik:"></asp:Label><br />
                                  <CKEditor:CKEditorControl ID="duyuruicerik" runat="server"></CKEditor:CKEditorControl>
                                  <br />
                              </div>
                            <div class="form-group">
                                <asp:Button ID="duyru_duzen" runat="server" Text="Duyuru Düzenle" CssClass="btn btn-primary pull-left" OnClick="duyru_duzen_Click" />
                              
                                <asp:Button ID="duyuru_ekle" runat="server" Text="Duyuru Ekle" CssClass="btn btn-primary pull-right" OnClick="duyuru_ekle_Click" />
                              </div>
                          </div>
                    </div>
                            </asp:View>
                            <asp:View ID="View6" runat="server">
                    <br />
                    <div class="panel panel-default">
                      <!-- Default panel contents -->
                      <div class="panel-heading">Yeni Bir Resim Yükle</div>
                        <br />
                        <asp:Literal ID="Literal2" runat="server"></asp:Literal>
                          <div class="panel-body" >
                              <div class="form-group">
                                  <asp:Label ID="Label12" runat="server" Text="Resim Seç:"></asp:Label><br />
                                  <asp:FileUpload ID="FileUpload1" runat="server" />
                              </div>
                            <div class="form-group">
                                <asp:Button ID="resimyukle" runat="server" Text="Resim Yükle" CssClass="btn btn-primary pull-right" OnClick="resimyukle_Click" />
                              </div>
                          </div>
                    </div>
                       <div class="panel panel-default">
                         <div class="panel-heading">Resimler</div>
                        <br />
                           <asp:DataList ID="DataList1" runat="server" RepeatColumns="2" OnItemCommand="DataList1_ItemCommand">
                               <ItemTemplate>
                                    <div class="row">
                                      <div class="col-xs-6 col-md-6">
                                        <a href="#" class="thumbnail">
                                            <asp:Label ID="resimyol2" runat="server" Text="<%# Container.DataItem %>" Visible="false"></asp:Label>
                                            <asp:Image ID="Image2" runat="server" ImageUrl="<%# Container.DataItem %>" /><br />
                                            <asp:Button ID="btnresimsil" runat="server" Text="Resimi Sil" CssClass="btn btn-danger" CommandName="siliver" />
                                        </a>
                                      </div>
                                    </div>
                               </ItemTemplate>
                           </asp:DataList>
                         </div>
                            </asp:View>

                <asp:View ID="View7" runat="server">
                    <br />
                    <div class="panel panel-default">
                      <!-- Default panel contents -->
                      <div class="panel-heading">Slider İçin Resim Yükle</div>
                        <br />
                        <asp:Literal ID="Literal1" runat="server"></asp:Literal>
                          <div class="panel-body" >
                              <div class="form-group">
                                  <asp:Label ID="Label20" runat="server" Text="Resim Seç:"></asp:Label><br />
                                  <asp:FileUpload ID="FileUpload2" runat="server" />
                              </div>
                            <div class="form-group">
                                <asp:Button ID="slider_yukle" runat="server" Text="Resim Yükle" CssClass="btn btn-primary pull-right" OnClick="slider_yukle_Click" />
                              </div>
                          </div>
                    </div>
                       <div class="panel panel-default">
                         <div class="panel-heading">Resimler</div>
                        <br />
                           <asp:DataList ID="DataList2" runat="server" RepeatColumns="2" OnItemCommand="DataList2_ItemCommand">
                               <ItemTemplate>
                                    <div class="row">
                                      <div class="col-xs-6 col-md-6">
                                        <a href="#" class="thumbnail">
                                            <asp:Label ID="resimyol" runat="server" Text="<%# Container.DataItem %>" Visible="false"></asp:Label>
                                            <asp:Image ID="Image2" runat="server" ImageUrl="<%# Container.DataItem %>" /><br />
                                            <asp:Button ID="btnresimsil" runat="server" Text="Resimi Sil" CssClass="btn btn-danger" CommandName="siliver" />
                                        </a>
                                      </div>
                                    </div>
                               </ItemTemplate>
                           </asp:DataList>
                         </div>
                            </asp:View>
                        </asp:MultiView>
                    </div>
                </div>
		    </div>
            </div>
                <script>
                    function gizleltr(literalid) {
                        setTimeout(function () {
                            $(literalid).hide(100);
                        }, 5000);
                    }
                </script>
            </ContentTemplate>
        </asp:UpdatePanel>
</asp:Content>

