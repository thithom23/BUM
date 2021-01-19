<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMaster.Master" AutoEventWireup="true" CodeBehind="QLKhachHang.aspx.cs" Inherits="BUMS.QLKhachHang" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <div class="content">
        <div class="container-fluid">
            <div class="row">
                <div class="col-md-12">
                    <div class="card">
                        <div class="header">
                            <h3 class="title">Thông tin khách hàng</h3>
                        </div>
                        <div class="content">                            
                            <div class="row">
                                <div class="col-md-6">
                                    <div class="form-group">
                                        <label>Họ và tên</label>
                                        <asp:Textbox ID="txtHoTen"  runat="server" class="form-control"></asp:Textbox>
                                    </div>
                                </div>
                                <div class="col-md-6">
                                    <div class="form-group">
                                        <label>Số điện thoại</label>
                                        <asp:Textbox ID="txtSDT" runat="server" class="form-control"></asp:Textbox>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-12">
                                    <div class="form-group">
                                        <label>Địa chỉ</label>
                                        <asp:Textbox ID="txtDiaChi" runat="server" class="form-control"></asp:Textbox>
                                    </div>
                                </div>
                            </div>                                
                            <asp:Button ID="btnCapNhat" runat="server" class="btn btn-info btn-fill pull-right" style="margin-left: 10px" Text="Cập nhật" OnClick="btnCapNhat_Click"/>
                            <asp:Button ID="btnThem" runat="server" class="btn btn-info btn-fill pull-right" Text="Thêm" OnClick="btnThem_Click"/>
                            <div class="clearfix"></div>                            
                        </div>
                    </div>
                </div>              
            </div>
            <div class="row">
                <div class="col-md-12">
                    <div class="card">
                        <div class="header">
                            <h3 class="title">Danh sách khách hàng</h3>
                        </div>
                        <div class="content table-responsive table-full-width">
                                <asp:GridView ID="gvKhachHang" class="table table-hover table-striped" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" Width="100%" OnSelectedIndexChanged="gvKhachHang_SelectedIndexChanged" OnRowDeleting="gvKhachHang_RowDeleting">
                                    <AlternatingRowStyle BackColor="White" />
                                    <Columns>
                                        <asp:BoundField DataField="MKH" HeaderText="Mã khách hàng" >
                                        </asp:BoundField>
                                        
                                        <asp:BoundField DataField="TenKH" HeaderText="Họ và tên">
                                        </asp:BoundField>
                                        <asp:BoundField DataField="DiaChiKH" HeaderText="Địa chỉ" >
                                        </asp:BoundField>
                                        <asp:BoundField DataField="SDTKH" HeaderText="Số điện thoại" >
                                        </asp:BoundField>
                                        
                                        <asp:CommandField ShowSelectButton="True" />

                                        <asp:CommandField ButtonType="Image" ShowDeleteButton="True" DeleteImageUrl="assets/img/delete.svg" DeleteText="Xóa" ControlStyle-Width="20px">
                                            
                                            <ControlStyle Width="20px"></ControlStyle>
                                            
                                        </asp:CommandField>
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
<asp:Content ID="Content1" runat="server" contentplaceholderid="ContentPlaceHolder1">
        
</asp:Content>

