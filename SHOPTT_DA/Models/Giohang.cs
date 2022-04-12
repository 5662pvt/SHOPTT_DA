using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SHOPTT_DA.Models;

namespace SHOPTT_DA.Models
{
    public class Giohang
    {
        MyDataDataContext data = new MyDataDataContext();
        public int imasp { get; set; }

        public string stensp { get; set; }

        public string shinh { get; set; }

        public Double dgiaban { get; set; }

        public int isoluong { get; set; }

        public Double dthanhtien
        {
            get { return isoluong * dgiaban; }
        }

        public  Giohang (int masp)
        {
            imasp = masp;
            SanPham sp = data.SanPhams.Single(n => n.MaSP == imasp);
            stensp = sp.TenSP;
            shinh = sp.Hinh;
            dgiaban = double.Parse(sp.GiaBan.ToString());
            isoluong = 1;       
        }
    }
}