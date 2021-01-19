using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
namespace BUMS
{
    public partial class ChiTietPhieuXuat : System.Web.UI.Page
    {

        ADO ado = new ADO();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["quyen"].ToString() == "")
                Response.Redirect("Login.aspx");
            if (!IsPostBack)
            {
                if (Session["MPX"].ToString() == "")
                {

                    Response.Redirect("QuanLyPhieuXuat.aspx?click=2");
                }
                {
                    Loadchitietphieuxuat();
                    Loadlabel();
                    Load_dropmasanpham();
                    Session["PageIndex"] = 0;
                }
            }
        }
        public void Loadchitietphieuxuat()
        {
            DataTable dt = new DataTable();
            string a = Session["MPX"].ToString();
            dt = ado.Loadchitietphieuxuat(int.Parse(a));

            gvchitietphieuxuat.DataSource = dt.DefaultView;

            gvchitietphieuxuat.DataBind();
            tonghoadon.Text = ado.tonggiatri(int.Parse(a)).ToString();

        }
        protected void Loadlabel()
        {
            string a = Session["MPX"].ToString();
            phieuxuat pn = new phieuxuat();
            pn = ado.layphieuxuat(int.Parse(a));
            lblMPX.Text = pn.MPX1.ToString();
            lblMNV.Text = pn.MNV1.ToString();
            lblMKH.Text = pn.MKH1.ToString();
            lblngayxuat.Text = pn.NgayXuat1.ToString();

        }
        protected void Load_dropmasanpham()
        {
            ddlMSP.DataSource = ado.getSanPham();
            ddlMSP.DataValueField = "MSP";
            ddlMSP.DataTextField = "MSP";
            ddlMSP.DataBind();
        }

        protected void btnthem_Click(object sender, EventArgs e)
        {
            if (ddlMSP.Text == "" || txtsoluong.Text == "")
                Response.Write("<script>alert('Chưa nhập đủ thông tin');</script>");

            else
            if (!IsNumber(txtsoluong.Text))
                Response.Write("<script>alert('Dữ liệu không hợp lệ');</script>");
            else
            {
                chitietphieuxuat pn = new chitietphieuxuat();
                chitietphieuxuat pxktra = new chitietphieuxuat();
                sanpham sp = new sanpham();

                pn.MPX1 = int.Parse(lblMPX.Text);
                pn.MSP1 = int.Parse(ddlMSP.Text);
                pn.SoLuongXuat1 = int.Parse(txtsoluong.Text);
                pxktra = ado.laychitietphieuxuat(pn.MPX1, pn.MSP1);
                sp = ado.laysanpham(pn.MSP1);
                if ((sp.SoLuong1- (pn.SoLuongXuat1 + pxktra.SoLuongXuat1)) < 0)
                    Response.Write("<script>alert('Số lượng sản phẩm không hợp lệ: " + (pn.SoLuongXuat1 + pxktra.SoLuongXuat1) + " lớn hơn số sản phẩm đã có: " + sp.SoLuong1 + "');</script>");
                else
                if (pxktra.MSP1 == pn.MSP1)
                {
                    if (ado.themtrungsanphampx(pn))
                        Response.Write("<script>alert('Đã cập nhật vào mã sản phẩm');</script>");
                    else
                        Response.Write("<script>alert('Không thể cập nhật');</script>");
                    Loadchitietphieuxuat();
                    Load_dropmasanpham();
                }
                else
                {
                    if (ado.themchitietphieuxuat(pn))
                        Response.Write("<script>alert('Đã thêm sản phẩm');</script>");
                    else
                        Response.Write("<script>alert('Không thể thêm');</script>");
                    Loadchitietphieuxuat();
                    Load_dropmasanpham();
                }

            }
        }


        protected void btnsua_Click(object sender, EventArgs e)
        {
            sanpham sp = new sanpham();
            if (ddlMSP.Text == "" || txtsoluong.Text == "")
                Response.Write("<script>alert('Chưa nhập đủ thông tin');</script>");

            else if (IsNumber(txtsoluong.Text))
            {
                chitietphieuxuat pxktra = new chitietphieuxuat();
                chitietphieuxuat pn = new chitietphieuxuat();
                pn.MPX1 = int.Parse(lblMPX.Text);
                pn.MSP1 = int.Parse(ddlMSP.Text);
                pn.SoLuongXuat1 = int.Parse(txtsoluong.Text);
                pxktra = ado.laychitietphieuxuat(pn.MPX1, pn.MSP1);
                sp = ado.laysanpham(pn.MSP1);
                if ((sp.SoLuong1 - pn.SoLuongXuat1 + pxktra.SoLuongXuat1) < 0)
                    Response.Write("<script>alert('Số lượng sản phẩm không hợp lệ: " + pn.SoLuongXuat1 + " lớn hơn số sản phẩm đã có: " + sp.SoLuong1 + "');</script>");
                else
                {
                    if (ado.suachitietphieuxuat(pn))
                        Response.Write("<script>alert('Đã sửa');</script>");
                    else
                        Response.Write("<script>alert('Sản phẩm không có trong phiếu');</script>");

                    Loadchitietphieuxuat();
                    Load_dropmasanpham();
                }
            }
            else
                Response.Write("<script>alert('Dữ liệu không hợp lệ');</script>");

        }

        protected void btnxoa_Click(object sender, GridViewDeleteEventArgs e)
        {
            /*  int masn = int.Parse(ddlMSP.Text);
              if (ado.xoasanphamctpx(masn, int.Parse(Session["MPX"].ToString())))
                  Response.Write("<script>alert('Đã xóa');</script>");
              else
                  Response.Write("<script>alert('Không thể xóa, mã sản phẩm không tồn tại trong phiếu');</script>");
              Loadchitietphieuxuat();
              Load_dropmasanpham();
              */
            try
            {
                int ma = int.Parse(gvchitietphieuxuat.Rows[e.RowIndex].Cells[0].Text);
                if (ado.xoasanphamctpx(ma,int.Parse(lblMPX.Text)))
                {
                    Response.Write("<script> alert('Xóa thành công'); </script>");
                   
                    Loadchitietphieuxuat();
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



        protected void gvchitietphieuxuat_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            int masp = int.Parse(gvchitietphieuxuat.DataKeys[e.NewSelectedIndex].Value.ToString());
            chitietphieuxuat pn = new chitietphieuxuat();
            string a = Session["MPX"].ToString();
            pn = ado.laychitietphieuxuat(int.Parse(a), masp);
            ddlMSP.SelectedValue = pn.MSP1.ToString();
            txtsoluong.Text = pn.SoLuongXuat1.ToString();


        }

        protected void btnback_Click(object sender, EventArgs e)
        {
            Response.Redirect("QuanLyPhieuXuat.aspx?click=2");
        }
        protected void OnDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                int sl = int.Parse(e.Row.Cells[1].Text.Trim());
                int masp = int.Parse(e.Row.Cells[0].Text.Trim());
                decimal gia = ado.gia(masp);
                Label total = e.Row.FindControl("lblTotal") as Label;
                total.Text = (sl * gia).ToString();
            }

        }
        public bool IsNumber(string pValue)
        {
            foreach (Char c in pValue)
            {
                if (!Char.IsDigit(c))
                    return false;
            }
            return true;
        }
    }
}