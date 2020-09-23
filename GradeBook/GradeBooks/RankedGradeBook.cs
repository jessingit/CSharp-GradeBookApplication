using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GradeBook.Enums;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook : BaseGradeBook
    {
        public RankedGradeBook(string name) : base(name)
        {
            Type = GradeBookType.Ranked;
        }

        public override char GetLetterGrade(double averageGrade)
        {
            
            // needs to be 5 to work
            if (Students.Count < 5) throw new InvalidOperationException("This system requires at least 5 students");
            //gets 20%
            var studentRank = (int) Math.Ceiling(Students.Count * 0.2);
            //sort it into descending easier to compare-- linq -- foreach e in Ag , select 1 not all to list
            var curGrade = Students.OrderByDescending(e => e.AverageGrade).Select(e => e.AverageGrade).ToList();
            //1 sets the index 
            if (curGrade[studentRank-1] <= averageGrade)
            {
                 return 'A';
            }
            else if (curGrade[(studentRank*2) - 1] <= averageGrade)
            {
                return 'B';
            }
            else if (curGrade[(studentRank * 3) - 1] <= averageGrade)
            {
                return 'C';
            }
            else if (curGrade[(studentRank * 4) - 1] <= averageGrade)
            {
                return 'D';
            }
            else return 'F';
            
            
        }

        public override void CalculateStatistics()
        {
            if (Students.Count < 5)
            {
                Console.WriteLine("Ranked grading requires at least 5 students with grades in order to properly calculate a student's overall grade.");
            }
            else base.CalculateStatistics();
        }

        public override void CalculateStudentStatistics(string name)
        {
            if (Students.Count < 5)
            {
                Console.WriteLine("Ranked grading requires at least 5 students with grades in order to properly calculate a student's overall grade."; 
            }
            else base.CalculateStudentStatistics(name);
        }
    }
}
