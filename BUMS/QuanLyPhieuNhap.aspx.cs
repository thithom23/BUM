using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
namespace BUMS
{
    public partial class QuanLyPhieuNhap : System.Web.UI.Page
    {
        ADO ado = new ADO();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["quyen"].ToString() == "")
                Response.Redirect("Login.aspx");
            if (!IsPostBack)
            {
                Loadphieunhap();
                Load_dropnhanvien();
                Load_dropnhacungcap();
                txtNgayNhap.Text = Convert.ToDateTime(DateTime.Now).Date.ToString("yyyy-MM-dd");
                //ddlMNV = Session["Manhanvien"]; mặc định cho drop ban đầu là mã nhân viên đang đăng nhập
                if (Session["quyen"].ToString()!="Admin")
                ddlMNV.Text = Session["quyen"].ToString();
                Session["PageIndex"] = 0;

            }
        }
        public void Loadphieunhap()
        {
            DataTable dt = new DataTable();
            dt = ado.Loadphieunhap();
            gvPhieuNhap.DataSource = dt.DefaultView;
            gvPhieuNhap.DataBind();

        }
        protected void Load_dropnhanvien()
        {
            ddlMNV.DataSource = ado.Loadnhanvien();
            ddlMNV.DataValueField = "MNV";
            ddlMNV.DataTextField = "MNV";
            ddlMNV.DataBind();
        }

        protected void Load_dropnhacungcap()
        {

            //cần phương thức của nhà cung cấp để load lên dropppppppppppppppppppppppppppppppppp
            ddlMNCC.DataSource = ado.getNhaCungCap();
            ddlMNCC.DataValueField = "MNCC";
            ddlMNCC.DataTextField = "MNCC";
            ddlMNCC.DataBind();
        }
        protected void gvPhieuNhap_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            DataTable dt = new DataTable();
            dt = ado.Loadphieunhap();
            Session["PageIndex"] = e.NewPageIndex;
            gvPhieuNhap.DataSource = dt.DefaultView;
            gvPhieuNhap.PageIndex = e.NewPageIndex;
            gvPhieuNhap.DataBind();

        }

        protected void btnchitiet_Click(object sender, EventArgs e)
        {
            if (txtMPN.Text == "") Response.Write("<script>alert('Vui lòng chọn mã phiếu nhập và bấm chi tiết');</script>");
            else
            {
                Session["MPN"] = txtMPN.Text;
                Response.Redirect("ChiTietPhieuNhap.aspx?click=1");
            }

        }

        protected void btnthem_Click(object sender, EventArgs e)
        {
            if (ddlMNV.Text == "" || ddlMNCC.Text == "" || txtNgayNhap.Text == "")
                Response.Write("<script>alert('Chưa nhập đủ thông tin');</script>");
            else
            {
                phieunhap pn = new phieunhap();
                pn.MNV1 = int.Parse(ddlMNV.Text);
                pn.MNCC1 = int.Parse(ddlMNCC.Text);
                pn.NgayNhap1 = DateTime.Parse(txtNgayNhap.Text);
                if(ado.themphieunhap(pn))
                    Response.Write("<script>alert('Đã thêm');</script>");
                else Response.Write("<script>alert('Không thể thêm');</script>");
                Loadphieunhap();
                Load_dropnhanvien();
                Load_dropnhacungcap();
            }
        }

        protected void btnsua_Click(object sender, EventArgs e)
        {

            if (ddlMNV.Text == "" || ddlMNCC.Text == "" || txtNgayNhap.Text == ""||txtMPN.Text=="")
                Response.Write("<script>alert('Chưa nhập đủ thông tin');</script>");
            else
            {
                phieunhap pn = new phieunhap();
                pn.MPN1 = int.Parse(txtMPN.Text);
                pn.MNV1 = int.Parse(ddlMNV.Text);
                pn.MNCC1 = int.Parse(ddlMNCC.Text);
                pn.NgayNhap1 = DateTime.Parse(txtNgayNhap.Text);
                if(ado.suaphieunhap(pn))
                Response.Write("<script>alert('Đã sửa');</script>");
                else
                    Response.Write("<script>alert('Không thể sửa');</script>");
                Loadphieunhap();
                Load_dropnhanvien();
                Load_dropnhacungcap();
            }
        }

        protected void btnxoa_Click(object sender, GridViewDeleteEventArgs e)
        {
          /*  
            int mapn = int.Parse(txtMPN.Text);
            if(ado.xoaphieunhap(mapn))
                Response.Write("<script>alert('Đã xóa');</script>");
            else Response.Write("<script>alert('Không thể xóa');</script>");
            Loadphieunhap();
            Load_dropnhanvien();
            Load_dropnhacungcap();
            txtMPN.Text = "";
            */
            try
            {
                int ma = int.Parse(gvPhieuNhap.Rows[e.RowIndex].Cells[0].Text);
                if (ado.xoaphieunhap(ma))
                {
                    Response.Write("<script> alert('Xóa thành công'); </script>");
                    txtMPN.Text = "";
                    Loadphieunhap();
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

        protected void gvPhieuNhap_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            int mapn = int.Parse(gvPhieuNhap.DataKeys[e.NewSelectedIndex].Value.ToString());
            phieunhap pn = new phieunhap();
            pn = ado.layphieunhap(mapn);
            txtMPN.Text = pn.MPN1.ToString();
            ddlMNV.SelectedValue = pn.MNV1.ToString();
            ddlMNCC.SelectedValue = pn.MNCC1.ToString();

            txtNgayNhap.Text = Convert.ToDateTime(pn.NgayNhap1).Date.ToString("yyyy-MM-dd");
        }

        protected void txtNgayNhap_TextChanged(object sender, EventArgs e)
        {

        }
    }
}