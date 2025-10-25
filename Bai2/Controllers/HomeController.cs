using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Bai2.Models;

namespace Bai2.Controllers
{
    public class HomeController : Controller
    {

        QLSach data = new QLSach();

        public ActionResult DMSach()
        {
            List<Sach> ds = data.Sach.ToList();
            return View(ds);
        }

        [HttpGet]
        public ActionResult ThemMoiSach()
        {
            ViewBag.MaCD = new SelectList(data.ChuDe.ToList().OrderBy(n => n.TenChuDe), "MaCD", "TenChuDe");
            ViewBag.MaNXB = new SelectList(data.NhaXuatBan.ToList().OrderBy(n => n.TenNXB), "MaNXB", "TenNXB");
            return View();
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult ThemMoiSach(Sach s)
        {
            if (ModelState.IsValid)
            {
                data.Sach.Add(s);
                data.SaveChanges();
                return RedirectToAction("DMSach");
            }

            ViewBag.MaCD = new SelectList(data.ChuDe.ToList().OrderBy(n => n.TenChuDe), "MaCD", "TenChuDe", s.MaCD);
            ViewBag.MaNXB = new SelectList(data.NhaXuatBan.ToList().OrderBy(n => n.TenNXB), "MaNXB", "TenNXB", s.MaNXB);
            return View(s);
        }

        public ActionResult Chitietsach(string id)
        {

            Sach sach = data.Sach.SingleOrDefault(n => n.MaSach == id);
            ViewBag.MaSach = sach?.MaSach;

            if (sach == null)
            {
                Response.StatusCode = 404;
                return null;
            }

            return View(sach);
        }

        [HttpGet]
        public ActionResult Delete(string id)
        {

            Sach sach = data.Sach.SingleOrDefault(n => n.MaSach == id);
            if (sach == null)
            {
                return HttpNotFound(); 
            }

            return View("Delete", sach);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult Xacnhanxoa(string id)
        {
            Sach sach = data.Sach.SingleOrDefault(n => n.MaSach == id);
            if (sach == null)
            {
                return HttpNotFound();
            }

            data.Sach.Remove(sach);
            data.SaveChanges();
            return RedirectToAction("DMSach");
        }

    }
}
