using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BUMS
{
    public partial class QLNhaCungCap : System.Web.UI.Page
    {
        ADO ado = new ADO();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["quyen"].ToString() == "")
                Response.Redirect("Login.aspx");
            else
            if (Session["quyen"].ToString() != "Admin")
                Response.Redirect("QLSanPham.aspx");
            loadNCC();
        }

        public void loadNCC()
        {
            
            DataTable dt = new DataTable();
            dt = ado.getNhaCungCap();
            gvNCC.DataSource = dt.DefaultView;
            gvNCC.DataBind();
        }

        protected void gvNCC_PageIndexChanged(object sender, GridViewPageEventArgs e)
        {
            
            DataTable dt = new DataTable();
            dt = ado.getNhaCungCap();
            Session["PageIndex"] = e.NewPageIndex;
            gvNCC.DataSource = dt.DefaultView;
            gvNCC.PageIndex = e.NewPageIndex;
            gvNCC.DataBind();
        }

        protected void gvNCC_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            int MNCC = int.Parse(gvNCC.DataKeys[e.NewSelectedIndex].Value.ToString());            
            nhacungcap nhacc = new nhacungcap();
            nhacc = ado.laynhacungcap(MNCC);
            txtMNCC.Text = nhacc.MNCC1.ToString();
            TenNCC.Text = nhacc.TenNCC1.ToString();
            txtDiaChiNCC.Text = nhacc.DiaChiNCC1.ToString();
            txtSDTNCC.Text = nhacc.SDTNCC1.ToString();
        }

        protected void btnsua_Click(object sender, EventArgs e)
        {
            if (TenNCC.Text == "" || txtSDTNCC.Text == "" || txtDiaChiNCC.Text == "")
                Response.Write("<script>alert('Chưa nhập đủ thông tin!');</script>");
            else
            {
                nhacungcap ncc = new nhacungcap();                
                ncc.MNCC1 = int.Parse(txtMNCC.Text);
                ncc.TenNCC1 = TenNCC.Text.ToString();
                ncc.DiaChiNCC1 = txtDiaChiNCC.Text.ToString();
                ncc.SDTNCC1 = txtSDTNCC.Text.ToString();
                ado.update_NhaCungCap(ncc);
                loadNCC();
                Response.Write("<script>alert('Cập nhật thông tin thành công!');</script>");

            }
        }

        protected void btnthem_Click(object sender, EventArgs e)
        {
            if (TenNCC.Text == "" || txtSDTNCC.Text == "" || txtDiaChiNCC.Text == "")
                Response.Write("<script>alert('Chưa nhập đủ thông tin!');</script>");
            else
            {
                nhacungcap ncc = new nhacungcap();                
                //ncc.MNCC1 = int.Parse(txtMNCC.Text);
                ncc.TenNCC1 = TenNCC.Text.ToString();
                ncc.DiaChiNCC1 = txtDiaChiNCC.Text.ToString();
                ncc.SDTNCC1 = txtSDTNCC.Text.ToString();
                ado.them_NhaCungCap(ncc);
                loadNCC();
                Response.Write("<script>alert('Thêm nhà cung cấp thành công!');</script>");

            }
        }
        protected void gvNCC_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            nhacungcap ncc = new nhacungcap();
            int MNCC = int.Parse(gvNCC.Rows[e.RowIndex].Cells[0].Text);
            ado.xoa_NhaCungCap(MNCC);
            Response.Write("<script>alert('Xóa thành công!');</script>");
            loadNCC();


        }
    }
}