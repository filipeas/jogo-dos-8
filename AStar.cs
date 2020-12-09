using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

class AStar
{
    private Busca busca;
    private Stopwatch stopwatchBusca = new Stopwatch();

    public AStar(No inicio, No fim)
    {
        this.busca = new Busca(inicio, fim, 30);

        this.stopwatchBusca.Start();
        this.busca.buscaAStar();
        this.stopwatchBusca.Stop();
    }

    public int custoDeCaminho()
    {
        return this.busca.solucao.First().g;
    }

    public int custoDeEspaco()
    {
        return this.busca.aberto.Count;
    }

    public int custoDeTempo()
    {
        return this.busca.fechado.Count;
    }

    /**
    * Método que mostra a lista de escolhas passo a passo até achar a resposta
    */
    public List<No> solucaoEscolhasDosPais()
    {
        return this.busca.solucaoPais;
    }

    /**
    * Método que mostra a lista de pais que chegam a resposta direta
    */
    public List<No> solucaoFinal()
    {
        return this.busca.solucao;
    }

    /**
    * Método que printa a árvore
    */
    public List<No> arvoreFinal()
    {
        return this.busca.arvore;
    }

    public TimeSpan tempoExecutado()
    {
        return this.stopwatchBusca.Elapsed;
    }
}