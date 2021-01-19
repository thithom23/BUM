using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BUMS
{
    public partial class BaoCao : System.Web.UI.Page
    {
        
        ADO ado = new ADO();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["quyen"].ToString() == "")
                Response.Redirect("Login.aspx");
            if (!this.IsPostBack)
            {
                load_dropdNam();
            }
        }
        protected void load_dropdNam()
        {
            string sqlnam = "select distinct Year(NgayXuat) as 'Nam' from PhieuXuat";
            dropNam.Items.Clear();
            dropNam.SelectedIndex = -1;
            dropNam.SelectedValue = null;
            dropNam.ClearSelection();
            dropNam.DataSource = ado.Get_Data(sqlnam);
            dropNam.DataTextField = "Nam";
            dropNam.DataValueField = "Nam";
            dropNam.DataBind();
            



        }

        protected void btnThongKe_Click(object sender, EventArgs e)
        {
            gvThongKe.Visible = true;
            string nam = dropNam.SelectedValue;
            string sqlGridView = "select Month(PhieuXuat.NgayXuat) as Thang, SUM(SanPham.DonGiaBan*CTPhieuXuat.SoLuongXuat-SanPham.DonGiaNhap*CTPhieuXuat.SoLuongXuat) as DoanhThu from PhieuXuat,PhieuNhap,SanPham,CTPhieuXuat,CTPhieuNhap where CTPhieuNhap.MPN=PhieuNhap.MPN and SanPham.MSP=CTPhieuNhap.MSP and PhieuXuat.MPX=CTPhieuXuat.MPX and SanPham.MSP=CTPhieuXuat.MSP and Year(PhieuXuat.NgayXuat)='" + nam + "' group by Month(PhieuXuat.NgayXuat)";
            gvThongKe.DataSource = ado.Get_Data(sqlGridView);
            gvThongKe.DataBind();
            Chart1.Visible = true;
            Chart1.DataSource = ado.Get_Data(sqlGridView);
            Chart1.DataBind();
        }
    }
}