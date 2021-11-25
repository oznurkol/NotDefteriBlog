<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="Hakkimizda.aspx.cs" Inherits="NotDefteriBlog.hakkimizda" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
   - Hakkımızda
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ortakisim" runat="server">
<div class="row">
    <div class="col-md-9 col-md-offset-1 bg-white main-border-4 mgb-30">
	    <h2>Hakkımızda</h2>
		    <hr />
        <asp:Literal ID="Literal1" runat="server"></asp:Literal>
			<hr />
		<div class="row">
		    <div class="col-md-9">
                <br />
		    </div>
	    </div>
    </div>
</div>
</asp:Content>
