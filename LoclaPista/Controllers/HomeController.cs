using LoclaPista.DAL;
using LoclaPista.Models;
using LoclaPista.Utils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Xml.Serialization;

namespace LoclaPista.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index(int?id)
        {
            HttpCookie myCookie = Request.Cookies["Loja"];
            string url = "http://servicos.cptec.inpe.br/XML/cidade/7dias/227/previsao.xml";

            WebClient client = new WebClient();

                string resultado = client.DownloadString(@url);
               // byte[] bytes = Encoding.Default.GetBytes(resultado);
                XmlSerializer serializer = new XmlSerializer(typeof(Tempo));
                using (StringReader reader = new StringReader(resultado))
                {
                    Tempo p = (Tempo)serializer.Deserialize(reader);
                UtilidadeXML.Tratar(p);
                    ViewBag.Tempo = p;
                }


            if ( id == null)
            {
                return View(HorarioPistaDAO.ListarTodos(Int32.Parse(myCookie.Values["lojaId"])));

            }
            DateTime data= DateTime.Today.Date;

            switch(id)
            {

                case 0:
                    data = DateTime.Today.Date;

                    break;
                case 1:
                    data = DateTime.Today.Date.AddDays(1);

                    break;
                case 2:
                    data = DateTime.Today.Date.AddDays(2);

                    break;
                case 3:
                    data = DateTime.Today.Date.AddDays(3);

                    break;
                case 4:
                    data = DateTime.Today.Date.AddDays(4);

                    break;
                case 5:
                    data = DateTime.Today.Date.AddDays(5);

                    break;
                case 6:
                    data = DateTime.Today.Date.AddDays(6);

                    break;
            }
            return View(HorarioPistaDAO.ProcurarbyData(data));
            
        }
    }
}