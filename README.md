# HotelReservaAPI

API simples para gerenciamento de reservas de hotel, desenvolvida em ASP.NET Core com InMemoryDatabase.

## Funcionalidades
- CRUD de hóspedes e acomodações
- Criação de reservas com verificação de disponibilidade
- Cálculo automático do valor total da reserva
- Utilização do padrão Repository

## Tecnologias
- ASP.NET Core 8.0
- Entity Framework Core (InMemory)
- Swagger

## 📦 Pacotes NuGet Utilizados

| Pacote | Versão | Descrição |
|--------|---------|------------|
| `Microsoft.EntityFrameworkCore` | 9.0.0 | ORM para mapeamento objeto-relacional. |
| `Microsoft.EntityFrameworkCore.InMemory` | 9.0.0 | Banco de dados em memória para desenvolvimento e testes. |
| `Swashbuckle.AspNetCore` | 6.6.2 | Interface gráfica do Swagger. |

## 🧠 Pré-requisitos

Antes de rodar o projeto, verifique se você tem instalado:

- [.NET SDK 8.0](https://dotnet.microsoft.com/pt-br/download/dotnet/8.0)
- Um editor de código (recomendado: [Visual Studio 2022](https://visualstudio.microsoft.com/pt-br/vs/))
- [Git](https://git-scm.com/) (para clonar o repositório)

## ▶️ Como Executar o Projeto

### 1️⃣ Clonar o repositório

Abra o terminal e execute:

```bash
git clone https://github.com/anderson-nasciment0/HotelReservaAPI.git
cd HotelReservaAPI
dotnet restore
dotnet run
