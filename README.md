# :books: Shop API

Projeto tem o objetivo gerenciar sites de lojas virtuais
[![diagrama](https://github.com/Luquini/aspnet-shop-api/blob/main/diagram.png)]

<br>

## :sparkles: Features
- CRUD de Clientes
- CRUD de Endereços
- CRUD de Vouchers 
- CRUD de Produtos
- CRUD de Pedidos (em construção)
- Pagamento Pagseguro (feito, falta integrar)
- Fila RabbitMQ (em construção)

<br>

## :wrench: Instalação
Você precisa do [ASP.NET Core](https://dotnet.microsoft.com/en-us/learn/aspnet/hello-world-tutorial/install), para compilar esse projeto.

Primeiro, clone o repository:
```bash
git clone git@github.com:Luquini/aspnet-shop-api.git
```
Entre na pasta e instale as dependências
```bash
cd aspnet-shop-api
dotnet restore
```
Após isso basta entrar na Pasta Shop.API e rodar o projeto, ele irá compilar os outros automaticamente
```bash
cd Shop.API
dotnet run
```

<br>

## :book: Documentação

Esse projeto possuí uma Documentação do Swagger na seguinte url http://localhost:5000/swagger/

<br>

## 	:microscope: Testes
Esse projeto conta com o apoio de Testes, para isso basta entrar na pasta Shop.Tests
e rodar o comando abaixo

```bash
dotnet test
```

<br>

Feito com amor por [Luquini](https://github.com/Luquini)