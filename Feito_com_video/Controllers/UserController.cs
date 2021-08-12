using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using crud4.Models;

namespace crud4.Controllers
{
    public class UserController : Controller
    {
        private DemoEntities db = new DemoEntities();

        // GET: User
        public async Task<ActionResult> Index()
        {
            return View(await db.Tb_User.ToListAsync());
        }

        // GET: User/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tb_User tb_User = await db.Tb_User.FindAsync(id);
            if (tb_User == null)
            {
                return HttpNotFound();
            }
            return View(tb_User);
        }


        // GET: User/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: User/Create
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Nome,Email,Endereco")] Tb_User tb_User)
        {
            if (ModelState.IsValid)
            {
                db.Tb_User.Add(tb_User);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(tb_User);
        }

        // GET: User/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tb_User tb_User = await db.Tb_User.FindAsync(id);
            if (tb_User == null)
            {
                return HttpNotFound();
            }
            return View(tb_User);
        }

        // POST: User/Edit/5
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Nome,Email,Endereco")] Tb_User tb_User)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tb_User).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(tb_User);
        }

        // GET: User/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tb_User tb_User = await db.Tb_User.FindAsync(id);
            if (tb_User == null)
            {
                return HttpNotFound();
            }
            return View(tb_User);
        }

        // POST: User/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Tb_User tb_User = await db.Tb_User.FindAsync(id);
            db.Tb_User.Remove(tb_User);
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
