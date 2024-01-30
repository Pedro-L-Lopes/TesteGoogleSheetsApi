using DesafioTuntsRocks;
using Google.Apis.Sheets.v4;
using Google.Apis.Sheets.v4.Data;
using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        var sheetsService = GoogleSheetsService.InitializeSheetsService();

        if (sheetsService != null)
        {
            string spreadsheetId = "1XvWJcRLj2WAeXO3ULQ_GxGm9---3SZkjMbGcXMJtt70";
            string range = "engenharia_de_software";

            var request = sheetsService.Spreadsheets.Values.Get(spreadsheetId, range);
            var response = request.Execute();
            var values = response.Values;

            if (values != null && values.Count > 3)
            {
                // Skip header
                var studentData = values.Skip(3).ToList();

                var students = ProcessData(studentData);

                Calculator.CalculateStatus(students);

                // Exibir os resultados no console
                foreach (var student in students)
                {
                    Console.WriteLine($"Nome: {student.Name}, Média: {student.Average}, Situação: {student.Status}, NaF: {student.FinalExamGrade}");
                }

                // Atualizar a planilha com os resultados.
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

    static void UpdateSpreadsheet(SheetsService sheetsService, string spreadsheetId, List<Student> students)
    {
        var updateValues = new List<IList<object>>();

        updateValues.Add(new List<object> { "Nome", "P1", "P2", "P3", "Faltas", "Média", "Situação" });

        foreach (var student in students)
        {
            updateValues.Add(new List<object>
            {
                student.Name,
                student.P1,
                student.P2,
                student.P3,
                student.Absences,
                student.Average,
                student.FinalExamGrade,
                student.Status
            });
        }

        string updateRange = "engenharia_de_software";

        var updateRequest = sheetsService.Spreadsheets.Values.Update(new ValueRange { Values = updateValues }, spreadsheetId, updateRange);
        updateRequest.ValueInputOption = SpreadsheetsResource.ValuesResource.UpdateRequest.ValueInputOptionEnum.RAW;

        //updateRequest.Execute();
    }
}
