using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SHOPTT_DA.Models;

namespace SHOPTT_DA.Controllers
{
    public class SneakerController : Controller
    {
        //TAO 1 doi tuong quan ly csdl
        MyDataDataContext data = new MyDataDataContext();

        private List<SanPham> SPMOI(int count)
        {
            //sap xep loc sp moi ra
            return data.SanPhams.OrderByDescending(a => a.NgayCapNhat).Take(count).ToList();
        }

        // GET: Sneaker
        public ActionResult Index()
        {
            var spmoi = SPMOI(5);
            return View(spmoi);
        }

        public ActionResult LoaiSanPham()
        {
            var loaisanpham = from lsp in data.LoaiSPs select lsp;
            return PartialView(loaisanpham);
        }

        public ActionResult ThuongHieu()
        {
            var thuonghieu = from th in data.ThuongHieus select th;
            return PartialView(thuonghieu);
        }

        public ActionResult SPTheoLoai(int id)
        {
            var sptl = from tl in data.SanPhams where tl.MaLoai == id select tl;
            return PartialView(sptl);
        }

        public ActionResult SPTheoTH(int id)
        {
            var sptth = from tl in data.SanPhams where tl.MaThuongHieu == id select tl;
            return PartialView(sptth);
        }

        public ActionResult Details(int id)
        {
            var sp = from s in data.SanPhams where s.MaSP == id select s;
            return View(sp.Single());
        }
    }
}