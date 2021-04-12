using DIO.series;
using System;
using System.Collections.Generic;
using System.Text;

namespace DIO.series
{
    class Series : EntidadeBase
    {
        private Genero Genero { get; set; }

        private string Titulo { get; set; }

        private string Descricao { get; set; }

        private int Ano { get; set; }

        private bool Excluido { get; set; }

        public Series(int id, string titulo, Genero genero, string descricao, int ano)
        {
            this.Id = id;
            this.Titulo = titulo;
            this.Genero = genero;
            this.Descricao = descricao;
            this.Ano = ano;
            this.Excluido = false;
        }
        public override string ToString()
        {
            string retorno = "";
            retorno += "|Titulo: " + this.Titulo + Environment.NewLine;
            retorno += "|Genero: " + this.Genero + Environment.NewLine;
            retorno += "|Descricao: " + this.Descricao + Environment.NewLine;
            retorno += "|Ano: " + this.Ano + Environment.NewLine;
            retorno += "|Exclusão: " + this.Excluido + Environment.NewLine;
            return retorno;
        }

        public string RetornaTitulo()
        {
            return this.Titulo;
        }

        public int RetornaID()
        {
            return this.Id;
        }

        public bool RetornaExcluido()
        {
            return this.Excluido;
        }

        public void Excluir()
        {
            this.Excluido = true;
        }
    }
}
