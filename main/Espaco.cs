using System;

namespace Trabalho_POO1
{
    internal class Espaco
    {
        public char Nome { get; set; }
        public int Capacidade { get; set; }
        public double ValorEspaco { get; set; }
        public bool Disponivel { get; set; } = true;

        public Espaco(char nome, int capacidade, double valorEspaco)
        {
            Nome = nome;
            Capacidade = capacidade;
            ValorEspaco = valorEspaco;
        }

    }
}