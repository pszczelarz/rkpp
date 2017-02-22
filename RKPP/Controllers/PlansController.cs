using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using RKPP.Models;

namespace RKPP.Controllers
{
    public class PlansController : Controller
    {
        private PlanDBContext db = new PlanDBContext();

        // GET: Plans
        public ActionResult Index()
        {
            return View(db.Plans.ToList());
        }

        // GET: Plans/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Plan plan = db.Plans.Find(id);
            if (plan == null)
            {
                return HttpNotFound();
            }
            return View(plan);
        }

        // GET: Plans/Create
        //[Authorize]
        //public ActionResult Create()
        //{
        //    return View();
        //}

        // POST: Plans/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //[Authorize]
        //public ActionResult Create([Bind(Include = "Id,Content")] Plan plan)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Plans.Add(plan);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //    return View(plan);
        //}

        // GET: Plans/Edit/5
        [Authorize]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Plan plan = db.Plans.Find(id);
            if (plan == null)
            {
                return HttpNotFound();
            }
            return View(plan);
        }

        // POST: Plans/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Edit([Bind(Include = "Id,Content")] Plan plan)
        {
            if (ModelState.IsValid)
            {
                db.Entry(plan).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(plan);
        }

        // GET: Plans/Delete/5
        //[Authorize]
        //public ActionResult Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Plan plan = db.Plans.Find(id);
        //    if (plan == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(plan);
        //}

        // POST: Plans/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //[Authorize]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    Plan plan = db.Plans.Find(id);
        //    db.Plans.Remove(plan);
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}
    }
}
