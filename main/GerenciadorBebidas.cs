using System;

namespace Trabalho_POO1
{
    public class GerenciadorBebidas
    {
        public Dictionary<string, double> _itens;

        public GerenciadorBebidas(int tipoCasamento)
        {
            _itens = new Dictionary<string, double>()
            {
                {"Água sem gás (1,5l)", 5.00},
                {"Suco (1L)", 7.00},
                {"Refrigerante (2l)", 8.00},
                {"Cerveja Comum (600ml)", 20.00},
                {"Espumante Nacional (750ml)", 80.00}
            };

            if (tipoCasamento == 1 || tipoCasamento == 2)
            {
                _itens.Add("Cerveja Artesanal (600ml)", 30.00);
                _itens.Add("Espumante Importado (750ml)", 140.00);
            }
        }

        public double CalcularTotalBebida(Dictionary<string, int> pedido)
        {
            double total = 0;
            foreach (var item in pedido)
            {
                total += item.Value * _itens[item.Key];
            }
            return total;
        }
    }
}