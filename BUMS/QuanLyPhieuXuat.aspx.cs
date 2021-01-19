using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
namespace BUMS
{
    
    public partial class QuanLyPhieuXuat : System.Web.UI.Page
    {
        ADO ado = new ADO();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["quyen"].ToString() == "")
                Response.Redirect("Login.aspx");
            if (!IsPostBack)
            {
                Loadphieuxuat();
                Load_dropnhanvien();
                Load_dropmakhachhang();
                txtNgayXuat.Text = Convert.ToDateTime(DateTime.Now).Date.ToString("yyyy-MM-dd");
                //ddlMNV = Session["Manhanvien"]; mặc định cho drop ban đầu là mã nhân viên đang đăng nhập
                if (Session["quyen"].ToString() != "Admin")
                    ddlMNV.Text = Session["quyen"].ToString();
                Session["PageIndex"] = 0;
            }
        }
        public void Loadphieuxuat()
        {
            DataTable dt = new DataTable();
            dt = ado.Loadphieuxuat();
            gvphieuxuat.DataSource = dt.DefaultView;
            gvphieuxuat.DataBind();

        }
        protected void Load_dropnhanvien()
        {
            ddlMNV.DataSource = ado.Loadnhanvien();
            ddlMNV.DataValueField = "MNV";
            ddlMNV.DataTextField = "MNV";
            ddlMNV.DataBind();
        }
        
        protected void Load_dropmakhachhang()
        {

            //cần cần phương thức của khách hàng để load lên drop
       
            ddlMKH.DataSource = ado.Get_Data_KhachHang();
            ddlMKH.DataValueField = "MKH";
            ddlMKH.DataTextField = "MKH";
            ddlMKH.DataBind();
        }
        protected void gvPhieuNhap_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            DataTable dt = new DataTable();
            dt = ado.Loadphieunhap();
            Session["PageIndex"] = e.NewPageIndex;
            gvphieuxuat.DataSource = dt.DefaultView;
            gvphieuxuat.PageIndex = e.NewPageIndex;
            gvphieuxuat.DataBind();

        }

        protected void btnchitiet_Click(object sender, EventArgs e)
        {
            if (txtMPX.Text == "")
                Response.Write("<script>alert('Vui lòng chọn mã phiếu xuất và bấm chi tiết');</script>");
            else
            {
                Session["MPX"] = txtMPX.Text;
                Response.Redirect("ChiTietPhieuXuat.aspx?click=2");
            }
        }

        protected void btnthem_Click(object sender, EventArgs e)
        {
            if (txtNgayXuat.Text == "")
                Response.Write("<script>alert('Chưa nhập đủ thông tin');</script>");
            else
            {
                phieuxuat pn = new phieuxuat();
                pn.MNV1 = int.Parse(ddlMNV.Text);
                pn.MKH1 = int.Parse(ddlMKH.Text);
                pn.NgayXuat1 = DateTime.Parse(txtNgayXuat.Text);
                if(ado.themphieuxuat(pn)) Response.Write("<script>alert('Đã thêm');</script>");
                else
                    Response.Write("<script>alert('Không thể thêm');</script>");
                Loadphieuxuat();
                Load_dropnhanvien();
                Load_dropmakhachhang();
            }
        }

        protected void btnsua_Click(object sender, EventArgs e)
        {

            if (txtNgayXuat.Text == ""||txtMPX.Text=="")
                Response.Write("<script>alert('Chưa nhập đủ thông tin');</script>");
            else
            {
                phieuxuat pn = new phieuxuat();
                pn.MPX1 = int.Parse(txtMPX.Text);
                pn.MNV1 = int.Parse(ddlMNV.Text);
                pn.MKH1 = int.Parse(ddlMKH.Text);
                pn.NgayXuat1 = DateTime.Parse(txtNgayXuat.Text);
                if(ado.suaphieuxuat(pn)) Response.Write("<script>alert('Đã sửa');</script>");
                else
                    Response.Write("<script>alert('Không thể sửa');</script>"); ;
                Loadphieuxuat();
            }
        }

        protected void btnxoa_Click(object sender, GridViewDeleteEventArgs e)
        {
            /* int mapn = int.Parse(txtMPX.Text);
             if(ado.xoaphieuxuat(mapn)) Response.Write("<script>alert('Đã xóa');</script>"); 
             else Response.Write("<script>alert('Không thể xóa');</script>");           
             Loadphieuxuat();
             txtMPX.Text = "";
             */
            try
            {
                int ma = int.Parse(gvphieuxuat.Rows[e.RowIndex].Cells[0].Text);
                if (ado.xoaphieuxuat(ma))
                {
                    Response.Write("<script> alert('Xóa thành công'); </script>");
                    txtMPX.Text = "";
                    Loadphieuxuat();
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

        protected void gvphieuxuat_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            int mapn = int.Parse(gvphieuxuat.DataKeys[e.NewSelectedIndex].Value.ToString());
            phieuxuat pn = new phieuxuat();
            pn = ado.layphieuxuat(mapn);
            txtMPX.Text = pn.MPX1.ToString();
            ddlMNV.SelectedValue = pn.MNV1.ToString();
            ddlMKH.SelectedValue = pn.MKH1.ToString();
            txtNgayXuat.Text = Convert.ToDateTime(pn.NgayXuat1).Date.ToString("yyyy-MM-dd");

        }

        protected void btnin_Click1(object sender, EventArgs e)
        {


        }
    }
}