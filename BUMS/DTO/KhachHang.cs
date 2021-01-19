using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BUMS
{
    public class KhachHang
    {
        private string mkh;
        private string tenKH;
        private string diaChiKH;
        private string sdtkh;
        

        public KhachHang()
        {

        }
        public KhachHang(string mkh, string tenKH, string diaChiKH, string sdtkh)
        {
            this.mkh = mkh;
            this.tenKH = tenKH;
            this.diaChiKH = diaChiKH;
            this.sdtkh = sdtkh;
           

        }
        public string MKH { get { return mkh; } set { mkh = value; } }
        public string TenKH { get { return tenKH; } set { tenKH = value; } }
        public string DiaChiKH { get { return diaChiKH; } set { diaChiKH = value; } }
        public string SDTKH { get { return sdtkh; } set { sdtkh = value; } }

    }
}