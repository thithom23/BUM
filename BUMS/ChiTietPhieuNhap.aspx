<%@ Page Language="C#" MasterPageFile="~/AdminMaster.Master" AutoEventWireup="true" CodeBehind="ChiTietPhieuNhap.aspx.cs" Inherits="BUMS.ChiTietPhieuNhap" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <%--<form runat="server">--%>
    
    <div class="content">
        <div class="container-fluid">     
            <div class="row">
         <div class="col-md-12">
             <div class="card">

                  <div class="content">
                     <div class="clearfix">
                          
                          <asp:Button ID="Button1" text="Quay Lại" runat="server" OnClick="btnback_Click" class="btn btn-info btn-fill pull-left" style="margin-left:10px" />
                      </div>
                  </div>
              </div>
    
            </div>
     </div>
                <div class="row">
                <div class="col-md-12">
                    <div class="card">
                        
                        <div class="header">
                            
                            <h4 class="title">CHI TIẾT PHIẾU NHẬP</h4>
                        </div>

                        <div class="content">
                            
                                <div class="row">
                                   
                                         <div class="col-md-6">
                                        
                                         <div class="form-group">
                                            <label>Mã phiếu nhập</label>
                                            <asp:label  ID="lblMPN" runat="server"></asp:label>
                                         </div>
                                         </div>
                                    <div class="col-md-6">
                                        <div class="form-group">
                                            <label>Mã sản phẩm</label>
                                            <asp:Textbox class="form-control" ID="txtMSP" runat="server"></asp:Textbox>
                                        </div>
                                    </div>
                                </div>
                                   <div class="row">
                                   
                                        <div class="col-md-6">
                                        <div class="form-group">
                                            <label>Mã nhân viên</label>
                                            <asp:label ID="lblMNV" runat="server"></asp:label>
                                        </div>
                                        </div>
                                        <div class="col-md-6">
                                        <div class="form-group">
                                            <label>Số lượng</label>
                                            <asp:Textbox class="form-control" ID="txtsoluong" runat="server"></asp:Textbox>
                                        </div>
                                        </div>
                                    </div>
         
                            <div class="row">
                                    <div class="col-md-12">
                                        <div class="form-group">
                                            <label>Mã nhà cung cấp</label>
                                            <asp:label  ID="lblMNCC" runat="server"></asp:label>
                                       </div>
                                        </div>
                                    <div class="col-md-6">
                                        <div class="form-group">
                                             <label>Ngày nhập</label>
                                            <asp:label ID="lblngaynhap" runat="server"></asp:label>
                                        </div>
                                       
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
                            <h4 class="title">Danh sách sản phẩm của phiếu</h4>
                        </div>
                        <div class="content table-responsive table-full-width">
                                <asp:GridView ID="gvchitietphieunhap"  class="table table-hover table-striped" 
                                    runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" 
                                    GridLines="None" Width="100%" DataKeyNames="MSP"
                                    OnRowDeleting="btnxoa_Click"
                                      onselectedindexchanging="gvchitietphieunhap_SelectedIndexChanging">
                                    <AlternatingRowStyle BackColor="White" />
                                    <Columns>
                                        <asp:BoundField DataField="MSP" HeaderText="Mã sản phẩm" SortExpression="MSP" InsertVisible="False" ReadOnly="True" >
                                        </asp:BoundField>
                                        <asp:BoundField DataField="SoLuongNhap" HeaderText="Số lượng nhập" SortExpression="SoLuongNhap">
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
