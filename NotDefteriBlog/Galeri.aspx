<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="Galeri.aspx.cs" Inherits="NotDefteriBlog.Galeri" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    - Galeri
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="updatepanel" runat="server">
    
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ortakisim" runat="server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <asp:Timer ID="Timer1" runat="server" Enabled="False" Interval="10000" OnTick="Timer1_Tick"></asp:Timer>
    <div class="row">
    <div class="col-md-9 col-md-offset-1 bg-white main-border-4 mgb-30">
        <br />
                <div class="row">
                  <div class="col-xs-12 col-md-12">
                     <a href="#" class="thumbnail">
                         <asp:Image ID="Image1" runat="server" />
                     </a>
                    </div>
                    <div class="col-md-5">
                        <asp:Button ID="Geri" runat="server" Text="Geri" CssClass="btn btn-info pull-left" OnClick="Geri_Click" />
                    </div>
                    <div class="col-md-5">
                        <asp:Button ID="oynat" runat="server" Text="Oynat/Durdur" CssClass="btn btn-info" OnClick="oynat_Click" />
                    </div>
                    <div class="col-md-2">
                        <asp:Button ID="Ileri" runat="server" Text="İleri" CssClass="btn btn-info pull-right" OnClick="Ileri_Click" />
                    </div>
                  </div>
        <br />
    </div>

    <div class="col-md-9 col-md-offset-1 bg-white main-border-4 mgb-30">
        <br />
        <asp:DataList ID="DataList1" runat="server" RepeatColumns="3">
            <ItemTemplate>
                <div class="row">
                  <div class="col-xs-6 col-md-6">
                     <a href="#" class="thumbnail">
                         <asp:Image ID="Image2" runat="server" ImageUrl="<%# Container.DataItem %>" CssClass="" OnClick="resim(this.src);" />
                     </a>
                    </div>
                  </div>
            </ItemTemplate>
        </asp:DataList>
    </div>
</div>

        </ContentTemplate>
    </asp:UpdatePanel>

</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="scriptmanager_bitis" runat="server">
</asp:Content>
