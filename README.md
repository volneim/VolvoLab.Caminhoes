# Volvo Lab Caminhões - Projeto de avaliação

Projeto modelo para avaliação.<br>
Aplicação em ASP.Core usando os conceitos aderentes à Clean Architecture.

![](img/eshop-webmvc-app-screenshot.png)

## Estrutura do projeto

| Camada | Descrição 
| ------------- | ------------- |
| VolvoLab.Caminhoes.API | Interface API para separar o backend do frontend  |
| VolvoLab.Caminhoes.Application | Interfaces, serviços e regras de negócio |
| VolvoLab.Caminhoes.Domain | Entidades do domínio  |
| VolvoLab.Caminhoes.Infra.Data | Responsável pelo acesso aos dados |
| VolvoLab.Caminhoes.Infra.IOC | Centraliza a injeção de dependência  |
| VolvoLab.Caminhoes.MVC | Interface com o usuário  |
| VolvoLab.Caminhoes.Tests |  Projeto de testes de unidade |

## Informações importantes



```powershell
docker-compose build
docker-compose up
```
