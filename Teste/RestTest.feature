Feature: RestTest

Testando a funcionalidade Rest

@tag1
Scenario: Obtendo Lista de usuarios
	Given Dado que tenho uma URL "https://jsonplaceholder.typicode.com/users"
	And Tenho o Tipo "Pessoa"
	When Quando fizer o Get
	Then vou ter resposta
	Then não vou ter erros
	Then Vou obter Status code "200"

	Scenario: Obtendo uma lista de posts
	Given Dado que tenho uma URL "https://jsonplaceholder.typicode.com/posts"
	And Tenho o Tipo "post"
	When Quando fizer o Get
	Then vou ter resposta
	Then não vou ter erros
	Then Vou obter Status code "200"

	Scenario: Tentar obter algo com a URl Vazia
	Given Dado que tenho uma URL ""
	And Tenho o Tipo "Pessoa"
	When Quando fizer o Get
	Then não vou ter resposta
	Then vou ter erro
	Then Vou obter Status code "0"

	Scenario: problema de Host unknow
	Given Dado que tenho uma URL "https://jsonzplaceholder.typicode.com/postss/"
	And Tenho o Tipo "Pessoa"
	When Quando fizer o Get
	Then não vou ter resposta
	Then vou ter erro
	Then Vou obter Status code "0"
