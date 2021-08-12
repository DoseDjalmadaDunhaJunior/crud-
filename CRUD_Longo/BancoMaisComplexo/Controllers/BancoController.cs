using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BancoMaisComplexo.Models;

namespace BancoMaisComplexo.Controllers
{
    public class BancoController : Controller
    {
        private ComplexoEntities db = new ComplexoEntities();

        // GET: Banco
        public async Task<ActionResult> Index()
        {
            return View(await db.bdLongoes.ToListAsync());
        }

        // GET: Banco/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            bdLongo bdLongo = await db.bdLongoes.FindAsync(id);
            if (bdLongo == null)
            {
                return HttpNotFound();
            }
            return View(bdLongo);
        }

        // GET: Banco/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Banco/Create
        // Para se proteger de mais ataques, habilite as propriedades específicas às quais você quer se associar. Para 
        // obter mais detalhes, veja https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Nome,Sexo,Telefone,Email,Endereco")] bdLongo bdLongo)
        {
            if (ModelState.IsValid)
            {
                db.bdLongoes.Add(bdLongo);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(bdLongo);
        }

        // GET: Banco/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            bdLongo bdLongo = await db.bdLongoes.FindAsync(id);
            if (bdLongo == null)
            {
                return HttpNotFound();
            }
            return View(bdLongo);
        }

        // POST: Banco/Edit/5
        // Para se proteger de mais ataques, habilite as propriedades específicas às quais você quer se associar. Para 
        // obter mais detalhes, veja https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Nome,Sexo,Telefone,Email,Endereco")] bdLongo bdLongo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bdLongo).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(bdLongo);
        }

        // GET: Banco/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            bdLongo bdLongo = await db.bdLongoes.FindAsync(id);
            if (bdLongo == null)
            {
                return HttpNotFound();
            }
            return View(bdLongo);
        }

        // POST: Banco/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            bdLongo bdLongo = await db.bdLongoes.FindAsync(id);
            db.bdLongoes.Remove(bdLongo);
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
