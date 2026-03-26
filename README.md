<div align="center">

# ⚽ Liga BetPlay — Simulador en C#

**Simulador de la Liga BetPlay colombiana como aplicación de consola en C#.**  
Gestiona equipos, genera un calendario todos contra todos y simula jornadas con tabla de posiciones en tiempo real.

[](https://dotnet.microsoft.com/)
[](https://learn.microsoft.com/en-us/dotnet/csharp/)
[](LICENSE)
[]()

</div>

---

## 📋 Tabla de contenido

- [Descripción](#-descripción)
- [Características](#-características)
- [Estructura del proyecto](#-estructura-del-proyecto)
- [Requisitos previos](#-requisitos-previos)
- [Instalación y ejecución](#-instalación-y-ejecución)
- [Flujo de uso](#-flujo-de-uso)
- [Roadmap V2](#-roadmap-v2)
- [Contribuir](#-contribuir)
- [Autores](#-autores)

---

## 📖 Descripción

**Liga BetPlay Simulator** es una aplicación de consola escrita en C# que replica el funcionamiento de un torneo de fútbol local tipo *todos contra todos*. Permite registrar equipos, generar el calendario de partidos, simular jornadas y consultar la tabla de posiciones con estadísticas completas.

El proyecto sigue una arquitectura en capas que separa la lógica de negocio (`Core`) de la presentación (`Modules`), facilitando la escalabilidad y el mantenimiento del código.

---

## ✨ Características

| Característica | Descripción |
| --- | --- |
| 🗓️ **Calendario round-robin** | Generación automática del fixture todos contra todos |
| 🎲 **Simulación de partidos** | Resultados aleatorios con goles, puntos y diferencia de gol |
| 📊 **Tabla de posiciones** | Clasificación en tiempo real con PJ, PG, PE, PP, GF, GC y DG |
| 🧩 **Arquitectura en capas** | Separación clara entre dominio, servicios y presentación |
| 🖥️ **Menú interactivo** | Navegación fluida por todas las funcionalidades desde consola |
| 💻 **Multiplataforma** | Compatible con Windows, Linux y macOS vía .NET SDK |

---

## 📁 Estructura del proyecto

```
ligaBetplay_C-/
├── .vscode/                  # Configuración recomendada para VS Code
├── Core/                     # Lógica de negocio y modelos de dominio
│   ├── Entities/             # Clases: Equipo, Partido, Jornada, Tabla, etc.
│   ├── Services/             # Servicios: calendario, simulación, estadísticas
│   └── Utils/                # Utilidades: random, validaciones, helpers
├── Modules/                  # Capa de presentación y orquestación
│   ├── Menu/                 # Menú principal y submenús
│   ├── Views/                # Impresión de tablas, resultados y reportes
│   └── Handlers/             # Manejadores de las opciones del menú
├── Program.cs                # Punto de entrada de la aplicación
├── ligabetplay.csproj        # Archivo de proyecto C#
└── ligabetplay.sln           # Solución para Visual Studio
```

---

## 🛠️ Requisitos previos

Antes de compilar o ejecutar el proyecto, asegúrate de tener instalado:

- [**.NET SDK 8.0 o superior**](https://dotnet.microsoft.com/download) *(recomendado)*
- Un IDE o editor compatible:
  - [Visual Studio 2022](https://visualstudio.microsoft.com/) con workload de `.NET Desktop`
  - [Visual Studio Code](https://code.visualstudio.com/) con la extensión [C# Dev Kit](https://marketplace.visualstudio.com/items?itemName=ms-dotnettools.csdevkit)

Verifica tu instalación con:

```bash
dotnet --version
```

---

## 🚀 Instalación y ejecución

### 1. Clonar el repositorio

```bash
git clone https://github.com/Tomfmp2/ligaBetplay_C-.git
cd ligaBetplay_C-
git checkout develop
```

### 2. Ejecutar la aplicación

---

#### 🪟 Windows

**Opción A — Terminal (PowerShell o CMD)**

```powershell
dotnet restore
dotnet build
dotnet run
```

**Opción B — Visual Studio 2022**

1. Abrir Visual Studio 2022
2. Ir a *File → Open → Project/Solution...* y seleccionar `ligabetplay.sln`
3. Esperar a que se restauren las dependencias
4. Verificar que el proyecto de inicio sea `ligabetplay`
5. Ejecutar con `F5` (con depuración) o `Ctrl + F5` (sin depuración)

**Opción C — VS Code**

1. Abrir la carpeta del proyecto con *File → Open Folder*
2. Asegurarse de tener instalada la extensión [C# Dev Kit](https://marketplace.visualstudio.com/items?itemName=ms-dotnettools.csdevkit)
3. Abrir la terminal integrada con `` Ctrl+` `` y ejecutar:

```powershell
dotnet run
```

---

#### 🐧 Linux

1. Instalar el .NET SDK para tu distribución desde la [web oficial de .NET](https://dotnet.microsoft.com/download)
  
  *Ejemplo en Ubuntu/Debian:*
  
  ```bash
  sudo apt-get update
  sudo apt-get install -y dotnet-sdk-8.0
  ```
  
2. Verificar la instalación:
  
  ```bash
  dotnet --version
  ```
  
3. Compilar y ejecutar:
  
  ```bash
  cd ligaBetplay_C-
  git checkout develop
  dotnet restore
  dotnet build
  dotnet run
  ```
  

> **Nota:** Toda la interacción es por consola, por lo que no se requiere entorno gráfico. Funciona perfectamente en servidores o terminales SSH.

---

#### 🍎 macOS

1. Instalar el .NET SDK para macOS (compatible con chips Intel x64 y Apple Silicon ARM) desde la [web oficial de .NET](https://dotnet.microsoft.com/download)
  
  *Alternativa con Homebrew:*
  
  ```bash
  brew install --cask dotnet-sdk
  ```
  
2. Verificar la instalación:
  
  ```bash
  dotnet --version
  ```
  
3. Abrir la app **Terminal** y ejecutar:
  
  ```bash
  cd ligaBetplay_C-
  git checkout develop
  dotnet restore
  dotnet build
  dotnet run
  ```
  

> **Nota Apple Silicon (M1/M2/M3):** Asegúrate de descargar el instalador para arquitectura **ARM64** para obtener el mejor rendimiento.

---

## 🎮 Flujo de uso

```
1. Iniciar la aplicación
        ↓
2. Registrar equipos participantes
        ↓
3. Generar el calendario (todos contra todos)
        ↓
4. Simular jornadas (una a una o en bloque)
        ↓
5. Consultar tabla de posiciones y estadísticas
        ↓
6. Reiniciar o continuar la liga
```

---

## 🗺️ Roadmap V2

Las siguientes funcionalidades están planificadas para próximas versiones:

- [ ] **Gestión avanzada de equipos** — Alta, baja y edición de equipos con plantillas de jugadores y estadísticas individuales
- [ ] **Persistencia de datos** — Guardar y cargar temporadas en JSON / XML / SQLite; historial de campeones
- [ ] **Simulación mejorada** — Parámetros de fuerza por equipo; simulación evento a evento (goles, tarjetas, cambios)
- [ ] **UI enriquecida** — Colores ANSI en consola, tablas más legibles, modo auto-simulación de toda la temporada
- [ ] **Estadísticas avanzadas** — Máximos goleadores, mejor defensa/ataque, rachas, exportación a CSV
- [ ] **Testing y CI/CD** — Tests unitarios para `Core` y workflow de GitHub Actions en cada push

---

## 👥 Autores

| Nombre | GitHub |
| --- | --- |
| Tomas Felipe Medina Prada | [@Tomfmp2](https://github.com/Tomfmp2) |
| Jhon Alejandro Escobar Lozada | [@melokaso1](https://github.com/melokaso1) |

---
