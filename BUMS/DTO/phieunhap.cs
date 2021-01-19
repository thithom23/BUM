using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BUMS
{
    public class phieunhap
    {
        private int MPN;
        private int MNV;
        private int MNCC;
        private DateTime NgayNhap;
       
        public int MPN1
        {
            get
            {
                return MPN;
            }

            set
            {
                MPN = value;
            }
        }

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

        public int MNCC1
        {
            get
            {
                return MNCC;
            }

            set
            {
                MNCC = value;
            }
        }

        public DateTime NgayNhap1   
        {
            get
            {
                return NgayNhap;
            }

            set
            {
                NgayNhap = value;
            }
        }
    }
}