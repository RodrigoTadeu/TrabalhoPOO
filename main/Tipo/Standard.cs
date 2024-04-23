using System;

namespace Trabalho_POO1
{
    public class Standard : TipoCasamento
    {
        private static double unidadeMesa =  50;
        private static double unidadeDecoracao = 50;
        private static double unidadeBolo = 10;
        private static double unidadeMusica = 20;
        private static double unidadeSalgado = 40;

        private double total = 0;
        public override double valorItensFesta(int totalConvidados)
        {
            total += totalConvidados * unidadeMesa;
            total += totalConvidados * unidadeDecoracao;
            total += totalConvidados * unidadeBolo;
            total += totalConvidados * unidadeMusica;
            total += totalConvidados * unidadeSalgado;

            return total; 
        }

    }
}