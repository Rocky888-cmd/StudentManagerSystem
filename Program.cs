using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

class Student
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

class GradeManager
{
    private List<Student> students = new List<Student>();

    public void AddStudent()
    {
        string name;
        while (true)
        {
            Console.Write("\nEnter student name: ");
            string input = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(input) && Regex.IsMatch(input, @"^[a-zA-Z\s]+$"))
            {
                name = input;
                break;
            }
            Console.WriteLine("Invalid name. Use letters only.");
        }

        Student student = new Student(name);

        for (int i = 0; i < 5; i++)
        {
            while (true)
            {
                Console.Write($"Enter grade {i + 1} for {name} (65–100): ");
                if (int.TryParse(Console.ReadLine(), out int grade) && grade >= 65 && grade <= 100)
                {
                    student.AddGrade(grade);
                    break;
                }
                Console.WriteLine("Invalid grade. Enter 65–100.");
            }
        }

        students.Add(student);
    }

    public void ShowAllStudents()
    {
        Console.WriteLine("\nAll students and their grades:");
        foreach (var s in students)
            s.ShowGrades();
    }

    public void ShowAverages()
    {
        Console.WriteLine("\nAverage grade of each student:");
        foreach (var s in students)
            Console.WriteLine($"{s.Name} - {s.GetAverage():F2}");
    }

    public void SearchByName()
    {
        Console.Write("\nEnter student name to search: ");
        string searchName = Console.ReadLine();
        bool found = false;

        foreach (var s in students)
        {
            if (s.Name.Equals(searchName, StringComparison.OrdinalIgnoreCase))
            {
                s.ShowGrades();
                found = true;
                break;
            }
        }
        if (!found) Console.WriteLine("Student not found.");
    }

    public void SearchByGrade()
    {
        Console.Write("\nEnter grade to search: ");
        if (int.TryParse(Console.ReadLine(), out int searchGrade))
        {
            bool found = false;
            foreach (var s in students)
            {
                foreach (var g in s.Grades)
                {
                    if (g == searchGrade)
                    {
                        Console.WriteLine($"{searchGrade} found for {s.Name}");
                        found = true;
                    }
                }
            }
            if (!found) Console.WriteLine("Grade not found.");
        }
        else
        {
            Console.WriteLine("Invalid input. Enter a number.");
        }
    }

    public void Menu()
    {
        while (true)
        {
            Console.WriteLine("\n=== Student Grade Manager ===");
            Console.WriteLine("1. Show all students and grades");
            Console.WriteLine("2. Show average grade of each student");
            Console.WriteLine("3. Search by student name");
            Console.WriteLine("4. Search by grade value");
            Console.WriteLine("5. Exit");
            Console.Write("Choose an option: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1": ShowAllStudents(); break;
                case "2": ShowAverages(); break;
                case "3": SearchByName(); break;
                case "4": SearchByGrade(); break;
                case "5": Console.WriteLine("Exiting program..."); return;
                default: Console.WriteLine("Invalid choice."); break;
            }
        }
    }
}

class Program
{
    static void Main()
    {
        GradeManager manager = new GradeManager();

        int studentCount;
        while (true)
        {
            Console.Write("How many students do you want to enter? ");
            if (int.TryParse(Console.ReadLine(), out studentCount) && studentCount > 0)
                break;
            Console.WriteLine("Please enter a valid number greater than 0.");
        }

        for (int i = 0; i < studentCount; i++)
            manager.AddStudent();

        manager.Menu();
    }
}
