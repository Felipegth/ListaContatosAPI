## Lista de Contatos em WebAPI

Projeto modelo de estudo de aplicação e conceitos em WebAPI.

Projeto usando uma classe estática para armazenamento dos dados em memória.

## Prerequisites

* .NET 5.0
* Visual Studio Community 2019

## technologies

Swagger, Postman, WebAPI, Docker e Heroku.

## Create project

```shell
mkdir ./src
touch README.md
git init
dotnet new gitignore
```
```shell
cd src
dotnet new console -o ListaContatosWebAPI

## Build

```shell
dotnet run --project src\Desenvolvimento\Estudo\ListaContatos\ListaContatos.csproj
```
## Autor
Felipe Rodrigues, trabalhando para empresa "Talk and Live" atualmente trabalho com desenvolvimento de sistemas Web e Mobile, frontend e backend, meu foco principal é .NET Core usando C #, para estudos futuros irei trabalhar com Xamarim.

## References

https://www.docker.com

https://hub.docker.com/editions/community/docker-ce-desktop-windows/

https://www.heroku.com

https://docs.microsoft.com/pt-br/dotnet/architecture/containerized-lifecycle/design-develop-containerized-apps/visual-studio-tools-for-docker

https://restfulapi.net/http-status-codes/

https://restfulapi.net/resource-naming/

https://medium.com/@renatoluizcarvalho/realizando-deploy-net-core-2-2-no-heroku-registry-5f34cbb50b07

https://docs.microsoft.com/pt-br/aspnet/core/web-api/action-return-types?view=aspnetcore-5.0#actionresultt-type

https://www.treinaweb.com.br/blog/publicando-uma-aplicacao-asp-net-core-no-heroku/#:~:text=Publicando%20a%20aplica%C3%A7%C3%A3o%20no%20Heroku,herokuapp.com%20

http://www.macoratti.net/17/04/aspcore_webapi1.htm

https://stackoverflow.com/questions/37604183/how-do-i-persist-data-in-memory-with-net-rest-api

https://docs.microsoft.com/pt-br/dotnet/csharp/programming-guide/classes-and-structs/static-classes-and-static-class-members
