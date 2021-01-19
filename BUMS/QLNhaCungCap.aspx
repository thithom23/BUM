<%@ Page Language="C#" AutoEventWireup="true"  Masterpagefile="~/AdminMaster.Master" CodeBehind="QLNhaCungCap.aspx.cs" Inherits="BUMS.QLNhaCungCap" %>

<asp:Content ID="Content6" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <%--<form runat="server">--%>
    <div class="content">
        <div class="container-fluid">
            <div class="row">
                <div class="col-md-full">
                    <div class="card">
                        <div class="header">
                            <h4 class="title">QUẢN LÝ NHÀ CUNG CẤP</h4>
                        </div>
                        <div class="content">                            
                                <div class="row">                                   
                                        <div class="col-md-6">                                        
                                        <div class="form-group">
                                            <label>MÃ NHÀ CUNG CẤP</label> 
                                            <asp:TextBox ID="txtMNCC" runat="server" class="form-control" placeholder="Mã nhà cung cấp" readonly></asp:TextBox>                                           
                                         </div>
                                    </div>
                                        <div class="col-md-6">
                                        <div class="form-group">
                                            <label>TÊN NHÀ CUNG CẤP</label>     
                                            <asp:TextBox ID="TenNCC" runat="server" class="form-control" placeholder="Nhập tên nhà cung cấp"></asp:TextBox>                                      
                                        </div>
                                    </div>  
                                    
                                </div>
         
                            <div class="row">
                                    <div class="col-md-6">
                                        <div class="form-group">
                                            <label>ĐỊA CHỈ</label>  
                                            <asp:TextBox ID="txtDiaChiNCC" runat="server" class="form-control" placeholder="Nhập địa chỉ nhà cung cấp"></asp:TextBox>                                          
                                       </div>
                                     </div>

                                      <div class="col-md-6">
                                        <div class="form-group">
                                             <label>SỐ ĐIỆN THOẠI</label>    
                                            <asp:TextBox ID="txtSDTNCC" runat="server" class="form-control" placeholder="Nhập số điện thoại nhà cung cấp"></asp:TextBox>                                        
                                        </div>
                                       
                                    </div>
                                    
                                    <div class="col-md-6">
                                        <div class="form-group">
                                             </div>
                                    </div>
                                    
                
                                </div>
                                <div class="clearfix">                                    
                                    <asp:Button ID="btnsua" text="Cập nhật" runat="server"  OnClick="btnsua_Click" Class="btn btn-info btn-fill pull-right" style="margin-left:5px" />
                                    <asp:Button ID="btnthem" text="Thêm" runat="server"  class="btn btn-info btn-fill pull-right" style="margin-left:5px" OnClick="btnthem_Click" />
                                           
                                </div>
                            
                        </div>
                    </div>
                </div>

            </div>
            <div class="row">
                <div class="col-md-12">
                    <div class="card">
                        <div class="header">
                            <h4 class="title">Danh sách Nhà cung cấp</h4>
                        </div>
                        <div class="content table-responsive table-full-width">
                                <asp:GridView ID="gvNCC" class="table table-hover table-striped" 
                                    runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" 
                                    GridLines="None" Width="100%" DataKeyNames="MNCC"
                                    OnRowDeleting="gvNCC_RowDeleting"
                                 
                                      onselectedindexchanging="gvNCC_SelectedIndexChanging">
                                    <AlternatingRowStyle BackColor="White" />
                                    <Columns>
                                        <asp:BoundField DataField="MNCC" HeaderText="Mã nhà cung cấp" SortExpression="MNCC" InsertVisible="False" ReadOnly="True" >
                                        </asp:BoundField>
                                        <asp:BoundField DataField="TenNCC" HeaderText="Tên nhà cung cấp" SortExpression="TenNCC">
                                        </asp:BoundField>
                                        <asp:BoundField DataField="DiaChiNCC" HeaderText="Địa chỉ" SortExpression="DiaChiNCC">
                                        </asp:BoundField>
                                        <asp:BoundField DataField="SDTNCC" HeaderText="Số điện thoại" SortExpression="SDTNCC">
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