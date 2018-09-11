//using System;
//using System.Collections.Generic;
//using System.Data;
//using System.Data.Entity;
//using System.Data.Entity.Infrastructure;
//using System.Linq;
//using System.Net;
//using System.Net.Http;
//using System.Web.Http;
//using System.Web.Http.Description;
//using LoclaPista.Models;
//using System.Web.Mvc;
//using LoclaPista.DAL;

//namespace LoclaPista.Controllers
//{
//    [System.Web.Http.RoutePrefix("api/Pessoas")]
//    public class ValuesController : ApiController
//    {
//        //private Context db = new Context();

//        //api/Pessoas/Todos

//        [System.Web.Http.Route("Todos")]
//        public List<Pessoa> GetPessoas()
//        {
//            return PessoasDAO.ListarTodas();
//        }


//        // api/Pessoas/Busca/5
//        [System.Web.Http.Route("Busca/{id}")]
//        [ResponseType(typeof(Pessoa))]
//        public IHttpActionResult GetPessoa(int id)
//        {
//            Pessoa pessoa = PessoasDAO.ProcurarbyId(id);
//            if (pessoa == null)
//            {
//                return NotFound();
//            }

//            return Ok(pessoa);
//        }

//        // api/Pessoas/Pagamento/5
//        [System.Web.Http.Route("Pagamento/{id}")]

//        public IHttpActionResult GetPagamentos(int id)
//        {
            
//            Pagamento p = PagamentoDAO.ProcurarbyId(id);
//            if (p == null)
//            {
//                return NotFound();
//            }

//            return Ok(p);
//        }


//        // api/Pessoas/CorridasPagamento/5
//        [System.Web.Http.Route("CorridasPagamento/{id}")]

//        public List<Corrida> GetCorridasPagamento(int id)
//        {
//            return CorridaDAO.ProcurarbyPagamento(id);
//        }

//        //// PUT: api/Values/5
//        //[ResponseType(typeof(void))]
//        //public IHttpActionResult PutPessoa(int id, Pessoa pessoa)
//        //{
//        //    if (!ModelState.IsValid)
//        //    {
//        //        return BadRequest(ModelState);
//        //    }

//        //    if (id != pessoa.Id)
//        //    {
//        //        return BadRequest();
//        //    }

//        //    db.Entry(pessoa).State = EntityState.Modified;

//        //    try
//        //    {
//        //        db.SaveChanges();
//        //    }
//        //    catch (DbUpdateConcurrencyException)
//        //    {
//        //        if (!PessoaExists(id))
//        //        {
//        //            return NotFound();
//        //        }
//        //        else
//        //        {
//        //            throw;
//        //        }
//        //    }

//        //    return StatusCode(HttpStatusCode.NoContent);
//        //}

//        //// POST: api/Values
//        //[ResponseType(typeof(Pessoa))]
//        //public IHttpActionResult PostPessoa(Pessoa pessoa)
//        //{
//        //    if (!ModelState.IsValid)
//        //    {
//        //        return BadRequest(ModelState);
//        //    }

//        //    db.Pessoas.Add(pessoa);
//        //    db.SaveChanges();

//        //    return CreatedAtRoute("DefaultApi", new { id = pessoa.Id }, pessoa);
//        //}

//        //// DELETE: api/Values/5
//        //[ResponseType(typeof(Pessoa))]
//        //public IHttpActionResult DeletePessoa(int id)
//        //{
//        //    Pessoa pessoa = db.Pessoas.Find(id);
//        //    if (pessoa == null)
//        //    {
//        //        return NotFound();
//        //    }

//        //    db.Pessoas.Remove(pessoa);
//        //    db.SaveChanges();

//        //    return Ok(pessoa);
//        //}

//        //protected override void Dispose(bool disposing)
//        //{
//        //    if (disposing)
//        //    {
//        //        db.Dispose();
//        //    }
//        //    base.Dispose(disposing);
//        //}

//        //private bool PessoaExists(int id)
//        //{
//        //    return db.Pessoas.Count(e => e.Id == id) > 0;
//        //}
//    }
//}