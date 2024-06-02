![image](https://github.com/AlexGSSoares/CSharks---LDS/assets/168682727/ad66d665-66a4-42a4-9ca2-e0d5f314e482)

      
      =========================================
      ## README - CSharks 7z Management Tool ##
      =========================================
A nossa ferramenta que utiliza a biblioteca **7z** para compactar e descompactar arquivos, proporcionando uma maneira eficiente de gerir arquivos compactados.


## INSTALAÇÃO ##


-- Descarregar o Git --
- **Windows:** 

	Descarregue o Git através do [link oficial](https://git-scm.com/download/win).

- **Linux (via PowerShell):**

  	apt install git
  	(* Digite "y" quando solicitado.)

  
## CLONAR REPOSITÓRIO ##

Para clonar o programa no seu computador, siga os passos abaixo:

1. Certifique-se de estar num diretório seguro onde deseja clonar o repositório. Use o comando `cd` para navegar entre pastas e `mkdir` para criar uma nova pasta, se necessário.

2. Clone o repositório. Comandos de Powershell:
   - git clone https://github.com/AlexGSSoares/CSharks---LDS
   - cd CSharks---LDS

## EXECUÇÃO E COMPILAÇÃO ##

Após clonar o repositório e navegar para o diretório do programa, compile e execute o programa usando os seguintes comandos no PowerShell:

dotnet build   # Compila o programa
dotnet run     # Executa o programa

## FUNCIONALIDADES DO PROGRAMA ##

O **CSharks** possui um menu interativo com três opções principais:

1. **Create Archive**
   - Solicita um nome para o arquivo (deve terminar com ".7z"). Exemplo: CSharks.7z
   - Pede os arquivos que deseja compactar, incluindo suas extensões.

2. **Extract Archive**
   - Solicita o nome do arquivo que deseja extrair (não esqueça de incluir a extensão). Exemplo: CSharks.7z
   - Pede o caminho onde o arquivo extraído será colocado.

3. **Exit**
   - Encerra o programa.
