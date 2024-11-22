# GreenVolt
GreenVolt é uma plataforma de gerenciamento de empresas, com foco no setor de energia renovável, permitindo que os usuários visualizem, criem e gerenciem informações sobre empresas do setor de energia, incluindo dados como nome, descrição, categoria e informações de contato.

# # O sistema é dividido em várias camadas:

API (Backend): Desenvolvida com .NET Core (ASP.NET), que fornece uma API RESTful para gerenciamento de dados sobre empresas.
Aplicação Mobile (Frontend): Desenvolvida com .NET MAUI, que consome a API para exibir informações das empresas e permitir interações com o usuário.
Tecnologias Utilizadas
Backend:

ASP.NET Core 8
Entity Framework Core (PostgreSQL)
AutoMapper (para mapeamento entre DTOs e modelos de banco de dados)
Swashbuckle (Swagger para documentação da API)
Frontend:

.NET MAUI (para desenvolvimento de aplicativos móveis)
MVVM (Model-View-ViewModel) para organização da arquitetura
HttpClient (para comunicação com a API)
AutoMapper (para conversão de dados entre os modelos de API e os modelos locais)
Funcionalidades
