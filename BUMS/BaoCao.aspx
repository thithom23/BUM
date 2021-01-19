<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMaster.Master" AutoEventWireup="true" CodeBehind="BaoCao.aspx.cs" Inherits="BUMS.BaoCao" %>

<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <div class="content">
        <div class="container-fluid">
            <div class="row">
                <div class="col-md-4">
                    <div class="card">
                        
                        <div class="content">
                                
                                <div class="row">
                                    <div class="col-md-5">
                                        <div class="form-group">
                                            <label>Năm</label>
                                            <asp:DropDownList ID="dropNam" class="form-control" runat="server" >
                                                <asp:ListItem>2021</asp:ListItem>
                                            </asp:DropDownList>
                                            <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="ddlistNhanVien" ErrorMessage="Không được để trống mục này" ForeColor="Red" OnLoad="Page_Load"></asp:RequiredFieldValidator>--%>
                                        </div>

                                    </div>
                                    
                
                                </div>

                                
                                <asp:Button ID="btnThongKe" runat="server" class="btn btn-info btn-fill pull-right" Text="Thống kê" OnClick="btnThongKe_Click" />
                                <div class="clearfix"></div>
                        </div>
                    </div>
                </div>

            </div>
            <div class="row">
                <div class="col-md-12">
                    <div class="card">
                        <div class="header">
                            <h3 class="title">Biểu đồ</h3>
                        </div>
                        <div class="content table-responsive table-full-width">
                            <asp:Chart ID="Chart1" runat="server" BorderlineWidth="0" Width="1000px" Visible="False">
                                <Series>
                                    <asp:Series Name="Series1" XValueMember="Thang" YValueMembers="DoanhThu"
                                        LegendText="Doanh thu" IsValueShownAsLabel="true" ChartArea="ChartArea1"
                                        MarkerBorderColor="#DBDBDB">
                                    </asp:Series>
                                </Series>
                                <Legends>
                                    <asp:Legend Title="Chú thích" />
                                </Legends>
                                <Titles>
                                    <asp:Title Docking="Top" Text="Báo cáo bán hàng" />
                                </Titles>
                                <ChartAreas>
                                    <asp:ChartArea Name="ChartArea1"></asp:ChartArea>
                                </ChartAreas>
                            </asp:Chart>        
                        </div>
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col-md-12">
                    <div class="card">
                        <div class="header">
                            <h3 class="title">Bảng thống kê</h3>
                        </div>
                        <div class="content table-responsive table-full-width">
                                <asp:GridView ID="gvThongKe" class="table table-hover table-striped" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" Width="100%" Visible="False" >
                                    <AlternatingRowStyle BackColor="White" />
                                    <Columns>
                                        <asp:BoundField DataField="Thang" HeaderText="Tháng">
                                            <ItemStyle Width="10%" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="DoanhThu" HeaderText="Doanh thu">
                                            <ItemStyle Width="10%" />
                                        </asp:BoundField>
                                        
                                        
                                    </Columns>
                                    <EditRowStyle BackColor="#2461BF" />
                                    <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                    <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                    <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                                    <RowStyle BackColor="#EFF3FB" />
                                    <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                    <SortedAscendingCellStyle BackColor="#F5F7FB" />
                                    <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                                    <SortedDescendingCellStyle BackColor="#E9EBEF" />
                                    <SortedDescendingHeaderStyle BackColor="#4870BE" />
                                </asp:GridView>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

