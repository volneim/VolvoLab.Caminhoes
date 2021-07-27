

# Volvo Lab Caminhões - Projeto de avaliação

Projeto modelo para avaliação.<br>
Aplicação em ASP.Core usando os conceitos aderentes à Clean Architecture.<br>
Seguindo os padrões mais modermos foiUtilizado uma camada de Web Api separando a frontend do backend, permitindo desta forma uma melhor escalabilidade ao sistema.   

![](img/eshop-webmvc-app-screenshot.png)

## Estrutura do projeto

| Camada | Descrição 
| ------------- | ------------- |
| VolvoLab.Caminhoes.API | Interface API para separar o backend do frontend  |
| VolvoLab.Caminhoes.Application | Interfaces, serviços e regras de negócio |
| VolvoLab.Caminhoes.Domain | Entidades do domínio  |
| VolvoLab.Caminhoes.Infra.Data | Responsável pelo acesso aos dados com EntityFramework |
| VolvoLab.Caminhoes.Infra.IOC | Centraliza a injeção de dependência  |
| VolvoLab.Caminhoes.MVC | Interface com o usuário com Bootstrap  |
| VolvoLab.Caminhoes.Tests |  Projeto de testes de unidade com xUnit |

## Informações importantes

Ao baixar o projeto seguir os passos descritos abaixo:
1. Clicar com o botão direito da Solution e selecionar no menu suspenso "Definir projetos de inicialização"
2. Na página que será aberta (Páginas de propriedades da Solução 'VolvoLab.Caminhoes') clicar em "Vários projetos de inicialização"
3. Na lista de projetos alterar a ação do projeto "VolvoLab.Caminhoes.API" para Iniciar
4. Na lista de projetos alterar a ação do projeto "VolvoLab.Caminhoes.MVC" para Iniciar

![VisualStudio](https://user-images.githubusercontent.com/9287336/126923709-6729c5e9-abbe-41fd-b48d-a3a4ddaafbfc.png)


![VisualStudio_2 png](https://user-images.githubusercontent.com/9287336/126923719-b00724e1-3f9b-43c7-b2ae-cae399a674f3.jpg)


Após esta configuração o projeto estará pronto para rodar:
O projeto abrirá o swagger com as APIs e o MVC com a tela de cadastro

![Volvo_API](https://user-images.githubusercontent.com/9287336/126924076-81a14eee-316a-4bfd-87b5-040caa5c4fcb.jpg)


![Volvo_MVC](https://user-images.githubusercontent.com/9287336/126924090-0dba37e1-1eaa-42fb-b05f-d3a3b674290f.jpg)


## Instruções de uso
Ao clicar em adicionar é apresentado o modal para o cadastro de um novo caminhão<br>
Obs.: Os modelos estão cadastrados no banco de dados sem tela de cadastro.<br>

![Volvo_Cadastro](https://user-images.githubusercontent.com/9287336/126924145-462d222c-1192-49b5-87fc-a0b407e1d2b1.jpg)

## Validações do sistema
No MVC<br>
   1 O número de série precisa ter no mínimo 3 e maxímo 18 caracteres<br>
   2 O ano de fabricação não pode ser diferente do ano atual<br>
Nas APIs<br>
   1 O número de série precisa ter no mínimo 3 e maxímo 18 caracteres<br>
   2 O Modelo não pode ser diferente dos que estão cadastrados na base<br>
   3 O ano de fabricação não pode ser diferente do ano atual <br>
   4 O ano modelo precisa estar entre o ano atual e o próximo ano
   
   
   








