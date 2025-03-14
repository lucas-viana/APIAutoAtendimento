# 🍽️ Garçom Virtual - (Ainda em desenvolvimento)

Um sistema de autoatendimento para restaurantes que permite aos clientes realizarem pedidos diretamente pelo sistema, otimizando o fluxo de atendimento e melhorando a experiência do usuário.

## 📌 Descrição do Projeto

O Garçom Virtual é uma aplicação cliente-servidor desenvolvida em **C#** com arquitetura monolítica. O sistema oferece funcionalidades como gerenciamento de pedidos, controle de status e interface para os garçons acompanharem em tempo real.

### 🎯 Objetivo
Facilitar o processo de pedidos em restaurantes, permitindo que os clientes façam suas solicitações de forma autônoma, enquanto os garçons acompanham e administram os pedidos em tempo real.

## ⚙️ Funcionalidades

- 📋 Cadastro de pedidos
- 🔍 Consulta de status do pedido
- 📊 Dashboard para acompanhamento de pedidos
- 🔔 Notificação de novos pedidos

## 🛠️ Tecnologias Utilizadas

- **Linguagem**: C# (.NET 6 ou superior)
- **Banco de Dados**: MySQL
- **Arquitetura**: Monolítica

## 🚀 Como Executar o Projeto

### Pré-requisitos

Certifique-se de ter as seguintes ferramentas instaladas:

- [SDK do .NET 6+](https://dotnet.microsoft.com/)
- [SQL Server](https://www.mysql.com/)
- [Git](https://git-scm.com/)

### Passos para execução

1. **Clone o repositório:**

```bash
 git clone https://github.com/seuusuario/garcom-virtual.git
 cd garcom-virtual
```

2. **Configure o banco de dados:**

- Crie um banco de dados no SQL Server.
- Atualize a string de conexão no arquivo `appsettings.json`.

3. **Restaure as dependências:**

```bash
 dotnet restore
```

4. **Execute as migrações do banco:**

```bash
 dotnet ef database update
```

5. **Execute a aplicação:**

```bash
 dotnet run
```

A API estará disponível em `http://localhost:5000`.

## 📚 Estrutura do Projeto

```
/garcom-virtual
├── /src              # Código-fonte principal
│   ├── Controllers   # APIs de pedido, status, etc.
│   ├── Models        # Entidades do banco
│   ├── Repositories  # Repositórios assíncronos
│   └── Services      # Lógica de negócios
├── /tests            # Testes automatizados
├── /docs             # Documentação do projeto
└── README.md         # Documentação principal
```

## ✅ Contribuição

1. Faça um **fork** do projeto
2. Crie uma **branch** com sua feature (`git checkout -b feature/minha-feature`)
3. **Commit** suas alterações (`git commit -m 'Adiciona nova feature'`)
4. Faça um **push** para a branch (`git push origin feature/minha-feature`)
5. Abra um **Pull Request**


"O sucesso é a soma de pequenos esforços repetidos dia após dia"

