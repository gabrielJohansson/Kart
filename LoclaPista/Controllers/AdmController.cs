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
            HttpCookie myCookie = Request.Cookies["Loja"];

            ViewBag.Clientes = PessoaLojaDAO.ListarTodasClientes(Int32.Parse(myCookie.Values["lojaId"]));
            ViewBag.Carros = CarrosDAO.ListarTodos(Int32.Parse(myCookie.Values["lojaId"]));
            ViewBag.Pistas = PistasDAO.ListarTodas(Int32.Parse(myCookie.Values["lojaId"]));
            ViewBag.Corridas = CorridaDAO.ProcurarbyAtivo(Int32.Parse(myCookie.Values["lojaId"]));
            //fazer um details
            // ViewBag.Composicao=ComposicaoDAO.ListarTodos();
            ViewBag.CarroPessoa = CarroPessoaDao.ListarTodos(Int32.Parse(myCookie.Values["lojaId"]));
            ViewBag.Horario = HorarioPistaDAO.ListarTodos(Int32.Parse(myCookie.Values["lojaId"]));

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