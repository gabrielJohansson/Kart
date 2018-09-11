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
    public class CorridasController : Controller
    {
        // GET: Corridas
        public ActionResult Index()
        {
            return View(CorridaDAO.ListarTodosData());
        }

        // GET: Corridas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Corrida corrida = CorridaDAO.ProcurarbyId(id);
            if (corrida == null)
            {
                return HttpNotFound();
            }
            return View(corrida);
        }

        // GET: Corridas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Corridas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,DtaCadastro,DtaCorrida,DtaCancelamento,Preco")] Corrida corrida)
        {
            if (ModelState.IsValid)
            {
                Corrida teste = CorridaDAO.ProcurarbyDtaCorrida(corrida.DtaCorrida);
                Corrida teste1 = CorridaDAO.ProcurarbyDtaCorrida(corrida.DtaCorrida.AddHours(1));
                if (teste != null && teste1 != null)
                {
                    CorridaDAO.AdicionarNovo(corrida);

                    return RedirectToAction("Index");
                }
                ModelState.AddModelError("", "Esse Horário já está ocupado!");
                return View();
            }

            return View(corrida);
        }

        // GET: Corridas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Corrida corrida = CorridaDAO.ProcurarbyId(id);
            if (corrida == null)
            {
                return HttpNotFound();
            }
            return View(corrida);
        }

        // POST: Corridas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,DtaCadastro,DtaCorrida,DtaCancelamento,Preco")] Corrida corrida)
        {
            if (ModelState.IsValid)
            {
                CorridaDAO.Editar(corrida,corrida.Id);
                return RedirectToAction("Index");
            }
            return View(corrida);
        }

        // GET: Corridas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Corrida corrida = CorridaDAO.ProcurarbyId(id);
            if (corrida == null)
            {
                return HttpNotFound();
            }
            return View(corrida);
        }

        // POST: Corridas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Corrida corrida = CorridaDAO.ProcurarbyId(id);
            CorridaDAO.Cancela(corrida.Id);
            HorarioPista h = HorarioPistaDAO.ProcurarbyDataHoraPista(corrida.DtaCorrida,corrida.Pista.Id);
            HorarioPistaDAO.Remove(h);
            return RedirectToAction("Index");
        }
    }
}
