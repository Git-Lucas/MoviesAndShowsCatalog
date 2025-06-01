# MoviesAndShowsCatalog
<table>
<tr>
<td>
  O projeto se refere ao desenho e implementação do back-end de uma aplicação de catálogos de filmes e séries baseada em microsserviços, que provê APIs	de cada microsserviço para gerenciamento dos dados (documentado utilizando o Swagger). Tecnologias utilizadas: C#, .NET 8, ASP.NET API, Authentication Jwt Bearer, Entity Framework, SQL Server, PostgreSQL, MySql, Docker, Clean Architecture, Hexagonal Architecture.
</td>
</tr>
</table>


## Getting Started
1. Para criar e iniciar os contêiners necessários à aplicação, na raiz da aplicação (local onde o 'docker-compose.yml' está localizado), rode:
   ```bash
   docker-compose up
   ```
![](https://github.com/Git-Lucas/MoviesAndShowsCatalog/blob/develop/imgs/docker-compose.png)
![](https://github.com/Git-Lucas/MoviesAndShowsCatalog/blob/develop/imgs/docker-compose1.png)
2. Acesse o microsserviço de 'User' em "http://localhost:8080/swagger";

3. Acesse o microsserviço de 'MovieAndShow' em "http://localhost:8081/swagger";

4. Acesse o microsserviço de 'RatingAndReview' em "http://localhost:8082/swagger";

5. O primeiro microsserviço que deve ser acessado é o de 'User', que possui os seguintes usuários iniciais para teste:
	- Username: "administrador"; Password: "000"; Role: "Administrator";
	- Username: "lucas"; Password: "111"; Role: "Commom";
	- Username: "joão"; Password: "222"; Role: "Commom";
	- Username: "maria"; Password: "333"; Role: "Commom";
	- Username: "carlos"; Password: "444"; Role: "Commom";
	![](https://github.com/Git-Lucas/MoviesAndShowsCatalog/blob/develop/imgs/Token.png)
	![](https://github.com/Git-Lucas/MoviesAndShowsCatalog/blob/develop/imgs/Token1.png)


# Aplicação
## Microsserviço de gerenciamento de usuários
Aplicação (com banco de dados MySql) responsável por expor os seguintes casos de uso:
- Registro de usuário; 
- Autenticação e autorização;
- Definir e visualizar os gêneros favoritos. Ex.: 'Action', 'Comedy', 'Drama', etc. (Os usuários iniciais 'Commom' informados acima, já possuem uma primeira definição de gêneros favoritos);
- Visualizar as notificações recebidas (a cada filme ou série, com o gênero marcado como favorito, o usuário recebe uma notificação);

Para usuários administradores, existem os seguintes casos de uso:
- Cadastrar um novo usuário (aqui seria possível criar um novo usuário administrador);
- Visualizar todos os usuários cadastrados no banco de dados;
- Editar um usuário;
- Excluir um usuário;

![](https://github.com/Git-Lucas/MoviesAndShowsCatalog/blob/develop/imgs/User.png)

## Microsserviço de filmes e séries
Aplicação (com banco de dados SQL Server) responsável por expor os seguintes casos de uso:
- Visualizar os gêneros suportados pela aplicação (com o objetivo de facilitar o entendimento de qual gênero o código retornado nas respostas dos endpoints se refere);
- Cadastrar um novo filme ou série (nesta ação, as outras 2 aplicações são notificadas para suas devidas ações correspondentes: a aplicação de 'User' envia notificação para os usuários interessados no gênero que existe novidade na plataforma; e a aplicação de 'RatingAndReview', cadastra este filme ou série em seu banco de dados, a fim de garantir autossuficiência de dados para cada aplicação);
- Visualizar os filmes ou séries cadastrados no banco de dados (consulta paginada);
![](https://github.com/Git-Lucas/MoviesAndShowsCatalog/blob/develop/imgs/MovieAndShowPaginated.png)
- Visualizar um filme ou série específico;
- Excluir um filme ou série específico (esta ação também dispara uma mensagem no RabbitMQ para que este filme ou série também seja excluído no banco de dados de 'RatingAndReview');

![](https://github.com/Git-Lucas/MoviesAndShowsCatalog/blob/develop/imgs/MovieAndShow.png)

## Microsserviço de classificações e comentários
Aplicação (com banco de dados Postgre) responsável por expor os seguintes casos de uso:
- Classificar e comentar um filme ou série visto (classificação de 1 a 5);
- Visualizar todas as classificações e comentários de um determinado filme (esta ação retorna também a média de avaliações do filme ou série);
![](https://github.com/Git-Lucas/MoviesAndShowsCatalog/blob/develop/imgs/RatingsAndReviewsByVisualProduction.png)
- Visualizar as classificações e comentários do melhor e pior classificado filme ou série;
- Visualizar todos os filmes ou séries cadastrados no banco de dados (recupera os filmes ou séries do banco de dados próprio - se a aplicação de filmes ou séries estiver indisponível, continua sendo possível acessar todas as funcionalidades de 'RatingAndReview');

![](https://github.com/Git-Lucas/MoviesAndShowsCatalog/blob/develop/imgs/RatingAndReview.png)

## RabbitMQ
A comunicação entre os microsserviços é realizada de forma assíncrona, pelo servidor de mensageria 'RabbitMQ'.

![](https://github.com/Git-Lucas/MoviesAndShowsCatalog/blob/develop/imgs/RabbitMQ.png)

## Segurança

Camadas de segurança implementadas:

- **Autenticação e autorização via token Bearer**  
  A autenticação é baseada em JWT (JSON Web Token), gerado pelo microsserviço `User`, e validado em cada requisição protegida.

- **Hashing seguro de senhas**  
  Senhas são armazenadas no banco de dados usando o algoritmo de hashing com salt via `PasswordHasher<TUser>` do ASP.NET Core Identity, protegendo contra ataques de vazamento de credenciais.

- **Rate limiting por IP**  
  A rota de login (`SignIn`) possui limitação de requisições (Rate Limiting) configurada para evitar ataques de força bruta. Um IP pode tentar no máximo 5 logins por minuto, retornando erro `429 Too Many Requests` após o limite.

- **Tratamento de logs com proteção de dados sensíveis**  
  Logs foram configurados para incluir o IP do solicitante e o motivo da falha na rota de autenticação, sem expor senhas, tokens ou detalhes técnicos.