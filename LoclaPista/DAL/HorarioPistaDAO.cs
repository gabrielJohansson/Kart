using LoclaPista.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Web;

namespace LoclaPista.DAL
{
    public class HorarioPistaDAO
    {
        private static Context ctx = Singleton.Instance.Context;

        public static List<HorarioPista> ListarTodos()
        {
            return ctx.HorarioPista.Include("pista").ToList();
        }

        public static HorarioPista ProcurarbyId(int? id)
        {
            return ctx.HorarioPista.Find(id);
        }

        public static void AdicionarNovo(HorarioPista p)
        {
            ctx.HorarioPista.Add(p);
            ctx.SaveChanges();
        }

        public static void Editar(HorarioPista car, int id)
        {
            HorarioPista p = ProcurarbyId(id);
            p.pista = car.pista;
            p.Hora_Final = car.Hora_Final;
            p.Hora_inicial = car.Hora_inicial;
            ctx.Entry(p).State = EntityState.Modified;
            ctx.SaveChanges();
        }

        public static void Remove(HorarioPista p)
        {
            ctx.HorarioPista.Remove(p);
            ctx.SaveChanges();
        }

        public static HorarioPista ProcurarbyPista(int id)
        {
            return ctx.HorarioPista.Where(p => p.pista.Id == id).FirstOrDefault();
        }

        //passa so a data
        public static List<HorarioPista> ProcurarbyData(DateTime id)
        {
            return ctx.HorarioPista.Where(p => EntityFunctions.TruncateTime(p.Hora_inicial) == id.Date).ToList();
        }
        //passa td
        public static List<HorarioPista> ProcurarbyDataHora(DateTime id)
        {
            return ctx.HorarioPista.Where(p => p.Hora_inicial == id).ToList();
        }
        //passa o horario
        public static List<HorarioPista> ProcurarbyHora(DateTime id)
        {
            return ctx.HorarioPista.Where(p => p.Hora_inicial.TimeOfDay.Equals( id.TimeOfDay)).ToList();
        }
        public static HorarioPista ProcurarbyDataHoraPista(DateTime id,int idp)
        {
            DateTime ad = id.AddHours(1);
            return ctx.HorarioPista.Where(p => p.Hora_inicial == id && p.pista.Id==idp|p.Hora_inicial == ad && p.pista.Id == idp).FirstOrDefault();
        }
    }
    }