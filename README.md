# ModularMonolith Ticketing Example

**ModularMonolith Ticketing Example** is a sample solution built using a **microkernel** architecture that transforms a traditional monolith into a modular, highly extensible solution. 
In a Microkernel architecture, the core system (or kernel) provides only essential services while all additional features are implemented as independently developed plugins. 
This design enables you to build a modular monolith where features are isolated, easily maintainable, and can be added or removed without affecting the core system.

---

## Table of Contents

- [Overview](#overview)
- [Architecture & Key Points](#architecture--key-points)
- [Module Independence & Deployment](#module-independence--deployment)
- [How to Add a New Module](#how-to-add-a-new-module)
- [Setup & Development](#setup--development)
- [Deployment](#deployment)
- [Conclusion](#conclusion)

## Overview

**ModularMonolith Ticketing Example** is a modern ticketing system demonstrating how a microkernel (plugin) architecture can be used to build a modular monolith. The core API host is completely unaware of the modules that it will load; at runtime, it dynamically scans a designated **plugins** folder for DLLs and automatically registers any modules it finds. Each module is a self-contained unit with its own domain logic, data access, business services, and controllers—ensuring that concerns are fully encapsulated and deployed independently.

---

## Architecture & Key Points

### Core (ModularMonolith.Core)
- **IModule Interface:**  
  Every module implements this interface (or extends the provided base `Module` class). This interface defines methods for registering services and mapping endpoints.
- **ModuleLoader:**  
  The ModuleLoader scans the **plugins** folder for DLLs, loads them, and instantiates classes that implement `IModule`. This dynamic discovery means that the API host does not need to know in advance which modules will be available.

### Module Implementation
Each module (e.g., Ticketing, Payment) follows a standardized folder structure:
- **Domain:** Contains models, interfaces, and exceptions.
- **Data:** Includes the EF Core DbContext and repository implementations.
- **Services:** Houses business logic.
- **Extensions:** Provides helper methods for service registration.
- **Controllers:** Exposes RESTful endpoints via standard ASP.NET Core controllers.
  
Each module keeps its own concerns internally and is compiled into a separate DLL, making it deployable independently. Simply add or remove a module’s DLL from the **plugins** folder, and the core system will automatically load (or unload) its features.

### API Host (ModularMonolith.API)
- **Bootstrapping Without Prior Knowledge:**  
  The API host is completely unaware of the available modules at build time. It dynamically loads all module assemblies from the **plugins** folder by adding them as ApplicationParts, ensuring their controllers are discovered.
- **Automatic Endpoint Discovery:**  
  By dynamically adding module assemblies as ApplicationParts, the API host automatically discovers controllers from external modules. Swagger then documents all endpoints seamlessly.
- **Loose Coupling:**  
  The API host does not need to be recompiled when modules change. This decoupling allows rapid iteration and easier maintenance.

---

## Module Independence & Deployment

- **Encapsulated Concerns:**  
  Every module is responsible for its own domain logic, data access, and API endpoints. This means each module is self-contained and can be developed, tested, and deployed independently.
- **Plug-and-Play Deployment:**  
  The API host’s bootstrapping process is entirely agnostic about which modules are present. Modules are simply discovered at runtime by scanning the **plugins** folder. Add a new module DLL to enable a new feature or remove one to disable it no changes to the core system are required.
- **Independent Evolution:**  
  Modules can be upgraded or replaced individually, making the system scalable and maintainable over time.

---

## How to Add a New Module

Adding a new module to **ModularMonolith Ticketing Example** is straightforward:

1. **Create a New Class Library Project:**
   - Follow our standard folder structure:
     - **Domain** (models, interfaces, exceptions)
     - **Data** (EF Core DbContext, repositories)
     - **Services** (business logic)
     - **Extensions** (dependency injection helpers)
     - **Controllers** (API endpoints)
2. **Implement the `IModule` Interface (or Extend the Base `Module` Class):**
   - In your module’s `RegisterServices` method, register dependencies like EF Core, repositories, and services.
   - Create controllers using standard ASP.NET Core attributes (e.g., `[ApiController]`, `[Route("api/[controller]")]`) so that they are automatically discovered.
3. **Build and Deploy:**
   - Use a post-build target to copy the module’s output (DLLs, PDBs, etc.) into the **plugins** folder.
   - The API host will automatically load your new module and expose its endpoints.

---

## Setup & Development

### Prerequisites
- [.NET SDK](https://dotnet.microsoft.com/download) (the solution is version-agnostic)
- Visual Studio, Visual Studio Code, or your preferred .NET IDE

### Getting Started

1. **Clone the Repository:**

2. **Open the Solution:**

3. **Build the solution**
Module projects (e.g., Ticketing and Payment) will compile, and post-build targets will copy their output into the plugins folder.

4. **Run the API**:
Set ModularMonolith.API as the startup project.
Run the project (either Visual Studio or via CLI: dotnet run --project ModularMonolith.API).

5. **View Swagger Documentation**:
Open your browser and navigate to the swagger page to see all endpoints from the different modules API.


## Debugging
Modules are part of the solution, so you can set breakpoints and debug them just like any other project.
Rebuild the solution to update the plugins folder with your latest changes.


## Deployment
Deploying ModularMonolith Ticketing Example in production is simple:

1. **Deploy the API Host**:
  Publish your ModularMonolith.API project.

2. **Deploy the Plugins**:
  Ensure that the entire plugins folder (which contains all module DLLs and their dependencies) is deployed alongside the API host.
  Enable or disable features by adding or removing module DLLs from this folder.

3. **Configuration**:
  Use environment variables or configuration files (such as appsettings.json) to specify the PluginsFolder path in your production environment.
  Monitor and Maintain:
  Integrate logging and monitoring to track module performance and runtime behavior.

