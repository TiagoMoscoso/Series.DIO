using DIO.series.Classes;
using System;
using DIO.series;
using System.Collections.Generic;
using DIO.series.Interface;

namespace DIO.series
{
    class Program
    {   
        static SerieRepositorio repositorio = new SerieRepositorio();
        static void Main(string[] args)
        {
            String opcaoUsuario = ObterOpcaoUsuario();

            while (opcaoUsuario.ToUpper() != "X")
            {
                switch(opcaoUsuario){

                    case "1":
                        ListarSeries();
                        break;
                    case "2":
                        InserirSeries();
                        break;
                    case "3":
                        AtualizarSeries();
                        break;
                    case "4":
                        ExcluirSeries();
                        break;
                    case "5":
                        VisualizarSeries();
                        break;
                    case "C":
                        Console.Clear();
                        break;

                    default:
                        throw new ArgumentOutOfRangeException();
                }
                opcaoUsuario = ObterOpcaoUsuario();
            }
        }

        private static void VisualizarSeries()
        {
            Console.WriteLine("Digite o ID da serie:");
            Console.WriteLine("");
            int indiceSerie = int.Parse(Console.ReadLine());
            Console.WriteLine("");
            var serie = repositorio.RetornaPorId(indiceSerie);
            Console.WriteLine(serie);
        }

        private static void ExcluirSeries()
        {
            Console.WriteLine("Digite o ID da serie:");
            Console.WriteLine("");
            int indiceSerie = int.Parse(Console.ReadLine());
            Console.WriteLine("Voce tem certeza que deseja excluir esta serie? 1- sim 2 - nao:");
            Console.WriteLine("");
            int Confirmacao = int.Parse(Console.ReadLine());
            if (Confirmacao == 1)
            {
                repositorio.Exclui(indiceSerie);
                Console.WriteLine("Serie excluida");
            }
            else
            {
                Console.WriteLine("Serie não foi excluida");
            }
        }

        private static void AtualizarSeries()
        {
            Console.WriteLine("Digite o ID da serie");
            int indiceSerie = int.Parse(Console.ReadLine());
            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0}- {1}", i, Enum.GetName(typeof(Genero), i));
            }
            Console.WriteLine("digite entre as opções acima:");
            Console.WriteLine("");
            int entradaDeGenero = int.Parse(Console.ReadLine());
            Console.WriteLine("");
            Console.WriteLine("digite o titulo da serie:");
            Console.WriteLine("");
            string entradaDeTitulo = Console.ReadLine();
            Console.WriteLine("");
            Console.WriteLine("digite o ano de inicio da serie:");
            Console.WriteLine("");
            int entradaDeAno = int.Parse(Console.ReadLine());
            Console.WriteLine("");
            Console.WriteLine("digite a descricao da serie:");
            Console.WriteLine("");
            string entradaDeDescricao = Console.ReadLine();
            Series atualizaSerie = new Series(id: repositorio.ProximoID(),
                                         genero: (Genero)entradaDeGenero,
                                         titulo: entradaDeTitulo,
                                         ano: entradaDeAno,
                                         descricao: entradaDeDescricao);
            repositorio.Atualiza(indiceSerie, atualizaSerie);
        }

        private static void InserirSeries()
        {
            Console.WriteLine("inserir nova serie");
            Console.WriteLine("");
            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0}- {1}", i, Enum.GetName(typeof(Genero), i));
            }
            Console.WriteLine("digite entre as opções acima:");
            Console.WriteLine("");
            int entradaDeGenero = int.Parse(Console.ReadLine());
            Console.WriteLine("");
            Console.WriteLine("digite o titulo da serie:");
            Console.WriteLine("");
            string entradaDeTitulo = Console.ReadLine();
            Console.WriteLine("");
            Console.WriteLine("digite o ano de inicio da serie:");
            Console.WriteLine("");
            int entradaDeAno = int.Parse(Console.ReadLine());
            Console.WriteLine("");
            Console.WriteLine("digite a descricao da serie:");
            Console.WriteLine("");
            string entradaDeDescricao = Console.ReadLine();
            Series novaserie = new Series(id: repositorio.ProximoID(),
                                          genero: (Genero)entradaDeGenero,
                                          titulo: entradaDeTitulo,
                                          ano: entradaDeAno,
                                          descricao: entradaDeDescricao);
            repositorio.Insere(novaserie);
        }

        private static void ListarSeries()
        {
            Console.WriteLine("listar series");
            Console.WriteLine("");
            var lista = repositorio.Lista();
            if(lista.Count == 0)
            {   
                Console.WriteLine("nehuma lista encontrada :c");
                Console.WriteLine("");
                return;
            }
            foreach(var serie in lista)
            {
                var excluido = serie.RetornaExcluido();
                if (!excluido)
                {
                    Console.WriteLine("#ID {0} : {1}",
                                      arg0: serie.RetornaID(),
                                      arg1: serie.RetornaTitulo());
                    Console.WriteLine("");
                }
            }
        }

        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("Bem vindo aMegaSeriesHD");
            Console.WriteLine("Selecione uma das opções abaixo");
            Console.WriteLine(); Console.WriteLine();
            Console.WriteLine("1-Listar numero de series");
            Console.WriteLine("2-Inserir nova serie");
            Console.WriteLine("3-Atualizar serie");
            Console.WriteLine("4-Excluir serie");
            Console.WriteLine("5-Visualizar serie");
            Console.WriteLine("C-Limpar tela");
            Console.WriteLine("X-Sair");
            Console.WriteLine(); Console.WriteLine();
            String opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUsuario;

        }
    }
}
