using System;

namespace MathGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            start();
        }

        public enum TipoJogo
        {
            Adicao = 1,
            Subtracao = 2,
            Multiplicacao = 3,
            Divisao = 4,
            Aleatorio = 5,
            Historico = 6,
            Sair = 0
        }

        internal class HistoricoPartida
        {

            public DateTime Data { get; set; }
            public TipoJogo TipoJogo { get; set; }
            public int Pontuacao { get; set; }
        }

        static void start()
        {
            configurarSaidaConsole();
            List<HistoricoPartida> historico = new List<HistoricoPartida>();
            while (true)
            {
                textoInicial();
                int escolha = int.Parse(Console.ReadLine());
                int pontuacao = 0;
                DateTime dataPartida = DateTime.Now;
                TipoJogo tipoJogo = (TipoJogo)escolha;

                
                if (escolha == (int)TipoJogo.Historico)
                {
                    Console.WriteLine("Histórico de Partidas:");
                    foreach (var partida in historico)
                    {
                        Console.WriteLine($"{partida.Data}: {partida.TipoJogo} - {partida.Pontuacao} pontos");
                    }
                    continue;
                }

                if (escolha == (int)TipoJogo.Sair)
                {
                    Console.WriteLine("Obrigado por jogar! Até a próxima.");
                    return;
                }

                foreach (var i in Enumerable.Range(1, 5))
                {
                    switch (escolha)
                    {
                        case 1:
                            var questaoSoma = gerarQuestaoSomar();
                            Console.WriteLine($"Quanto é {questaoSoma[0]} + {questaoSoma[1]}?");
                            int respostaSoma = int.Parse(Console.ReadLine());
                            if (respostaSoma == questaoSoma[2])
                            {
                                Console.WriteLine("Resposta correta! +10 pontos.");
                                pontuacao += 10;
                            }
                            else
                            {
                                Console.WriteLine($"Resposta incorreta. A resposta correta é {questaoSoma[2]}.");
                            }
                            break;
                        case 2:
                            var questaoSubtracao = gerarQuestaoSubtrair();
                            Console.WriteLine($"Quanto é {questaoSubtracao[0]} - {questaoSubtracao[1]}?");
                            int respostaSubtracao = int.Parse(Console.ReadLine());
                            if (respostaSubtracao == questaoSubtracao[2])
                            {
                                Console.WriteLine("Resposta correta! +10 pontos.");
                                pontuacao += 10;
                            }
                            else
                            {
                                Console.WriteLine($"Resposta incorreta. A resposta correta é {questaoSubtracao[2]}.");
                            }
                            break;
                        case 3:
                            var questaoMultiplicacao = gerarQuestaoMultiplicar();
                            Console.WriteLine($"Quanto é {questaoMultiplicacao[0]} x {questaoMultiplicacao[1]}?");
                            int respostaMultiplicacao = int.Parse(Console.ReadLine());
                            if (respostaMultiplicacao == questaoMultiplicacao[2])
                            {
                                Console.WriteLine("Resposta correta! +10 pontos.");
                                pontuacao += 10;
                            }
                            else
                            {
                                Console.WriteLine($"Resposta incorreta. A resposta correta é {questaoMultiplicacao[2]}.");
                            }
                            break;
                        case 4:
                            var questaoDivisao = gerarQuestaoDividir();
                            Console.WriteLine($"Quanto é {questaoDivisao[0]} ÷ {questaoDivisao[1]}?");
                            int respostaDivisao = int.Parse(Console.ReadLine());
                            if (respostaDivisao == questaoDivisao[2])
                            {
                                Console.WriteLine("Resposta correta! +10 pontos.");
                                pontuacao += 10;
                            }
                            else
                            {
                                Console.WriteLine($"Resposta incorreta. A resposta correta é {questaoDivisao[2]}.");
                            }
                            break;
                        case 5:
                            int tipoAleatorio = new Random().Next(1, 5);
                            if (tipoAleatorio == 1) goto case 1;
                            if (tipoAleatorio == 2) goto case 2;
                            if (tipoAleatorio == 3) goto case 3;
                            if (tipoAleatorio == 4) goto case 4;
                            break;
                    }
                }
                historico.Add(new HistoricoPartida { Data = dataPartida, TipoJogo = tipoJogo, Pontuacao = pontuacao });
                Console.WriteLine($"Fim do jogo! Sua pontuação total: {pontuacao} pontos.");
            }
        }

        private static void configurarSaidaConsole()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
        }

        static int[] gerarQuestaoSomar()
        {
            Random random = new Random();
            int num1 = random.Next(1, 100);
            int num2 = random.Next(1, 100);
            int answer = num1 + num2;
            return new int[] { num1, num2, answer };
        }

        static int[] gerarQuestaoSubtrair()
        {
            Random random = new Random();
            int num1 = random.Next(1, 100);
            int num2 = random.Next(1, 100);
            int answer = num1 - num2;
            return new int[] { num1, num2, answer };
        }

        static int[] gerarQuestaoMultiplicar()
        {
            Random random = new Random();
            int num1 = random.Next(1, 12);
            int num2 = random.Next(1, 12);
            int answer = num1 * num2;
            return new int[] { num1, num2, answer };
        }   

        static int[] gerarQuestaoDividir()
        {
            Random random = new Random();
            int divisor = random.Next(1, 101); // 1..100
            int maxQuociente = 100 / divisor;  // garante que dividendo <= 100
            int quociente = random.Next(0, maxQuociente + 1); // inclui 0 e maxQuociente
            int dividendo = divisor * quociente;
            return new int[] { dividendo, divisor, quociente };
        }



        static void textoInicial()
        {
            Console.WriteLine( @"
============================================================
        🧮  MATH QUIZ GAME  🧮
============================================================
     Bem-vindo! Teste seus conhecimentos matemáticos.
     Responda corretamente e acumule pontos!
    ------------------------------------------------------------
     📋  MENU PRINCIPAL

      [1] ➕  Adição
      [2] ➖  Subtração
      [3] ✖️  Multiplicação
      [4] ➗  Divisão
      [5] 🎲  Jogo Aleatório
      [6] 📊  Histórico de Partidas
      [0] 🚪  Sair
    ------------------------------------------------------------
     Digite o número da opção desejada: ");
        }

    }
}
