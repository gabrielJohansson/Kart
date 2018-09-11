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
    public class TabelaCarroPessoasController : Controller
    {
        

        // GET: TabelaCarroPessoas
        public ActionResult Index(int id)
        {

            return View(CarroPessoaDao.ProcurarbyPessoa(id));
        }

        // GET: TabelaCarroPessoas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TabelaCarroPessoa tabelaCarroPessoa = CarroPessoaDao.ProcurarbyId(id);
            if (tabelaCarroPessoa == null)
            {
                return HttpNotFound();
            }
            return View(tabelaCarroPessoa);
        }

        // GET: TabelaCarroPessoas/Create
        public ActionResult Create()
        {
            ViewBag.Carro = CarrosDAO.ListarTodos();
            ViewBag.Pessoa = PessoasDAO.ListarTodasClientes();
            return View();
        }

        // POST: TabelaCarroPessoas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(int carroid,int pessoaid,TabelaCarroPessoa tabelaCarroPessoa)
        {
            Carro c = CarrosDAO.ProcurarbyId(carroid);
            Pessoa p = PessoasDAO.ProcurarbyId(pessoaid);
            tabelaCarroPessoa.c = c;
            tabelaCarroPessoa.p = p;
            tabelaCarroPessoa.dtaCadastro = DateTime.Now;
            if (ModelState.IsValid)
            {
                TabelaCarroPessoa teste = CarroPessoaDao.ProcurarbyExitencia(tabelaCarroPessoa.c.Id, tabelaCarroPessoa.p.Id);
                if (teste == null)
                {
                    CarroPessoaDao.AdicionarNovo(tabelaCarroPessoa);
                    return RedirectToAction("Index", "Home");
                }
                
                return RedirectToAction("Index", "Home");
            }

            return View(tabelaCarroPessoa);
        }

        //// GET: TabelaCarroPessoas/Edit/5
        //public ActionResult Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    TabelaCarroPessoa tabelaCarroPessoa = db.CarroPessoa.Find(id);
        //    if (tabelaCarroPessoa == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(tabelaCarroPessoa);
        //}

        //// POST: TabelaCarroPessoas/Edit/5
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include = "id,dtaCadastro")] TabelaCarroPessoa tabelaCarroPessoa)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(tabelaCarroPessoa).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    return View(tabelaCarroPessoa);
        //}

        // GET: TabelaCarroPessoas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TabelaCarroPessoa tabelaCarroPessoa = CarroPessoaDao.ProcurarbyId(id);
            if (tabelaCarroPessoa == null)
            {
                return HttpNotFound();
            }
            return View(tabelaCarroPessoa);
        }

        // POST: TabelaCarroPessoas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TabelaCarroPessoa tabelaCarroPessoa = CarroPessoaDao.ProcurarbyId(id);
            CarroPessoaDao.Remove(tabelaCarroPessoa);
            return RedirectToAction("Index");
        }

    }
}
