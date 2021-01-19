using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BUMS
{
    public partial class QLSanPham : System.Web.UI.Page
    {
        ADO ado = new ADO();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["quyen"].ToString() == "")
                Response.Redirect("Login.aspx");
            loadSP();
            //Session["quyen"] = "Admin";
            if (!IsPostBack)
            {
                txtTimKiem.Attributes.Add("onkeypress", "return clickButton(event,'" + btnTimKiem.ClientID + "')");
                txtDonGiaBan.Attributes.Add("onkeypress", "return clickButton(event,'" + btnCapNhat.ClientID + "')");
                txtDonGiaNhap.Attributes.Add("onkeypress", "return clickButton(event,'" + btnCapNhat.ClientID + "')");
                txtDonViTinh.Attributes.Add("onkeypress", "return clickButton(event,'" + btnCapNhat.ClientID + "')");
                txtTenSP.Attributes.Add("onkeypress", "return clickButton(event,'" + btnCapNhat.ClientID + "')");
            }

        }

        public void loadSP()
        {
            DataTable dt = new DataTable();
            dt = ado.getSanPham();
            gvSanPham.DataSource = dt.DefaultView;
            gvSanPham.DataBind();
        }

        protected void btnTimKiem_Click(object sender, EventArgs e)
        {
            string search = txtTimKiem.Text;
            if (txtTimKiem.Text == "")
                Response.Write("<script>alert('Chưa nhập nội dung tìm kiếm');</script>");
            else
            {

                if (ddlTimKiem.Text == "LoaiSP")
                {

                    DataTable dt = new DataTable();
                    dt = ado.getSanPham_Loai(txtTimKiem.Text);
                    gvSanPham.DataSource = dt.DefaultView;
                    gvSanPham.DataBind();

                }
                else
                if (ddlTimKiem.Text == "TenSP")
                {

                    DataTable dt = new DataTable();
                    dt = ado.getSanPham_Ten(txtTimKiem.Text);
                    gvSanPham.DataSource = dt.DefaultView;
                    gvSanPham.DataBind();

                }

                else
                {

                    DataTable dt = new DataTable();
                    dt = ado.getSanPham_Tatca(txtTimKiem.Text);
                    gvSanPham.DataSource = dt.DefaultView;
                    gvSanPham.DataBind();

                }

            }

        }

        protected void btnCapNhat_Click1(object sender, EventArgs e)
        {
            if (txtTenSP.Text == "" || txtSoLuong.Text == "" || txtDonViTinh.Text == "" || txtDonGiaBan.Text == "" || txtDonGiaNhap.Text == "")
                Response.Write("<script>alert('Chưa nhập đủ thông tin!');</script>");
            else
            {
                sanpham sp = new sanpham();

                sp.MSP1 = int.Parse(txtMSP.Text);
                sp.TenSP1 = (txtTenSP.Text).ToString();
                sp.LoaiSP1 = (ddlLoaiSP.Text).ToString();
                sp.DonViTinh1 = (txtDonViTinh.Text).ToString();
                sp.SoLuong1 = int.Parse(txtSoLuong.Text);
                sp.DonGiaBan1 = decimal.Parse(txtDonGiaBan.Text);
                sp.DonGiaNhap1 = decimal.Parse(txtDonGiaNhap.Text);

                ado.update_sanpham(sp);
                Response.Write("<script>alert('Cập nhật thông tin sản phẩm thành công!');</script>");
                loadSP();
            }
        }



        protected void gvSanPham_PageIndexChanged(object sender, GridViewPageEventArgs e)
        {

            DataTable dt = new DataTable();
            dt = ado.getSanPham();
            Session["PageIndex"] = e.NewPageIndex;
            gvSanPham.DataSource = dt.DefaultView;
            gvSanPham.PageIndex = e.NewPageIndex;
            gvSanPham.DataBind();
        }

        protected void gvSanPham_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            int MSP = int.Parse(gvSanPham.DataKeys[e.NewSelectedIndex].Value.ToString());

            sanpham sp = new sanpham();
            sp = ado.laysanpham(MSP);
            txtMSP.Text = sp.MSP1.ToString();
            txtTenSP.Text = sp.TenSP1.ToString();
            ddlLoaiSP.SelectedValue = sp.LoaiSP1.ToString();
            txtDonViTinh.Text = sp.DonViTinh1.ToString();
            txtSoLuong.Text = sp.SoLuong1.ToString();
            txtDonGiaNhap.Text = sp.DonGiaNhap1.ToString();
            txtDonGiaBan.Text = sp.DonGiaBan1.ToString();
        }



        protected void txtTimKiem_TextChanged(object sender, EventArgs e)
        {

        }

        protected void ddlTimKiem_SelectedIndexChanged(object sender, EventArgs e)
        {


        }

        private static string ASCENDING = " ASC";
        private static string DESCENDING = " DESC";

        protected void gvSanPham_Sorting(object sender, GridViewSortEventArgs e)
        {
            string sortExpression = e.SortExpression;
            ViewState["SortExpression"] = sortExpression;
            if (GridViewSortDirection == SortDirection.Ascending)
            {
                GridViewSortDirection = SortDirection.Descending;
                SortGridView(sortExpression, DESCENDING);
            }
            else
            {
                GridViewSortDirection = SortDirection.Ascending;
                SortGridView(sortExpression, ASCENDING);
            }
        }

        private SortDirection GridViewSortDirection
        {
            get
            {
                if (ViewState["sortDirection"] == null)
                    ViewState["sortDirection"] = SortDirection.Ascending;
                return (SortDirection)ViewState["sortDirection"];
            }
            set { ViewState["sortDirection"] = value; }
        }

        //========================================

        private void SortGridView(string sortExpression, string direction)
        {
           
            DataTable dt = new DataTable();
            dt = ado.getSanPham();
            DataView dv = new DataView(dt); // dt_dept là table chứa dữ liệu của gridview
            dv.Sort = sortExpression + direction;
            gvSanPham.DataSource = dv;
            gvSanPham.DataBind();
        }
    }
}