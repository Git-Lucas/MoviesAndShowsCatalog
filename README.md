# MoviesAndShowsCatalog
<table>
<tr>
<td>
  O projeto se refere ao desenho e implementa��o do back-end de uma aplica��o de cat�logos de filmes e s�ries baseada em microsservi�os, que prov� APIs	de cada microsservi�o para gerenciamento dos dados (documentado utilizando o Swagger). Tecnologias utilizadas: C#, .NET 8, ASP.NET API, Authentication Jwt Bearer, Entity Framework, SQL Server, PostgreSQL, MySql, Docker, Clean Architecture, Hexagonal Architecture.
</td>
</tr>
</table>


## Getting Started
1. Para criar e iniciar os cont�iners necess�rios � aplica��o, na raiz da aplica��o (local onde o 'docker-compose.yml' est� localizado), rode:
   ```bash
   docker-compose up
   ```
![](https://github.com/Git-Lucas/MoviesAndShowsCatalog/blob/develop/imgs/docker-compose.png)
![](https://github.com/Git-Lucas/MoviesAndShowsCatalog/blob/develop/imgs/docker-compose1.png)
2. Acesse o microsservi�o de 'User' em "http://localhost:8080/swagger";

3. Acesse o microsservi�o de 'MovieAndShow' em "http://localhost:8081/swagger";

4. Acesse o microsservi�o de 'RatingAndReview' em "http://localhost:8082/swagger";

5. O primeiro microsservi�o que deve ser acessado � o de 'User', que possui os seguintes usu�rios iniciais para teste:
	- Username: "administrador"; Password: "000"; Role: "Administrator";
	- Username: "lucas"; Password: "111"; Role: "Commom";
	- Username: "jo�o"; Password: "222"; Role: "Commom";
	- Username: "maria"; Password: "333"; Role: "Commom";
	- Username: "carlos"; Password: "444"; Role: "Commom";
	![](https://github.com/Git-Lucas/MoviesAndShowsCatalog/blob/develop/imgs/Token.png)
	![](https://github.com/Git-Lucas/MoviesAndShowsCatalog/blob/develop/imgs/Token1.png)


# Aplica��o
## Microsservi�o de gerenciamento de usu�rios
Aplica��o (com banco de dados MySql) respons�vel por expor os seguintes casos de uso:
- Registro de usu�rio; 
- Autentica��o e autoriza��o;
- Definir e visualizar os g�neros favoritos. Ex.: 'Action', 'Comedy', 'Drama', etc. (Os usu�rios iniciais 'Commom' informados acima, j� possuem uma primeira defini��o de g�neros favoritos);
- Visualizar as notifica��es recebidas (a cada filme ou s�rie, com o g�nero marcado como favorito, o usu�rio recebe uma notifica��o);

Para usu�rios administradores, existem os seguintes casos de uso:
- Cadastrar um novo usu�rio (aqui seria poss�vel criar um novo usu�rio administrador);
- Visualizar todos os usu�rios cadastrados no banco de dados;
- Editar um usu�rio;
- Excluir um usu�rio;

![](https://github.com/Git-Lucas/MoviesAndShowsCatalog/blob/develop/imgs/User.png)

## Microsservi�o de filmes e s�ries
Aplica��o (com banco de dados SQL Server) respons�vel por expor os seguintes casos de uso:
- Visualizar os g�neros suportados pela aplica��o (com o objetivo de facilitar o entendimento de qual g�nero o c�digo retornado nas respostas dos endpoints se refere);
- Cadastrar um novo filme ou s�rie (nesta a��o, as outras 2 aplica��es s�o notificadas para suas devidas a��es correspondentes: a aplica��o de 'User' envia notifica��o para os usu�rios interessados no g�nero que existe novidade na plataforma; e a aplica��o de 'RatingAndReview', cadastra este filme ou s�rie em seu banco de dados, a fim de garantir autossufici�ncia de dados para cada aplica��o);
- Visualizar os filmes ou s�ries cadastrados no banco de dados (consulta paginada);
![](https://github.com/Git-Lucas/MoviesAndShowsCatalog/blob/develop/imgs/MovieAndShowPaginated.png)
- Visualizar um filme ou s�rie espec�fico;
- Excluir um filme ou s�rie espec�fico (esta a��o tamb�m dispara uma mensagem no RabbitMQ para que este filme ou s�rie tamb�m seja exclu�do no banco de dados de 'RatingAndReview');

![](https://github.com/Git-Lucas/MoviesAndShowsCatalog/blob/develop/imgs/MovieAndShow.png)

## Microsservi�o de classifica��es e coment�rios
Aplica��o (com banco de dados Postgre) respons�vel por expor os seguintes casos de uso:
- Classificar e comentar um filme ou s�rie visto (classifica��o de 1 a 5);
- Visualizar todas as classifica��es e coment�rios de um determinado filme (esta a��o retorna tamb�m a m�dia de avalia��es do filme ou s�rie);
![](https://github.com/Git-Lucas/MoviesAndShowsCatalog/blob/develop/imgs/RatingsAndReviewsByVisualProduction.png)
- Visualizar as classifica��es e coment�rios do melhor e pior classificado filme ou s�rie;
- Visualizar todos os filmes ou s�ries cadastrados no banco de dados (recupera os filmes ou s�ries do banco de dados pr�prio - se a aplica��o de filmes ou s�ries estiver indispon�vel, continua sendo poss�vel acessar todas as funcionalidades de 'RatingAndReview');

![](https://github.com/Git-Lucas/MoviesAndShowsCatalog/blob/develop/imgs/RatingAndReview.png)

## RabbitMQ
A comunica��o entre os microsservi�os � realizada de forma ass�ncrona, pelo servidor de mensageria 'RabbitMQ'.

![](https://github.com/Git-Lucas/MoviesAndShowsCatalog/blob/develop/imgs/RabbitMQ.png)

## Seguran�a

Camadas de seguran�a implementadas:

- **Autentica��o e autoriza��o via token Bearer**  
  A autentica��o � baseada em JWT (JSON Web Token), gerado pelo microsservi�o `User`, e validado em cada requisi��o protegida.

- **Hashing seguro de senhas**  
  Senhas s�o armazenadas no banco de dados usando o algoritmo de hashing com salt via `PasswordHasher<TUser>` do ASP.NET Core Identity, protegendo contra ataques de vazamento de credenciais.

- **Rate limiting por IP**  
  A rota de login (`SignIn`) possui limita��o de requisi��es (Rate Limiting) configurada para evitar ataques de for�a bruta. Um IP pode tentar no m�ximo 5 logins por minuto, retornando erro `429 Too Many Requests` ap�s o limite.

- **Tratamento de logs com prote��o de dados sens�veis**  
  Logs foram configurados para incluir o IP do solicitante e o motivo da falha na rota de autentica��o, sem expor senhas, tokens ou detalhes t�cnicos.