using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Bai1.Models;

namespace Bai1.Controllers
{
    public class HomeController : Controller
    {
        //GET: /Home/
        BookStore data = new BookStore();

        public ActionResult Index()
        {
            List<Theloaitin> ds = data.Theloaitin.ToList();
            return View(ds);
        }

        public ActionResult ThemMoi()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create (Theloaitin ltin)
        {
            data.Theloaitin.Add(ltin);
            data.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Edit (int id)
        {
            var EB_tin = data.Theloaitin.First(m => m.IDLoai == id);
            return View(EB_tin);
        }

        [HttpPost]
        public ActionResult Edit (int id, FormCollection collection)
        {
            //Tạo 1 biến Ltin gắn với đối tượng có id=id truyền vào
            var Ltin = data.Theloaitin.First(m => m.IDLoai == id);
            var E_Loaitin = collection["Tentheloai"];

            Ltin.IDLoai = id;
            Ltin.Tentheloai = E_Loaitin;
            //Thực hiện update
            UpdateModel(Ltin);
            data.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Details(int id)
        {
            var Details_tin = data.Theloaitin.Where(m => m.IDLoai == id).First();   
            return View(Details_tin);
        }

        public ActionResult Delete(int id)
        {
            var D_tin = data.Theloaitin.First(m => m.IDLoai == id);
            return View(D_tin);
        }

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            //Tạo 1 biến D_Tin gắn với đối tượng có ID bằng với ID tham số
            var D_tin = data.Theloaitin.Where(m => m.IDLoai == id).First();
            //xóa
            data.Theloaitin.Remove(D_tin);
            data.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}