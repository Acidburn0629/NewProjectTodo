using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Web.Models;

namespace Web.Controllers
{
    public class ColorMasterController : Controller
    {
        private SQLTESTEntities db = new SQLTESTEntities();


        //


        // GET: ColorMaster
        public ActionResult Index()
        {
            return View(db.COLORMASTERFILEs.ToList());
        }

        // GET: ColorMaster/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            COLORMASTERFILE cOLORMASTERFILE = db.COLORMASTERFILEs.Find(id);
            if (cOLORMASTERFILE == null)
            {
                return HttpNotFound();
            }
            return View(cOLORMASTERFILE);
        }

        // GET: ColorMaster/Create
        public ActionResult Create()
        {
            return View();
        }



        //******** UPDATED BY NIX *********//
        // POST: ColorMaster/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "COLORCODE,DESCRIPTIONS,ID")] COLORMASTERFILE cOLORMASTERFILE)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.COLORMASTERFILEs.Add(cOLORMASTERFILE);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }

            }
            catch (Exception ex)    
            {
                // Log the error (uncomment dex variable name and add a line here to write a log.
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
               
            }
            return View(cOLORMASTERFILE);
        }

        // GET: ColorMaster/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            COLORMASTERFILE cOLORMASTERFILE = db.COLORMASTERFILEs.Find(id);
            if (cOLORMASTERFILE == null)
            {
                return HttpNotFound();
            }
            return View(cOLORMASTERFILE);



        }

        //******** UPDATED BY NIX *********//
        // POST: ColorMaster/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "COLORCODE,DESCRIPTIONS,ID")] COLORMASTERFILE cOLORMASTERFILE)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cOLORMASTERFILE).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cOLORMASTERFILE);

        }




        // GET: ColorMaster/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            COLORMASTERFILE cOLORMASTERFILE = db.COLORMASTERFILEs.Find(id);
            if (cOLORMASTERFILE == null)
            {
                return HttpNotFound();
            }
            return View(cOLORMASTERFILE);
        }

        // POST: ColorMaster/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            COLORMASTERFILE cOLORMASTERFILE = db.COLORMASTERFILEs.Find(id);
            db.COLORMASTERFILEs.Remove(cOLORMASTERFILE);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
