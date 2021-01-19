<%@ Page Language="C#" MasterPageFile="~/AdminMaster.Master" AutoEventWireup="true" CodeBehind="QuanLyNhanVien.aspx.cs" Inherits="BUMS.QuanLyNhanVien" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <%--<form runat="server">--%>
    
    <div class="content">
        <div class="container-fluid">     
                <div class="row">
                <div class="col-md-12">
                    <div class="card">
                        <div class="header">
                            <h4 class="title">QUẢN LÝ NHÂN VIÊN</h4>
                        </div>
                        <div class="content">
                                <div class="row">
                                         <div class="col-md-6">
                                         <div class="form-group">
                                            <label>Họ Tên</label>
                                            <asp:textbox ID="txthoten" class="form-control" runat="server"></asp:textbox>
                                        </div>
                                         </div>
                                    <div class="col-md-6">
                                        <div class="form-group">
                                            <label>Mật khẩu</label>
                                            <asp:Textbox class="form-control" ID="txtmatkhau" runat="server"></asp:Textbox>
                                        </div>
                                    </div>
                                </div>
                                   <div class="row">
                                   
                                        <div class="col-md-6">
                                        <div class="form-group">
                                            <label>Số điện thoại</label>
                                            <asp:textbox  ID="txtsdt" class="form-control" runat="server"></asp:textbox>
                                       </div>
                                        </div>
                                        <div class="col-md-6">
                                        <div class="form-group">
                                            <label>Ngày sinh</label>
                                            <asp:Textbox class="form-control" Type="date" ID="txtngaysinh" runat="server"></asp:Textbox>
                                        </div>
                                        </div>
                                    </div>
         
                            <div class="row">
                                    <div class="col-md-6">
                                        
                                        </div>
                                </div>
                                <div class="clearfix">
                                     <asp:Button ID="btnsua" text="Sửa" runat="server" OnClick="btnsua_Click" class="btn btn-info btn-fill pull-right" style="margin-left:5px" />
                                    <asp:Button ID="btnthem" text="Thêm" runat="server" OnClick="btnthem_Click" class="btn btn-info btn-fill pull-right" style="margin-left:5px" />
                                </div>
                            
                        </div>
                    </div>
                </div>

            </div>
            <div class="row">
                <div class="col-md-12">
                    <div class="card">
                        <div class="header">
                            <h4 class="title">Danh sách nhân viên</h4>
                        </div>
                        <div class="content table-responsive table-full-width">
                                <asp:GridView ID="gvnhanvien"  class="table table-hover table-striped" 
                                    runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" 
                                    GridLines="None" Width="100%" DataKeyNames="MNV"
                                    OnRowDeleting="btnxoa_Click"
                                      onselectedindexchanging="gvnhanvien_SelectedIndexChanging">
                                    <AlternatingRowStyle BackColor="White" />
                                    <Columns>
                                        <asp:BoundField DataField="MNV" HeaderText="Mã nhân viên" SortExpression="MNV" InsertVisible="False" ReadOnly="True" >
                                        </asp:BoundField>
                                        <asp:BoundField DataField="MatKhau" HeaderText="Mật khẩu" SortExpression="MatKhau">
                                        </asp:BoundField>
                                        <asp:BoundField DataField="HoTenNV" HeaderText="Họ tên" SortExpression="HoTenNV">
                                        </asp:BoundField>
                                        <asp:BoundField DataField="NgaySinh" HeaderText="Ngày Sinh" SortExpression="NgaySinh">
                                        </asp:BoundField>
                                        <asp:BoundField DataField="SDTNV" HeaderText="Số điện thoại" SortExpression="SDTNV">
                                        </asp:BoundField>
                                        <asp:CommandField SelectText="Chọn" ShowSelectButton="True" />
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
        <%--</form>--%>
</asp:Content>

 
