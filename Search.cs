using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Busca
{
    public int profMax;
    public int testados;
    public int _inversoes;

    public int _largAux = 0;

    public bool achouMeta = false;

    public int cost = 0;

    public No inicial;
    public No meta;
    public No _current;

    public List<No> aberto = new List<No> { };
    public List<No> fechado = new List<No> { };
    public List<No> solucao = new List<No> { };

    public Busca(No _ini, No _meta, int pMax)
    {
        inicial = _ini;
        meta = _meta;
        profMax = pMax;
    }
    /**
    * Método responsável por fazer busca em largura
    */
    public void buscaLargura()
    {
        // 0. instancia de qtd de nós visitados
        int nos = 0;

        //1. Verifica se o problema é solúvel
        if (!isSoluvel(inicial))
        {
            Console.WriteLine("->INSOLÚVEL\n-->INVERSÕES: " + _inversoes);
            return;
        }

        Console.WriteLine("->SOLÚVEL\n-->INVERSÕES: " + _inversoes + "\n");

        _current = inicial;

        aberto.Add(_current);

        while (aberto.Count > 0 && !achouMeta)
        {
            // nó visitado é contabilizado
            nos += 1;
            // Console.WriteLine("Profundidade atual: " + _current.prof);
            if (isMeta(_current))
            {
                break;
            }

            if (aberto.Count > 0)
            {
                expande(_current);
                // Console.WriteLine("Possib. de movimento na profundidade atual: " + _current.prof);
                // Console.WriteLine("----------");
            }

            aberto.Remove(aberto.First());

            if (aberto.Count > 0)
                _current = aberto.First();
        }

        //9. Se houver resultado é adicionado a cadeia de "pais" a uma pilha
        while (_current != null && achouMeta)
        {
            solucao.Add(_current);
            _current = _current._parent;
        }

        //10. Termina
        //Console.WriteLine("->SOLÚVEL\n-->INVERSÕES: " + _inversoes + "\n");
        // printa qtd de nós gerados
        Console.Write("Qtd. de nós visitados: " + nos + "\n");

    }

    /**
    * Método responsável por realizar busca em profundidade.
    */
    public void buscaProfundidade()
    {
        Console.WriteLine("Buscando profundidade máxima: " + profMax);

        // 0. instancia de qtd de nós visitados
        int nos = 0;

        //1. Verifica se o problema é solúvel
        if (!isSoluvel(inicial))
        {
            Console.WriteLine("->INSOLÚVEL\n-->INVERSÕES: " + _inversoes);
            return;
        }

        //2. Define o estado atual
        _current = inicial;

        //3. Adiciona o estado atual na pilha
        aberto.Add(_current);

        //4. Enquanto tiverem estados abertos ou a meta não for encontrada
        while (aberto.Count > 0 && !achouMeta)
        {
            // nó visitado é contabilizado
            nos += 1;
            // Console.WriteLine("Profundidade atual: " + _current.prof);
            //5. Checa se o estado é meta                  
            if (isMeta(_current))
            {
                break;
            }

            //6. Se tiverem estados abertos, remove o ultimo
            if (aberto.Count > 0)
                aberto.Remove(aberto.Last());

            //7. Se a profundidade máxima não foi alcançada: expande o nó
            if (_current.prof < profMax)
            {
                expande(_current);
                // Console.WriteLine("Possib. de movimento na profundidade atual: " + _current.prof);
                // Console.WriteLine("----------");
            }

            //8. Se tiverem estados abertos seta o topo da pilha como estado atual
            if (aberto.Count > 0)
            {
                _current = aberto.Last();
            }
        }

        if (achouMeta == false && profMax < 30)
        {
            profMax++;
            _current = inicial;
            aberto.Clear();
            solucao.Clear();
            fechado.Clear();
            buscaProfundidade();
        }

        //9. Se houver resultado é adicionado a cadeia de "pais" a uma pilha
        while (_current != null && achouMeta)
        {
            solucao.Add(_current);
            _current = _current._parent;
        }

        //10. Termina
        // printa qtd de nós gerados
        Console.Write("Qtd. de nós visitados: " + nos + "\n");
    }

    /**
    * Busca gulosa com heuristica manhatan
    */
    public void buscaGulosa()
    {
        // 0. instancia de qtd de nós visitados
        int nos = 0;

        //1. Verifica se o problema é solúvel
        if (!isSoluvel(inicial))
        {
            Console.WriteLine("->INSOLÚVEL\n-->INVERSÕES: " + _inversoes);
            return;
        }

        // Console.WriteLine("->SOLÚVEL\n-->INVERSÕES: " + _inversoes + "\n");

        _current = inicial;

        aberto.Add(_current);

        while (aberto.Count > 0 && !achouMeta)
        {
            // nó visitado é contabilizado
            nos += 1;
            // Console.WriteLine("Profundidade atual: " + _current.prof);
            if (isMeta(_current))
            {
                break;
            }

            if (aberto.Count > 0)
            {
                // Console.Write("Extandindo jogadas possiveis: \n");
                expande(_current);
                // Console.WriteLine("Possib. de movimento na profundidade atual: " + _current.prof);
                // Console.WriteLine("----------");
            }

            aberto.Remove(_current);

            if (aberto.Count > 0)
            {
                int menorCusto = ManhattanDistance(aberto.First());
                int proximoNo = 0;

                for (int i = 1; i < aberto.Count; i++)
                {
                    Random gen = new Random();
                    int prob = gen.Next(2);
                    if (ManhattanDistance(aberto[i]) < menorCusto)
                    {
                        menorCusto = ManhattanDistance(aberto[i]);
                        proximoNo = i;
                        continue;
                    }
                    else if (ManhattanDistance(aberto[i]) == menorCusto && prob != 0)
                    {
                        menorCusto = ManhattanDistance(aberto[i]);
                        proximoNo = i;
                        continue;
                    }
                }

                _current = aberto[proximoNo];
                aberto = new List<No> { };
                aberto.Add(_current);
                // Console.Write("\nno selecionado: \n");
                // _current.mostraValores();
                // Console.WriteLine("=====");
                // System.Threading.Thread.Sleep(1000);
            }
        }

        //9. Se houver resultado é adicionado a cadeia de "pais" a uma pilha
        while (_current != null && achouMeta)
        {
            solucao.Add(_current);
            _current = _current._parent;
        }

        //10. Termina
        //Console.WriteLine("->SOLÚVEL\n-->INVERSÕES: " + _inversoes + "\n");
        // printa qtd de nós gerados
        Console.Write("Qtd. de nós visitados: " + nos + "\n");
    }

    /**
    * Busca A* com heuristica manhatan
    */
    public void buscaAStar()
    {
        // 0. instancia de qtd de nós visitados
        int nos = 0;

        //1. Verifica se o problema é solúvel
        if (!isSoluvel(inicial))
        {
            Console.WriteLine("->INSOLÚVEL\n-->INVERSÕES: " + _inversoes);
            return;
        }

        // Console.WriteLine("->SOLÚVEL\n-->INVERSÕES: " + _inversoes + "\n");

        _current = inicial;
        _current.g = 0;
        _current.h = ManhattanDistance(_current);
        _current.f = _current.g + _current.h;

        aberto.Add(_current);

        while (aberto.Count > 0 && !achouMeta)
        {
            // nó visitado é contabilizado
            nos += 1;
            // Console.WriteLine("Profundidade atual: " + _current.prof);
            if (isMeta(_current))
            {
                break;
            }

            if (aberto.Count > 0)
            {
                // Console.Write("Extandindo jogadas possiveis: \n");
                expande(_current);
                // Console.WriteLine("Possib. de movimento na profundidade atual: " + _current.prof);
                // Console.WriteLine("----------");
            }

            // remove o nó atual para não dar loop
            aberto.Remove(_current);
            // adiciona nó atual na lista fechada para evitar repetir estados
            fechado.Add(_current);

            if (aberto.Count > 0)
            {
                int menorCusto = aberto.First().f; // f(n)
                int proximoNo = 0;

                for (int i = 1; i < aberto.Count; i++)
                {
                    Random gen = new Random();
                    int prob = gen.Next(2);

                    // if (fechado.Find(x => x.Equals(aberto[i])) != null)
                    // {
                    //     Console.Write("\n** ACHOOOOOOU **\n");
                    //     continue;
                    // }

                    if (aberto[i].f < menorCusto)
                    {
                        menorCusto = aberto[i].f;
                        proximoNo = i;
                        continue;
                    }
                    else if (aberto[i].f == menorCusto && prob != 0)
                    {
                        menorCusto = aberto[i].f;
                        proximoNo = i;
                        continue;
                    }
                }

                _current = aberto[proximoNo];
                // aberto = new List<No> { };
                // aberto.Add(_current);
                // Console.Write("\nno selecionado: \n");
                // _current.mostraValores();
                // Console.WriteLine("=====");
                // System.Threading.Thread.Sleep(500);
            }
        }

        //9. Se houver resultado é adicionado a cadeia de "pais" a uma pilha
        while (_current != null && achouMeta)
        {
            solucao.Add(_current);
            _current = _current._parent;
        }

        //10. Termina
        //Console.WriteLine("->SOLÚVEL\n-->INVERSÕES: " + _inversoes + "\n");
        // printa qtd de nós gerados
        Console.Write("Qtd. de nós visitados: " + nos + "\n");
        Console.Write("Tamanho da lista aberta: " + aberto.Count + "\n");
        Console.Write("Tamanho da lista fechado: " + fechado.Count + "\n");
    }

    /**
    * Método encontrado em um trabalho da UFRJ. Ela consegue dizer se a posição inicial
    * informada tem ou não solução.
    */
    public bool isSoluvel(No n)
    {
        List<int> curr = new List<int> { };
        int invers = 0;

        /**
         * Posiciona os valores da matriz em um vetor temporário
         * */
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {

                curr.Add(n._state[i, j]);
            }
        }


        //Conta o numero de inversoes
        for (int i = 0; i < curr.Count; i++)
        {
            if (curr[i] != 0)
            {
                for (int j = i; j < curr.Count; j++)
                {
                    if (curr[j] != 0)
                    {
                        if (curr[i] > curr[j])
                        {
                            invers++;
                        }
                    }
                }
            }
        }

        _inversoes = invers;

        // verifica se há solução. Se der par é porque tem solução, se der impar não tem.
        if (invers % 2 == 0)
        {
            return true;
        }

        return false;
    }

    /**
    * Método que informa se o estado atual é igual a solução desejada.
    */
    public bool isMeta(No n)
    {
        testados++;

        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                if (n._state[i, j] != meta._state[i, j])
                {
                    return false;
                }
            }
        }

        achouMeta = true;
        return true;
    }

    // calcula a distancia manhattan entre dois pontos
    private static int ManhattanDistanceBetweenCoordinates(int p1_x, int p1_y, int p2_x, int p2_y)
    {
        int distX = Math.Abs(p1_x - p2_x);
        int distY = Math.Abs(p1_y - p2_y);
        return distX + distY;
    }

    // método que calcula a distancia manhattan das posições do estado informado.
    public int ManhattanDistance(No curr)
    {
        int totalDifference = 0;

        int n = curr._state.GetLength(0);

        for (int i = 0; i < n; ++i)
        {
            for (int j = 0; j < n; ++j)
            {
                int value = curr._state[i, j];

                if (value == 0) continue;

                // obtenha a coordenada final para o valor atual:
                int finalX = value / n;
                int finalY = value % n;

                // calcula distancia mengattan:
                int dist = ManhattanDistanceBetweenCoordinates(i, j, finalX, finalY);

                //Console.Write("[" + i + "," + j + "] with value of " + board[i, j] + " has to been moved to [" + finalX + "," + finalY + "] coordinates.");
                //Console.WriteLine(" Manhattan distance to goal: " + dist );

                totalDifference += dist;
            }
        }

        return totalDifference;
    }

    /**
    * Método responsável por realizar expansão dos movimentos possíveis da peça vazia.

    * Retorno:
    * bool _achou - se achou um movimento possivel (sem uso atualmente)
    */
    public bool expande(No curr)
    {
        bool _achou = false;

        No _novoUp = new No(curr._state, curr);
        No _novoDown = new No(curr._state, curr);
        No _novoRight = new No(curr._state, curr);
        No _novoLeft = new No(curr._state, curr);

        // Peça vazia move-se para cima
        if (_novoUp.moveUp())
        {
            if (equalPrevious(_novoUp, curr) == false)
            {
                _achou = true;
                // guardando peso do no atual + o peso do pai (necessario para busca A*)
                _novoUp.g = curr.g + 1; // g(n)
                _novoUp.h = ManhattanDistance(_novoUp); // h(n)
                _novoUp.f = _novoUp.g + _novoUp.h; // f(n)
                aberto.Add(_novoUp);
                // teste para largura, profundidade e guloso
                // Console.Write("\nManhanttan: " + ManhattanDistance(_novoUp) + "\n");
                // teste para A*
                // Console.Write("\nA* Manhanttan g(n): " + _novoUp.g + "\n");
                // Console.Write("\nA* Manhanttan h(n): " + _novoUp.h + "\n");
                // Console.Write("\nA* Manhanttan f(n): " + _novoUp.f + "\n");
                // _novoUp.mostraValores();
                // Console.WriteLine("\n");
            }
        }

        // Peça vazia move-se para baixo
        if (_novoDown.moveDown())
        {

            if (equalPrevious(_novoDown, curr) == false)
            {
                _achou = true;
                // guardando peso do no atual + o peso do pai (necessario para busca A*)
                _novoDown.g = curr.g + 1; // g(n)
                _novoDown.h = ManhattanDistance(_novoDown); // h(n)
                _novoDown.f = _novoDown.g + _novoDown.h; // f(n)
                aberto.Add(_novoDown);
                // teste para largura, profundidade e guloso
                // Console.Write("\nManhanttan: " + ManhattanDistance(_novoDown) + "\n");
                // teste para A*
                // Console.Write("\nA* Manhanttan g(n): " + _novoDown.g + "\n");
                // Console.Write("\nA* Manhanttan h(n): " + _novoDown.h + "\n");
                // Console.Write("\nA* Manhanttan f(n): " + _novoDown.f + "\n");
                // _novoDown.mostraValores();
                // Console.WriteLine("\n");
            }
        }

        // Peça vazia move-se para a esquerda
        if (_novoLeft.moveLeft())
        {
            if (equalPrevious(_novoLeft, curr) == false)
            {
                _achou = true;
                // guardando peso do no atual + o peso do pai (necessario para busca A*)
                _novoLeft.g = curr.g + 1; // g(n)
                _novoLeft.h = ManhattanDistance(_novoLeft); // h(n)
                _novoLeft.f = _novoLeft.g + _novoLeft.h; // f(n)
                aberto.Add(_novoLeft);
                // teste para largura, profundidade e guloso
                // Console.Write("\nManhanttan: " + ManhattanDistance(_novoLeft) + "\n");
                // teste para A*
                // Console.Write("\nA* Manhanttan g(n): " + _novoLeft.g + "\n");
                // Console.Write("\nA* Manhanttan h(n): " + _novoLeft.h + "\n");
                // Console.Write("\nA* Manhanttan f(n): " + _novoLeft.f + "\n");
                // _novoLeft.mostraValores();
                // Console.WriteLine("\n");
            }
        }

        // Peça vazia move-se para a direita
        if (_novoRight.moveRight())
        {
            if (equalPrevious(_novoRight, curr) == false)
            {
                _achou = true;
                // guardando peso do no atual + o peso do pai (necessario para busca A*)
                _novoRight.g = curr.g + 1; // g(n)
                _novoRight.h = ManhattanDistance(_novoRight); // h(n)
                _novoRight.f = _novoRight.g + _novoRight.h; // f(n)
                aberto.Add(_novoRight);
                // teste para largura, profundidade e guloso
                // Console.Write("\nManhanttan: " + ManhattanDistance(_novoRight) + "\n");
                // teste para A*
                // Console.Write("\nA* Manhanttan g(n): " + _novoRight.g + "\n");
                // Console.Write("\nA* Manhanttan h(n): " + _novoRight.h + "\n");
                // Console.Write("\nA* Manhanttan f(n): " + _novoRight.f + "\n");
                // _novoRight.mostraValores();
                // Console.WriteLine("\n");
            }
        }

        return _achou;
    }

    // método expande as jogadas possiveis mas só empilha a que tiver menor distancia manhattan.
    // public bool expandeGuloso(No curr)
    // {
    //     bool _achou = false;

    //     No _novoUp = new No(curr._state, curr);
    //     int up = 0;
    //     No _novoDown = new No(curr._state, curr);
    //     int down = 0;
    //     No _novoRight = new No(curr._state, curr);
    //     int right = 0;
    //     No _novoLeft = new No(curr._state, curr);
    //     int left = 0;

    //     // Peça vazia move-se para cima
    //     if (_novoUp.moveUp())
    //     {
    //         if (equalPrevious(_novoUp, curr) == false)
    //         {
    //             _achou = true;
    //             up = ManhattanDistance(_novoUp);
    //             // aberto.Add(_novoUp);
    //             // _novoUp.mostraValores();
    //             // Console.WriteLine("\n");
    //         }
    //     }

    //     // Peça vazia move-se para baixo
    //     if (_novoDown.moveDown())
    //     {

    //         if (equalPrevious(_novoDown, curr) == false)
    //         {
    //             _achou = true;
    //             down = ManhattanDistance(_novoDown);
    //             // aberto.Add(_novoDown);
    //             // _novoDown.mostraValores();
    //             // Console.WriteLine("\n");
    //         }
    //     }

    //     // Peça vazia move-se para a esquerda
    //     if (_novoLeft.moveLeft())
    //     {
    //         if (equalPrevious(_novoLeft, curr) == false)
    //         {
    //             _achou = true;
    //             left = ManhattanDistance(_novoLeft);
    //             // aberto.Add(_novoLeft);
    //             // _novoLeft.mostraValores();
    //             // Console.WriteLine("\n");
    //         }
    //     }

    //     // Peça vazia move-se para a direita
    //     if (_novoRight.moveRight())
    //     {
    //         if (equalPrevious(_novoRight, curr) == false)
    //         {
    //             _achou = true;
    //             right = ManhattanDistance(_novoRight);
    //             // aberto.Add(_novoRight);
    //             // _novoRight.mostraValores();
    //             // Console.WriteLine("\n");
    //         }
    //     }

    //     List<int> menoresNumeros = new List<int> { up, down, left, right };
    //     int min = menoresNumeros[0];
    //     int minIndex = 0;

    //     for (int i = 1; i < menoresNumeros.Count; ++i)
    //     {
    //         if (menoresNumeros[i] < min)
    //         {
    //             min = menoresNumeros[i];
    //             minIndex = i;
    //         }
    //     }

    //     switch (minIndex)
    //     {
    //         case 0:
    //             aberto.Add(_novoUp);
    //             _novoUp.mostraValores();
    //             Console.WriteLine("\n");
    //             break;
    //         case 1:
    //             aberto.Add(_novoDown);
    //             _novoDown.mostraValores();
    //             Console.WriteLine("\n");
    //             break;
    //         case 2:
    //             aberto.Add(_novoLeft);
    //             _novoLeft.mostraValores();
    //             Console.WriteLine("\n");
    //             break;
    //         case 3:
    //             aberto.Add(_novoRight);
    //             _novoRight.mostraValores();
    //             Console.WriteLine("\n");
    //             break;
    //     }

    //     return _achou;
    // }

    // public bool expandeAStar(List<No> successors, No curr)
    // {
    //     bool _achou = false;

    //     No _novoUp = new No(curr._state, curr);
    //     No _novoDown = new No(curr._state, curr);
    //     No _novoRight = new No(curr._state, curr);
    //     No _novoLeft = new No(curr._state, curr);

    //     // Peça vazia move-se para cima
    //     if (_novoUp.moveUp())
    //     {
    //         if (equalPrevious(_novoUp, curr) == false)
    //         {
    //             _achou = true;
    //             successors.Add(_novoUp);
    //             // _novoUp.mostraValores();
    //             // Console.WriteLine("\n");
    //         }
    //     }

    //     // Peça vazia move-se para baixo
    //     if (_novoDown.moveDown())
    //     {

    //         if (equalPrevious(_novoDown, curr) == false)
    //         {
    //             _achou = true;
    //             successors.Add(_novoDown);
    //             // _novoDown.mostraValores();
    //             // Console.WriteLine("\n");
    //         }
    //     }

    //     // Peça vazia move-se para a esquerda
    //     if (_novoLeft.moveLeft())
    //     {
    //         if (equalPrevious(_novoLeft, curr) == false)
    //         {
    //             _achou = true;
    //             successors.Add(_novoLeft);
    //             // _novoLeft.mostraValores();
    //             // Console.WriteLine("\n");
    //         }
    //     }

    //     // Peça vazia move-se para a direita
    //     if (_novoRight.moveRight())
    //     {
    //         if (equalPrevious(_novoRight, curr) == false)
    //         {
    //             _achou = true;
    //             successors.Add(_novoRight);
    //             // _novoRight.mostraValores();
    //             // Console.WriteLine("\n");
    //         }
    //     }

    //     return _achou;
    // }

    /*
     * Checa se o estado novo (a nova jogada) é igual ao estado anterior (atual jogada mas que está se tornando a anterior)
     * */
    public bool equalPrevious(No n, No curr)
    {
        if (curr._parent == null)
        {
            return false;
        }

        No _tmp = curr._parent;
        bool result = true;
        while (_tmp != null)
        {
            result = true;
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (n._state[i, j] != curr._parent._state[i, j])
                    {
                        result = false;
                    }
                }
            }

            _tmp = _tmp._parent;

        }

        return result;
    }
}
