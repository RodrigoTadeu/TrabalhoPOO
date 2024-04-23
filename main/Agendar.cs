using System;

namespace Trabalho_POO1
{
    internal class Agendar
    {
        private DateTime data;
        public DateTime Data
        {
            get { return data; }
            set { data = value; }
        }

        private string nome;
        public string Nome
        {
            get { return nome; }
            set { nome = value; }
        }

        private int numconvidados;
        public int Numconvidados
        {
            get { return numconvidados; }
            set { numconvidados = value; }
        }
        public Agendar(string nome, int numconvidados)
        {

            this.nome = nome;
            this.numconvidados = numconvidados;
        }

        private List<Agendar> listacasamento = new List<Agendar>();

        // Definição dos espaços
        private List<Espaco> espacos = new List<Espaco>
        {
            new Espaco('A', 100, 10000),
            new Espaco('B', 100, 10000),
            new Espaco('C', 100, 10000),
            new Espaco('D', 100, 10000),
            new Espaco('E', 200, 17000),
            new Espaco('F', 200, 17000),
            new Espaco('G', 50, 8000),
            new Espaco('H', 500, 35000)
        };

        // Método para obter as próximas 12 datas de sexta-feira e sábado após 30 dias
        public List<DateTime> ProximasDatasDisponiveis()
        {
            List<DateTime> datas = new List<DateTime>();
            DateTime dataAtual = DateTime.Today.AddDays(30); // Começa a partir de 30 dias após o dia atual
            while (datas.Count < 12)
            {
                if (dataAtual.DayOfWeek == DayOfWeek.Friday || dataAtual.DayOfWeek == DayOfWeek.Saturday)
                {
                    datas.Add(dataAtual);
                }
                dataAtual = dataAtual.AddDays(1);
            }
            return datas;
        }

        // Método para imprimir as próximas 12 datas de sexta-feira e sábado após 30 dias
        public void ImprimirDatasDisponiveis()
        {
            List<DateTime> datas = ProximasDatasDisponiveis();
            Console.WriteLine("Próximas datas disponíveis para casamento:");
            for (int i = 0; i < datas.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {datas[i].ToShortDateString()}");
            }
        }

        public bool MarcarCasamento(DateTime data, string nome, int numConvidados)
        {
            // Encontra o melhor espaço e marca o casamento
            Espaco melhorEspaco = EncontrarMelhorEspaco(numConvidados);
            if (melhorEspaco != null)
            {
                Console.WriteLine($"Casamento marcado para o dia {data.ToShortDateString()} no espaço {melhorEspaco.Nome}.");
                listacasamento.Add(new Agendar(nome, numConvidados));
                melhorEspaco.Disponivel = false; // Marca o espaço como indisponível
                return true;
            }
            else
            {
                Console.WriteLine("Não há espaço disponível para o número de convidados.");
                return false;
            }
        }

        private Espaco EncontrarMelhorEspaco(int numConvidados)
        {
            Espaco espacoDisponivel = null;
            List<Espaco> menorEspaco = new List<Espaco>();
            for (int i = 0; i < espacos.Count; i++)
            {
                if (espacos[i].Disponivel && numConvidados <= espacos[i].Capacidade)
                {
                    // Se o espaço atender aos requisitos, será escolhido
                    espacoDisponivel = espacos[i];
                    menorEspaco.Add(espacoDisponivel);
                }
            }
            for(int i = 0;i < menorEspaco.Count; i++)
            {
                if (menorEspaco[i].Capacidade < espacoDisponivel.Capacidade)
                {
                    espacoDisponivel = menorEspaco[i];
                }
            }
            return espacoDisponivel;
        }

    }
}