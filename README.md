<h1>Desafio Tunts.Rocks 2024 - Documentação do Desafio Técnico</h1>

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

<h3>pacotes utilizados:</h3>
	<ul>
    <li>Google.Apis.Auth - Versão: 1.66.0</li>
    <li>Google.Apis.Sheets.v4 - Versão 1.66.0.3148</li>
  </ul>

<h3>
Descrição das classes</h3>
<ul>
  <li><b>Student:</b> Contém todas as propriedades do aluno</li>
  <li><b>Calculator:</b> Contém toda a logica para verificar a média, quantidade de faltas, situação do aluno e a nota para aprovação final(se necessário)</li>
  <li><b>GoogleSheetsService:</b> inicializa e fornece acesso à API do Google Sheets</li>
  <li><b>Program:</b> Recupera dados de uma planilha específica, processa os dados para criar uma lista de alunos, calcula seus status usando uma classe Calculator, exibe os resultados no console e atualiza a planilha com as informações calculadas.</li>
</ul>

<h3>Configurações necessário:</h3>
<ul>
	<ol>1- Certifique-se de ter o .NET 6 instalado</ol>
	<ol>2 - Instale os pacotes utilizados e suas respectivas versões.</ol>
	<ol>3 - Crie um arquivo chamado "credentials.json" no mesmo nível da classe Program e cole as informações da credencial fornecida.</ol>
	<ol>4 - Na classe "GoogleSheetsService", atribua o caminho completo do arquivo "credentials.json" à variável "CredentialsPath" (se estiver usando o Visual Studio, clique com o botão direito sobre o arquivo 	"credentials.json" e selecione "copiar o caminho completo").</ol>
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
