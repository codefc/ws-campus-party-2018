# Campus Party 2018

## Descrição
Este repositório foi criado com o intuito de servir como base para o workshop sobre o modelo de desenvolvimento de boas práticas para entrega contínua de valor utilizando as estratégias **Feature Toggle** e **Trunk Based**, na Campus Party MG 2018.

---

# Workshop

![Diagrama do Projeto](/img/ProjetoCampusParty2018.png)

Conforme apresentado na figura acima, o projeto consiste em duas aplicações, backend e frontend. As duas aplicações com as principais implmementações encontram-se neste repositório. Nos demais passos deste workshop você vai aprender alguns cocneitos importantes e ter a oportunidade de fazer alterações nas aplicações.

Existem 3 grandes grupos definidos:
- Dev - representa o ambiente de desenvolvimento. Todo o código possuirá o controle de versão **git**.
- Pipeline - a submissão do frontend e do backend será feita com o apoio do **Azure Pipeline** adicionado ao seu repositório **git**. Todos os passos de como criar builds e releases seão explicados nos próximos tópicos.
- Cloud - O host da aplicação será o Azure e as aplicações serão executadas como **Web Container app**.

O principal objetivo deste workshop é demonstrar como trabalhar com a estratégia de **Trunk Based** apoiado pela estratégia de **Feature Toggle**.

### Backend

O Backend foi desenvolvido utilizando a versão 2.1 do .net Core. A apicação será executada em um contâiner docker. Boas práticas foram implementadas para potencializar o aprendizado. O código possui comentários para melhorar o entendimento.

### Frontend

O Frontend foi desenvolvido utilizando o framework VueJS. Fique tranquilo se nunca trabalhou com este framwork. Os tópicos abaixo vão direcioná-lo em como interagir com o código para provar os principais conceitos deste workshop.

## Pré-requisitos

- Visual Studio Community / Visual Studio Code
- .Net Core 2.1
- Conta no [Microsoft Azure](http://portal.azure.com) 
- Criar uma conta no [Configcat](https://configcat.com)
- Node
- NPM

### IDE

Para o desenvolvimento da solução apresentada no workshop será necessário a utilização de uma IDE. Existem duas IDEs gratuitas disponíveis:

- Microsoft Visual Studio Community [https://visualstudio.microsoft.com/vs/](https://visualstudio.microsoft.com/vs/)
- Visual Studio Code [http://code.visualstudio.com](http://code.visualstudio.com)

Fiquei a vontade para escolher a IDE de sua preferência.

### .Net core 2.1

A API desenvolvida no projeto será construída utilizando o .NET Core 2.1. Se ainda não possui o SDK instalado você pode efetuar o download em: [https://www.microsoft.com/net/download](https://www.microsoft.com/net/download)

### Microsoft Azure

Para a publicação das aplicações utilizadas no workshop, será necessário possuir uma conta no Azure. Caso ainda não possua uma conta, acesse o seguinte site: [https://azure.microsoft.com/en-us/free/](https://azure.microsoft.com/en-us/free/) e crie uma conta gratuita.

### ConfigCat

O Configcat será o servidor de toggle utilizado no workshop. Siga os seguintes passos para criar uma conta:

1. Acesse a página de [registro](https://configcat.com/Account/Register);
2. Informe os seus dados e crie o seu acesso;

Após criada a conta, efetue o login e crie um projeto com um nome de sua preferência:
![Novo projeto](/img/newProjectCC.png)

Após a criação do projeto, acesse o seu gerenciamento:

![Gerenciando o projeto](/img/ManageProject.png)


Clique na aba **Environment** e guarde o valor da **API Key** para utilzação nos projetos de frontend e backend.

## Configuração do Azure Pipeline

O Azure Pipeline será utilizado para build e release das aplicações na nuvem. Para isso, antes de iniciar sua configuração efetue o **FORK** deste repositório em sua conta git:

![Fork do projeto](/img/fork.png)

> Ao efetuar o Fork do projeto o mesmo será importado como repositório em seu usuário GIT. É de **extrema importância** este passo. Sem isso não será necessário efetuar commits no repositório original, prejudicando sua evolução neste workshop.

Após efetuado o fork, siga os seguintes passo para configuração do Azure Pipeline em seu repositório:

1. Após logar-se no **github** com o seu usuário, clique no link *Marketplace* localizada na barra principal, no topo da página:
![Marketplace](/img/marketplace.png)
2. Em **Search marketplace** digite o valor **Azure Pipeline**.
3. Clique na ferramenta **Azure Pipeline** obtida como resultado da busca e em seguida clique na opção **Set up plan**.
4. Em **Price and Setup** deixe a opção **Free**.
5. Clique em **Complete order and begin instalation**
6. Selecione a opção **Only Selected Repositories** e em seguida selecione o repositório no qual efetuou o fork anteriormente - **ws-campus-party-2018**
7. Clique em **install**
8. Na próxima tela, efetue o login com sua conta de e-mail associada à *Microsoft*.
9. No diálogo **Setup your Azure Pipeline project** selecione ou defina uma nova organização(é um agrupamento para seus repositórios) e o nome desejado para o seu projeto. Clique em continue.
10. Clique no botão **Authorize Azure Pipelines by Azure Pipelines**

Ao terminas os passos anteriores, o AzurePipeline irá solicitar a configuração de uma build. Para garantir o uso de criação de builds visualmente, faça:

1. No canto superior esquerdo da tela, clique em sua foto e em seguida, clique em **Preview Features**:
![Preview Features](/img/previewFeatures.png) 
2. Defina como **Off** a opção **New YAML pipeline creation expirience**:
![Desabilitando feature de YAML](/img/offNewFeature.png)

#### Build do Backend

No menu, clique na opção **Build** e siga os seguintes passos para definir uma build para o backend:

1. Clique em **New pipeline**
2. Em **Select a source** deixe a opção **Azure Repos Git** marcada com o repositório do seu projeto no **Azure Pipeline** e clique em continue.
3. Selecione a opção **Docker Container** e clique em **Apply**:
![Template de Pipeline](/img/dockercontainer.png).
4. Configure os steps de acordo com os seguintes parâmetros:

##### Build and image

- **Version**: 1.*
- **Container registry type**: Container Registry
- **Docker registry service connection**:
  - Clique na opção **Manage**
  - Na nova janela, clique em **New Service Connection** e em **Docker Registry**:
  ![Docker Registry](/img/dockerregistry.png)
  - No diálogo **Add Docker Registry service connection**, marque a opção **Docker Hub** em **Registry type** e em seguida defina um nome para a conexão, Docker Hub por exemplo, insira o **Docker ID(seu usuário do docker hub), senha e e-mail e clique em ok.
  ![Docker Hub connection](/img/dockerhubregistry.png)
  - Feche a janela
  - Selecione a connection criada em **Docker Registry**
- **DockerFile**: src/back/Dockerfile
- **Image name**: $(Build.Repository.Name):$(Build.BuildId)

![Build image step](/img/buildimagestep.png)

##### Push an image

- **Version**: 1.*
- **Container registry type**: Container Registry
- **Docker registry service connection**: Docker Hub
- **Image name**: $(Build.Repository.Name):$(Build.BuildId)

![Push Image](/img/pushimagestep.png)

##### Build do projeto

Com a build criada, basta clicar no botão **Save and queue** para efetuar a primeira compilação do backend.

#### Build do Frontend

A criação da build do Frontend é semelhante à do Backend com as seguintes configurações específicas:

##### Build and image

- **DockerFile**: src/front/Dockerfile

O Restante das configurações são idênticas.

##### Build do projeto

Com a build criada, basta clicar no botão **Save and queue** para efetuar a primeira compilação do backend.

#### Azure

Antes de configurar a release dos projetos, será necessário criar alguns recursos no **Azure**.

Acesse [https://portal.azure.com](https://portal.azure.com)


No portal execute os seguintes passos:

- Clique em **Create a resource**
- Na caixa de texto, digite **Web App for Containers**
- Clique em **Create**
- Defina um nome em **App Name** para conter o serviço de backend
- Selecione a **subscription**
- Em **Resource Group** selecione **Create New** e defina o nome de **CPMG3**
- Em OS defina a opção **Linux**
- Crie um **App Service plan/location**, caso não exista
- Clique em **Configure container**
- Em **Image source** selecione **Docker Hub**
- Em **Image and optional tag (eg 'image:tag')** defina o valor como **hello-world** e em seguida clique em **Apply**
- Clique em **Create** e aguarde a criação do recurso.


Efetue os mesmos procedimentos acima para criar um Web app for container para a aplicação de front. Mas na opção **Resourse Group** marque **Use existing** e selecione **CPMG3**.

#### Criação das Releases

### Criação de uma nova feature

