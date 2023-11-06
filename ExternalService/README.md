# External Service

## Descripción

Se crea un proyecto con MVC .NET Framework 4.8 que expone una API en la ruta /date que restorna la fecha 
con el objetivo de ejemplificar una arquitectura de microservicios.

La API es consumida desde la aplicación principal para mostrar la fecha en el Layout de las vistas.

Para que el proyecto pueda ser ejecutado desde un contenedor, se debe publicar la aplicación, por ejemplo en el directorio obj/Docker y luego ajustar el Dockerfile de la siguiente forma:

```bash
FROM mcr.microsoft.com/dotnet/framework/aspnet:4.8-windowsservercore-ltsc2019
ARG source
WORKDIR /inetpub/wwwroot
COPY ./obj/Docker/ /inetpub/wwwroot
```

## Requisitos

Para crear la solución desde Windows, es necesario tener Docker Desktop instalado con contenedores Windows, no Linux.

## Ejecución

Una vez creada la imagen, podemos iniciar el contenedor desde Docker Desktop o la línea de comando.
```
PM> docker run -d --name externalservice externalservice
```
```
C:\Users\m_par>docker ps
CONTAINER ID   IMAGE                 COMMAND                   CREATED          STATUS          PORTS                  NAMES
d5fcdbe3cf6d   externalservice:dev   "C:\\ServiceMonitor.e…"   42 minutes ago   Up 16 minutes   0.0.0.0:9090->80/tcp   quirky_cori
```
Para acceder a la aplicación, ingresar a la URL http://localhost:9090/ desde cualquier navegador.