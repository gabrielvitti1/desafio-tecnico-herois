# Projeto Heróis

## Descrição
O **Projeto Heróis** é uma aplicação web FullStack desenvolvida para gerenciar uma base de dados de heróis e seus superpoderes. O projeto é composto por dois módulos principais:

- **Backend**: Uma API RESTful construída com ASP.NET Core, responsável por gerenciar os dados dos heróis e seus superpoderes.
- **Frontend**: Uma interface interativa desenvolvida com Angular, permitindo aos usuários visualizar, criar, editar e excluir heróis de forma dinâmica.

**Funcionalidades**
- **Gerenciamento de super-heróis**: Inserção, visualização, edição e exclusão dos heróis.
- **Exibição Dinâmica**: Visualização de heróis e seus superpoderes em uma interface amigável.

**Tecnologias Utilizadas**

### Backend
- **ASP.NET Core 8.0**: Framework para construção da API RESTful.
- **Entity Framework Core**: ORM para acesso e manipulação de dados no banco.
- **MySQL**: Banco de dados relacional para armazenamento de heróis e superpoderes.
- **Swagger/OpenAPI**: Documentação interativa da API.

### Frontend
- **Angular 16.0**: Framework para construção da interface de usuário.
- **TypeScript**: Para maior tipagem e segurança no código.
- **HTML e SCSS**: Para estruturação e estilização básica da interface.

### Versionamento
- **Git & GitHub**: Para versionamento e hospedagem do código.

📁 **Estrutura do Projeto**

O repositório está organizado em três pastas principais:
```
desafio-tecnico-herois/  # Pasta raiz do projeto
├── herois-api/          # Pasta contendo o backend ASP.NET Core da aplicação
├── herois-app/          # Pasta contendo o frontend Angular da aplicação
├── sql-scripts/         # Pasta contendo os scripts SQL (criação de contexto e tabelas)
└── README.md            # Arquivo README com informações do projeto
```

▶️ **Como Rodar o Projeto (Passo a Passo)**

### Pré-requisitos
- **.NET SDK 8.0** (ou superior)
- **Node.js** (versão 16.17.0 ou superior) e **npm**
- **Angular CLI** (instalado globalmente via `npm install -g @angular/cli@16.2.16`)
- **MySQL Server** e **MySQL Workbench** (ou outra ferramenta de gerenciamento de banco)
- **Visual Studio 2022** (recomendado para o backend)
- Navegador moderno (ex.: Chrome, Firefox)

### 1. Configurar o Banco de Dados
1. Abra o MySQL Workbench e conecte-se ao seu servidor MySQL (ex.: `localhost`).
2. Execute os scripts SQL localizados na pasta `Database/`:
   - `Hero.sql`: Cria o contexto das tabelas (execute-o primeiro).
   - `Herois.sql`: Cria a tabela para armazenar os heróis.
   - `Superpoderes.sql`: Cria a tabela para armazenar os superpoderes.
   - `Herois_Superpoderes.sql`: Cria a tabela para armazenar as relaçoes n:n entre heróis e superpoderes.

4. Verifique se as tabelas foram criadas corretamente.

### 2. Iniciar o Back-End (API ASP.NET Core)
1. Abra a solução `desafio-tecnico-herois/herois-api/Heroes.sln` no Visual Studio 2022.
2. Configure a conexão com o banco de dados MySQL:
   - No arquivo `Program.cs`, certifique-se de que as credenciais fornecidas correspondam à sua instância do MySQL.

     ```csharp
     builder.Services.AddDbContext<HeroesContext>(options =>
         options.UseMySQL("server=localhost;database=hero;user=SEU_USUARIO;password=SUA_SENHA"));
   
3. Pressione `F5` ou clique em "Iniciar" no Visual Studio para compilar e executar a API.
4. A API estará disponível em `https://localhost:5001` (ou outra porta configurada).
5. Acesse `https://localhost:5001/swagger` para testar os endpoints da API via Swagger.

### 3. Iniciar o Front-End (Aplicativo Angular)
1. Na pasta raiz do repositório, abra um terminal e navegue até a pasta do frontend:
   ```bash
   cd herois-app
   ```
2. Instale as dependências:
   ```bash
   npm install
   ```
3. Inicie o servidor de desenvolvimento:
   ```bash
   ng serve --open
   ```
4. O aplicativo Angular será aberto automaticamente no navegador em `http://localhost:4200`.

### 4. Interagir com a Aplicação
- Acesse `http://localhost:4200` no navegador.
- Verifique a configuração da URL da API no frontend:
  - Abra o arquivo `src\environment.ts`.
  - Confirme se as propriedades `api_heroi e api_superpoder` estão configuradas para a URL correta da API, que deve corresponder à porta onde o backend foi iniciado (ex.: `https://localhost:5001`). Exemplo de configuração:
    ```typescript
    export const environment = {
      api_heroi: 'https://localhost:5001/api/heroes',
      api_superpoder: 'https://localhost:5001/api/superpoderes',
      production: false
    };
    ```
  - Se a URL estiver incorreta (ex.: apontando para uma porta diferente ou endereço inválido), atualize-a para corresponder à URL exibida no console do backend ao iniciá-lo (ex.: `https://localhost:5001`).
  - Após alterar o arquivo, reinicie o servidor Angular com `ng serve` para aplicar as mudanças.
- Utilize os formulários para criar, editar ou excluir heróis e seus superpoderes.
- Visualize a lista de heróis e detalhes de seus superpoderes.
- Verifique no MySQL Workbench se os dados foram persistidos corretamente.

💡 **Aprendizados e Considerações Finais**

O Projeto Heróis foi uma excelente oportunidade para aplicar e expandir meus conhecimentos em desenvolvimento full-stack. Trabalhar no frontend foi especialmente divertido, permitindo que eu explorasse novos conceitos, como Signals, enquanto o backend também proporcionou desafios gratificantes e aprendizado significativo no processo de desenvolvimento.
