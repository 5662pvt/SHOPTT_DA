using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SHOPTT_DA.Models;

namespace SHOPTT_DA.Controllers
{
    public class GiohangController : Controller
    {
        MyDataDataContext db = new MyDataDataContext();
        // GET: Giohang
        public ActionResult Index()
        {
            return View();
        }

        public List<Giohang> Laygiohang()
        {
            List<Giohang> listGioHang = Session["Giohang"] as List<Giohang>;
            //neu ton tai thi gan vao gio hang
            if (listGioHang == null)
            {
                listGioHang = new List<Giohang>();
                Session["Giohang"] = listGioHang;
            }
            return listGioHang;
        }

        public ActionResult ThemGioHang(int imasp, string strURL)
        {
            //Laygiohang secsion
            List<Giohang> listGioHang = Laygiohang();
            //kt sach da chon vao gio hang hay chua
            Giohang sanpham = listGioHang.Find(n => n.imasp == imasp);
            if (sanpham == null)
            {
                sanpham = new Giohang(imasp);
                listGioHang.Add(sanpham);
                return Redirect(strURL);
            }
            else
            {
                sanpham.isoluong++;
                return Redirect(strURL);
            }
        }

        private int TongSoluong()
        {
            int tsl = 0;
            List<Giohang> listGioHang = Session["Giohang"] as List<Giohang>;
            if (listGioHang != null)
            {
                tsl = listGioHang.Sum(n => n.isoluong);
            }
            return tsl;
        }

        private int TongSoluongSanPham()
        {
            int tsl = 0;
            List<Giohang> listGioHang = Session["Giohang"] as List<Giohang>;
            if (listGioHang != null)
            {
                tsl = listGioHang.Count;
            }
            return tsl;
        }

        private double TongTien()
        {
            double tt = 0;
            List<Giohang> listGioHang = Session["Giohang"] as List<Giohang>;
            if (listGioHang != null)
            {
                tt = listGioHang.Sum(n => n.dthanhtien);
            }
            return tt;
        }

        public ActionResult GioHang()
        {
            List<Giohang> listGioHang = Laygiohang();
           
            ViewBag.Tongsoluong = TongSoluong();
            ViewBag.Tongtien = TongTien();
            ViewBag.Tongsoluongsanpham = TongSoluongSanPham();
            return View(listGioHang);
        }

        public ActionResult GioHangPartial()
        {
            ViewBag.Tongsoluong = TongSoluong();
            ViewBag.Tongtien = TongTien();
            ViewBag.Tongsoluongsanpham = TongSoluongSanPham();
            return PartialView();
        }

        public ActionResult XoaGiohang(int iMaSP)
        {
            List<Giohang> listGioHang = Laygiohang();
            Giohang sanpham = listGioHang.SingleOrDefault(n => n.imasp == iMaSP);
            if (sanpham != null)
            {
                listGioHang.RemoveAll(n => n.imasp == iMaSP);
                return RedirectToAction("Giohang");
            }
            return RedirectToAction("Giohang");
        }

        public ActionResult CapnhatGiohang(int iMaSP, FormCollection collection)
        {
            List<Giohang> listGioHang = Laygiohang();
            Giohang sanpham = listGioHang.SingleOrDefault(n => n.imasp == iMaSP);
            if (sanpham != null)
            {
                sanpham.isoluong = int.Parse(collection["txtSolg"].ToString());
            }
            return RedirectToAction("Giohang");
        }

        public ActionResult XoaTatCaGioHang()
        {
            List<Giohang> listGioHang = Laygiohang();
            listGioHang.Clear();
            return RedirectToAction("Giohang");
        }
    }
}