# Anime API

Este repositório contém uma aplicação de API web que gerencia animes, desenvolvida como parte de um desafio técnico. A aplicação segue os requisitos e boas práticas de desenvolvimento para demonstrar conhecimentos em .NET, Clean Architecture, Entity Framework, MediatR, testes unitários, entre outros.

## Funcionalidades

A API oferece as seguintes funcionalidades para manipulação de animes:

- **Obter todos os animes**: Retorna todos os animes cadastrados.
- **Obter anime por ID, diretor ou nome**: Permite buscar animes com base em qualquer combinação desses campos.
- **Cadastrar anime**: Cria um novo anime com nome, diretor e resumo.
- **Alterar anime**: Atualiza os detalhes de um anime existente.
- **Excluir anime**: Remove um anime do banco de dados.

## Requisitos Técnicos

A aplicação foi desenvolvida com as seguintes tecnologias:

- **.NET 8** (versão mais recente)
- **Clean Architecture**
- **Entity Framework** para operações de banco de dados
- **SQL Server** ou **MongoDB** (configurável)
- **MediatR** para comunicação entre componentes
- **xUnit** para testes unitários
- **Docker** para suportar deploy em containers
- **Logs de exceção** para rastreamento de erros

## Endpoints

Os endpoints seguem o padrão REST e são versionados:

- `GET /api/v1/animes` - Retorna todos os animes.
- `GET /api/v1/animes/{id}` - Retorna o anime pelo ID.
- `GET /api/v1/animes/search` - Retorna animes filtrados por nome ou diretor.
- `POST /api/v1/animes` - Cadastra um novo anime.
- `PUT /api/v1/animes/{id}` - Atualiza um anime existente.
- `DELETE /api/v1/animes/{id}` - Exclui um anime.

## Como Executar

### Pré-requisitos

- .NET 8 instalado
- Docker (para executar a aplicação em container)
- Banco de dados SQL Server ou MongoDB (configurável)

### Rodando a Aplicação

1. Rodando com docker:

```bash
git clone https://github.com/matheus55391/anime-api.git
```

```bash
 cd anime-api
```

```bash
docker-compose up -d
```

1. Rodando via terminal:

```bash
git clone https://github.com/matheus55391/anime-api.git
```

```bash
 cd anime-api
```

```bash
dotnet watch --project AnimeAPI.API
```
