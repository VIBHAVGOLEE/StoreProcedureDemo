using StoreProcedureDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StoreProcedureDemo.Controllers
{
    public class BranchController : Controller
    {
        imsEntities db = new imsEntities();
        // GET: Branch
        public ActionResult Index()
        {
            return View(db.sp_select_branch().ToList());
        }

        public ActionResult Create()
        {
            return View();
        }


        // Post: Save Branch
        [HttpPost]
        public ActionResult Create(Branch branch)
        {
            db.sp_insert_branch(branch.Id,branch.BranchName);
            return RedirectToAction("Index");
        }


        public ActionResult Edit(int Id)
        {
            var b = db.sp_find_branch(Id).FirstOrDefault();
            return View(b);
        }

        [HttpPost]
        public ActionResult Edit(Branch b)
        {
            db.sp_update_branch(b.Id, b.BranchName);

            return RedirectToAction("Index");
        }

        public ActionResult Delete(int Id)
        {
            db.sp_delete_branch(Id);
            return RedirectToAction("Index");
        }
    }
}