using System;
using System.Collections.Generic;
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
            try
            {
                if (Students.Count > 5)
                {
                    switch (averageGrade)
                    {
                        case double n when (int)n >= 90:
                            return 'A';

                        case double n when (int)n >= 80:
                            return 'B';

                        case double n when (int)n >= 70:
                            return 'C';

                        case double n when (int)n >= 60:
                            return 'D';

                        case double n when (int)n >= 90.00:
                            return 'F';

                    }
                }

                return 'F';



            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw new InvalidOperationException();
            }


        }
    }
}
