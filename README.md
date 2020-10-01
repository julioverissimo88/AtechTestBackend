# AtechTestBackend

Para rodar o projeto é necessário possuir dotnetcore 3.1, dotnetcore cli


1 - Clonar repositório
`https://github.com/julioverissimo88/AtechTestBackend.git`

Uso Docker
2 - Baixar/Rodar Container para Sql Server
`$ docker run -e 'ACCEPT_EULA=Y' -e 'SA_PASSWORD=jcvatechPW2020!' -p 1401:1433 -d --name=juliodb microsoft/mssql-server-linux:2017-latest`

3 - Abrir a pasta do projeto e restaurar os pacotes pelo prompt de comando
`$ dotnet restore`

4 - Rodar Migrações para criação do Banco
`$ update-database`

5 - Run!!
`dotnet run --project AtechTestBackend`

ou 

`De o Play via Visual Studio`

**Documentação Swagger**

https://localhost:44305/swagger/index.html *(A porta da Url pode variar de acordo com a disponibilidade de portas de sua maquina)

![](https://i.ibb.co/Rhkj6Sw/image.png)

**Cadastro**
curl -X POST "https://localhost:44305/api/Pessoa" -H  "accept: */*" -H  "Content-Type: application/json" -d "{\"id\":0,\"nome\":\"string\",\"estadoCivil\":\"string\",\"dataNascimento\":\"2020-10-01T17:47:29.103Z\",\"nomeParceiro\":\"string\",\"dataNascimentoParceiro\":\"string\"}"
![](https://i.ibb.co/KmJqYvf/image.png)


**Listagem**
curl -X GET "https://localhost:44305/api/Pessoa?pageIndex=1&pageSize=10" -H  "accept: */*"

![](https://i.ibb.co/4dTKfK2/image.png)

**Deletar**
curl -X DELETE "https://localhost:44305/api/Pessoa/1" -H  "accept: */*"

![](https://i.ibb.co/vkYhf4w/image.png)

**Pacotes utilizados**

- EntityFrameworkCore (ORM)
- Automapper (Mapeamento automático de entidades)
- Swagger (Documentação da API)
- FluentValidation (Validação de Entidades da API)
