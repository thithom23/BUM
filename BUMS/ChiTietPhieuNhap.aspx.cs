using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
namespace BUMS
{

    public partial class ChiTietPhieuNhap : System.Web.UI.Page
    {
        ADO ado = new ADO();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["quyen"].ToString() == "")
                Response.Redirect("Login.aspx");
            if (!IsPostBack)
            {
                if (Session["MPN"].ToString()== "")
                {
                    Response.Redirect("QuanLyPhieuNhap.aspx?click=1");
                }
                {
                    Loadchitietphieunhap();
                    Loadlabel();
                    Session["PageIndex"] = 0;
                }
            }
        }
        public void Loadchitietphieunhap()
        {
            DataTable dt = new DataTable();
            string a = Session["MPN"].ToString();
            dt = ado.Loadchitietphieunhap(int.Parse(a));
            gvchitietphieunhap.DataSource = dt.DefaultView;
            gvchitietphieunhap.DataBind();

        }
        protected void Loadlabel()
        {
            string a = Session["MPN"].ToString();;
            phieunhap pn = new phieunhap();
            pn = ado.layphieunhap(int.Parse(a));
            lblMPN.Text = pn.MPN1.ToString();
            lblMNV.Text = pn.MNV1.ToString();
            lblMNCC.Text = pn.MNCC1.ToString();
            lblngaynhap.Text = pn.NgayNhap1.ToString();
        }


        protected void btnthem_Click(object sender, EventArgs e)
        {
            if (txtMSP.Text == "" || txtsoluong.Text == "")
                Response.Write("<script>alert('Chưa nhập đủ thông tin');</script>");
            else
            if(!IsNumber(txtsoluong.Text)||!IsNumber(txtMSP.Text)) Response.Write("<script>alert('Dữ liệu nhập vào phải là số');</script>");
            else
            {
                chitietphieunhap pn = new chitietphieunhap();
                chitietphieunhap pnktra = new chitietphieunhap();
                sanpham sp = new sanpham();
                pn.MPN1 = int.Parse(Session["MPN"].ToString());
                pn.MSP1 = int.Parse(txtMSP.Text);
                pn.SoLuongNhap1 = int.Parse(txtsoluong.Text);
                pnktra = ado.laychitietphieunhap(int.Parse(Session["MPN"].ToString()), pn.MSP1);
                if (pnktra.MSP1 == pn.MSP1)
                {
                    Response.Write("<script>alert('Đã cập nhật vào mã sản phẩm');</script>");
                    ado.themtrungsanphampn(pn);
                    Loadchitietphieunhap();
                }
                else
                {
////////////////////////////////////////////////////////////////////////////////
                    sp = ado.laysanpham(pn.MSP1);
                    if (sp.MSP1 == pn.MSP1)
                    {
                        Response.Write("<script>alert('Đã thêm sản phẩm vào phiếu nhập');</script>");
                        ado.themchitietphieunhap(pn);
                        Loadchitietphieunhap();
                    }
                    else
                    {
                        sanpham sp2 = new sanpham();
                        sp2.MSP1 = pn.MSP1;
                        sp2.SoLuong1 = pn.SoLuongNhap1;
                        Response.Write("<script>alert('Đã thêm sản phẩm vào danh sách sản phẩm và phiếu nhập');</script>");
                        ado.themsanphammoi(sp2);
                        ado.themchitietphieunhap(pn);
                        Loadchitietphieunhap();
                    }
                }

            }
        }


        protected void btnsua_Click(object sender, EventArgs e)
        {
            if (txtMSP.Text == "" || txtsoluong.Text == "" || txtsoluong.Text == "")
                Response.Write("<script>alert('Chưa nhập đủ thông tin');</script>");
            else
            if(IsNumber(txtsoluong.Text)||IsNumber(txtsoluong.Text))
            {
                chitietphieunhap pn = new chitietphieunhap();
                pn.MPN1 = int.Parse(Session["MPN"].ToString());
                pn.MSP1 = int.Parse(txtMSP.Text);
                pn.SoLuongNhap1 = int.Parse(txtsoluong.Text);
                if(ado.suachitietphieunhap(pn))
                    Response.Write("<script>alert('Đã sửa');</script>");
                else Response.Write("<script>alert('Sản phẩm không có trong phiếu');</script>");
                Loadchitietphieunhap();
            }
            else
                Response.Write("<script>alert('Mã sản phẩm phải là số');</script>");

        }

        protected void btnxoa_Click(object sender, GridViewDeleteEventArgs e)
        {
            /*if (IsNumber(txtMSP.Text))
            {
                int masn = int.Parse(txtMSP.Text);
                ado.xoasanpham(masn, int.Parse(Session["MPN"].ToString()));
                Response.Write("<script>alert('Đã xóa');</script>");
                Loadchitietphieunhap();
            }
            else Response.Write("<script>alert('Mã sản phẩm phải là số');</script>");
            */
            try
            {
                int ma = int.Parse(gvchitietphieunhap.Rows[e.RowIndex].Cells[0].Text);
                if (ado.xoasanphampn(ma,int.Parse(lblMPN.Text)))
                {
                    Response.Write("<script> alert('Xóa thành công'); </script>");
                   
                    Loadchitietphieunhap();
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



        protected void gvchitietphieunhap_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            int masp = int.Parse(gvchitietphieunhap.DataKeys[e.NewSelectedIndex].Value.ToString());
            chitietphieunhap pn = new chitietphieunhap();
            string a = Session["MPN"].ToString();
            pn = ado.laychitietphieunhap(int.Parse(a), masp);
            txtMSP.Text = masp.ToString();
            txtsoluong.Text = pn.SoLuongNhap1.ToString();

        }

        protected void btnback_Click(object sender, EventArgs e)
        {
            Response.Redirect("QuanLyPhieuNhap.aspx?click=1");
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