using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using LoclaPista.Models;
using LoclaPista.DAL;

namespace LoclaPista.Controllers
{
    public class HorarioPistasController : Controller
    {

        // GET: HorarioPistas
        public ActionResult Index()
        {
            HttpCookie myCookie = Request.Cookies["Loja"];
            return View(HorarioPistaDAO.ListarTodos(Int32.Parse(myCookie.Values["lojaId"])));
        }

        // GET: HorarioPistas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HorarioPista horarioPista = HorarioPistaDAO.ProcurarbyId(id);
            if (horarioPista == null)
            {
                return HttpNotFound();
            }
            return View(horarioPista);
        }

        // GET: HorarioPistas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: HorarioPistas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,Hora_inicial,Hora_Final")] HorarioPista horarioPista)
        {
            if (ModelState.IsValid)
            {
                HorarioPistaDAO.AdicionarNovo(horarioPista);
                return RedirectToAction("Index");
            }

            return View(horarioPista);
        }

        // GET: HorarioPistas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HorarioPista horarioPista = HorarioPistaDAO.ProcurarbyId(id);
            if (horarioPista == null)
            {
                return HttpNotFound();
            }
            return View(horarioPista);
        }

        // POST: HorarioPistas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,Hora_inicial,Hora_Final")] HorarioPista horarioPista)
        {
            if (ModelState.IsValid)
            {
                HorarioPistaDAO.Editar(horarioPista, horarioPista.id);
                return RedirectToAction("Index");
            }
            return View(horarioPista);
        }

        // GET: HorarioPistas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HorarioPista horarioPista = HorarioPistaDAO.ProcurarbyId(id);
            if (horarioPista == null)
            {
                return HttpNotFound();
            }
            return View(horarioPista);
        }

        // POST: HorarioPistas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            HorarioPista horarioPista = HorarioPistaDAO.ProcurarbyId(id);
            HorarioPistaDAO.Remove(horarioPista);
            return RedirectToAction("Index");
        }
     
    }
}
