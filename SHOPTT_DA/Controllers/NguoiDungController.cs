using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SHOPTT_DA.Models;

namespace SHOPTT_DA.Controllers
{
    public class NguoiDungController : Controller
    {
        MyDataDataContext db = new MyDataDataContext();
        // GET: NguoiDung
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult DangKy()
        {
            return View();
        }

        [HttpPost]
        public ActionResult DangKy(FormCollection collection,KhachHang kh)
        {
            //gan gia tri vao form
            var hoten = collection["HotenKH"];
            var tendn = collection["TenDN"];
            var matkhau = collection["MatKhau"];
            var mknl = collection["MatKhauNhapLai"];
            var sdt = collection["SDT"];
            var email = collection["Email"];
            var diachi = collection["DiacChi"];
            var ngaysinh = String.Format("{0:MM/dd/yyyy}", collection["NgaySinh"]);
            if(string.IsNullOrEmpty(hoten))
            {
                ViewData["Loi1"] = "Ho ten khong duoc de trong";
            }
            if (string.IsNullOrEmpty(tendn))
            {
                ViewData["Loi2"] = "ten dang nhap khong duoc de trong";
            }
            if (string.IsNullOrEmpty(matkhau))
            {
                ViewData["Loi3"] = "mat khau khong duoc de trong";
            }
            if (string.IsNullOrEmpty(mknl))
            {
                ViewData["Loi4"] = "Nhap lai mat khau khong duoc de trong";
            }
            if (string.IsNullOrEmpty(sdt))
            {
                ViewData["Loi5"] = "so dien thoai khong duoc de trong";
            }
            if (string.IsNullOrEmpty(email))
            {
                ViewData["Loi6"] = "email khong duoc de trong";
            }
            //if (string.IsNullOrEmpty(diachi))
            //{
            //    ViewData["Loi7"] = "dia chi khong duoc de trong";
            //}
            else
            {
                //gan vao data
                kh.TenKH = hoten;
                kh.SDT = sdt;
                kh.Email = email;
                kh.DiaChi = diachi;
                kh.NgaySinh = DateTime.Parse(ngaysinh);
                kh.TaiKhoan = tendn;
                kh.MatKhau = matkhau;
                db.KhachHangs.InsertOnSubmit(kh);
                db.SubmitChanges();
                return RedirectToAction("DangNhap");
            }
            return this.DangKy();
        }
    }
}