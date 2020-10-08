using System;
using tabuleiro;
using xadrez;

namespace xadrez_console
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                PartidaDeXadrez partida = new PartidaDeXadrez();                

                while (!partida.Terminada)
                {

                    try
                    {
                        Console.Clear();
                        Console.WriteLine();
                        Console.WriteLine("  JOGO DE XADREZ");
                        Tela.ImprimirPartida(partida);

                        Console.Write("Origem: ");
                        Posicao origem = Tela.LerPosicaoXadrez().ToPosicao();
                        partida.ValidarPosicaoOrigem(origem);

                        bool[,] posicoesPossiveis = partida.Tab.Peca(origem).movimentosPossiveis();

                        Console.Clear();

                        Console.WriteLine("  JOGO DE XADREZ");
                        Tela.ImprimirTabuleiro(partida.Tab, posicoesPossiveis);

                        Console.WriteLine();
                        Console.Write("Destino: ");
                        Posicao destino = Tela.LerPosicaoXadrez().ToPosicao();
                        partida.ValidarPosicaoDestino(origem, destino);

                        partida.Realizajogada(origem, destino);
                    }
                    catch (TabuleiroException e)
                    {
                        Console.WriteLine(e.Message);
                        Console.WriteLine("Aperte uma tecla para realizar nova jogada!");
                        Console.ReadLine();
                    }
                }
                Console.Clear();
                Console.WriteLine();
                Console.WriteLine("   XEQUEMATE! ");
                Tela.ImprimirPartida(partida);
            }
            catch (TabuleiroException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
