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
    public class PistasController : Controller
    {

        // GET: Pistas
        public ActionResult Index()
        {
            HttpCookie myCookie = Request.Cookies["Loja"];
            return View(PistasDAO.ListarTodas(Int32.Parse(myCookie.Values["lojaId"])));
        }

        // GET: Pistas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pista pista = PistasDAO.ProcurarbyId(id);
            if (pista == null)
            {
                return HttpNotFound();
            }
            return View(pista);
        }

        // GET: Pistas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Pistas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nome,dtaCadastro,Ativo")] Pista pista)
        {
            HttpCookie myCookie = Request.Cookies["Loja"];
            
           
            pista.loja=  LojaDAO.ProcurarbyId(Int32.Parse(myCookie.Values["lojaId"]));
            
            pista.Ativo = 1;
            pista.dtaCadastro = DateTime.Now;
            if (ModelState.IsValid)
            {
                Pista Teste = PistasDAO.ProcurarbyNome(pista.Nome);
                if(Teste==null)
                {
                   PistasDAO.AdicionarNovo(pista);
                    return RedirectToAction("Index");
                }
                ModelState.AddModelError("", "Pista com mesmo Nome já Cadastrada");
                return View();
            }

            return View(pista);
        }

        // GET: Pistas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pista pista = PistasDAO.ProcurarbyId(id);
            if (pista == null)
            {
                return HttpNotFound();
            }
            return View(pista);
        }

        // POST: Pistas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nome,dtaCadastro,Ativo")] Pista pista, bool chkConectado)
        {
               
                Pista Teste = PistasDAO.ProcurarbyNome(pista.Nome);
            if(chkConectado)
            {
                pista.Ativo = 0;
            }
            else
            {
                pista.Ativo = 1;
            }
                if (Teste == null||!chkConectado)
                {
                    PistasDAO.Editar(pista, pista.Id);
                    return RedirectToAction("Index");
                }
                ModelState.AddModelError("", "Pista com mesmo Nome já Cadastrada");
                return View();
            
        }

        // GET: Pistas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pista pista = PistasDAO.ProcurarbyId(id);
            if (pista == null)
            {
                return HttpNotFound();
            }
            return View(pista);
        }

        // POST: Pistas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Pista pista = PistasDAO.ProcurarbyId(id);
            PistasDAO.Remove(pista);
            return RedirectToAction("Index");
        }


    }
}
