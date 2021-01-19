using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BUMS
{
    public class nhanvien
    {
        private int MNV;
        private string Matkhau;
        private string Hoten;
        private DateTime Ngaysinh;
        private string sdt;

        public int MNV1
        {
            get
            {
                return MNV;
            }

            set
            {
                MNV = value;
            }
        }

        public string Matkhau1
        {
            get
            {
                return Matkhau;
            }

            set
            {
                Matkhau = value;
            }
        }

        public string Hoten1
        {
            get
            {
                return Hoten;
            }

            set
            {
                Hoten = value;
            }
        }

        public DateTime Ngaysinh1
        {
            get
            {
                return Ngaysinh;
            }

            set
            {
                Ngaysinh = value;
            }
        }

        public string Sdt
        {
            get
            {
                return sdt;
            }

            set
            {
                sdt = value;
            }
        }
    }
}