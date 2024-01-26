# Teste Técnico

## **Considerações iniciais**
* Versão da Unity utilizada: 2022.3.18f1 LTS - URP
  * Foi criado um MenuItem "HEIMO" na parte superior do Editor onde muito do que foi feito pode ser acessado, inclusive as cenas do jogo
* Builds disponíveis para Windows e WEBGL
* Para acessar o jogo: Extrair o arquivo ".\Artifacts\Build - Windows.rar" e executar o .exe
* O jogo também pode ser acesso pelo navegador pelo link https://hugouchoasborges.itch.io/heimo-games-studio, senha: fsm
* Dentro da Unity
* Alguns registros (prints) podem ser encontrados na pasta ".\Images"

## Organização das atividades e registro de tempo
* Para organização e priorização das atividades foi utilizado o programa Notion, onde criei um sistema **parecido** com o que o JIRA faz,  tendo Projects\Releases\Stories\Tasks\Subtasks
* Para registro de tempo foi utilizado o programa Toggl Track, onde registrei o tempo gasto por atividade\assunto

## **Separação de código**

Os scripts utilizados no teste estão localizados em **Assets\HEIMO\Scripts**, sendo:
* EXTERNAL_CODE: Código copiado de fontes externas, contendo apenas o controle de movimento do veículo;
* INHERITED_CODE: Código herdado de outros projetos criados por mim. Esse repositório Github foi criado a partir de um template que já continha esses scripts herdados;
* O restante são scripts exclusivamente criados para o teste.

## **Sistemas herdados utilizados**
* FSM - Finite State Machine
  *  Criei um sistema de FSM onde é possível transformar qualquer Monobehaviour em uma máquina de estados finitos.
  *  Gosto sempre de utilizar esse sistema para melhor definir ações para os Controladores baseados em estados. Então o Controlador de fato apenas realiza a ação, mas seus estados definem quando realizar tal ação.
*  Logs
  * Tenho um sisteminha de logs simples. Foi útil durante o desenvolvimento, mas sempre prefiro usar o debugger do VStudio

## **Sistemas criados**
* Loja e Inventário
  * Utilizei ScriptableObjects para gerenciar os itens disponíveis para venda e os itens comprados pelo jogador
  * Como é apenas um teste, deixei livre para o jogador atribuir o quanto de dinheiro\crédito deseja, pensando mais nesse 'jogo' como um protótipo a ser testado
* Inspector
  * Antes de criar interfaces, eu gosto de disponibilizar as mecânicas para teste no Inspector.
    * Então ao selecionar um item da loja no projeto, é possível aplicá-lo ao jogador em tempo de execução para teste
    * Da mesma forma, no inventario do jogador (Menu HEIMO/GARAGE/Player Inventory) é possível resetar as compras feitas
* Criação dos scriptableObjects para a loja
  * Ao clicar com o botão direito em um material, é possível criar uma nova pintura já inclusa na loja
  * Ao clicar com o botão direito em um material + uma Mesh, é possível criar uma nova
  * Etc

## **Autoavaliação**
### O que tive orgulho
* O sistema de criação dos ScriptableObjects a partir da aba projeto, selecionando os assets que compõem o objeto
* O sistema de FSM herdado que sempre me ajuda bastante a manter uma boa separação da lógica
* As visualizações no Inspector para testar mecânicas sem precisar de uma interface

  
### O que tive dificuldade ou não gostei
* Generalização dos diferentes componentes da loja em uma classe abstrata
  * Sinceramente eu jogaria tudo que fiz fora (classes que herdam de AbstractCarPartSO) e faria novamente, pois ficou muito código repetido para cada tipo de ICarPart implementado.
  
### Onde mais gastei tempo
* Pensando no sistema da loja, em como eu listaria os produtos e em como eu marcaria um produto como já comprado pelo jogador
* Refiz esse sistema 3 vezes até achar uma alternative menos complexa

### Onde menos gastei tempo
* Na criação dos cenários - Simplesmente copiei o que já existia nos pacotes importados
* Nas lógicas de transição de estado, pois estou bem acostumado com sistemas FSM

### O que não foi feito e estava na descrição do teste
* Customização de para-choque
  * Como o para-choque era uma peça embutida no corpo do carro, substituí essa customização pelas luminárias adicionais do carro.
* Venda de ítens
  * Sinceramente só percebi que era necessário implementá-la quando estava atualizando esse README
  * Como eu fiz um botão para resetar as compras, não vi problema em não ter implementado a venda
  
### O que não foi feito mas gostaria de fazer:
* Persistência das customizações em disco
* Animações de transição de câmera
* Uma melhor interface para os menus
