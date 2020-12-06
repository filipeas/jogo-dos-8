# Jogo dos 8

## Detalhes iniciais

* Trabalho de Inteligência artificial da Universidade Federal do Piauí. O objetivo deste trabalho é implementar 4 buscas, que são:
- [x] Busca em largura
- [x] Busca em profundidade
- [x] Busca gulosa
- [x] Busca A*

* Implementamos o trabalho de uma forma que não fosse necessário guardar estados visitados. Para contornar loops e repetição de estados já visitados decidimos implementar o que chamamos de "escolha aleatória de movimento". Isso significa que sempre quando a busca chegar a um estado provavelmente repetido, ele irá aleatóriamente, decidir se escolhe ou não esse estado como jogada possível. Também ressaltamos que sempre quando houver a análise de movimentos possíveis para um estado, todas as buscas sempre irão fazer movimentos diferentes dos estados que eles foram gerados.

## Modo de uso

* Este repositório guarda apenas os algoritmos de busca. Para executar é necessário utilizar [SDK dotnet .NET](https://dotnet.microsoft.com/download). Após a instalação execute o comando na raiz do projeto: ``` dotnet run ```. Lembre-se que sempre quando fizer alguma alteração no código, execute ``` dotnet clean ```.

## Contribuintes
- [Daniel Dantas](https://github.com/DanielDantasL)
- [Filipe A. Sampaio](https://github.com/filipeas)