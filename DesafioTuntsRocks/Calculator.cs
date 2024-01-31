namespace DesafioTuntsRocks
{
    // Calculator class responsible for determining the status of each student based on given criteria
    public class Calculator
    {
        // Percentage threshold for considering a student as having too many absences
        private const double AbsencesThreshold = 0.25;

        // Total number of classes in the course
        private const int TotalClasses = 60;

        // Method to calculate the status of each student and update their properties accordingly
        public static void CalculateStatus(List<Student> students)
        {
            foreach (var student in students)
            {
                // Calculate the average of the three test scores and round it to the nearest integer
                student.Average = Math.Round((student.P1 + student.P2 + student.P3) / 3.0);

                if (student.Absences > AbsencesThreshold * TotalClasses)
                {
                    student.Status = "Reprovado por faltas";
                }
                else if (student.Average < 50)
                {
                    student.Status = "Reprovado por nota";
                }
                else if (student.Average >= 50 && student.Average < 70)
                {
                    // Calculate the Final Exam Grade (NaF) based on the given formula
                    student.FinalExamGrade = (int)Math.Ceiling(100 - student.Average);

                     if (student.FinalExamGrade < 0)
                    {
                        student.FinalExamGrade = 0;
                    }
                    student.Status = "Exame final";
                }
                else
                {
                    student.Status = "Aprovado";
                }
            }
        }
    }
}
