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
using System.Globalization;

namespace LoclaPista.Controllers
{
    public class ComposicaoCorridasController : Controller
    {
        // GET: ComposicaoCorridas
        public ActionResult Index()
        {
            return View(ComposicaoDAO.ListarTodos());
        }

        // GET: ComposicaoCorridas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ComposicaoCorrida composicaoCorrida = ComposicaoDAO.ProcurarbyId(id);
            if (composicaoCorrida == null)
            {
                return HttpNotFound();
            }
            return View(composicaoCorrida);
        }

        // GET: ComposicaoCorridas/Create
        public ActionResult Create()
        {
            ViewBag.Pista = PistasDAO.ListarTodasAtivas();
            ViewBag.CarroPessoa = CarroPessoaDao.ListarTodos();
           
            return View();
        }

        // POST: ComposicaoCorridas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(int carroid, int carroid2, int carroid3, int carroid4,int pistaid,string data,int id, ComposicaoCorrida composicaoCorrida)
        {
            try
            {
                DateTime dta = DateTime.ParseExact(data, "dd/MM/yyyy HH:mm",
                                       CultureInfo.InvariantCulture);


                HorarioPista ho = HorarioPistaDAO.ProcurarbyDataHoraPista(dta, pistaid);
                if (ho == null)
                {
                    string guid = System.Guid.NewGuid().ToString();
                    TabelaCarroPessoa teste1 = CarroPessoaDao.ProcurarbyId(carroid);
                    TabelaCarroPessoa teste2 = CarroPessoaDao.ProcurarbyId(carroid2);
                    TabelaCarroPessoa teste3 = CarroPessoaDao.ProcurarbyId(carroid3);
                    TabelaCarroPessoa teste4 = CarroPessoaDao.ProcurarbyId(carroid4);
                    //verificar se nao repete ngm
                    //ver se os carros sao diferentes
                    //ver se no dia no horario e a pista estao vagaas
                    if (ModelState.IsValid)
                    {
                        if (teste1.c.placa != teste2.c.placa | teste1.c.placa != teste3.c.placa | teste1.c.placa != teste4.c.placa | teste2.c.placa != teste3.c.placa | teste2.c.placa != teste4.c.placa | teste3.c.placa != teste4.c.placa | teste1.p.Cpf != teste2.p.Cpf | teste1.p.Cpf != teste3.p.Cpf | teste1.p.Cpf != teste4.p.Cpf | teste2.p.Cpf != teste3.p.Cpf | teste2.p.Cpf != teste4.p.Cpf | teste3.p.Cpf != teste4.p.Cpf)
                        {
                            ComposicaoCorrida t1 = new ComposicaoCorrida();
                            ComposicaoCorrida t2 = new ComposicaoCorrida();
                            ComposicaoCorrida t3 = new ComposicaoCorrida();
                            ComposicaoCorrida t4 = new ComposicaoCorrida();

                            t1.p = teste1.p;
                            t2.p = teste2.p;
                            t3.p = teste3.p;
                            t4.p = teste4.p;


                            t1.c = teste1.c;
                            t2.c = teste2.c;
                            t3.c = teste3.c;
                            t4.c = teste4.c;

                            t1.ComposicaoGuid = guid.ToString();
                            t2.ComposicaoGuid = guid.ToString();
                            t3.ComposicaoGuid = guid.ToString();
                            t4.ComposicaoGuid = guid.ToString();



                            ComposicaoDAO.AdicionarNovo(t1);
                            ComposicaoDAO.AdicionarNovo(t2);
                            ComposicaoDAO.AdicionarNovo(t3);
                            ComposicaoDAO.AdicionarNovo(t4);

                            Corrida corrida = new Corrida();
                            corrida.ComposicaoGuid = guid.ToString();
                            corrida.Pista = PistasDAO.ProcurarbyId(pistaid);
                            corrida.Preco = 20.00;
                            corrida.DtaCadastro = DateTime.Now;
                            corrida.DtaCorrida = dta;
                            corrida.DtaCancelamento = corrida.DtaCadastro;
                            corrida.Responsavel = PessoasDAO.ProcurarbyId(id);
                            

                            CorridaDAO.AdicionarNovo(corrida);

                            HorarioPista horariopista = new HorarioPista();
                            horariopista.pista = PistasDAO.ProcurarbyId(pistaid);
                            horariopista.Hora_inicial = dta;
                            horariopista.Hora_Final = dta.AddHours(1);

                            HorarioPistaDAO.AdicionarNovo(horariopista);


                            return RedirectToAction("Index", "Pessoas");
                        }
                        ModelState.AddModelError("", "Alguma Coisa está repetida(Competidor ou Carro)");
                        return RedirectToAction("Create");
                    }
                }
                ModelState.AddModelError("", "Horário Ocupado");
                return RedirectToAction("Create");


                ModelState.AddModelError("", "Data ou Hora Já Passou");
                return RedirectToAction("Create");
            }
            catch
            {
                ModelState.AddModelError("", "Hora Inválida/Dia Inválido");

                return RedirectToAction("Create");
            }
        }

// GET: ComposicaoCorridas/Edit/5
public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ComposicaoCorrida composicaoCorrida = ComposicaoDAO.ProcurarbyId(id);
            if (composicaoCorrida == null)
            {
                return HttpNotFound();
            }
            return View(composicaoCorrida);
        }

        // POST: ComposicaoCorridas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id")] ComposicaoCorrida composicaoCorrida)
        {
            if (ModelState.IsValid)
            {
                ComposicaoDAO.Editar(composicaoCorrida, composicaoCorrida.id);
                return RedirectToAction("Index");
            }
            return View(composicaoCorrida);
        }

        // GET: ComposicaoCorridas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ComposicaoCorrida composicaoCorrida = ComposicaoDAO.ProcurarbyId(id);
            if (composicaoCorrida == null)
            {
                return HttpNotFound();
            }
            return View(composicaoCorrida);
        }

        // POST: ComposicaoCorridas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ComposicaoCorrida composicaoCorrida = ComposicaoDAO.ProcurarbyId(id);
            ComposicaoDAO.Remove(composicaoCorrida);
            return RedirectToAction("Index");
        }    
    }
}
