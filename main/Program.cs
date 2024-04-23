using System;

namespace Trabalho_POO1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            void totalFesta(int numConvidados, int tipoCasamento, TipoCasamento objeto)
            {
                Console.WriteLine("Escolha as bebidas e a quantidade para seu casamento :");
                Console.WriteLine("\n");


                double TotalItens = objeto.valorItensFesta(numConvidados);

                GerenciadorBebidas gerenciador = new GerenciadorBebidas(tipoCasamento);

                Dictionary<string, int> pedido = new Dictionary<string, int>();
                foreach (var item in gerenciador._itens)
                {
                    Console.Write($"Quantos(as) {item.Key} deseja? ");
                    int quantidade = Convert.ToInt32(Console.ReadLine());
                    pedido[item.Key] = quantidade;
                }

                Console.WriteLine("--------------------------------------------");

                double totalBebida = gerenciador.CalcularTotalBebida(pedido);

                Console.WriteLine($"Valor total dos itens da festa: R${TotalItens:F2}");
                Console.WriteLine($"Valor total da bebida: R${totalBebida:F2}");

                double totalFesta = TotalItens + totalBebida;
                Console.WriteLine($"Valor total da festa: R${totalFesta:F2}");
            }

            bool consulta = true;
            while (consulta)
            {
                Console.WriteLine("--------------------------------------------");

                Console.WriteLine("Insira o nome do casal:");
                string nomeCasal = Console.ReadLine();
                Console.WriteLine("Insira o número de convidados:");
                int numConvidados = int.Parse(Console.ReadLine());


                Agendar agendar = new Agendar(nomeCasal, numConvidados);

                agendar.ImprimirDatasDisponiveis();

                // Solicitar informações para marcar o casamento
                Console.WriteLine("\nPor favor, escolha uma data para o casamento:");
                Console.WriteLine("Insira o número correspondente à data desejada:");
                int escolhaData = int.Parse(Console.ReadLine());
                DateTime dataEscolhida = agendar.ProximasDatasDisponiveis()[escolhaData - 1];


                // Tentar marcar o casamento
                bool casamentoMarcado = agendar.MarcarCasamento(dataEscolhida, nomeCasal, numConvidados);
                if (casamentoMarcado)
                {
                    Console.WriteLine("Casamento marcado com sucesso!");

                    Console.WriteLine("--------------------------------------------");

                    Console.WriteLine("Qual o tipo de casamento ? Digite o número correspondente");
                    Console.WriteLine("1. Premier");
                    Console.WriteLine("2. Luxo");
                    Console.WriteLine("3. Standard");

                    Console.WriteLine("--------------------------------------------");

                    int tipoCasamento = int.Parse(Console.ReadLine());

                    if (tipoCasamento == 1)
                    {
                        Console.WriteLine("Opção PREMIER escolhida !");
                        Premier p1 = new Premier();
                        totalFesta(numConvidados, tipoCasamento, p1);

                    }
                    else if (tipoCasamento == 2)
                    {
                        Console.WriteLine("Opção LUXO escolhida !");
                        Luxo l1 = new Luxo();
                        totalFesta(numConvidados, tipoCasamento, l1);

                    }
                    else if (tipoCasamento == 3)
                    {
                        Console.WriteLine("Opção STANDARD escolhida !");
                        Standard s1 = new Standard();
                        totalFesta(numConvidados, tipoCasamento, s1);

                    }
                    else
                    {
                        Console.WriteLine("Opção incorreta !");
                    }
                }
                else
                {
                    Console.WriteLine("Desculpe, não foi possível marcar o casamento.");
                }

                Console.WriteLine("--------------------------------------------");

                Console.WriteLine("Consulta realizada com sucesso. Precione ENTER para realizar uma nova consulta.");
                Console.ReadLine();
            }
        }
    }
}