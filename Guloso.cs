using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

class Guloso
{
    private Busca busca;
    private Stopwatch stopwatchBusca = new Stopwatch();

    public Guloso(No inicio, No fim)
    {
        this.busca = new Busca(inicio, fim, 30);

        this.stopwatchBusca.Start();
        this.busca.buscaGulosa();
        this.stopwatchBusca.Stop();
    }

    public int custoDeCaminho()
    {
        return this.busca.noFinal;
    }

    public int custoDeEspaco()
    {
        return this.busca.abertoTemp.Count;
    }

    public int custoDeTempo()
    {
        return this.busca.solucao.Count;
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