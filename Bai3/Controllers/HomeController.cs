using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Bai3.Models;

namespace Bai3.Controllers
{
    public class HomeController : Controller
    {
        QL_NhanSu db = new QL_NhanSu();
        public ActionResult Index()
        {
            List<tbl_Employee> ds = db.tbl_Employee.Include("tbl_Deparment").ToList();
            ViewBag.Departments = db.tbl_Deparment.ToList();
            return View(ds);
        }

        public  ActionResult FilterByDepartment(int DepId)
        {
            List<tbl_Employee> ds;
            if (DepId == 0)
            {
                ds = db.tbl_Employee.Include("tbl_Deparment").ToList();
                ViewBag.CurrentDepName = "Tất Cả Nhân Viên";
            }
            else
            {
                ds = db.tbl_Employee.Include("tbl_Deparment").Where(e => e.DepId == DepId).ToList();
                ViewBag.CurrentDepName = db.tbl_Deparment.Find(DepId).DepName;
            }
            ViewBag.Departments = db.tbl_Deparment.ToList() ;
            return View("Index", ds);
                
        }
        public ActionResult ThemMoi()
        {
            ViewBag.DepId = new SelectList(db.tbl_Deparment.ToList(), "DepId", "DepName");
            return View();
        }
        [HttpPost]
        public ActionResult Create(tbl_Employee lnv)
        {
            db.tbl_Employee.Add(lnv);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {

            ViewBag.DepId = new SelectList(db.tbl_Deparment.ToList(), "DepId", "DepName");

            var E_em = db.tbl_Employee.First(m => m.Id == id);
            return View(E_em);
        }

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {

            var E_em = db.tbl_Employee.First(m => m.Id == id);

            E_em.Id = id;

            UpdateModel(E_em);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Details(int id)
        {
            var Details_em = db.tbl_Employee
                               .Include("tbl_Deparment") 
                               .Where(m => m.Id == id)
                               .First();
            return View(Details_em);
        }

        public ActionResult Delete(int id)
        {
            var D_em = db.tbl_Employee.First(m => m.Id == id);
            return View(D_em);
        }

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            var D_tin = db.tbl_Employee.Where(m => m.Id == id).First();
            //xóa
            db.tbl_Employee.Remove(D_tin);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}