# DionicioAstoWebAPI
Descripción del Proyecto

Este proyecto es una aplicación REST API desarrollada en .NET Core 7.0 que sigue el patrón de arquitectura CQRS (Command Query Responsibility Segregation) junto con el patrón Mediator para gestionar los comandos y consultas. La aplicación sigue una estructura modular y utiliza la inyección de dependencias para mantener un acoplamiento bajo entre los diferentes componentes.

Estructura del Proyecto

PruebaUPC.Application: Contiene los comandos y consultas de la aplicación. Products/Commands: Contiene los comandos relacionados con la entidad "Product". Products/Queries: Contiene las consultas relacionadas con la entidad "Product". DependencyInjection.cs: Configuración de la inyección de dependencias para la capa de aplicación. PruebaUPC.Domain: Define la entidad principal del dominio, en este caso, la clase Product. PruebaUPC.Infrastructure: Proporciona la implementación de la capa de infraestructura, incluyendo el repositorio y la configuración de la inyección de dependencias. PruebaUPC.WebApi: La capa de la interfaz de usuario (API) que expone los endpoints para realizar operaciones CRUD en los productos. Controllers: Contiene los controladores de la API, como ProductController y StatusController. Models/Requests: Define los modelos de solicitud utilizados en las peticiones HTTP. Models/Responses: Define los modelos de respuesta utilizados en las respuestas HTTP. appsettings.json: Configuración de la aplicación. Program.cs: Punto de entrada de la aplicación. PruebaUPC.Test: Contiene pruebas unitarias para algunos aspectos de la aplicación.

Patrones y Tecnologías Utilizadas

CQRS (Command Query Responsibility Segregation): Divide las operaciones de lectura y escritura en comandos y consultas, permitiendo una escalabilidad y mantenimiento más sencillos. Mediator Pattern: Utilizado para la gestión de comandos y consultas de manera desacoplada. Inyección de Dependencias: Utilizado para proporcionar una forma flexible y desacoplada de gestionar las dependencias entre los componentes de la aplicación.

Levantar el Proyecto Localmente

Tener instalado .NET Core 7.0 y un entorno de desarrollo compatible.

Dar click en Code/Download ZIP. El archivo se va a descargar en la carpeta de Descargas "C:\Users\mdionici\Downloads\DionicioAstoWebAPI-main.zip" el cual debe ser descomprimido. Luego de haber descromprimido el archivo ir a la ruta "C:\Users\mdionici\Downloads\DionicioAstoWebAPI-main\DionicioAstoWebAPI-main" el cual se encuentra la solucion donde se encontrara los archivos de la solucion, se debe ejeutar el archivo "PruebaUPC.sln" en visual studio 2022.

Información Adicional

Pruebas Unitarias: Se han incluido pruebas unitarias en el proyecto PruebaUPC.Test utilizando el framework NUnit y la biblioteca Moq para realizar mock de dependencias. Logging: La aplicación utiliza un sistema de registro (logging) que almacena los registros en archivos, ubicados en el directorio de la aplicación. Caché: Se ha implementado un ejemplo de caché utilizando la biblioteca MemoryCache para almacenar temporalmente los estados de la aplicación en el controlador StatusController. la ruta del archivo LOGS se encuentra en PruebaUPC.WebApi\bin\Debug\net7.0\Logs
