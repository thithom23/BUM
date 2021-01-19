using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BUMS
{
    public partial class QLKhachHang : System.Web.UI.Page
    {
        ADO ado = new ADO();
        protected void Load_GridKH()
        {
            gvKhachHang.DataSource = ado.Get_Data_KhachHang();
            gvKhachHang.DataBind();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["quyen"].ToString() == "")
                Response.Redirect("Login.aspx");
            if (!IsPostBack)
            {
                Load_GridKH();
            }
        }
        protected void btnThem_Click(object sender, EventArgs e)
        {
            if (txtHoTen.Text != "")
            {
                KhachHang khachhang = new KhachHang();
                khachhang.TenKH = txtHoTen.Text;
                khachhang.DiaChiKH = txtDiaChi.Text;
                khachhang.SDTKH = txtSDT.Text;
                if (ado.Check_KhachHang(khachhang))
                {
                    Response.Write("<script>alert('Khách hàng này đã tồn tại trong cơ sở dữ liệu!');</script>");
                }
                else
                {
                    if (ado.Insert_KhachHang(khachhang))
                    {
                        Response.Write("<script>alert('Tạo mới thành công');</script>");
                        Load_GridKH();
                    }
                    else
                    {
                        Response.Write("<script>alert('Sự cố hệ thống, không thể tạo mới!');</script>");
                    }
                }
                    
            }
            else
            {
                Response.Write("<script>alert('Bạn cần phải nhập Họ và tên.');</script>");
            }
        }

        

        protected void gvKhachHang_SelectedIndexChanged(object sender, EventArgs e)
        {
            string idkhachhang = gvKhachHang.SelectedRow.Cells[0].Text;
            Variable.ID = idkhachhang;
            DataTable table = new DataTable();
            table = ado.Get_Data_KhachHangLenForm(idkhachhang);

            if (table != null)
            {
                Dodulieulenform(table);
            }
        }

        protected void Dodulieulenform(DataTable table)
        {
            txtHoTen.Text = table.Rows[0].ItemArray[1].ToString();
            txtDiaChi.Text = table.Rows[0].ItemArray[2].ToString();
            txtSDT.Text = table.Rows[0].ItemArray[3].ToString();
            
        }

        protected void btnCapNhat_Click(object sender, EventArgs e)
        {
            if (txtHoTen.Text != "")
            {
                    
                KhachHang khachhang = new KhachHang();
                khachhang.MKH = Variable.ID;
                khachhang.TenKH = txtHoTen.Text;
                khachhang.DiaChiKH = txtDiaChi.Text;
                khachhang.SDTKH = txtSDT.Text;
                if (ado.Check_KhachHang(khachhang))
                {
                    Response.Write("<script>alert('Khách hàng này đã tồn tại trong cơ sở dữ liệu!');</script>");
                }
                else
                {
                    if (ado.Update_KhachHang(khachhang))
                    {
                        Response.Write("<script>alert('Cập nhật thành công');</script>");
                        Load_GridKH();
                    }
                    else
                    {
                        Response.Write("<script>alert('Sự cố hệ thống, không thể cập nhật!');</script>");
                    }
                }
                    
            }
            else
            {
                Response.Write("<script>alert('Bạn cần phải nhập Họ và tên.');</script>");
            }
        }

        protected void gvKhachHang_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                KhachHang khachhang = new KhachHang();
                khachhang.MKH = gvKhachHang.Rows[e.RowIndex].Cells[0].Text;
                if (ado.Delete_KhachHang(khachhang))
                {
                    Response.Write("<script> alert('Xóa thành công'); </script>");
                    Load_GridKH();
                }
                else
                {
                    Response.Write("<script> alert('Sự cố hệ thống, không thể xóa!'); </script>");
                }
            }
            catch (Exception)
            {
                Response.Write("<script> alert('Sự cố hệ thống, không thể xóa!'); </script>");
            }
        }
    }
}