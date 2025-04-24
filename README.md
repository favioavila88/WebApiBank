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

3. Crea las dependencias:
   ```bash
   dotnet ef migrations add InitialCreate

4. Aplicar las migraciones y crear la base de datos:
    ```bash
    dotnet ef database update

5. Ejecutar el proyecto:
    ```bash
    dotnet run

6. Acceder a Swagger:
    ```bash
    https://localhost:51835/swagger

# 🏦 Sistema Bancario - Documentación Técnica

Este sistema bancario implementa una arquitectura limpia y escalable basada en principios SOLID y patrones de diseño de software. Su objetivo es mantener un código mantenible, extensible, testeable y fácil de entender.

---

## 📌 Principios SOLID Implementados

### 🔹 SRP (Single Responsibility Principle)
Cada clase tiene una única responsabilidad claramente definida.

**Ejemplos:**
- `AccountService`: se encarga exclusivamente de la lógica relacionada con cuentas.
- `DepositCommand`, `WithdrawalCommand`: manejan una única acción específica.

---

### 🔹 OCP (Open/Closed Principle)
El sistema está abierto para extensión pero cerrado para modificación.

**Ejemplo:**
- La implementación de `ICommand`, `DepositCommand`, `WithdrawalCommand` permite agregar nuevas operaciones sin modificar el código existente.

---

### 🔹 LSP (Liskov Substitution Principle)
Las subclases pueden reemplazar a sus clases base sin alterar el comportamiento esperado.

**Ejemplo:**
- `TransactionHandlerBase` y sus derivados como `PositiveAmountValidator` y `SufficientFundsValidator` pueden ser utilizados de forma intercambiable.

---

### 🔹 ISP (Interface Segregation Principle)
Interfaces específicas y pequeñas que evitan forzar la implementación de métodos innecesarios.

**Ejemplo:**
- `ITransactionHandler` expone solo los métodos esenciales (`HandleAsync`, `SetNext`).

---

### 🔹 DIP (Dependency Inversion Principle)
Las clases dependen de abstracciones y no de implementaciones concretas.

**Ejemplo:**
- Servicios inyectados por interfaz (`IAccountService`) en `Program.cs`, facilitando pruebas unitarias y mantenimiento.

---

## 🧱 Patrones de Diseño Implementados

### 🧬 Patrones Creacionales

#### 🔸 Builder
**Clase:** `AccountBuilder`  
**Uso:** Construcción fluida de objetos `Account` o `AccountDTO`.

**✅ Beneficios:**
- Facilita la creación de objetos complejos.
- Mejora la legibilidad.
- Evita constructores sobrecargados.

---

#### 🔸 Factory Method (implícito)
**Clases:** `DepositCommand`, `WithdrawalCommand`  
**Uso:** Cada clase representa una operación específica simulando una fábrica de comandos.

**✅ Beneficios:**
- Añadir nuevas operaciones sin modificar código existente.
- Favorece el principio OCP.

---

#### 🔸 Abstract Factory
**Clases:** `ITransactionFactory`, `TransactionFactory`  
**Uso:** Encapsula la creación de objetos para distintos tipos de transacciones.

**✅ Beneficios:**
- Permite agregar nuevas familias de objetos fácilmente (como transferencias).
- Refuerza el OCP.
- Promueve consistencia en la construcción de objetos.

---

### 🤖 Patrones de Comportamiento

#### 🔸 Command
**Clases:** `DepositCommand`, `WithdrawalCommand`, `CommandHandler`  
**Uso:** Encapsulan acciones como objetos independientes.

**✅ Beneficios:**
- Facilita logs, deshacer/rehacer, colas de ejecución.
- Desacopla el invocador del ejecutor.

---

#### 🔸 Chain of Responsibility
**Clases:** `PositiveAmountValidator`, `SufficientFundsValidator`, `TransactionProcessor`  
**Uso:** Encadena validaciones previas a ejecutar una transacción.

**✅ Beneficios:**
- Aumenta la modularidad.
- Permite añadir nuevas validaciones sin modificar el código existente.

---

#### 🔸 Strategy
**Clases:** `ITransactionStrategy`, `DepositStrategy`, `WithdrawalStrategy`  
**Uso:** Permite cambiar dinámicamente el comportamiento de una transacción.

**✅ Beneficios:**
- Reutilización y extensión de lógica de negocio.
- Ideal para manejar múltiples tipos de operaciones.

---

### 🏗️ Patrones Estructurales

#### 🔸 Facade
**Clases:** `AccountController`, `DepositController`, `WithdrawalController`  
**Uso:** Interfaces REST que encapsulan la lógica de negocio y servicios.

**✅ Beneficios:**
- Oculta la complejidad del sistema.
- Facilita el consumo desde frontend u otros clientes.

---

#### 🔸 DTO (Data Transfer Object)
**Clases:** `AccountDTO`, `ClientDTO`, `TransactionDTO`  
**Uso:** Encapsulan datos que se transfieren entre el cliente y el servidor.

**✅ Beneficios:**
- Aíslan la lógica del dominio.
- Minimiza el acoplamiento entre capas.

---

## 📁 Estructura y Componentes Clave

- **Servicios:** `IAccountService`, `AccountService`
- **Repositorios:** Interfaces e implementaciones usando `DbContext`
- **Validaciones:** Basadas en Chain of Responsibility
- **Comandos:** Acciones encapsuladas como comandos
- **Controladores:** Puerta de entrada a través de rutas RESTful
- **DTOs:** Separan presentación y lógica de dominio

---

## ✅ Ventajas de la Arquitectura

- Alta cohesión, bajo acoplamiento.
- Fácil mantenimiento y extensión.
- Preparado para pruebas unitarias.
- Compatible con CI/CD.
- Escalable: permite añadir nuevas funcionalidades sin alterar las existentes.

---

## 🚀 Próximos Pasos

- Implementar nuevas estrategias como transferencias y pagos automáticos.
- Agregar soporte para eventos y logs transaccionales.
- Añadir autenticación y autorización basada en roles.

---

> Este proyecto representa una sólida base para aplicaciones bancarias modernas, aplicando principios robustos de ingeniería de software que garantizan su evolución en el tiempo.
