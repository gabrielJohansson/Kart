using LoclaPista.DAL;
using LoclaPista.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace LoclaPista.Controllers
{
    public class AdmController : Controller
    {
        // GET: Adm
        public ActionResult Index()
        {
            ViewBag.Clientes = PessoasDAO.ListarTodasClientes();
            ViewBag.Carros = CarrosDAO.ListarTodos();
            ViewBag.Pistas = PistasDAO.ListarTodas();
            ViewBag.Corridas = CorridaDAO.ProcurarbyAtivo();
            //fazer um details
            // ViewBag.Composicao=ComposicaoDAO.ListarTodos();
            ViewBag.CarroPessoa = CarroPessoaDao.ListarTodos();
            ViewBag.Horario = HorarioPistaDAO.ListarTodos();

            return View();
        }


        public ActionResult Details(int? id)
        {
            if (id ==null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Corrida co = CorridaDAO.ProcurarbyId(id);
            List<ComposicaoCorrida> c = ComposicaoDAO.BuscarporGuid(co.ComposicaoGuid);
            return View(c);
        }


    }
}