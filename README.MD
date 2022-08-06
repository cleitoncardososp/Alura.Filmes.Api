# Alura Filmes Api #

Aplicação desenvolvida durante a Formação .NET Core REST APIs, realizando a manipulação (CRUD) das entidades filme, cinema, endereço, gerente e sessão com EntityFramework Core, Banco de Dados MySQL e controle de usuário com Microsoft Identity.

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
Refatoração de código, encapsulando lógica de negócio em classes de serviço.
Utilização do FluentResult, pacote que padroniza o retorno de métodos.
Utilização do Identity para Gerenciamento, Validação e Ativação das contas de usuários.
Utilização dos Pacotes MailKit e MimeKit para criação/envio de e-mail por SMTP.

https://cursos.alura.com.br/formacao-dotnet

