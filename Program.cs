using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Puzzle_Search_Problem___Jogo_dos_8
{
    class Program
    {
        // da inversao
        // public static int[,] estadoInicial = new int[3, 3]{
        //     {7, 5, 3},
        //     {8, 2, 0},
        //     {1, 4, 6}
        // };

        // funciona para largura, profundidade, guloso e A*
        // public static int[,] estadoInicial = new int[3, 3]{
        //     {1, 0, 2},
        //     {3, 4, 5},
        //     {6, 7, 8}
        // };

        // funciona para largura, profundidade, guloso e A*
        // public static int[,] estadoInicial = new int[3, 3]{
        //     {1, 2, 3},
        //     {4, 0, 8},
        //     {7, 6, 5}
        // };

        // funciona para largura, profundidade, guloso e A*
        // public static int[,] estadoInicial = new int[3, 3]{
        //     {2, 1, 3},
        //     {4, 5, 0},
        //     {7, 6, 8}
        // };

        // da inversao
        // public static int[,] estadoInicial = new int[3, 3]{
        //     {2, 8, 3},
        //     {1, 6, 4},
        //     {7, 0, 5}
        // };

        // da inversao
        // public static int[,] estadoInicial = new int[3, 3]{
        //     {1, 3, 2},
        //     {5, 0, 4},
        //     {7, 6, 8}
        // };

        // testes do professor
        public static int[,] estadoInicial = new int[3, 3]{
            {4, 1, 2},
            {0, 5, 3},
            {6, 7, 8}
        };

        // public static int[,] estadoInicial = new int[3, 3]{
        //     {0, 7, 2},
        //     {1, 4, 3},
        //     {6, 8, 5}
        // };

        // public static int[,] estadoInicial = new int[3, 3]{
        //     {1, 2, 4},
        //     {3, 5, 0},
        //     {7, 6, 8}
        // };

        // public static int[,] estadoInicial = new int[3, 3]{
        //     {1, 2, 3},
        //     {4, 7, 5},
        //     {6, 8, 0}
        // };

        // public static int[,] estadoDesejado = new int[3, 3]{
        //     {0, 1, 2},
        //     {3, 4, 5},
        //     {6, 7, 8}
        // };
        public static int[,] estadoDesejado = new int[3, 3]{
            {1, 2, 3},
            {4, 0, 5},
            {6, 7, 8}
        };

        static void Main(string[] args)
        {
            No _ini = new No(estadoInicial, null);
            No _met = new No(estadoDesejado, null);

            // Largura buscaLargura = new Largura(_ini, _met);
            // Console.Write("Tempo de execução: " + buscaLargura.tempoExecutado());
            // // printSolucao(buscaLargura.solucaoFinal()); // printa a solução da busca em largura
            // Console.Write("Custo de caminho: " + buscaLargura.custoDeCaminho() + "\n");
            // Console.Write("Custo de espaço: " + buscaLargura.custoDeEspaco() + "\n");
            // Console.Write("Custo de tempo: " + buscaLargura.custoDeTempo() + "\n");
            // printArvore(buscaLargura.arvoreFinal()); // printa a arvore ate a profundidade 5 da busca em largura

            // Profundidade buscaProfundidade = new Profundidade(_ini, _met);
            // Console.Write("Tempo de execução: " + buscaProfundidade.tempoExecutado() + "\n");
            // // printSolucao(buscaProfundidade.solucaoEscolhasDosPais()); // printa a solução da busca em profundidade
            // Console.Write("Custo de caminho: " + buscaProfundidade.custoDeCaminho() + "\n");
            // Console.Write("Custo de espaço: " + buscaProfundidade.custoDeEspaco() + "\n");
            // Console.Write("Custo de tempo: " + buscaProfundidade.custoDeTempo() + "\n");
            // printArvore(buscaProfundidade.arvoreFinal()); // printa a arvore ate a profundidade 5 da busca em profundidade

            // Guloso buscaGulosa = new Guloso(_ini, _met);
            // Console.Write("Tempo de execução: " + buscaGulosa.tempoExecutado() + "\n");
            // // printSolucao(buscaGulosa.solucaoEscolhasDosPais()); // printa a solução da busca gulosa
            // Console.Write("Custo de caminho: " + buscaGulosa.custoDeCaminho() + "\n");
            // Console.Write("Custo de espaço: " + buscaGulosa.custoDeEspaco() + "\n");
            // Console.Write("Custo de tempo: " + buscaGulosa.custoDeTempo() + "\n");
            // printArvore(buscaGulosa.arvoreFinal()); // printa a arvore ate a profundidade 5 da busca gulosa

            // AStar buscaAStar = new AStar(_ini, _met);
            // Console.Write("Tempo de execução: " + buscaAStar.tempoExecutado() + "\n");
            // // printSolucao(buscaAStar.solucaoEscolhasDosPais()); // printa a solução da busca A*
            // Console.Write("Custo de caminho: " + buscaAStar.custoDeCaminho() + "\n");
            // Console.Write("Custo de espaço: " + buscaAStar.custoDeEspaco() + "\n");
            // Console.Write("Custo de tempo: " + buscaAStar.custoDeTempo() + "\n");
            // printArvore(buscaAStar.arvoreFinal()); // printa a arvore ate a profundidade 5 da busca A*


            // insira o estado inicial, o desejado e o limite de nós que 
            // a busca se aprofundará
            // Busca busca = new Busca(_ini, _met, 30);
            // Busca busca = new Busca(_ini, _met, 5);

            // BUSCA EM LARGURA
            // var stopwatchBuscaLarg = new Stopwatch();
            // stopwatchBuscaLarg.Start();
            // busca.buscaLargura();
            // stopwatchBuscaLarg.Stop();
            // Console.Write($"Tempo passado para busca em largura: {stopwatchBuscaLarg.Elapsed}\n");

            // BUSCA EM PROFUNDIDADE
            // var stopwatchBuscaProfundi = new Stopwatch();
            // stopwatchBuscaProfundi.Start();
            // busca.buscaProfundidade();
            // stopwatchBuscaProfundi.Stop();
            // Console.Write($"Tempo passado para busca em profundidade: {stopwatchBuscaProfundi.Elapsed}\n");

            // BUSCA GULOSA MANHATTAN
            // var stopwatchBuscaGulosa = new Stopwatch();
            // stopwatchBuscaGulosa.Start();
            // busca.buscaGulosa();
            // stopwatchBuscaGulosa.Stop();
            // Console.Write($"Tempo passado para busca gulosa Manhattam: {stopwatchBuscaGulosa.Elapsed}\n");

            // BUSCA A* COM MANHATTAN
            // var stopwatchBuscaAStar = new Stopwatch();
            // stopwatchBuscaAStar.Start();
            // busca.buscaAStar();
            // stopwatchBuscaAStar.Stop();
            // Console.Write($"Tempo passado para busca A* Manhattam: {stopwatchBuscaAStar.Elapsed}\n");


            // printSolucao(busca.solucao); // printa a solução
            // printArvore(busca.arvore); // printa a arvore ate a profundidade 5

            // if (!busca.achouMeta)
            // {
            //     Console.WriteLine("Não encontrou o resultado.");
            // }

            Console.ReadKey(true);
        }

        static void printSolucao(List<No> lista)
        {
            int i = lista.Count - 1;
            foreach (No n in lista)
            {
                Console.Write("Estado: " + i + "\n");
                Console.Write("Profundidade: " + n.prof + "\n");
                n.mostraValores();
                Console.Write("\n");
                i--;
            }
        }

        static void printArvore(List<No> arvore)
        {
            int[,] separador = new int[3, 3]{
            {0, 0, 0},
            {0, 0, 0},
            {0, 0, 0}
        };

            No noSeparador = new No(separador, null);

            foreach (No noArvore in arvore)
            {
                if (noArvore.prof > 6) break;

                if (noArvore.isIgual(noSeparador))
                {
                    Console.Write("\n--------------------\n");
                    continue;
                }
                else
                {
                    Console.Write("\nProfundidade: " + noArvore.prof + "\n");
                    noArvore.mostraValores();
                    Console.Write("\n");
                    // System.Threading.Thread.Sleep(500);
                }
            }
        }
    }
}
