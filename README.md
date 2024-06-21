<H1>Desafio.AeC</H1>
<blockquote>Status: Concluído</blockquote> 

## Descrição do Projeto ##
### Este projeto consiste em uma aplicação web em ASP.NET que oferece aos usuários a capacidade de realizar login e gerenciar um CRUD de endereços. A aplicação possui as seguintes funcionalidades: ###

* Autenticação de Usuário: Permite que os usuários realizem cadastro e login para acessar suas informações e gerenciar seus endereços de forma segura.
* Gestão de Endereços: Os usuários podem adicionar, editar, visualizar e excluir endereços em sua conta.
* Busca Automática de Endereço pelo CEP: Os usuários têm a opção de inserir o endereço manualmente ou informar um CEP para que a aplicação busque os dados do endereço automaticamente através da integração com a API do ViaCEP (https://viacep.com.br/).
* Exportação de Endereços: Os usuários podem exportar seus endereços salvos para um arquivo CSV, facilitando o backup e o compartilhamento de informações.

## Pré-requisitos
- [.NET 8.0](https://dotnet.microsoft.com/pt-br/download/dotnet/8.0)
- [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads)

## Bibliotecas Utilizadas
Biblioteca   | Funcionalidade
--------- | ------
AutoMapper | AutoMapper é uma biblioteca de mapeamento de objetos que ajuda a transformar dados entre objetos de diferentes tipos. É especialmente útil para converter ViewModels em entidades de domínio e vice-versa, reduzindo a quantidade de código de mapeamento manual necessário.
EntityFramework Core | EntityFramework Core (EF Core) é um ORM (Object-Relational Mapper) que permite aos desenvolvedores trabalhar com um banco de dados usando objetos .NET. EF Core facilita a criação, leitura, atualização e exclusão de dados no banco de dados de maneira eficiente e intuitiva, suportando várias bases de dados como SQL Server, MySQL, SQLite, entre outras.
FluentValidation | FluentValidation é uma biblioteca para validação de objetos em .NET. Ela permite definir regras de validação de forma fluente e expressiva, facilitando a validação de dados em ViewModels e entidades de domínio. Suas regras de validação são configuráveis e reutilizáveis.
toastr | toastr é uma biblioteca de notificações JavaScript que permite exibir mensagens de feedback ao usuário de forma elegante e não intrusiva. É útil para mostrar notificações de sucesso, erro, aviso ou informação diretamente na interface do usuário.

## Instalação
1. Clone o repositório: [DesafioAeC](https://github.com/SilvaHugo/DesafioAeC);
2. Crie o banco de dados e execute o script para criação das tabelas (está localizado na raiz do repositório);
3. Configure a ConnectionString "DesafioAeCContext" com o Usuário e Senha que terá acesso de escrita e leitura na base criada;
4. Defina o projeto DesafioAeC.Web como Projeto de Inicialização e execute a aplicação.

## Funcionalidades
1. Ao iniciar a aplicação, o primeiro passo será efetuar o seu cadastro no sistema na aba "Cadastrar";
2. Com o cadastro bem sucedido, você será redirecionado para a tela de Login;
3. Faça o login com o usuário cadastrado;
4. Ao fazer o login, você será redirecionado para a tela inicial de Endereços;
5. Para adicionar um novo endereço, basta clicar no botão "Novo Endereço" e preencher o formulário exibido;
6. Ao fornecer um CEP válido as informações respectivas serão carregadas e o formulário será preenchido, restando apenas o campo Número (obrigatório) e Complemento (Opcional). Vale lembrar que você conseguirá alterar o valor de todos os campos
7. Após efetuar o cadastro do endereço, o sistema irá redirecionar para a tela de detalhes do endereço;
8. A tela de detalhes contém as informações do endereço cadastrado, um botão para alterar as informações e um botão para retornar a tela inicial;
9. Após ter o seu primeiro endereço cadastrado, a função de exportar os dados para uma planilha no formato CSV será disponibilizado na tela inicial de Endereços, sendo necessário apenas um clique no botão "Exportar";
10. Na listagem de endereços, em cada linha será exibido os botões para dar início aos processos de alterar, remover e ver detalhes

### Extras
* Clique no botão "Sair" no canto superior direito para deslogar do sistema;
* Para encontrar um endereço na lista, escreva a informação desejada no campo "Pesquisar" acima da tabela de listagem;
* É possível configurar a paginação para 10, 25, 50 ou 100 registros por página no dropdown acima da tabela, no canto esquerdo;
* Em caso de perda da senha, entre em contato com o administrador do sistema;
