using LoclaPista.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LoclaPista.Utils
{
    public class UtilidadeXML
    {
        public static Tempo Tratar(Tempo t)
        {
            for (int i = 0; i < t.previsao.Count; i++)
            {
                switch (t.previsao[i].tempo)
                {
                    case "ec":
                        t.previsao[i].tempo = "	Encoberto com Chuvas Isoladas";
                        break;
                    case "ci":
                        t.previsao[i].tempo = "		Chuvas Isoladas";
                        break;
                    case "c":
                        t.previsao[i].tempo = "	Chuva";
                        break;
                    case "in":
                        t.previsao[i].tempo = "		Instável";
                        break;
                    case "pp":
                        t.previsao[i].tempo = "	Poss. de Pancadas de Chuva";
                        break;
                    case "cm":
                        t.previsao[i].tempo = "	Chuva pela Manhã";
                        break;
                    case "cn":
                        t.previsao[i].tempo = "Chuva a Noite";
                        break;
                    case "pt":
                        t.previsao[i].tempo = "Pancadas de Chuva a Tarde";
                        break;
                    case "pm":
                        t.previsao[i].tempo = "Pancadas de Chuva pela Manhã";
                        break;
                    case "np":
                        t.previsao[i].tempo = "	Nublado e Pancadas de Chuva";
                        break;
                    case "pc":
                        t.previsao[i].tempo = "Pancadas de Chuva";
                        break;
                    case "pn":
                        t.previsao[i].tempo = "Parcialmente Nublado";
                        break;
                    case "cv":
                        t.previsao[i].tempo = "Chuvisco";
                        break;
                    case "ch":
                        t.previsao[i].tempo = "Chuvoso";
                        break;
                    case "t":
                        t.previsao[i].tempo = "	Tempestade";
                        break;
                    case "ps":
                        t.previsao[i].tempo = "	Predomínio de Sol";
                        break;
                    case "e":
                        t.previsao[i].tempo = "Encoberto";
                        break;
                    case "n":
                        t.previsao[i].tempo = "	Nublado";
                        break;
                    case "cl":
                        t.previsao[i].tempo = "		Céu Claro";
                        break;
                    case "nv":
                        t.previsao[i].tempo = "	Nevoeiro";
                        break;
                    case "g":
                        t.previsao[i].tempo = "		Geada";
                        break;
                    case "ne	":
                        t.previsao[i].tempo = "	Neve";
                        break;
                    case "nd":
                        t.previsao[i].tempo = "	Não Definido";
                        break;
                    case "pnt":
                        t.previsao[i].tempo = "Pancadas de Chuva a Noite";
                        break;
                    case "psc":
                        t.previsao[i].tempo = "	Possibilidade de Chuva";
                        break;
                    case "pcm":
                        t.previsao[i].tempo = "Possibilidade de Chuva pela Manhã";
                        break;
                    case "pct":
                        t.previsao[i].tempo = "	Possibilidade de Chuva a Tarde";
                        break;
                    case "pcn":
                        t.previsao[i].tempo = "		Possibilidade de Chuva a Noite";
                        break;
                    case "npt":
                        t.previsao[i].tempo = "		Nublado com Pancadas a Tarde";
                        break;
                    case "npn":
                        t.previsao[i].tempo = "Nublado com Pancadas a Noite";
                        break;
                    case "ncn":
                        t.previsao[i].tempo = "	Nublado com Poss. de Chuva a Noite";
                        break;
                    case "nct":
                        t.previsao[i].tempo = "	Nublado com Poss. de Chuva a Tarde";
                        break;
                    case "ncm":
                        t.previsao[i].tempo = "	Nubl. c/ Poss. de Chuva pela Manhã";
                        break;
                    case "npm":
                        t.previsao[i].tempo = "	Nublado com Pancadas pela Manhã";
                        break;
                    case "npp":
                        t.previsao[i].tempo = "		Nublado com Possibilidade de Chuva";
                        break;
                    case "vn":
                        t.previsao[i].tempo = "		Variação de Nebulosidade";
                        break;
                    case "ct":
                        t.previsao[i].tempo = "Chuva a Tarde";
                        break;
                    case "ppn":
                        t.previsao[i].tempo = "		Poss. de Panc. de Chuva a Noite";
                        break;
                    case "ppt":
                        t.previsao[i].tempo = "Poss. de Panc. de Chuva a Tarde";
                        break;
                    case "ppm":
                        t.previsao[i].tempo = "	Poss. de Panc. de Chuva pela Manhã";
                        break;

                }


            }
            return t;
        }
    }
}