# Arquitetura de Software

---
 
## MVC (Model-View-Controller)

Separa a aplicação em três camadas: o **Model**, que guarda os dados e as regras de negócio; a **View**, responsável por exibir esses dados ao utilizador; e o **Controller**, que recebe as interações do utilizador, aciona o Model e decide qual View mostrar. É o padrão clássico em aplicações desktop e web (ex.: Spring MVC, ASP.NET MVC). Vantagem principal: separação clara de responsabilidades, facilitando testes e manutenção. Desvantagem: em projetos maiores, o Controller pode acumular demasiada lógica ("Controllers gordos").

## MVVM (Model-View-ViewModel)

Evolução do MVC voltada para interfaces com *data binding* (ex.: WPF, Angular, Vue). O **Model** continua a representar os dados; a **View** é a interface visual; e o **ViewModel** atua como intermediário que expõe os dados do Model de forma pronta para a View consumir, sincronizando alterações automaticamente através de *binding*. Reduz código repetitivo de sincronização entre interface e dados, mas pode tornar o fluxo de dados menos explícito e mais difícil de depurar.

## Pipelines

Arquitetura em que o processamento é dividido numa sequência de etapas (*stages*), onde a saída de uma etapa é a entrada da seguinte. Muito usada em processamento de dados, compiladores, CI/CD e sistemas de streaming. Facilita a composição e reutilização de etapas isoladas e permite paralelização, mas pode dificultar o tratamento de erros que ocorrem a meio da cadeia e introduzir latência se as etapas forem síncronas.

## Microsserviços

Divide a aplicação em serviços pequenos, independentes e implantados separadamente, cada um responsável por uma funcionalidade de negócio específica, comunicando entre si normalmente via HTTP/REST ou mensagens. Permite escalar, atualizar e implementar cada serviço de forma independente, com equipas a trabalhar em paralelo. Em contrapartida, aumenta a complexidade operacional (monitorização, comunicação entre serviços, consistência de dados distribuídos) comparado com um monólito.

## Event Driven (Orientada a Eventos)

Os componentes comunicam através da emissão e consumo de **eventos**, em vez de chamadas diretas entre si, geralmente com um *broker*/*event bus* a intermediar (ex.: Kafka, RabbitMQ). Promove baixo acoplamento entre produtores e consumidores de eventos e boa escalabilidade, sendo comum em sistemas reativos e de tempo real. A dificuldade está em manter a rastreabilidade do fluxo de eventos e garantir consistência, já que o processamento é assíncrono.