# 🏦 WebApiBank

Este proyecto es una API RESTful construida con .NET 8 para manejar operaciones bancarias: clientes, cuentas, depósitos y retiros.

## 🚀 Requisitos

- .NET 8 SDK
- SQL Server (o LocalDB)
- Visual Studio Code o Visual Studio

## ⚙️ Instalación

1. Clonar el repositorio:
   ```bash
   git clone https://github.com/tuusuario/WebApiBank.git
   cd WebApiBank

2. Restaurar las dependencias:
   ```bash
   dotnet restore

3. Aplicar las migraciones y crear la base de datos:
    ```bash
    dotnet ef database update

4. Ejecutar el proyecto:
    ```bash
    dotnet run

5. Acceder a Swagger:
    ```bash
    https://localhost:51835/swagger

## 📦 Estructura
Controllers: Endpoints de la API

Services: Lógica de negocio

Repositories: Capa de acceso a datos

Data/BankContext.cs: Contexto de EF Core

Migrations: Migraciones generadas

## 🧪 Tecnologías usadas
ASP.NET Core 8

Entity Framework Core

SQL Server

Swagger

## 🛠 Notas
1. Si no tenés dotnet-ef instalado:
   ```bash
    dotnet tool install --global dotnet-ef

