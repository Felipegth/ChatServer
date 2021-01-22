﻿# ChatServer

Projeto modelo de estudo de aplicação de conceitos SignalR em .NET.
## Prerequisites

* .NET 5.0
* Visual Studio Community 2019

## Create project

```shell
mkdir ./src
touch README.md
git init
dotnet new gitignore
```

```shell
cd src
dotnet new console -o ChatServer
```

## Build

```shell
dotnet run --project src\ChatServer\ChatServer.csproj
```

## References

https://docs.microsoft.com/pt-br/aspnet/core/tutorials/signalr?view=aspnetcore-5.0&tabs=visual-studio
