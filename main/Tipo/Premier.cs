using System;

namespace Trabalho_POO1
{
    public class Premier : TipoCasamento
    {
        private static double unidadeMesa =  100;
        private static double unidadeDecoracao = 100;
        private static double unidadeBolo = 20;
        private static double unidadeMusica = 30;
        private static double unidadeSalgado = 60;

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