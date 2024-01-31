<h1>Desafio Tunts.Rocks 2024 - Documentação do Desafio Técnico</h1>

<p>Sobre: Aplicação que le uma planilha do Google Sheets, recupera as informações necessárias, calcula e escreve os resultados de volta na planilha.</p>

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
5 <= (m + naf)/2
</br>Se a situação do aluno for diferente de "Exame Final", preencha o campo "Nota para Aprovação Final" com 0. (Arredonda o resultado para o próximo número inteiro (aumente) se necessário)

<h1>Tecnologias</h1>
Aplicação de console feita utilizando C# .NET 6 usando GoogleSheetsApi (com conta de serviço)

<h3>pacotes utilizados:</h3>
	<ul>
    <li>Google.Apis.Auth - Versão: 1.66.0</li>
    <li>	Google.Apis.Sheets.v4 - Versão 1.66.0.3148</li>
  </ul>

<h3>
Descrição das classes</h3>
<ul>
  <li><b>Student:</b> Contém todas as propriedades do aluno</li>
  <li><b>Calculator:</b> Contém toda a logica para verificar a média, quantidade de faltas, situação do aluno e a nota para aprovação final(se necessário)</li>
  <li><b>GoogleSheetsService:</b> inicializa e fornece acesso à API do Google Sheets</li>
  <li><b>Program:</b> Recupera dados de uma planilha específica, processa os dados para criar uma lista de alunos, calcula seus status usando uma classe Calculator, exibe os resultados no console e atualiza a planilha com as informações calculadas.</li>
</ul>

<h3>Necessário (Recrutador):</h3>
Instalar os pacotes utilizados e suas respectivas versões, crie um arquivo chamado "credentials.json" no mesmo nível da classe program e, cole as informações da credencial fornecida. Após isso vá até a classe "GoogleSheetsService" e coloque o caminho do arquivo "credentials.json" da sua maquina na variavel "CredentialsPath" (se estiver usando o Visual Studio clique com o botão direito sobre o arquivo "credentials.json" e clique em "copiar o caminho completo".

<h3>Comandos:</h3>
Certifique-se de ter o .NET 6 instalado:
</br>
Abra um terminal ou prompt de comando:
Você pode usar o terminal integrado em seu ambiente de desenvolvimento (por exemplo, Visual Studio Code, Visual Studio) ou um prompt de comando padrão do sistema.

Navegue até o diretório do projeto:
Use o comando cd para navegar até o diretório que contém seu projeto C#.

Restaure as dependências do projeto:
Execute o comando dotnet restore para restaurar as dependências do projeto.

Compile o projeto:
Execute o comando dotnet build para compilar o projeto.

Execute o aplicativo:
Execute o comando dotnet run para executar o aplicativo.

<h4>Qualquer duvida entre em contato: https://www.linkedin.com/in/pedro-lucas-41a838241/</h4>
