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
    public class CarroesController : Controller
    {


        // GET: Carroes
        public ActionResult Index()
        {
            HttpCookie myCookie = Request.Cookies["Loja"];
            return View(CarrosDAO.ListarTodos(Int32.Parse(myCookie.Values["lojaId"])));
        }

        // GET: Carroes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Carro carro = CarrosDAO.ProcurarbyId(id);
            if (carro == null)
            {
                return HttpNotFound();
            }
            return View(carro);
        }

        // GET: Carroes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Carroes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,placa,modelo,marca,cor")] Carro carro,int?id)
        {
            HttpCookie myCookie = Request.Cookies["Loja"];
            carro.loja = LojaDAO.ProcurarbyId(Int32.Parse(myCookie.Values["lojaId"]));
            if (ModelState.IsValid)
            {
                Carro teste = CarrosDAO.ProcurarbyPlaca(carro.placa);
                if (teste == null)
                {
                    CarrosDAO.AdicionarNovo(carro);
                    ///fazer a relaçao
                    Carro teste2 = CarrosDAO.ProcurarbyPlaca(carro.placa);
                    TabelaCarroPessoa t = new TabelaCarroPessoa();
                    t.c = teste2;
                    t.p = PessoasDAO.ProcurarbyId(id);
                    t.dtaCadastro = DateTime.Now;
                    CarroPessoaDao.AdicionarNovo(t);
                    return RedirectToAction("Index","Pessoas");
                }
                ModelState.AddModelError("", "Carro já Cadastrado");
                return View();
            }

            return View(carro);
        }

        // GET: Carroes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Carro carro = CarrosDAO.ProcurarbyId(id);
            if (carro == null)
            {
                return HttpNotFound();
            }
            return View(carro);
        }

        // POST: Carroes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,placa,modelo,marca,cor")] Carro carro)
        {
            if (ModelState.IsValid)
            {
                CarrosDAO.Editar(carro, carro.Id);
                return RedirectToAction("Index");
            }
            return View(carro);
        }

        // GET: Carroes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Carro carro = CarrosDAO.ProcurarbyId(id);
            if (carro == null)
            {
                return HttpNotFound();
            }
            return View(carro);
        }

        // POST: Carroes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Carro carro = CarrosDAO.ProcurarbyId(id);
            CarrosDAO.Remove(carro);
            return RedirectToAction("Index");
        }

    }
}
