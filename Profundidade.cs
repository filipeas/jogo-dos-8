using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

class Profundidade
{
    private Busca busca;
    private Stopwatch stopwatchBusca = new Stopwatch();

    public Profundidade(No inicio, No fim)
    {
        this.busca = new Busca(inicio, fim, 30);

        this.stopwatchBusca.Start();
        this.busca.buscaProfundidade();
        this.stopwatchBusca.Stop();
    }

    public int custoDeCaminho()
    {
        return this.busca.solucao.Count;
    }

    public int custoDeEspaco()
    {
        return this.busca.aberto.Count;
    }

    public int custoDeTempo()
    {
        return this.busca.noFinal;
    }

    public List<No> solucaoFinal()
    {
        return this.busca.solucao;
    }

    public List<No> arvoreFinal()
    {
        return this.busca.arvore;
    }

    public TimeSpan tempoExecutado()
    {
        return this.stopwatchBusca.Elapsed;
    }
}