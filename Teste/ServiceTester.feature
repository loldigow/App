Feature: Desenvolvimento e Teste de UsuarioService

Nesta funcinalidade será necessario Testar o Serviço juntamente com o Repositorio


@tag1
Scenario: Obter registros de pessoas e post, e atualizar o banco local
	Given Que obtenho "5" usuarios e "10" posts para baixar
	When Quando Sincronizar com o serviço
	Then vou ter sucesso no Sync

Scenario: Em falhas de sincronismo, deve manter o banco local com as ultimas informações
	Given Que obtenho "5" usuarios e "10" posts para baixar 
	And O processo de sync de pessoas falha
	When Quando Sincronizar com o serviço
	Then vou ter falha no sync

Scenario: Em falhas ao obter o post mas sucesso no de obter usuario, ignorar sinc
	Given Que obtenho "5" usuarios e "10" posts para baixar
	And O processo de sync de post falha
	When Quando Sincronizar com o serviço
	Then vou ter falha no sync
