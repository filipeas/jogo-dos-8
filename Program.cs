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
        public static int[,] estadoInicial = new int[3, 3]{
            {1, 2, 3},
            {4, 0, 8},
            {7, 6, 5}
        };

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

        public static int[,] estadoDesejado = new int[3, 3]{
            {0, 1, 2},
            {3, 4, 5},
            {6, 7, 8}
        };

        static void Main(string[] args)
        {
            No _ini = new No(estadoInicial, null);
            No _met = new No(estadoDesejado, null);

            // insira o estado inicial, o desejado e o limite de nós que 
            // a busca se aprofundará
            Busca busca = new Busca(_ini, _met, 30);
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
            var stopwatchBuscaAStar = new Stopwatch();
            stopwatchBuscaAStar.Start();
            busca.buscaAStar();
            stopwatchBuscaAStar.Stop();
            Console.Write($"Tempo passado para busca A* Manhattam: {stopwatchBuscaAStar.Elapsed}\n");


            printArvore(busca.solucao);

            if (!busca.achouMeta)
            {
                Console.WriteLine("Não encontrou o resultado.");
            }

            Console.ReadKey(true);
        }

        static void printArvore(List<No> lista)
        {
            int i = lista.Count - 1;
            foreach (No n in lista)
            {
                Console.Write("Estado: " + i + "\n");
                n.mostraValores();
                Console.Write("\n");
                i--;
            }
        }
    }
}
