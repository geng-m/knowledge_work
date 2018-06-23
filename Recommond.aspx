<%@ Page Language="C#" Debug="true" AutoEventWireup="true" CodeFile="Recommond.aspx.cs"
    Inherits="Main" %>

<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>

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
                    <asp:Label ID="Label1" runat="server" Text="输入类别"></asp:Label>
                    <asp:TextBox ID="txt_recommond" runat="server">Star_Wars</asp:TextBox>
                </td>
                
                <td style="width: 25%" align="center">
                   
                    <asp:Button ID="btn_search" runat="server" Text="查询" BackColor="White" 
                        BorderColor="#6666FF" ForeColor="#9966FF" onclick="btn_search_Click" />
                   
                </td>
            </tr>
        </table>

    </div>
    <div>
            <table style="width: 100%">
            <tr>
                <td align="center">
                    <asp:Chart ID="chart_show" runat="server" Width="782px">
                    <Series>
                        <asp:Series Name="Series1" IsValueShownAsLabel=true>
                        </asp:Series>
                    </Series>
                    <ChartAreas>
                        <asp:ChartArea Name="ChartArea1">
                        </asp:ChartArea>
                    </ChartAreas>
                </asp:Chart>
                </td>
            </tr>
            </table>
    </div>
        <asp:GridView ID="grid_data" runat="server" AutoGenerateColumns="False" CssClass="Check"
            Width="100%" CellPadding="4" ForeColor="#333333" GridLines="None">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:BoundField DataField="callret-1" HeaderText="电影名称">
                    <ItemStyle Height="20px" />
                </asp:BoundField>
                <asp:BoundField DataField="callret-0" HeaderText="相似级别">
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
        
    </form>
</body>
</html>
