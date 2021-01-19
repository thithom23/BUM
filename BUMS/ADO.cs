using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Text;
using System.Linq;
using System.Web;

namespace BUMS
{
    public class ADO
    {
        string connectionString = ConfigurationManager.ConnectionStrings["BUMS"].ConnectionString;
        public DataTable Get_Data(string sql)
        {
            DataTable table = new DataTable();

            using (SqlConnection connect = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(sql, connect);
                connect.Open();
                SqlDataAdapter daA = new SqlDataAdapter(cmd);
                daA.Fill(table);
                connect.Close();

                return table;
            }
        }


        public bool Insert_Update_Delete(string sql)
        {
            using (SqlConnection connect = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(sql, connect);
                connect.Open();
                int count = cmd.ExecuteNonQuery();
                connect.Close();
                return count >= 1;
            }
        }

        //-----------------------KHÁCH HÀNG--------------------------------
        public DataTable Get_Data_KhachHang()
        {
            string sqlGetData = "select * from KhachHang";
            return Get_Data(sqlGetData);
        }
        public bool Insert_KhachHang(KhachHang khachhang)
        {
            string sqlinsert = "insert into KhachHang values (N'" + khachhang.TenKH + "',N'" + khachhang.DiaChiKH + "','" + khachhang.SDTKH + "')";
            return Insert_Update_Delete(sqlinsert);
        }
        public DataTable Get_Data_KhachHangLenForm(string idkhachhang)
        {
            string sqlGetData = "select * from KhachHang where MKH='" + idkhachhang + "'";
            return Get_Data(sqlGetData);
        }
        public bool Update_KhachHang(KhachHang khachhang)
        {
            string sqlUpdate = "update KhachHang set TenKH=N'" + khachhang.TenKH + "',DiaChiKH=N'" + khachhang.DiaChiKH + "',SDTKH='" + khachhang.SDTKH + "' where MKH='" + khachhang.MKH + "'";
            return Insert_Update_Delete(sqlUpdate);
        }
        public bool Delete_KhachHang(KhachHang khachhang)
        {
            string sqlDelete = "delete from KhachHang where MKH='" + khachhang.MKH + "'";
            return Insert_Update_Delete(sqlDelete);
        }
        public bool Check(string sql)
        {
            using (SqlConnection connect = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(sql, connect);
                connect.Open();
                int count = (int)cmd.ExecuteScalar();
                connect.Close();
                return (count >= 1);
            }
        }
        public bool Check_KhachHang(KhachHang khachhang)
        {
            string sqlCheck = "select count(*) from KhachHang where TenKH=N'" + khachhang.TenKH + "' and DiaChiKH=N'" + khachhang.DiaChiKH + "' and SDTKH='" + khachhang.SDTKH + "'";
            return Check(sqlCheck);
        }
        // ---------------------------------------------------------------------------Phiếu nhập------------------------------------------------
        public bool themphieunhap(phieunhap pn)
        {
            string qry = "insert into PhieuNhap(MNV,MNCC,NgayNhap) values(" + "'" +
               pn.MNV1 + "','" + pn.MNCC1 + "','" + pn.NgayNhap1 + "')";
            return Insert_Update_Delete(qry);
        }
        public bool suaphieunhap(phieunhap pn)
        {
            string qry = "update PhieuNhap set MNV = '" +
                pn.MNV1 + "' ,MNCC= '" + pn.MNCC1 + "',NgayNhap= '" +
                pn.NgayNhap1 + "' where MPN='" + pn.MPN1 + "'";
            return Insert_Update_Delete(qry);
        }
        public bool xoaphieunhap(int mapn)
        {
            string qry = "delete PhieuNhap where MPN ='" + mapn + "'";
            return Insert_Update_Delete(qry);
        }
        public DataTable Loadphieunhap()
        {
            string sqlGetData = "select * from PhieuNhap";
            return Get_Data(sqlGetData);
        }
        public phieunhap layphieunhap(int mapn)
        {
            using (SqlConnection connect = new SqlConnection(connectionString))
            {
                connect.Open();
                string sql = "select * from PhieuNhap where MPN=" + mapn;
                SqlCommand cmd = new SqlCommand(sql, connect);
                SqlDataReader reader = cmd.ExecuteReader();
                reader.Read();
                phieunhap a = new phieunhap();
                a.MPN1 = reader.GetInt32(0);
                a.MNV1 = reader.GetInt32(1);
                a.MNCC1 = reader.GetInt32(2);
                a.NgayNhap1 = reader.GetDateTime(3);
                cmd.Dispose();
                reader.Dispose();
                connect.Close();
                return a;
            }
        }
        //-------------------------------------phiếu xuất--------------------------------------
        public bool themphieuxuat(phieuxuat px)
        {
            string qry = "insert into PhieuXuat(MNV,MKH,NgayXuat) values(" + "'" +
                px.MNV1 + "','" + px.MKH1 + "','" + px.NgayXuat1 + "')";
            return Insert_Update_Delete(qry);
        }
        public bool suaphieuxuat(phieuxuat px)
        {
            string qry = "update PhieuXuat set MNV = '" + px.MNV1 + "' ,MKH= '" + px.MKH1 + "',NgayXuat= '" +
                 px.NgayXuat1 + "' where MPX='" + px.MPX1 + "'";
            return Insert_Update_Delete(qry);
        }
        public bool xoaphieuxuat(int mapx)
        {
            string qry = "delete PhieuXuat where MPX =" + mapx;
            return Insert_Update_Delete(qry);
        }
        public DataTable Loadphieuxuat()
        {
            String qry = "select * from PhieuXuat";
            return Get_Data(qry);
        }
        public phieuxuat layphieuxuat(int mapx)
        {
            using (SqlConnection connect = new SqlConnection(connectionString))
            {
                connect.Open();
                string sql = "select * from PhieuXuat where MPX=" + mapx;
                SqlCommand cmd = new SqlCommand(sql, connect);
                SqlDataReader reader = cmd.ExecuteReader();
                reader.Read();
                phieuxuat a = new phieuxuat();
                a.MPX1 = reader.GetInt32(0);
                a.MNV1 = reader.GetInt32(1);
                a.MKH1 = reader.GetInt32(2);
                a.NgayXuat1 = reader.GetDateTime(3);
                cmd.Dispose();
                reader.Dispose();
                connect.Close();
                return a;
            }
        }
        //------------------------------------------------------chi tiet phieu nhap---------------------------------
        public bool themchitietphieunhap(chitietphieunhap pn)
        {
            string qry = "insert into CTPhieuNhap(MPN,MSP,SoLuongNhap) values('" +
                pn.MPN1 + "','" + pn.MSP1 + "','" + pn.SoLuongNhap1 + "') ";
            return Insert_Update_Delete(qry);
        }
        public bool themtrungsanphampn(chitietphieunhap pn)
        {
            string qry = "update CTPhieuNhap set SoLuongNhap = SoLuongNhap + '"
                 + pn.SoLuongNhap1 + "'where MSP = '" + pn.MSP1 + "'and MPN = '" + pn.MPN1 + "'";
            return Insert_Update_Delete(qry);
        }
        public bool suachitietphieunhap(chitietphieunhap pn)
        {
            string qry = "update CTPhieuNhap set SoLuongNhap= '" + pn.SoLuongNhap1 + "' where MPN='" +
                pn.MPN1 + "' and MSP='" + pn.MSP1 + "'";
            return Insert_Update_Delete(qry);
        }
        public bool xoasanphampn(int masp, int maphieunhap)
        {
            string qry = "delete CTPhieuNhap where MSP ='" + masp + "'and MPN='" + maphieunhap + "'";
            return Insert_Update_Delete(qry);
        }
        public DataTable Loadchitietphieunhap(int MPN)
        {
            String qry = "select * from CTPhieuNhap where MPN=" + MPN;
            return Get_Data(qry);
        }
        public chitietphieunhap laychitietphieunhap(int mapn, int masp)
        {
            chitietphieunhap a = new chitietphieunhap();
            SqlConnection connect = new SqlConnection(connectionString);

            connect.Open();
            string qry = "select * from CTPhieuNhap where MPN='" + mapn + "'and MSP='" + masp + "'";
            SqlCommand cmd = new SqlCommand(qry, connect);
            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                a.MPN1 = reader.GetInt32(0);
                a.MSP1 = reader.GetInt32(1);
                a.SoLuongNhap1 = reader.GetInt32(2);
            }
            cmd.Dispose();
            reader.Dispose();
            connect.Close();

            return a;
        }
        //-----------------------------------------------------------------------------------------chi tiết phiếu xuất-------
        public bool themchitietphieuxuat(chitietphieuxuat px)
        {
            string qry = "insert into CTPhieuXuat(MPX,MSP,SoLuongXuat) values('" + px.MPX1 + "','" + px.MSP1 + "','" + px.SoLuongXuat1 + "')";
            return Insert_Update_Delete(qry);
        }
        public bool suachitietphieuxuat(chitietphieuxuat px)
        {
            string qry = "update CTPhieuXuat set SoLuongXuat= '" + px.SoLuongXuat1 + "' where MPX='" + px.MPX1 + "'and MSP =" + px.MSP1;
            return Insert_Update_Delete(qry);
        }
        public bool xoasanphamctpx(int masp, int maphieuxuat)
        {
            string qry = "delete CTPhieuXuat where MSP ='" + masp + "'and MPX='" + maphieuxuat + "'";
            return Insert_Update_Delete(qry);
        }

        public DataTable Loadchitietphieuxuat(int MPX)
        {
            String qry = "select * from CTPhieuXuat where MPX=" + MPX;
            return Get_Data(qry);

        }
        public chitietphieuxuat laychitietphieuxuat(int mapx, int masp)
        {
            string qry = "select * from CTPhieuXuat where MPX=" + mapx + "and MSP=" + masp;

            using (SqlConnection connect = new SqlConnection(connectionString))
            {
                connect.Open();
                SqlCommand cmd = new SqlCommand(qry, connect);
                SqlDataReader reader = cmd.ExecuteReader();
                chitietphieuxuat a = new chitietphieuxuat();
                if (reader.Read())
                {
                    a.MPX1 = reader.GetInt32(0);
                    a.MSP1 = reader.GetInt32(1);
                    a.SoLuongXuat1 = reader.GetInt32(2);
                }
                cmd.Dispose();
                reader.Dispose();
                connect.Close();
                return a;
            }
        }
        public decimal tonggiatri(int pn)
        {
            decimal tong = 0;
            using (SqlConnection connect = new SqlConnection(connectionString))
            {
                connect.Open();
                string qry = "select sum(SoLuongXuat*DonGiaBan) from CTPhieuXuat,SanPham where CTPhieuXuat.MSP=SanPham.MSP and MPX=" + pn;
                SqlCommand cmd = new SqlCommand(qry, connect);
                SqlDataReader reader = cmd.ExecuteReader();
                chitietphieuxuat a = new chitietphieuxuat();
                if (reader.Read())
                    try
                    {
                        tong = reader.GetDecimal(0);
                    }
                    catch (Exception e)
                    {
                        tong = 0;
                    }
                cmd.Dispose();
                reader.Dispose();
                connect.Close();
                return tong;
            }
        }
        public decimal gia(int sp)
        {
            decimal tong = 0;
            using (SqlConnection connect = new SqlConnection(connectionString))
            {
                connect.Open();
                string qry = "select DonGiaBan from SanPham where MSP=" + sp;
                SqlCommand cmd = new SqlCommand(qry, connect);
                SqlDataReader reader = cmd.ExecuteReader();
                chitietphieuxuat a = new chitietphieuxuat();
                if (reader.Read())
                    try
                    {
                        tong = reader.GetDecimal(0);
                    }
                    catch (Exception e)
                    {
                        tong = 0;
                    }
                cmd.Dispose();
                reader.Dispose();
                connect.Close();
                return tong;
            }
        }
        public bool themtrungsanphampx(chitietphieuxuat pn)
        {
            string qry = "update CTPhieuXuat set SoLuongXuat = SoLuongXuat + '"
                + pn.SoLuongXuat1 + "'where MSP = '" + pn.MSP1 + "'and MPX = '" + pn.MPX1 + "'";
            return Insert_Update_Delete(qry);
        }
        //-------------------------------------------------------quản lý sản phẩm--------------------------------------------------------------------------
        public bool themsanphammoi(sanpham sp)
        {
            String qry = "SET IDENTITY_INSERT SanPham ON insert SanPham(MSP,TenSP,LoaiSP,DVT,SoLuong,DonGiaNhap,DonGiaBan) values('"
                + sp.MSP1 + "',N'Chưa có tên',N'Sách',N'Chưa có đơn vị tính','0' , '0','"
                + sp.DonGiaBan1 + "') SET IDENTITY_INSERT SanPham OFF";

            return Insert_Update_Delete(qry);
        }
        public bool update_sanpham(sanpham sp)
        {
            string qry = "update SanPham set TenSP = N'" + sp.TenSP1 + "' ,LoaiSP = N'" + sp.LoaiSP1 + "', DVT = N'" + sp.DonViTinh1 + "', SoLuong = '" + sp.SoLuong1 + "', DonGiaBan = '" + sp.DonGiaBan1 + "', DonGiaNhap = '" + sp.DonGiaNhap1 + "' where MSP='" + sp.MSP1 + "'";
            return Insert_Update_Delete(qry);
        }
        public DataTable getSanPham()
        {
            string qry = "select * from SanPham";
            return Get_Data(qry);
        }


        public sanpham laysanpham(int MaSP)
        {
            string qry = "select * from SanPham where MSP='" + MaSP + "'";
            using (SqlConnection connect = new SqlConnection(connectionString))
            {
                connect.Open();
                SqlCommand cmd = new SqlCommand(qry, connect);
                SqlDataReader reader = cmd.ExecuteReader();
                sanpham a = new sanpham();
                if (reader.Read())
                {
                    a.MSP1 = reader.GetInt32(0);
                    a.TenSP1 = reader.GetString(1);
                    a.LoaiSP1 = reader.GetString(2);
                    a.DonViTinh1 = reader.GetString(3);
                    a.SoLuong1 = reader.GetInt32(4);
                    a.DonGiaBan1 = reader.GetDecimal(5);
                    a.DonGiaNhap1 = reader.GetDecimal(6);
                }
                cmd.Dispose();
                reader.Dispose();
                connect.Close();
                return a;
            }
        }

        //Tìm kiếm theo loại, tên, tất cả
        public DataTable getSanPham_Loai(string txtTimKiem)
        {
            string qry = "select * from SanPham where LoaiSP like N'%" + txtTimKiem + "%' or dbo.fChuyenCoDauThanhKhongDau(LoaiSP) LIKE N'%" + txtTimKiem + "%'";
            using (SqlConnection connect = new SqlConnection(connectionString))
            {
                DataTable dt = new DataTable();
                connect.Open();
                SqlCommand cmd = new SqlCommand(qry, connect);
                SqlDataReader reader = cmd.ExecuteReader();
                dt.Load(reader);
                cmd.Dispose();
                reader.Dispose();
                connect.Close();
                return dt;
            }
        }


        public DataTable getSanPham_Ten(string txtTimKiem)
        {
            string qry = "select * from SanPham where TenSP like N'%" + txtTimKiem + "%' or dbo.fChuyenCoDauThanhKhongDau(TenSP) LIKE N'%" + txtTimKiem + "%'";
            using (SqlConnection connect = new SqlConnection(connectionString))
            {
                DataTable dt = new DataTable();
                connect.Open();
                SqlCommand cmd = new SqlCommand(qry, connect);
                SqlDataReader reader = cmd.ExecuteReader();
                dt.Load(reader);
                cmd.Dispose();
                reader.Dispose();
                connect.Close();
                return dt;
            }
        }


        public DataTable getSanPham_Tatca(string txtTimKiem)
        {
            string qry = "Select * from SanPham where TenSP like N'%" + txtTimKiem + "%' or LoaiSP like N'%" + txtTimKiem + "%' or DVT like N'%" + txtTimKiem
                + "%' or SoLuong like N'%" + txtTimKiem + "%' or DonGiaNhap like N'%" + txtTimKiem + "%' or DonGiaBan like '%" + txtTimKiem + "%' or dbo.fChuyenCoDauThanhKhongDau(TenSP) LIKE N'%" + txtTimKiem + "%' or dbo.fChuyenCoDauThanhKhongDau(LoaiSP) LIKE N'%" + txtTimKiem + "%' or dbo.fChuyenCoDauThanhKhongDau(DVT) LIKE N'%" + txtTimKiem + "%'";
            using (SqlConnection connect = new SqlConnection(connectionString))
            {
                DataTable dt = new DataTable();
                connect.Open();
                SqlCommand cmd = new SqlCommand(qry, connect);
                SqlDataReader reader = cmd.ExecuteReader();
                dt.Load(reader);
                cmd.Dispose();
                reader.Dispose();
                connect.Close();
                return dt;
            }
        }


        //-----------------------------------------------------------------------Quản lý nhân viên---------------------
        public bool themnhanvien(nhanvien nv)
        {
            nv.Matkhau1 = Encrypt(nv.Matkhau1);
            string qry = "insert into NhanVien(MatKhau,HoTenNV,NgaySinh,SDTNV) values('" +
                nv.Matkhau1 + "',N'" + nv.Hoten1 + "','" + nv.Ngaysinh1 + "','" + nv.Sdt + "')";
            return Insert_Update_Delete(qry);
        }
        public bool suanhanvien(nhanvien nv)
        {
            nv.Matkhau1 = Encrypt(nv.Matkhau1);
            string qry = "update NhanVien set MatKhau = '" +
                nv.Matkhau1 + "' ,HoTenNV= N'" + nv.Hoten1 + "',NgaySinh= '" +
                nv.Ngaysinh1 + "',SDTNV='" + nv.Sdt + "' where MNV='" + nv.MNV1 + "'";
            return Insert_Update_Delete(qry);
        }
        public bool xoanhanvien(int manv)
        {
            string qry = "delete NhanVien where MNV ='" + manv + "'";
            return Insert_Update_Delete(qry);
        }
        public DataTable Loadnhanvien()
        {
            string qry = "select * from NhanVien";
            return Get_Data(qry);
        }
        public nhanvien laynhanvien(int manv)
        {
            string qry = "select * from NhanVien where MNV=" + manv;
            using (SqlConnection connect = new SqlConnection(connectionString))
            {
                connect.Open();
                SqlCommand cmd = new SqlCommand(qry, connect);
                SqlDataReader reader = cmd.ExecuteReader();
                if (!reader.Read())
                {
                    return null;
                }
                nhanvien a = new nhanvien();
                a.MNV1 = reader.GetInt32(0);
                a.Matkhau1 = reader.GetString(1);


 //////////////////////////////////////////////////chỗ này nếu muốn hiện mật khẩu đã mã hóa lên text box thì xóa cái decrypt này đi////////////////////////////////////////////////////////////////////////////////////////////////////
                a.Matkhau1 = Decrypt(a.Matkhau1);
                a.Hoten1 = reader.GetString(2);
                a.Ngaysinh1 = reader.GetDateTime(3);
                a.Sdt = reader.GetString(4);
                cmd.Dispose();
                reader.Dispose();
                connect.Close();
                return a;
            }
        }
        public string Encrypt(string toEncrypt)
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

        public string Decrypt(string toDecrypt)
        {
            byte[] keyArray;
            byte[] toEncryptArray = Convert.FromBase64String(toDecrypt);
            var hashmd5 = new MD5CryptoServiceProvider();
            keyArray = hashmd5.ComputeHash(Encoding.UTF8.GetBytes("dmtuibay"));
            var tdes = new TripleDESCryptoServiceProvider
            {
                Key = keyArray,
                Mode = CipherMode.ECB,
                Padding = PaddingMode.PKCS7
            };
            ICryptoTransform cTransform = tdes.CreateDecryptor();
            byte[] resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);
            return Encoding.UTF8.GetString(resultArray);
        }

        //-------------------------------QUẢN LÝ NHÀ CUNG CẤP------------------------------------------


        public DataTable getNhaCungCap()
        {
            string qry = "select * from NhaCungCap";
            return Get_Data(qry);
        }

        public bool them_NhaCungCap(nhacungcap ncc)
        {
            string qry = "insert into NhaCungCap(TenNCC, DiaChiNCC, SDTNCC) values(N'" + ncc.TenNCC1 + "', N'" + ncc.DiaChiNCC1 + "', N'" + ncc.SDTNCC1 + "')";
            return Insert_Update_Delete(qry);
        }
        public bool update_NhaCungCap(nhacungcap ncc)
        {
            string qry = "update NhaCungCap set TenNCC = N'" + ncc.TenNCC1 + "' ,DiaChiNCC = N'" + ncc.DiaChiNCC1 + "', SDTNCC = N'" + ncc.SDTNCC1 + "' where MNCC='" + ncc.MNCC1 + "'";
            return Insert_Update_Delete(qry);
        }
        public bool xoa_NhaCungCap(int MNCC)
        {
            string qry = "delete NhaCungCap where MNCC =" + MNCC;
            return Insert_Update_Delete(qry);
        }
        public nhacungcap laynhacungcap(int MNCC)
        {
            string qry = "select * from NhaCungCap where MNCC=" + MNCC;
            using (SqlConnection connect = new SqlConnection(connectionString))
            {
                connect.Open();
                SqlCommand cmd = new SqlCommand(qry, connect);
                SqlDataReader reader = cmd.ExecuteReader();
                reader.Read();
                nhacungcap a = new nhacungcap();
                a.MNCC1 = reader.GetInt32(0);
                a.TenNCC1 = reader.GetString(1);
                a.DiaChiNCC1 = reader.GetString(2);
                a.SDTNCC1 = reader.GetString(3);
                cmd.Dispose();
                reader.Dispose();
                connect.Close();
                return a;
            }
        }

        //----------------LOGIN



        public bool Check_Login(int ten,string pass)
        {
            string sqlCheck = "select count(*) from NhanVien where MatKhau='" + pass + "' and MNV='"+ten+"'";
            return Check(sqlCheck);
        }

      
        public DataTable get_TaiKhoan()
        {
            string qry = "select * from NhanVien";
            using (SqlConnection connect = new SqlConnection(connectionString))
            {
                DataTable dt = new DataTable();
                connect.Open();
                SqlCommand cmd = new SqlCommand(qry, connect);
                SqlDataReader reader = cmd.ExecuteReader();
                dt.Load(reader);
                cmd.Dispose();
                reader.Dispose();
                connect.Close();
                return dt;
            }
        }

        public DataTable get_MNV(string MNV)
        {
            string qry = "select * from NhanVien where MNV = '" + MNV + "'";
            using (SqlConnection connect = new SqlConnection(connectionString))
            {

                DataTable dt = new DataTable();
                connect.Open();
                SqlCommand cmd = new SqlCommand(qry, connect);
                SqlDataReader reader = cmd.ExecuteReader();
                dt.Load(reader);
                cmd.Dispose();
                reader.Dispose();
                connect.Close();
                return dt;
            }
        }

        public bool get_MatKhau(string MatKhau)
        {
            string qry = "select * from NhanVien where MatKhau like '%" + MatKhau + "%'";
            using (SqlConnection connect = new SqlConnection(connectionString))
            {

                DataTable dt = new DataTable();
                connect.Open();
                SqlCommand cmd = new SqlCommand(qry, connect);
                SqlDataReader reader = cmd.ExecuteReader();
                dt.Load(reader);
                cmd.Dispose();
                reader.Dispose();
                connect.Close();
                return true;
            }

        }
    }
}