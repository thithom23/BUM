using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
namespace BUMS
{
    public partial class QuanLyNhanVien : System.Web.UI.Page
    {
       
        ADO ado = new ADO();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["quyen"].ToString() == "")
                Response.Redirect("Login.aspx");
            else
            if (Session["quyen"].ToString() != "Admin")
                Response.Redirect("QLSanPham.aspx");
            if (!IsPostBack)
            {
               
                Loadnhanvien();
                txtngaysinh.Text = Convert.ToDateTime(DateTime.Now).Date.ToString("yyyy-MM-dd");
                //ddlMNV = Session["Manhanvien"];
                Session["PageIndex"] = 0;
                
            }
        }
        public void Loadnhanvien()
        {
            DataTable dt = new DataTable();
            dt = ado.Loadnhanvien();
            gvnhanvien.DataSource = dt.DefaultView;
            gvnhanvien.DataBind();

        }


        protected void gvnhanvien_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            DataTable dt = new DataTable();
            dt = ado.Loadnhanvien();
            Session["PageIndex"] = e.NewPageIndex;
            gvnhanvien.DataSource = dt.DefaultView;
            gvnhanvien.PageIndex = e.NewPageIndex;
            gvnhanvien.DataBind();
        }
        protected void btnthem_Click(object sender, EventArgs e)
        {

            //      pn.MPN1 = int.Parse(txtMPN.Text);

            if ( txthoten.Text == "" || txtmatkhau.Text == "" || txtngaysinh.Text == "" || txtsdt.Text == "")
                Response.Write("<script>alert('Chưa nhập đủ thông tin');</script>");
            else if(txtsdt.Text.Length!=10)
                Response.Write("<script>alert('Nhập sai số điện thoại (10 số)');</script>");
            else
            {
                nhanvien pn = new nhanvien();
                pn.Matkhau1 = txtmatkhau.Text;
                pn.Hoten1 = txthoten.Text;
                pn.Ngaysinh1 = DateTime.Parse(txtngaysinh.Text);
                pn.Sdt = txtsdt.Text;
                if (ado.themnhanvien(pn))
                {
                    Response.Write("<script>alert('Đã thêm');</script>");
                     txtmatkhau.Text = "";
                    txthoten.Text = "";
                    txtsdt.Text = "";
                }
                else
                    Response.Write("<script>alert('Không thể thêm');</script>");
                Loadnhanvien();
            }
        }

        protected void btnsua_Click(object sender, EventArgs e)
        {
            if(Variable.ID=="") Response.Write("<script>alert('Hãy chọn và nhập dữ liệu cho nhân viên cần sửa');</script>");
             else if (txtsdt.Text.Length != 10)
                Response.Write("<script>alert('Nhập sai số điện thoại (10 số)');</script>");
             else
            if ( txthoten.Text == "" || txtmatkhau.Text == "" || txtngaysinh.Text == "" || txtsdt.Text == "")
                Response.Write("<script>alert('Chưa nhập đủ thông tin');</script>");
            else
            {
                nhanvien pn = new nhanvien();
                pn.MNV1 = int.Parse(Variable.ID) ;
                pn.Matkhau1 = txtmatkhau.Text;
                pn.Hoten1 = txthoten.Text;
                pn.Ngaysinh1 = DateTime.Parse(txtngaysinh.Text);
                pn.Sdt = txtsdt.Text;
                ado.suanhanvien(pn);
                Response.Write("<script>alert('Đã sửa');</script>");
                Loadnhanvien();
                Variable.ID = "";
                txtmatkhau.Text = "";
                txthoten.Text = "";
                txtsdt.Text = "";
            }
        }

        protected void btnxoa_Click(object sender, GridViewDeleteEventArgs e)
        {
            /*if (Variable.ID == "") Response.Write("<script>alert('Vui lòng chọn nhân viên và bấm nút xóa');</script>");
            else
            if (ado.xoanhanvien(int.Parse(Variable.ID)))
            {
                Response.Write("<script>alert('Đã xóa');</script>");
                Loadnhanvien(); 
                txtmatkhau.Text = "";
                txthoten.Text = "";
                txtsdt.Text = "";
            }
            else
                Response.Write("<script>alert('Không thể xóa');</script>");
            Variable.ID = "";
            */
            try
            {
                int ma = int.Parse(gvnhanvien.Rows[e.RowIndex].Cells[0].Text);
                if (ado.xoanhanvien(ma))
                {
                    Response.Write("<script> alert('Xóa thành công'); </script>");
                    Loadnhanvien();
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

        protected void gvnhanvien_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            Variable.ID  = gvnhanvien.DataKeys[e.NewSelectedIndex].Value.ToString();
            nhanvien pn = new nhanvien();
            
            pn = ado.laynhanvien(int.Parse(Variable.ID));
            txthoten.Text = pn.Hoten1.ToString();
            txtmatkhau.Text = pn.Matkhau1.ToString();
            txtsdt.Text = pn.Sdt.ToString();
            txtngaysinh.Text = Convert.ToDateTime(pn.Ngaysinh1).Date.ToString("yyyy-MM-dd");
        }

        protected void txtNgayNhap_TextChanged(object sender, EventArgs e)
        {

        }
    }
}