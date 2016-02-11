<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Cities Population</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <br />
        Population of Largest U.S. Cities<br />
        <br />
        <br />
        <asp:Label ID="lblState" runat="server" Text="Select State:"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="lblCity" runat="server" Text="Select City:"></asp:Label>
        <br />
        <asp:DropDownList ID="ddlState" runat="server" Height="19px" Width="141px" AutoPostBack="True" OnSelectedIndexChanged="ddlState_SelectedIndexChanged">
        </asp:DropDownList>
&nbsp;&nbsp;&nbsp;
        <asp:DropDownList ID="ddlCities" runat="server" Height="19px" Width="141px" AutoPostBack="True" OnSelectedIndexChanged="ddlCities_SelectedIndexChanged">
        </asp:DropDownList>
&nbsp;
        <asp:Label ID="lblPopulation" runat="server" Text="Population"></asp:Label>
        <br />
        <br />
    
    </div>
    </form>
</body>
</html>
