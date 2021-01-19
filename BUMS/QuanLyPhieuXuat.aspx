<%@ Page Language="C#" MasterPageFile="~/AdminMaster.Master" AutoEventWireup="true" CodeBehind="QuanLyPhieuXuat.aspx.cs" Inherits="BUMS.QuanLyPhieuXuat" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <%--<form runat="server">--%>
    <div class="content">
        <div class="container-fluid">
            <div class="row">
                <div class="col-md-full">
                    <div class="card">
                        <div class="header">
                            <h4 class="title">QUẢN LÝ PHIẾU XUẤT</h4>
                        </div>
                        <div class="content">
                            
                                <div class="row">
                                   
                                        <div class="col-md-6">
                                        
                                        <div class="form-group">
                                            <label>Mã phiếu xuất</label>
                                            <asp:textbox class="form-control" ID="txtMPX" runat="server" ReadOnly="true"></asp:textbox>
                                         </div>
                                    </div>
                                        <div class="col-md-6">
                                        <div class="form-group">
                                            <label>Mã khách hàng</label>
                                            <asp:DropDownList class="form-control" ID="ddlMKH" runat="server"></asp:DropDownList>
                                        </div>
                                    </div>  
                                    
                                </div>
         
                            <div class="row">
                                    <div class="col-md-6">
                                        <div class="form-group">
                                            <label>Mã nhân viên</label>
                                            <asp:DropDownList class="form-control" ID="ddlMNV" runat="server"></asp:DropDownList>
                                       </div>
                                     </div>

                                      <div class="col-md-6">
                                        <div class="form-group">
                                             <label>Ngày xuất</label>
                                          <asp:textbox class="form-control" ID="txtNgayXuat" type="date" runat="server"></asp:textbox>
                                             
                                          
                                        </div>
                                       
                                    </div>
                                    
                                    <div class="col-md-6">
                                        <div class="form-group">
                                             </div>
                                    </div>
                                    
                
                                </div>
                                <div class="clearfix">
                                    <asp:Button ID="btnin" text="In" runat="server" OnClientClick = "window.print ();" class="btn btn-info btn-fill pull-right" style="margin-left:5px" />
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
                            <h4 class="title">Danh sách phiếu xuất</h4>
                        </div>
                        <div class="content table-responsive table-full-width">
                                <asp:GridView ID="gvphieuxuat" class="table table-hover table-striped" 
                                    runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" 
                                    GridLines="None" Width="100%" DataKeyNames="MPX"
                                        OnRowDeleting="btnxoa_Click"
                                      onselectedindexchanging="gvphieuxuat_SelectedIndexChanging">
                                    <AlternatingRowStyle BackColor="White" />
                                    <Columns>
                                        <asp:BoundField DataField="MPX" HeaderText="Mã phiếu xuất" SortExpression="MPX" InsertVisible="False" ReadOnly="True" >
                                        </asp:BoundField>
                                        <asp:BoundField DataField="MKH" HeaderText="Mã khách hàng" SortExpression="MKH">
                                        </asp:BoundField>
                                        <asp:BoundField DataField="MNV" HeaderText="Mã nhân viên" SortExpression="MNV" >
                                        </asp:BoundField>
                                        <asp:BoundField DataField="NgayXuat" HeaderText="Ngày xuất" SortExpression="NgayXuat">
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
