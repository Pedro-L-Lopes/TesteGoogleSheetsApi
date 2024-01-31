using DesafioTuntsRocks;
using Google.Apis.Sheets.v4;
using Google.Apis.Sheets.v4.Data;

class Program
{
    static void Main(string[] args)
    {
        // Initalize the Google Sheets service
        var sheetsService = GoogleSheetsService.InitializeSheetsService();

        if (sheetsService != null)
        {
            // Define spreadsheet ID and range
            string spreadsheetId = "1Iv9ptodGr47BG5AlzeyjZUav82Rjb5GWMvScmaSffRY";
            string range = "engenharia_de_software";

            // Make a request to get values from the specified range in the spreadsheet
            var request = sheetsService.Spreadsheets.Values.Get(spreadsheetId, range);
            var response = request.Execute();
            var values = response.Values;

            if (values != null && values.Count > 3)
            {
                // Skip header and convert the data to a list
                var studentData = values.Skip(3).ToList();

                // Process the data and create a list of Student objetcs
                var students = ProcessData(studentData);

                // Calculate status for each student
                Calculator.CalculateStatus(students);

                // Display the results on the console
                foreach (var student in students)
                {
                    Console.WriteLine($"Nome: {student.Name}, Média: {student.Average}, Situação: {student.Status}, NaF: {student.FinalExamGrade}");
                }

                // Update the spreadsheet with the results
                UpdateSpreadsheet(sheetsService, spreadsheetId, students);
            }
            else
            {
                Console.WriteLine("Não foram encontrados dados suficientes na planilha.");
            }
        }
        else
        {
            Console.WriteLine("Não foi possível inicializar o serviço do Google Sheets.");
        }
    }

    // Process raw data and create a list of Student objects
    static List<Student> ProcessData(List<IList<object>> data)
    {
        var students = new List<Student>();

        foreach (var row in data)
        {
            var student = new Student
            {
                Name = row[1].ToString(),
                P1 = int.Parse(row[3].ToString()),
                P2 = int.Parse(row[4].ToString()),
                P3 = int.Parse(row[5].ToString()),
                Absences = int.Parse(row[2].ToString())
            };

            students.Add(student);
        }

        return students;
    }

    // Update the Google Sheets spreadsheet with calculated results
    static void UpdateSpreadsheet(SheetsService sheetsService, string spreadsheetId, List<Student> students)
    {
        try
        {
            var updateValues = new List<IList<object>>
            {
                // Add header information
                new List<object> { "Engenharia de Software" },
                new List<object> { "Total de aulas no semestre: 60" },
                new List<object> { "Matricula", "Aluno", "Faltas", "P1", "P2", "P3", "Situação", "Nota para Aprovação Final" }
            };

            // Add student data
            foreach (var (index, student) in students.Select((s, i) => (i + 1, s)))
            {
                updateValues.Add(new List<object>
            {
                index,
                student.Name,
                student.Absences,
                student.P1,
                student.P2,
                student.P3,
                student.Status,
                student.FinalExamGrade
            });
            }

            string updateRange = "engenharia_de_software";

            // Create a request to update values in the spreadsheet
            var updateRequest = sheetsService.Spreadsheets.Values.Update(new ValueRange { Values = updateValues }, spreadsheetId, updateRange);
            updateRequest.ValueInputOption = SpreadsheetsResource.ValuesResource.UpdateRequest.ValueInputOptionEnum.RAW;

            // Execute the update request
            var updateResponse = updateRequest.Execute();

            Console.WriteLine($"Atualização bem-sucedida! {updateResponse.UpdatedCells} células foram atualizadas.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro ao atualizar a planilha: {ex.Message}");
        }
    }


}
