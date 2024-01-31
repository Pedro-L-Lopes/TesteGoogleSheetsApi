<h1>Desafio Tunts.Rocks 2024 - Documentação do Desafio Técnico PT-BR</h1>

<p>Esta aplicação em C# .NET 6 foi desenvolvida para ler uma planilha do Google Sheets, extrair informações relevantes, realizar cálculos específicos e atualizar a planilha com os resultados processados</p>
<p>A estrutura de arquivos é bem simples devida a baixa complexidade do projeto</p>

<h2>Regras de negócio</h2>
Calcula a situação de cada aluno com base na média das três provas (P1, P2 e P3), de acordo com a tabela:

Média (m) Situação:
<ul>
<li>m < 5 - Reprovado por Nota</li>
<li>5 <= m < 7 - Exame Final</li>
<li>m >= 7 - Aprovado</li>
</ul>
Se o número de faltas ultrapassar 25% do número total de aulas, o aluno terá a situação de "Reprovado por Falta", independentemente da média.
  Se a situação for "Exame Final", é necessário calcular a "Nota para Aprovação Final" (naf) de cada aluno de acordo com a seguinte fórmula:
5 <= (m + naf)/2 (Arredonda o resultado para o próximo número inteiro (aumente) se necessário)
</br>Se a situação do aluno for diferente de "Exame Final", preenche o campo "Nota para Aprovação Final" com 0. 

<h1>Tecnologias</h1>
Aplicação de console feita utilizando C# .NET 6 consumindo GoogleSheetsApi com uma conta de serviço

<h3>Pacotes utilizados:</h3>
	<ul>
    <li>Google.Apis.Auth - Versão: 1.66.0</li>
    <li>Google.Apis.Sheets.v4 - Versão 1.66.0.3148</li>
  </ul>

<h3>
Descrição das classes</h3>
<ul>
  <li><b>Student:</b> Contém todas as propriedades do aluno</li>
  <li><b>Calculator:</b> Contém toda a lógica para verificar a média, quantidade de faltas, situação do aluno e a nota para aprovação final(se necessário)</li>
  <li><b>GoogleSheetsService:</b> inicializa e fornece acesso à API do Google Sheets</li>
  <li><b>Program:</b> Recupera dados de uma planilha específica, processa os dados para criar uma lista de alunos, calcula seus status usando uma classe Calculator, exibe os resultados no console e atualiza a planilha com as informações calculadas.</li>
</ul>

<h3>Configurações necessárias:</h3>
<ul>
	<ol>1 - Certifique-se de ter o .NET 6 instalado</ol>
	<ol>2 - Instale os pacotes utilizados e suas respectivas versões.</ol>
	<ol>3 - Crie um arquivo chamado "credentials.json" no mesmo nível da classe Program e cole as informações da credencial fornecida.</ol>
	<ol>4 - Na classe "GoogleSheetsService", atribua o caminho completo do arquivo "credentials.json" à variável "CredentialsPath" (se estiver usando o Visual Studio, clique com o botão direito sobre o arquivo 	"credentials.json", selecione "copiar o caminho completo" e cole o caminho para atribuir a variavel).</ol>
</ul>

<h3>Comandos:</h3>
<ul>
	<ol>1 - Abra um terminal ou prompt de comando.</ol>
	<ol>2 - Navegue até o diretório do projeto usando o comando cd.</ol>
	<ol>3 - Execute dotnet restore para restaurar as dependências do projeto.</ol>
	<ol>4 - Execute dotnet build para compilar o projeto.</ol>
	<ol>5 - Execute dotnet run para executar o aplicativo.</ol>
</ul>


<h4>Qualquer duvida entre em contato: https://www.linkedin.com/in/pedro-lucas-41a838241/</h4>

</br>
</br>

<h1>Tunts.Rocks Challenge 2024 - Technical Challenge Documentation EN</h1>

<p>This C# .NET 6 application was developed to read a Google Sheets spreadsheet, extract relevant information, perform specific calculations, and update the spreadsheet with the processed results.</p>
<p>The file structure is simple due to the low complexity of the project.</p>

<h2>Business Rules</h2>
Calculates the situation of each student based on the average of the three exams (P1, P2, and P3), according to the table:

Average (m) Situation:
<ul>
  <li>m < 5 - Failed by Grade</li>
  <li>5 <= m < 7 - Final Exam</li>
  <li>m >= 7 - Approved</li>
</ul>
If the number of absences exceeds 25% of the total number of classes, the student will have the "Failed by Absence" situation, regardless of the average.
If the situation is "Final Exam," it is necessary to calculate the "Final Approval Grade" (naf) for each student according to the following formula:
5 <= (m + naf)/2 (Round the result to the next integer (up) if necessary)
</br>If the student's situation is different from "Final Exam," fill in the "Final Approval Grade" field with 0.

<h1>Technologies</h1>
Console application made using C# .NET 6 consuming Google Sheets API with a service account.

<h3>Used Packages:</h3>
	<ul>
    <li>Google.Apis.Auth - Version: 1.66.0</li>
    <li>Google.Apis.Sheets.v4 - Version 1.66.0.3148</li>
  </ul>

<h3>Description of Classes</h3>
<ul>
  <li><b>Student:</b> Contains all student properties</li>
  <li><b>Calculator:</b> Contains all logic to check the average, number of absences, student's situation, and the final approval grade (if necessary)</li>
  <li><b>GoogleSheetsService:</b> Initializes and provides access to the Google Sheets API</li>
  <li><b>Program:</b> Retrieves data from a specific spreadsheet, processes the data to create a list of students, calculates their status using a Calculator class, displays the results in the console, and updates the spreadsheet with the calculated information.</li>
</ul>

<h3>Required Configurations:</h3>
<ul>
	<ol>1 - Ensure that you have .NET 6 installed</ol>
	<ol>2 - Install the used packages and their respective versions.</ol>
	<ol>3 - Create a file named "credentials.json" at the same level as the Program class and paste the provided credential information.</ol>
	<ol>4 - In the "GoogleSheetsService" class, assign the full path of the "credentials.json" file to the "CredentialsPath" variable (if using Visual Studio, right-click on the "credentials.json" file and select "Copy Full Path").</ol>
</ul>

<h3>Commands:</h3>
<ul>
	<ol>1 - Open a terminal or command prompt.</ol>
	<ol>2 - Navigate to the project directory using the cd command.</ol>
	<ol>3 - Execute dotnet restore to restore project dependencies.</ol>
	<ol>4 - Execute dotnet build to compile the project.</ol>
	<ol>5 - Execute dotnet run to run the application.</ol>
</ul>

<h4>For any questions, please contact: https://www.linkedin.com/in/pedro-lucas-41a838241/</h4>

