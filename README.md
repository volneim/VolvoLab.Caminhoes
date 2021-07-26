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

Ao baixar o projeto seguir os passos descritos abaixo:
1. Clicar com o botão direito da Solution e selecionar no menu suspenso "Definir projetos de inicialização"
2. Na página que será aberta (Páginas de propriedades da Solução 'VolvoLab.Caminhoes') clicar em "Vários projetos de inicialização"
3. Na lista de projetos alterar a ação do projeto "VolvoLab.Caminhoes.API" para Iniciar
4. Na lista de projetos alterar a ação do projeto "VolvoLab.Caminhoes.MVC" para Iniciar

Após esta configuração o projeto estará pronto para rodar



```powershell
docker-compose build
docker-compose up
```
