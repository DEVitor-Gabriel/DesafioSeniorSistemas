# DesafioSeniorSistemas

## Descrição do Projeto
Este projeto foi desenvolvido como parte de um desafio proposto. O objetivo era criar uma API REST utilizando .NET e C#. O projeto segue a arquitetura DDD (Domain-Driven Design), onde a camada de Domínio foi separada da aplicação em um projeto independente. Além disso, a camada de infraestrutura foi dividida em projetos separados para abranger as funcionalidades de API, Log e Repositório.

## Desafio de SQL
O desafio de SQL está resolvido no arquivo `DesafioSQL.sql`.

## Tecnologias Utilizadas
- .NET
- C#
- Entity Framework
- Identity

## Banco de Dados
Para este projeto, foi utilizado o banco de dados em memória, ideal para fins de desenvolvimento e testes.

## Estrutura do Projeto
O projeto foi estruturado da seguinte forma:

### 1. Domínio
Neste projeto estão definidos os elementos fundamentais do domínio da aplicação, incluindo:
- Entidades (Entities)
- Objetos de Valor (Value Objects)
- Fábricas (Factories)
- Serviços (Services)

### 2. Infraestrutura
Este projeto abrange as funcionalidades relacionadas à infraestrutura da aplicação, incluindo:
- API
- Log
- Repositório (Database Repository)

## Autenticação da API REST
Todas as rotas da API requerem autenticação. Um token de autenticação deve ser incluído no cabeçalho das requisições. Este token pode ser obtido através da rota `api/Auth/Login`.

## Instruções de Uso
Para executar este projeto em seu ambiente local, siga estas etapas:

1. Clone este repositório em sua máquina:
https://github.com/DEVitor-Gabriel/DesafioSeniorSistemas.git

2. Abra a solução no Visual Studio ou em sua IDE preferida.

3. Certifique-se de ter o .NET SDK instalado em sua máquina.

4. Execute o projeto.

## Licença
Este projeto está licenciado sob a [Licença MIT](https://opensource.org/licenses/MIT).

---
© 2024 DesafioSeniorSistemas. Desenvolvido por [Vitor Gabriel](https://github.com/DEVitor-Gabriel).

