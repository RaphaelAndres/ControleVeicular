# Controle Automotivo

O projeto não está completamente finalizado mas já possui conteúdo suficiente para sua validação. Falta o filtro via Ajax no cadastro de anúncio, finalizar a funcionalidade de login/autenticação e o relatório PDF; Pretendo finalizar isso amanhã (01/06) ou depois de amanhã, sempre no período da noite.
O objetivo deste desenvolvimento é prover uma ferramenta de controle de estoque de loja de automóveis utilizando C#/Asp.Net (2.2.0), Angular 9 e SqlServer.

## Instalação

É necessário instalar o framework do .Net da versão 2.2.0 disponível no link a seguir:
[.Net 2.2](https://dotnet.microsoft.com/download/dotnet-core/2.2)


## Como rodar
Primeiro, é necessário executar o arquivo "CriarDabase.bat" disponível na raíz do projeto.
Depois disso, é necessário executar o frontend e o backend, para isto, abra dois CMDs na pasta do projeto e rode o seguinte:
Front-end (fechar o CMD irá causar na parada da execução):
```batch
cd .\ControleVeicular-app\
ng serve -o
```
Back-end (fechar o CMD irá causar na parada da execução):
```batch
cd .\controleVeicular.WebApi\
dotnet run
```

## O que falta?
Falta o filtro via Ajax no cadastro de anúncio, finalizar a funcionalidade de login/autenticação e o relatório PDF; Pretendo finalizar isso amanhã (01/06) ou depois de amanhã, sempre no período da noite.

Algumas outras coisas que não foram solicitadas mas que eu queria ter feito e pretendo fazer após concluir o que citei acima, seria permitir vincular fotos aos anúncios e mostrar todos os anúncios na página inicial, sem obrigar autenticação, de forma que mostrasse literalmente um portfólio. Outra coisa que queria fazer é colocar a aplicação em Docker e disponibiliza-la no AWS. 

Quanto à tudo que não foi feito, foi tudo devido à falta de tempo. De todas as coisas solicitadas, as duas únicas em que eu não possuia domínio é na parte de PDF (nunca gerei relatórios em PDF usando C#) e a questão da autenticação, eu poderia obviamente fazer algo extremamente simples como criar uma tabela de usuário, solicitar o login e comparar os dados, mas prefiri fazer da forma mais comum (e aceita no mundo) que é usar o serviço de autenticação do .Net, o problema é que quando trabalho com .Net e C#, esta parte sempre vem pronta, então nunca tive que mexer diretamente nisso.