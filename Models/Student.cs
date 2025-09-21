using System;
using System.Collections.Generic;

namespace StudentGradesManager.Models
{
    public class Student
    {
        public string Name { get; private set; }
        public List<int> Grades { get; private set; }

        public Student(string name)
        {
            Name = name;
            Grades = new List<int>();
        }

        public void AddGrade(int grade)
        {
            if (grade >= 65 && grade <= 100)
                Grades.Add(grade);
            else
                throw new ArgumentException("Grade must be between 65 and 100.");
        }

        public double GetAverage()
        {
            if (Grades.Count == 0) return 0;
            int sum = 0;
            foreach (var g in Grades)
                sum += g;
            return sum / (double)Grades.Count;
        }

        public void ShowGrades()
        {
            Console.Write($"{Name} - ");
            for (int i = 0; i < Grades.Count; i++)
            {
                Console.Write(Grades[i]);
                if (i < Grades.Count - 1) Console.Write(", ");
            }
            Console.WriteLine();
        }
    }
}
