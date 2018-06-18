<%@ Page Language="C#" Debug="true" AutoEventWireup="true" CodeFile="Main.aspx.cs"
    Inherits="Main" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<link href="resource/css/gridcss.css" rel="stylesheet" type="text/css" />
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table style="width: 100%">
            <tr>
                
                <td style="width: 25%" align="center">
                    <asp:Label ID="Label1" runat="server" Text="Name:"></asp:Label>
                    <asp:TextBox ID="txt_search" runat="server">War</asp:TextBox>
                </td>
                
                <td style="width: 25%" align="center">
                   
                    <asp:Button ID="btn_search" runat="server" Text="查询" BackColor="White" 
                        BorderColor="#6666FF" ForeColor="#9966FF" onclick="btn_search_Click" />
                   
                </td>
            </tr>
        </table>
    </div>
    <div>
        <asp:GridView ID="grid_data" runat="server" AutoGenerateColumns="False" CssClass="Check"
            Width="100%" CellPadding="4" ForeColor="#333333" GridLines="None">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:BoundField DataField="url" HeaderText="地址">
                    <ItemStyle Height="20px" />
                </asp:BoundField>
                <asp:BoundField DataField="label" HeaderText="标签">
                    <ItemStyle Height="20px" />
                </asp:BoundField>
                <asp:BoundField DataField="name" HeaderText="名称">
                    <ItemStyle Height="20px" />
                </asp:BoundField>
                <asp:BoundField DataField="wikiPageID" HeaderText="wiki地址">
                    <ItemStyle Height="20px" />
                </asp:BoundField>
                <asp:BoundField DataField="abstract" HeaderText="摘要">
                    <ItemStyle Height="20px" />
                </asp:BoundField>
                <asp:BoundField DataField="writer" HeaderText="作者">
                    <ItemStyle Height="20px" />
                </asp:BoundField>
            </Columns>
            <EditRowStyle BackColor="#7C6F57" />
            <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#E3EAEB" Height="20px" />
            <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#F8FAFA" />
            <SortedAscendingHeaderStyle BackColor="#246B61" />
            <SortedDescendingCellStyle BackColor="#D4DFE1" />
            <SortedDescendingHeaderStyle BackColor="#15524A" />
        </asp:GridView>
    </div>
    </form>
</body>
</html>
