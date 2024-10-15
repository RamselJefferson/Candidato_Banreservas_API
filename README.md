# Candidatos_Banreserva

#Descripcion 
Este proyecto esta basado en un crud Basico de Candidatos. La arquitectura del proyecto esta basada en Onion Architecture, el cual consta de varias capas; Domain, como la capa mas interna que no tiene referencia de ninguna de las otras capas(proyectos) para desacoplar de manera correta y generar una buena escalabilidad, luego le sigue la capa de Aplicacion que esta consta de los casos de uso  la misma tiene acceso a la capa Domain pero no hacia afuera, Por otro lado tenemos la capa Infraestructure que contiene mi acceso a datos la misma tiene acceso a los casos de usos(capa de aplicacion) y domain, por otro lado tenemos la capa mas externa que es la capa presentation esta es la capa de usuario. Esta arquitectura asegura que cada capa tenga una responsabilidad unica siguiendo asi los principios SOLID.

El proyecto de igual forma contiene un middleware para guardar un log de los request, en la db tenemos un procedure que se encarga de modelar los datos para saber cuantas peticiones por min se realizan a los diferentes endpoint y cuantas peticiones se han realizado al mismo, de igual forma podemos filtrar por rango de fecha.

Principales patrones de diseño y librerias  del proyecto:
Decorator,
Pattern Repository,
AutoMaper,
Dependency Injection
ApiVersioning
ADO.Net



#Manual de instalicion

## 1. Ejecutar el siguiente script de creación de la base de datos:

```sql
USE [master];
GO
CREATE DATABASE [Candidato_Banreservas];
GO

USE [Candidato_Banreservas];
GO

SET ANSI_NULLS ON;
GO
SET QUOTED_IDENTIFIER ON;
GO

-- Crear tabla ApiRequestLog
CREATE TABLE [dbo].[ApiRequestLog] (
    [Id] [int] IDENTITY(1,1) NOT NULL,
    [Endpoint] varchar NOT NULL,
    [HttpMethod] varchar NOT NULL,
    [RequestTime] [datetime] NOT NULL,
    [ResponseTime] [float] NOT NULL,
    [Result] [int] NOT NULL,
    CONSTRAINT [PK__ApiReque__3214EC074E240E0A] PRIMARY KEY CLUSTERED (
        [Id] ASC
    ) WITH (
        PAD_INDEX = OFF,
        STATISTICS_NORECOMPUTE = OFF,
        IGNORE_DUP_KEY = OFF,
        ALLOW_ROW_LOCKS = ON,
        ALLOW_PAGE_LOCKS = ON,
        OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF
    ) ON [PRIMARY]
) ON [PRIMARY];
GO

-- Crear tabla Candidatos
CREATE TABLE [dbo].[Candidatos] (
    [Id] [int] IDENTITY(1,1) NOT NULL,
    [Nombres] varchar NULL,
    [Apellidos] varchar NULL,
    [CorreoElectronico] varchar NULL,
    [Telefono] varchar NULL,
    [FechaNacimiento] [datetime] NULL,
    [PuestoAplicado] varchar NULL,
    [FechaAplicacionPuesto] [datetime] NULL
) ON [PRIMARY];
GO

-- Procedimiento almacenado para ReporteApiRequest
SET ANSI_NULLS ON;
GO
SET QUOTED_IDENTIFIER ON;
GO

CREATE PROCEDURE [dbo].[ReporteApiRequest]
    @FECHAINICIO DATETIME = NULL,
    @FECHAFINAL DATETIME = NULL
AS
BEGIN
    SELECT
        EndPoint,
        COUNT(EndPoint) AS CantidadPeticion,
        HttpMethod,
        AVG(CAST(ResponseTime AS int)) AS PromedioRespuestaMs,
        CAST(Result AS int) AS Result,
        CAST(COUNT(FORMAT(RequestTime, 'yyyy-MM-dd HH:mm')) AS int) AS TransaccionesPorMinuto
    FROM [dbo].[ApiRequestLog]
    WHERE (FORMAT(@FECHAINICIO, 'yyyy-MM-dd') IS NULL OR FORMAT(RequestTime, 'yyyy-MM-dd') >= FORMAT(@FECHAINICIO, 'yyyy-MM-dd'))
      AND (FORMAT(@FECHAFINAL, 'yyyy-MM-dd') IS NULL OR FORMAT(RequestTime, 'yyyy-MM-dd') <= FORMAT(@FECHAFINAL, 'yyyy-MM-dd'))
    GROUP BY EndPoint, Result, HttpMethod;
END;
GO


2.ejecutar en git bash el siguiente comando: git clone "https://github.com/RamselJefferson/Candidatos_Banreserva.git"



