# Livraria Tech - API

API para gerenciamento de uma livraria especializada em tecnologia desenvolvida em C#.

## Tecnologias

- Entity Framework Core
- Swagger
- JWT Authentication
- SQLite

## Pré-requisitos

- [.NET 9 SDK](https://dotnet.microsoft.com/pt-br/download/dotnet/9.0)
- IDE (Visual Studio/Rider)

## Links Úteis

- [DBBrowser](https://sqlitebrowser.org/dl/)
- [BCrypt](https://github.com/BcryptNet/bcrypt.net)
- [Jwt.io](https://jwt.io)

## Autenticação
Registre um usuário em /Users

Faça login em /Login

Use o token retornado no header Authorization das requisições

Rotas da API
Books
GET /Books/Filter
Filtra livros com paginação
Parâmetros:

pageNumber (Número da página)

title (Filtro por título)

Exemplo de resposta:
```json
{
  "pagination": {
    "pageNumber": 0,
    "totalCount": 0
  },
  "books": [
    {
      "id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
      "title": "Clean Code",
      "author": "Robert C. Martin"
    }
  ]
}
```
Checkouts
POST /Checkouts/{bookId}
Realiza checkout de um livro
Parâmetro:

bookId (UUID do livro)

Users
POST /Users
Cria novo usuário:
```json
{
  "name": "Seu Nome",
  "email": "seu@email.com",
  "password": "SuaSenha123@"
}
```
Login
POST /Login
Autentica usuário:
```json
{
  "email": "seu@email.com",
  "password": "SuaSenha123@"
}
```
Exemplos de Uso

Filtrar livros:
```bash
curl -X GET "https://localhost:7187/Books/Filter?pageNumber=1&title=clean" \
-H "Authorization: Bearer (TOKEN DE ACESSO GERADO NO LOGIN)"
```

Realizar checkout:
```bash
curl -X POST "https://localhost:7187/Checkouts/3fa85f64-5717-4562-b3fc-2c963f66afa6" \
-H "Authorization: Bearer (TOKEN DE ACESSO GERADO NO LOGIN)"
```
Tratamento de Erros

Exemplo de erro:
```json
{
  "errors": [
    "Credenciais inválidas",
    "Livro não encontrado"
  ]
}
```
Como Contribuir
Faça um fork do projeto

Crie uma branch: git checkout -b minha-feature

Commit suas mudanças: git commit -m 'Minha nova feature'

Push para a branch: git push origin minha-feature

Abra um Pull Request

Licença
MIT

Desenvolvido por Pedro Arruda - 🔗 [LinkedIn](https://www.linkedin.com/in/pedrohendp/)
