<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="NotDefteriBlog.Index" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    - Ana Sayfa
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="ortakisim" runat="server">
    			<div class="row">
                    
                    <asp:Repeater ID="Repeater1" runat="server">
                        <ItemTemplate>
                            <div class="col-md-9 col-md-offset-1 bg-white main-border-4 mgb-30">
                            <h2><%# Eval("baslik") %></h2>
                            <hr />
                            <%# Eval("icerik") %>
                            <hr />
					        <div class="row">
						        <div class="col-md-9">
							        <h6>Tarih: <%# Eval("tarih")%></h6>
							        <h6>Yazar: <%# Eval("yazar")%></h6>
						        </div>
						        <div class="col-md-3">
							    <a href="YaziGoruntule.aspx?id=<%# Eval("yaziid")%>"><button type="button" class="btn btn-primary pull-right">Devamı İçin >></button></a>
						    </div>
					        </div>
                             </div>
                            <div class="col-md-2 main-border-3 bg-white"><%# Eval("kate_baslik")%></div>
                        </ItemTemplate>
                    </asp:Repeater>
			</div>
</asp:Content>

