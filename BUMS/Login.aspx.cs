using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Security.Cryptography;
using System.Text;

namespace BUMS
{
    public partial class Login : System.Web.UI.Page
    {
        ADO ado = new ADO();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["quyen"].ToString() != "")
                Response.Redirect("QLSanPham.aspx");
            //Session.Abandon();
            if (!IsPostBack)
            {
                HttpCookie req = Request.Cookies["cookie"];
                if (req != null)
                {
                    txtUsername.Text = req["username"].ToString();
                    txtPassword.Text = req["password"].ToString();
                    CheckBox1.Checked = true;
                }
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
        protected void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            HttpCookie cookie = new HttpCookie("cookie");
            cookie["username"] = txtUsername.Text;
            cookie["password"] = txtPassword.Text;
            cookie.Expires = DateTime.Now.AddDays(1);
            Response.Cookies.Add(cookie);
        }
        private string Encrypt(string toEncrypt)
        {
            byte[] keyArray;
            byte[] toEncryptArray = Encoding.UTF8.GetBytes(toEncrypt);
            var hashmd5 = new MD5CryptoServiceProvider();
            keyArray = hashmd5.ComputeHash(Encoding.UTF8.GetBytes("dmtuibay"));
            var tdes = new TripleDESCryptoServiceProvider
            {
                Key = keyArray,
                Mode = CipherMode.ECB,
                Padding = PaddingMode.PKCS7
            };
            ICryptoTransform cTransform = tdes.CreateEncryptor();
            byte[] resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);
            return Convert.ToBase64String(resultArray, 0, resultArray.Length);
        }
        protected void btnLogin_Click(object sender, EventArgs e)
        {
            // taikhoan.MatKhau1 = Encrypt(txtPassword.Text);
            string name = txtUsername.Text;
            string pass = txtPassword.Text;

            if (name == "0" && pass == "Admin")
            {
                Session["quyen"] = "Admin";
                Response.Write("<script>alert('Đăng nhập thành công!');</script>");
                Response.Redirect("QLSanPham.aspx");
            }
            else 
            if (!IsNumber(name))
            {
                Response.Write("<script>alert('Tên không hợp lệ!');</script>");
            }
            else
            {
               int n = int.Parse(name);
                if (ado.Check_Login(n,Encrypt(pass)))
                {
                    if (!CheckBox1.Checked)
                    {
                        Response.Cookies["cookie"].Expires = DateTime.Now.AddDays(-1);
                    }
                    Session["quyen"] = name;
                    Response.Redirect("QLSanPham.aspx");
                }
                else
                {
                    Response.Write("<script> alert('Không thể đăng nhập');</script>");
                }
            }

        }
    }
}







