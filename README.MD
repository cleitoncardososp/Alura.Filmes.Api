# Alura Filmes Api #

Aplica��o desenvolvida durante o curso API Rest com .NET 5: opera��es essenciais com verbos HTTP, realizando a manipula��o (CRUD) das entidades filmes, cinemas e endere�o com EntityFramework Core e o Banco de Dados MySQL.

Principais t�picos abordados:

Roteamento -> "controller/action/id" <br>
Verbos HTTP -> Get, Post, Put, Delete <br>
Passagem de parametros -> [FromBody], [FromRoute], [FromQuery] <br>
Valida��o de entrada dos Par�metros -> DataAnnotation [Required] <br>
Conceitos iniciais de ORM -> EntityFramework, DbContext, Add-Migration, Update-Database <br>
Gerenciador de Pacotes(Nuget) -> Microsoft.EntityFrameworkCore, <br> EntityFrameworkCore.Tools, MySql.EntityFrameworkCore <br>
AppSettings -> Configura��o da String de Conex�o com o Banco de Dados. <br>
Inje��o de Depend�ncia da conex�o do Banco no Startup -> services.AddDbContext<DataContext>(options => options.UseMySQL(Configuration.GetConnectionString("FilmeConnection"))); <br>
Conceito de DTO -> Padroniza��o da entrada e sa�da de dados.<br>
Vis�o Geral sobre AutoMapper -> Pacote que possibilita convers�o de objetos, c�pia/sobreescrita de dados dos objetos. <br>

https://www.alura.com.br/curso-online-api-rest-net-5-operacoes-verbos-http