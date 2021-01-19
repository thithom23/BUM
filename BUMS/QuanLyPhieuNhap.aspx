<%@ Page Language="C#" MasterPageFile="~/AdminMaster.Master" AutoEventWireup="true" CodeBehind="QuanLyPhieuNhap.aspx.cs" Inherits="BUMS.QuanLyPhieuNhap" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <%--<form runat="server">--%>
    <div class="content">
        <div class="container-fluid">
            <div class="row">
                <div class="col-md-full">
                    <div class="card">
                        <div class="header">
                            <h4 class="title">QUẢN LÝ PHIẾU NHẬP</h4>
                        </div>
                        <div class="content">
                            
                                <div class="row">
                                   
                                        <div class="col-md-6">
                                        
                                        <div class="form-group">
                                            <label>Mã phiếu nhập</label>
                                            <asp:textbox class="form-control" ID="txtMPN" Placeholder="Mã phiếu nhập" runat="server" ReadOnly="true"></asp:textbox>
                                         </div>
                                    </div>
                                        <div class="col-md-6">
                                        <div class="form-group">
                                            <label>Mã nhân viên</label>
                                            <asp:DropDownList class="form-control" ID="ddlMNV" runat="server"></asp:DropDownList>
                                        </div>
                                    </div>  
                                    
                                </div>
         
                            <div class="row">
                                    <div class="col-md-6">
                                        <div class="form-group">
                                            <label>Mã nhà cung cấp</label>
                                            <asp:DropDownList class="form-control" ID="ddlMNCC" runat="server"></asp:DropDownList>
                                       </div>
                                     </div>

                                      <div class="col-md-6">
                                        <div class="form-group">
                                             <label>Ngày nhập</label>
                                            <asp:textbox class="form-control" ID="txtNgayNhap" type="date" runat="server"></asp:textbox>                                        
                                        </div>
                                       
                                    </div>
                                    
                                    <div class="col-md-6">
                                        <div class="form-group">
                                             </div>
                                    </div>
                                    
                
                                </div>
                                <div class="clearfix">                                  
                                    <asp:Button ID="btnsua" text="Sửa" runat="server" OnClick="btnsua_Click" class="btn btn-info btn-fill pull-right" style="margin-left:5px" />
                                    <asp:Button ID="btnthem" text="Thêm" runat="server" OnClick="btnthem_Click" class="btn btn-info btn-fill pull-right" style="margin-left:5px" />
                                    <asp:Button ID="btnchitiet" text="Chi tiết" runat="server" OnClick="btnchitiet_Click" class="btn btn-info btn-fill pull-right" style="margin-left:5px" />
                                    
                                </div>
                            
                        </div>
                    </div>
                </div>

            </div>
            <div class="row">
                <div class="col-md-12">
                    <div class="card">
                        <div class="header">
                            <h4 class="title">Danh sách phiếu nhập</h4>
                        </div>
                        <div class="content table-responsive table-full-width">
                                <asp:GridView ID="gvPhieuNhap" class="table table-hover table-striped" 
                                    runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" 
                                    GridLines="None" Width="100%" DataKeyNames="MPN"
                                 OnRowDeleting="btnxoa_Click"
                                      onselectedindexchanging="gvPhieuNhap_SelectedIndexChanging">
                                    <AlternatingRowStyle BackColor="White" />
                                    <Columns>
                                        <asp:BoundField DataField="MPN" HeaderText="Mã phiếu nhập" SortExpression="MPN" InsertVisible="False" ReadOnly="True" >
                                        </asp:BoundField>
                                        <asp:BoundField DataField="MNV" HeaderText="Mã nhân viên" SortExpression="MNV">
                                        </asp:BoundField>
                                        <asp:BoundField DataField="MNCC" HeaderText="Mã nhà cung cấp" SortExpression="MNCC">
                                        </asp:BoundField>
                                        <asp:BoundField DataField="NgayNhap" HeaderText="Ngày nhập" SortExpression="NgayNhap">
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

