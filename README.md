# Media API

Este repositório contém uma aplicação de API web que gerencia medias, desenvolvida como parte de um desafio técnico. A aplicação segue os requisitos e boas práticas de desenvolvimento para demonstrar conhecimentos em .NET, Clean Architecture, Entity Framework, MediatR, testes unitários, entre outros.

## 🚀 Rodando a Aplicação

### 📦 Rodando com Docker

1. Clone o repositório:

   ```bash
   git clone https://github.com/matheus55391/media-api-desafio.git
   ```

2. Acesse a pasta do projeto:

   ```bash
   cd media-api-desafio
   ```

3. Configure a conexão com o banco de dados:

   - O banco de dados SQL Server será iniciado automaticamente pelo Docker.
   - Edite os arquivos `MediaAPI/appsettings.json` e `MediaAPI/appsettings.Development.json` para garantir que a string de conexão esteja correta.
   - Se estiver usando um banco externo, comente a seção referente ao `sqlserver` no `docker-compose.yml` e ajuste a string de conexão para apontar ao banco externo.

4. Construa e inicie os containers em segundo plano:

   ```bash
   docker-compose up -d
   ```

5. A API estará disponível em `http://localhost:8080`.

### 🖥️ Rodando via .NET CLI

1. Clone o repositório:

   ```bash
   git clone https://github.com/matheus55391/media-api-desafio.git
   ```

2. Acesse a pasta do projeto:

   ```bash
   cd media-api-desafio
   ```

3. Inicie a API com recarregamento automático:

   ```bash
   dotnet watch --project MediaAPI.API
   ```

4. A API estará disponível em `http://localhost:8080`.

### 📌 Rodando as Migrations

Se for necessário atualizar o banco de dados com as migrations, execute:

```bash
dotnet ef database update --project MediaAPI.Infrastructure --startup-project MediaAPI.API
```

Isso aplicará as migrations ao banco configurado.

### 🖥️ Recomendações de IDE

Recomenda-se o uso do **Visual Studio** para facilitar o desenvolvimento, pois ele oferece:

- Debugging avançado e integrado.
- Gerenciamento simplificado de dependências e projetos.
- Ferramentas nativas para Entity Framework e migrations.
- Suporte aprimorado para desenvolvimento com .NET 8.

Se preferir, o **Visual Studio Code** também pode ser utilizado com a extensão C#.

---

🔹 **Observação:** Certifique-se de ter o .NET SDK 8.0 instalado para rodar via terminal sem Docker.

## Funcionalidades

A API oferece as seguintes funcionalidades para manipulação de medias:

- **Obter todos os medias**: Retorna todos os medias cadastrados.
- **Obter media por ID, diretor ou nome**: Permite buscar medias com base em qualquer combinação desses campos.
- **Cadastrar media**: Cria um novo media com nome, diretor e resumo.
- **Alterar media**: Atualiza os detalhes de um media existente.
- **Excluir media**: Remove um media do banco de dados.

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

- `GET /api/v1/medias` - Retorna todos os medias.
- `POST /api/v1/medias` - Cadastra um novo media.
- `PUT /api/v1/medias` - Atualiza um media existente.
- `DELETE /api/v1/medias/{id}` - Exclui um media.

### Pré-requisitos

- .NET 8 instalado
- Docker (para executar a aplicação em container)
- Banco de dados SQL Server ou MongoDB (configurável)
