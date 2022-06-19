# Alura Filmes Api #

Aplicação desenvolvida durante o curso API Rest com .NET 5: operações essenciais com verbos HTTP, realizando a manipulação (CRUD) das entidades filmes, cinemas e endereço com EntityFramework Core e o Banco de Dados MySQL.

Principais tópicos abordados:

Roteamento -> "controller/action/id" <br>
Verbos HTTP -> Get, Post, Put, Delete <br>
Passagem de parametros -> [FromBody], [FromRoute], [FromQuery] <br>
Validação de entrada dos Parâmetros -> DataAnnotation [Required] <br>
Conceitos iniciais de ORM -> EntityFramework, DbContext, Add-Migration, Update-Database <br>
Gerenciador de Pacotes(Nuget) -> Microsoft.EntityFrameworkCore, <br> EntityFrameworkCore.Tools, MySql.EntityFrameworkCore <br>
AppSettings -> Configuração da String de Conexão com o Banco de Dados. <br>
Injeção de Dependência da conexão do Banco no Startup -> services.AddDbContext<DataContext>(options => options.UseMySQL(Configuration.GetConnectionString("FilmeConnection"))); <br>
Conceito de DTO -> Padronização da entrada e saída de dados.<br>
Visão Geral sobre AutoMapper -> Pacote que possibilita conversão de objetos, cópia/sobreescrita de dados dos objetos. <br>

https://www.alura.com.br/curso-online-api-rest-net-5-operacoes-verbos-http