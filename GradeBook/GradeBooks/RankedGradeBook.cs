using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook : BaseGradeBook
    {
        public RankedGradeBook(string name) : base(name)
        {
            Type = Enums.GradeBookType.Ranked;
        }

        public override char GetLetterGrade(double averageGrade)
        {
            char result;

            if(5 < Students.Count)
            {
                throw new InvalidOperationException("Ranked-grading requires a minimum of 5 students to work");
            }

            int threshold = (int)Math.Ceiling(Students.Count * 0.2);
            List<double> grades = Students.OrderByDescending(e => e.AverageGrade).Select(e => e.AverageGrade).ToList();

            if(grades[threshold-1] <= averageGrade)
            {
                result = 'A';
            }
            else if(grades[(2*threshold)-1] <= averageGrade)
            {
                result = 'B';
            }
            else if (grades[(3 * threshold) - 1] <= averageGrade)
            {
                result = 'C';
            }
            else if (grades[(4 * threshold) - 1] <= averageGrade)
            {
                result = 'D';
            }
            else
            {
                result = 'F';
            }

            return result;
        }

        public override void CalculateStatistics()
        {
            if (5 < Students.Count)
            {
                Console.WriteLine("Ranked grading requires at least 5 students with grades in order to properly calculate a student's overall grade.");
            }
            else
            {
                base.CalculateStatistics();
            }

            return;
        }

        public override void CalculateStudentStatistics(string name)
        {
            if (5 < Students.Count)
            {
                Console.WriteLine("Ranked grading requires at least 5 students with grades in order to properly calculate a student's overall grade.");
            }
            else
            {
                base.CalculateStudentStatistics(name);
            }

            return;
        }
    }
}
