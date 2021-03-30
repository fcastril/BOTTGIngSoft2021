**Implementación y Desarrollo BOT**

1.  **Preparación Preliminar para ambiente de desarrollo**

    1.  **Requisitos Iniciales**

Para implementar el ambiente de desarrollo se debe instalar los
siguientes programas

a.  Microsoft Visual Studio 2019: [IDE de Visual Studio 2019: software
    > de programación para Windows
    > (microsoft.com)](https://visualstudio.microsoft.com/es/vs/)

b.  Bot Framework SDK Versión 4.0: [Bot Framework v4 SDK Templates for
    > Visual Studio - Visual Studio
    > Marketplace](https://marketplace.visualstudio.com/items?itemName=BotBuilder.botbuilderv4)

c.  Bot Framework Emulator: [microsoft/BotFramework-Emulator: A desktop
    > application that allows users to locally test and debug chat bots
    > built with the Bot Framework SDK.
    > (github.com)](https://github.com/microsoft/BotFramework-Emulator)

    1.  **Creación del Repositorio en GITHUB**

Para el desarrollo de esta solución se implementará por medio de
repositorio alojados en GITHUB, específicamente en
[fcastril/BOTTGIngSoft2021: BOT para el Trabajo de Grado Ingeniería de
Software 2021
(github.com)](https://github.com/fcastril/BOTTGIngSoft2021)

2.  **Creación del Proyecto**

Ingresar a Microsoft Visual Studio y crear un nuevo proyecto basado en
las plantillas previamente instaladas gracias al BOT Framework SDK V4.

![](media/image1.png){width="5.1071095800524935in"
height="2.7130435258092738in"}

En el asistente **"Create a new Project"** buscar una de las plantillas
del BOT Framework V4, específicamente para este caso se utilizar
**"Empty Bot (Bot Framework v4 - .Net Core 3.1)"**

![](media/image2.png){width="6.1375in" height="3.2604166666666665in"}

En la siguiente opción se define el nombre del proyecto y su
localización.

![](media/image3.png){width="6.1375in" height="3.515972222222222in"}

Al crear el proyecto con la plantilla **EMPTY BOT** se crea una clase
llamada **EmptyBot.cs** la cual debemos renombrar de acuerdo con el
nombre del proyecto, esto se puede hacer refactorizando o bien
manualmente tanto en el nombre del archivo como en la definición de la
clase

![](media/image4.png){width="6.1375in" height="3.2604166666666665in"}

Esta clase tiene un método llamado **OnMemberAddedAsync,** este método
se encarga de capturar a los nuevos usuarios que se conectan al BOT y
mostrarles una información de bienvenida.

3.  **Configuración Inicial del Emulador de BOTs -- Prueba Inicial**

Para realizar las pruebas del Desarrollo del BOT se hace necesario
utilizar el Emulator BOT y configurarlo para su uso, y se debe ejecutar
el proyecto de Visual Studio.

Para esto debemos crear una nueva configuración del BOT.

![](media/image5.png){width="1.9460258092738407in"
height="2.700906605424322in"}

Darle los datos básicos de configuración entre ellos:

a.  Un Nombre para el BOT

b.  Asignar el URL Endpoint que arroja la ejecución del proyecto de
    Visual Studio

![](media/image6.png){width="6.1375in" height="3.4444444444444446in"}

Al ejecutar el proyecto este hace referencia al Endpoint necesario.

Con estos datos se configurará el Emulador del BOT.

![](media/image7.png){width="3.614375546806649in"
height="3.379166666666667in"}

Al ejecutar el Emulator BOT nos aparece los mensajes que venimos
organizando en el Proyecto.

![](media/image8.png){width="5.429201662292214in"
height="3.4652777777777777in"}

1.  **Implementación de Requisitos Iniciales AZURE**

    1.  **Creación de la cuenta AZURE**

Ingresar al siguiente link: <https://azure.microsoft.com/es-es/>

![](media/image9.png){width="6.1375in" height="3.5652777777777778in"}

En AZURE se puede crear una cuenta gratuita para realizar las pruebas o
bien crear una cuenta empresarial.

Al darle clic en **"Pruebe Azure gratis"**, el cual permite utilizar
durante 12 meses muchos de los servicios de forma gratuita.

![](media/image10.png){width="6.1375in" height="6.471527777777778in"}

Y seguir los pasos para la creación.

Para nuestro caso, utilizaremos una cuenta académica suministrada para
fines educativos.

2.  **Configurar el estado del BOT con Azure Blob Storage**

Configurar el estado y el almacenamiento del estado del BOT, bien sea el
estado de la conversación o el estado del usuario.

Para esto debemos ingresar al portal de Azure, el cual se ingresa por el
siguiente link: <https://portal.azure.com>.

1.  **Creación de un Grupo de Recursos**

La mejor forma de administrar los procesos o recursos en AZURE es
creando un grupo de recursos.

![](media/image11.png){width="6.1375in" height="3.7395833333333335in"}

La forma más fácil es buscar **"Grupo de Recursos"** o si aparece la
opción en el dashboard también se puede utilizar

![](media/image12.png){width="6.1375in" height="2.0479166666666666in"}

Al darle clic en nuevo se nos presenta la siguiente pantalla.

![](media/image13.png){width="6.1375in" height="5.209027777777778in"}

Donde se nos solicita el tipo de suscripción, en este caso por ser
educativa nos sale **"Azure para estudiantes",** en el caso de cuentas
empresariales sales las suscripciones a las que se tienen acceso.

En Grupo de recursos, se debe digitar un nombre para identificar el
grupo de recursos y se termina con la región de ubicación del grupo de
recursos, se debe tener en cuenta que se debe seleccionar una región lo
más cercana posible a la ubicación general de implementación.

Y terminar dándole clic en **"Revisar y Crear"**

![](media/image14.png){width="4.798314741907261in"
height="6.444444444444445in"}

Verificar los datos y Crear.

2.  **Crear el Azure Blob Storage**

Por medio de esta opción se va a crear el AZURE BLOB STORAGE, para el
almacenamiento como tal.

Ingresamos al Grupo de Recursos que se creo en el apartado anterior, y
luego le damos los pasos para crear el AZURE BLOB STORAGE

![](media/image15.png){width="5.152777777777778in"
height="2.504676290463692in"}

En el Marketplace de Azure, en la herramienta de búsqueda digitamos
**"Azure Blob Account"** y buscamos

![](media/image16.png){width="4.351489501312336in"
height="3.6597222222222223in"}

Al ingresar a la opción de **"Cuenta de Almacenamiento"** nos da la
opción de crear y procedemos a llegar la información necesaria.

![](media/image17.png){width="6.1375in" height="7.34375in"}

Luego de digitar un nombre para el STORAGE se le da clic en **"Revisar y
Crear"**

![](media/image18.png){width="6.1375in" height="1.770138888888889in"}

El sistema hace el proceso de implementación que se puede tardar unos
minutos.

Luego de creado el STORAGE ir al recurso e implementar un contenedor

![](media/image19.png){width="6.1375in" height="2.5347222222222223in"}

Y se crea un nuevo contenedor

![](media/image20.png){width="6.1375in" height="2.8631944444444444in"}

Se digitan los datos de identificación del contenedor

![](media/image21.png){width="3.0308716097987753in"
height="2.8225634295713036in"}

Luego de creado el container, nos desplazamos para **"Claves de
acceso"** donde se copiará la cadena de conexión para ser utilizada en
el Proyecto de Desarrollo.

![](media/image22.png){width="4.75051946631671in"
height="4.381944444444445in"}

![](media/image23.png){width="6.1375in" height="2.75in"}

3.  **Configuración del Blob Storage en el Proyecto de Desarrollo**

La información de las claves de acceso se utilizan en el app.settings
del proyecto

![](media/image24.png){width="6.1375in" height="3.2604166666666665in"}

En el app.settings ingresamos la siguiente información:

![](media/image25.png){width="6.1375in" height="2.814583333333333in"}

Al proyecto se debe instalar el paquete Bot.Builder.Azure.Blobs.

a.  **Ingresamos al Administrador de Paquetes**

![](media/image26.png){width="4.583176946631671in"
height="4.826388888888889in"}

b.  **Buscar el Paquete e Instalarlo**

![](media/image27.png){width="6.1375in" height="1.5673611111111112in"}

c.  **Configurar el Startup.cs**

Utilizaremos los siguientes using.

![](media/image28.png){width="6.1375in" height="1.7097222222222221in"}

Y configuramos el storage, estado del usuario y el estado de la
conversación.

![](media/image29.png){width="6.1375in" height="3.0381944444444446in"}

d.  **Configurar la inyección de dependencias y utilización de los
    > estados.**

![](media/image30.png){width="3.8219695975503063in"
height="7.006944444444445in"}

![](media/image31.png){width="6.1375in" height="3.8201388888888888in"}

Se crea el método para capturar las actividades del BOT como las del
usuario

![](media/image32.png){width="6.1375in" height="2.6006944444444446in"}

Al probar la implementación obtenemos lo siguiente:

![](media/image33.png){width="6.1375in" height="3.11875in"}

**Referencias**

-   Bot Framework V4 y Microsoft Azure Completo ([Bot Framework V4 y
    Microsoft Azure Completo \|
    Udemy](https://www.udemy.com/course/aprende-a-crear-bots-con-bot-framework-v4-y-microsoft-azure/learn/lecture/18032995#overview))
