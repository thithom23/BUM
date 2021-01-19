<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMaster.Master" AutoEventWireup="true" CodeBehind="QLSanPham.aspx.cs" Inherits="BUMS.QLSanPham" %>

<asp:Content ID="Content5" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <%--<form runat="server">--%>
    <div class="content">
        <div class="container-fluid">
            <div class="row">
                <div class="col-md-8">
                    <div class="card">
                        <div class="header">
                            <h4 class="title">QUẢN LÝ SẢN PHẨM</h4>
                        </div>
                        <div class="content">
                            <div class="row">
                                <div class="col-md-6">
                                    <div class="form-group">
                                        <label>TÌM KIẾM</label>

                                        <asp:DropDownList ID="ddlTimKiem" class="form-control" runat="server" Width=" 150" OnSelectedIndexChanged="ddlTimKiem_SelectedIndexChanged" AutoPostBack="True">
                                            <asp:ListItem Selected="True" Value="All">Tất cả</asp:ListItem>
                                            <asp:ListItem Value="LoaiSP">Loại</asp:ListItem>
                                            <asp:ListItem Value="TenSP">Tên sản phẩm</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>

                                    <asp:TextBox ID="txtTimKiem" runat="server" class="form-control" placeholder="Nhập nội dung tìm kiếm" OnTextChanged="txtTimKiem_TextChanged"></asp:TextBox>


                                    <asp:Button ID="btnTimKiem" runat="server" OnClick="btnTimKiem_Click" Text="Tìm kiếm" class="btn btn-info btn-fill pull-right" Style="margin-left: 30px; margin-top: 10px" />



                                </div>
                            </div>




                            <div class="row">
                                <div class="col-md-6">
                                    <div class="form-group">
                                    <label>MÃ SẢN PHẨM</label>
                                    <asp:TextBox ID="txtMSP" runat="server" class="form-control" placeholder="Mã sản phẩm" ReadOnly></asp:TextBox>
                                </div>                                   
                                </div>
                                <div class="col-md-6">
                                    <div class="form-group">
                                        <label>ĐƠN VỊ TÍNH</label>
                                        <asp:TextBox ID="txtDonViTinh" runat="server" class="form-control" placeholder="Đơn vị tính"></asp:TextBox>
                                    </div>
                                </div>
                            </div>

                            <div class="row">
                                <div class="col-md-6">
                                     <div class="form-group">
                                        <label>TÊN SẢN PHẨM</label>
                                        <asp:TextBox ID="txtTenSP" runat="server" class="form-control" placeholder="Tên sản phẩm"></asp:TextBox>
                                    </div>
                                    
                                </div>
                                <div class="col-md-6">
                                    <div class="form-group">
                                        <label>SỐ LƯỢNG</label>
                                        <asp:TextBox ID="txtSoLuong" runat="server" class="form-control" placeholder="Số lượng" ReadOnly></asp:TextBox>
                                    </div>
                                </div>
                                </div>
                                <div class ="row">
                                <div class="col-md-6">
                                    <div class="form-group">
                                        <label>LOẠI SẢN PHẨM</label>
                                        <asp:DropDownList ID="ddlLoaiSP" class="form-control" runat="server">
                                            <asp:ListItem>Văn phòng phẩm</asp:ListItem>
                                            <asp:ListItem>Sách</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                    </div>
                                    <div class="col-md-6">
                                    <div class="form-group">
                                        <label>GIÁ NHẬP</label>
                                        <asp:TextBox ID="txtDonGiaNhap" runat="server" class="form-control" placeholder="Giá nhập"></asp:TextBox>
                                    </div>
                                
                                    </div>
                                    </div>
                                <div class ="row">
                                <div class="col-md-6">
                                    <div class="form-group">
                                        <label>GIÁ BÁN</label>
                                        <asp:TextBox ID="txtDonGiaBan" runat="server" class="form-control" placeholder="Giá bán"></asp:TextBox>
                                    </div>
                                </div>



                                <div class="clearfix">
                                    <asp:Button ID="btnCapNhat" runat="server" OnClick="btnCapNhat_Click1" Text="Cập nhật" class="btn btn-info btn-fill pull-right" Style="margin-right: 30px" />
                                </div>

                            </div>
                            
                            
                                </div>
                        </div>
                    </div>
        </div>
            <div class="row">
                <div class="col-md-12">
                    <div class="card">
                        <div class="header">
                            <h4 class="title">Danh sách sản phẩm</h4>
                            <p class="category">Here is a subtitle for this table</p>
                        </div>
                        <div class="content table-responsive table-full-width">
                                <asp:GridView ID="gvSanPham"
                                     class="table table-hover table-striped" 
                                    runat="server" AutoGenerateColumns="False" 
                                    CellPadding="4" ForeColor="#333333" GridLines="None"
                                     Width="100%" DataKeyNames="MSP"
                                     AllowSorting="True"
                                     OnSorting="gvSanPham_Sorting"
                                 
                                      onselectedindexchanging="gvSanPham_SelectedIndexChanging" >
                                    <AlternatingRowStyle BackColor="White" />
                                    <Columns>        
                                        <asp:BoundField DataField="MSP" HeaderText="Mã sản phẩm">
                                        </asp:BoundField>                                
                                        <asp:BoundField DataField="TenSP" HeaderText="Tên sản phẩm">
                                        </asp:BoundField>
                                        <asp:BoundField DataField="LoaiSP" HeaderText="Loại sản phẩm">
                                        </asp:BoundField>
                                        <asp:BoundField DataField="DVT" HeaderText="Đơn vị tính">
                                        </asp:BoundField>
                                        <asp:BoundField DataField="SoLuong" HeaderText="Số lượng" SortExpression ="SoLuong" />
                                        <asp:BoundField DataField="DonGiaNhap" HeaderText="Giá nhập" /> 
                                        <asp:BoundField DataField="DonGiaBan" HeaderText="Giá bán" />                                       
                                        <asp:CommandField SelectText="Chọn" ShowSelectButton="True" />
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
    <script type="text/javascript"> 
  
        function clickButton(e, buttonid)
        {   
          var evt = e ? e : window.event;  
          var bt = document.getElementById(buttonid);  
  
          if (bt){
              if (evt.keyCode == 13){   
                    bt.click();   
                    return false;   
              }   
          }   
        }  
    </script>

</asp:Content>
