using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MD.Data.Models;

namespace MasterData.Controllers
{
    public class LinksController : Controller
    {
        private MdContext db = new MdContext();

        // GET: Links
        public async Task<ActionResult> Index()
        {
            //var linkSet = db.LinkSet.Include(l => l.Contractor).Include(l => l.Node);
            return View(await db.LinkSet.ToListAsync());
        }

        // GET: Links/Details/5
        public async Task<ActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Link link = await db.LinkSet.FindAsync(id);
            if (link == null)
            {
                return HttpNotFound();
            }
            return View(link);
        }

        // GET: Links/Create
        public ActionResult Create()
        {
            ViewBag.ContractorId = new SelectList(db.ContractorSet.OrderBy(c => c.Name), "Id", "Name");
            ViewBag.NodeId = new SelectList(db.NodeSet, "Id", "Name");
            return View();
        }

        // POST: Links/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Date,ContractorId,NativeId,NodeId")] Link link)
        {
            if (ModelState.IsValid)
            {
                link.Id = Guid.NewGuid();
                link.Date = DateTime.Now;
                db.Entry(link.Contractor).State = EntityState.Unchanged;
                db.Entry(link.Node).State = EntityState.Unchanged;
                db.LinkSet.Add(link);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.ContractorId = new SelectList(db.ContractorSet, "Id", "Name", link.ContractorId);
            ViewBag.NodeId = new SelectList(db.NodeSet, "Id", "Name", link.NodeId);
            return View(link);
        }

        // GET: Links/Edit/5
        public async Task<ActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Link link = await db.LinkSet.FindAsync(id);
            if (link == null)
            {
                return HttpNotFound();
            }
            ViewBag.ContractorId = new SelectList(db.ContractorSet.OrderBy(c => c.Name), "Id", "Name", link.ContractorId);
            ViewBag.NodeId = new SelectList(db.NodeSet, "Id", "Name", link.NodeId);
            return View(link);
        }

        // POST: Links/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,ContractorId,NativeId,NodeId")] Link link)
        {
            if (ModelState.IsValid)
            {
                link.Date = DateTime.Now;
                db.Entry(link).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.ContractorId = new SelectList(db.ContractorSet, "Id", "Name", link.ContractorId);
            ViewBag.NodeId = new SelectList(db.NodeSet, "Id", "Name", link.NodeId);
            return View(link);
        }

        // GET: Links/Delete/5
        public async Task<ActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Link link = await db.LinkSet.FindAsync(id);
            if (link == null)
            {
                return HttpNotFound();
            }
            return View(link);
        }

        // POST: Links/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(Guid id)
        {
            Link link = await db.LinkSet.FindAsync(id);
            db.LinkSet.Remove(link);
            await db.SaveChangesAsync();
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
