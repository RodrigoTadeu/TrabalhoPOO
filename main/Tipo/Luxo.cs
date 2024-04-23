using System;

namespace Trabalho_POO1
{
    public class Luxo : TipoCasamento
    {
        private static double unidadeMesa =  75;
        private static double unidadeDecoracao = 75;
        private static double unidadeBolo = 15;
        private static double unidadeMusica = 25;
        private static double unidadeSalgado = 48;

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