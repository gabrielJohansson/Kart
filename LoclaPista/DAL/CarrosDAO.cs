using LoclaPista.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace LoclaPista.DAL
{
    public class CarrosDAO
    {
        private static Context ctx = Singleton.Instance.Context;


        public static List<Carro> ListarTodos(int id)
        {
            return ctx.Carros.Where(c=>c.loja.Id==id).ToList();
        }

        public static Carro ProcurarbyId(int? id)
        {
            return ctx.Carros.Find(id);
        }

        public static void AdicionarNovo(Carro p)
        {
            ctx.Carros.Add(p);
            ctx.SaveChanges();
        }

        public static void Editar(Carro car, int id)
        {
            Carro p = ProcurarbyId(id);
            p.cor = car.cor;
            p.marca = car.marca;
            p.modelo = car.modelo;
            p.placa = p.placa;
            ctx.Entry(p).State = EntityState.Modified;
            ctx.SaveChanges();
        }

        public static void Remove(Carro p)
        {
            ctx.Carros.Remove(p);
            ctx.SaveChanges();
        }

        public static Carro ProcurarbyPlaca(string placa)
        {
            return ctx.Carros.Where(p => p.placa.Equals(placa)).FirstOrDefault();
        }
    }
}