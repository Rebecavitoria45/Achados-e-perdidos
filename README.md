</h1>
<h1>
   <span>Achados e Perdidos-API👜👒</span>
</h1>

## Tecnologias Usadas 👩‍💻
[![GitHub](https://img.shields.io/badge/GitHub-000?style=for-the-badge&logo=github&logoColor=30A3DC)](https://docs.github.com/)
[![Git](https://img.shields.io/badge/Git-000?style=for-the-badge&logo=git&logoColor=E94D5F)](https://git-scm.com/doc)
[![C#](https://img.shields.io/badge/C%23-239120?style=for-the-badge&logo=c-sharp&logoColor=white)](https://git-scm.com/doc)
[![.NET](https://img.shields.io/badge/.NET-512BD4?style=for-the-badge&logo=dotnet&logoColor=white)](https://git-scm.com/doc)
![MicrosoftSQLServer](https://img.shields.io/badge/Microsoft%20SQL%20Server-CC2927?style=for-the-badge&logo=microsoft%20sql%20server&logoColor=white)
![Swagger](https://img.shields.io/badge/-Swagger-%23Clojure?style=for-the-badge&logo=swagger&logoColor=white)
![Postman](https://img.shields.io/badge/Postman-FF6C37?style=for-the-badge&logo=postman&logoColor=white)
<br />



## Visão Geral
 <b>Bem-vindo à API do sistema de Achados e Perdidos. Esta API permite gerenciar Objetos e documentos perdidos e encontrados, facilitando o registro, a busca e a recuperação desses itens. Além de cadastrar e gerenciar os usuários. </b>

![tela inicial](https://github.com/Rebecavitoria45/Achados-e-perdidos/assets/117654851/e6a9029a-674b-4d7d-8b7b-cce61fcb43d2)
## Principais Recursos
 ### Usuários
   <p> Permite Cadastrar, Listar, Excluir e editar os usuários.</p>
   
![usuario](https://github.com/Rebecavitoria45/Achados-e-perdidos/assets/117654851/e197e536-8e90-41e8-98c0-312e8b6c7d11)

   Exemplo de Retorno do método Get (Busca usuário pelo id):
  ```json
 {
    "dados": {
        "idUsuario": 7,
        "nome": "Rebeca",
        "email": "rebeca@gmail.com",
        "telefone": 4556677
    },
    "mensagem": "Usuário Encontrado com sucesso",
    "status": true
}
```
### Objetos
<p> Permite Cadastrar, Listar, Excluir e editar Objetos, além de buscar objetos cadastrados por um usuário. </p>

![objeto](https://github.com/Rebecavitoria45/Achados-e-perdidos/assets/117654851/373ba661-4072-41ea-9fda-c2d0411ed8c4)
  Exemplo do Body para o método Post:
  ```json
  {
  "nome": "string",
  "fotoObjeto": "string",
  "ativo": true,
  "descrição": "string",
  "categoria": "Perdido",
  "usuarioId": 0
}
```
### Documentos
<p> Permite Cadastrar, Listar, Excluir e editar Documentos, além de buscar documentos cadastrados por um usuário. </p>

![documento](https://github.com/Rebecavitoria45/Achados-e-perdidos/assets/117654851/deebcd3e-7b72-4f89-a9ba-1b7d34d4afa2)
  Exemplo de Retorno do método Get (Busca documentos pelo id do usuário):
   ```json
    {
    "dados": [
        {
            "idDocumento": 3,
            "tipoDocumento": "Rg",
            "numeroDocumento": "23456795809",
            "nomeCompletoDocumento": "Luan alvez",
            "estadoDocumento": "Amapá",
            "usuarioId": 5,
            "usuario": null
        }
    ],
    "mensagem": "",
    "status": true
}
```
### Obeservações
 Exemplo de Body para o método Patch (Atualiza parcialmente)
 ```json
  [
  {
    "operationType": "Replace",
    "path": "Nome",
    "op": "replace",
    "from": "string",
    "value": "Rebeca Vitória"
  }
]
```
Utilizei uma Response Model para padronizar o formato dos retornos
```json
{
    "dados": null,
    "mensagem": "",
    "status": true
}
```
## Instalação
  1.Clone o repósitorio </br>
 ```
 git clone https://github.com/Rebecavitoria45/Achados-e-perdidos
  cd Achados-e-perdidos 
```
 2.Configure a string de conexão do banco de dados no arquivo appsettings.json: </br>
   ```
  { 
  "ConnectionStrings": { 
    "DefaultConnection": "Server=.;Database=LostAndFound;Trusted_Connection=True;MultipleActiveResultSets=true" 
  },
 ```
  3.Execute as migrações do banco de dados: </br>
   ```
    dotnet ef database update
 ```
 4.Inicie o servidor:
  ```
 dotnet run 
 ```
## Contato
   ### Autora: Rebeca vitória
   ### Email: bebecavitoria4738@gmail.com
   ### Linkedin: https://www.linkedin.com/in/rebecavitoriadev/


       




  
