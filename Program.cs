using System;

class Program
{
    static void Main()
    {
        Console.Write("How many students do you want to enter? ");
        int studentCount = int.Parse(Console.ReadLine());

        string[] names = new string[studentCount];
        int[,] grades = new int[studentCount, 5]; // 2D array: [student, grade]

        // Input student names and grades
        for (int i = 0; i < studentCount; i++)
        {
            Console.Write($"\nEnter name of student {i + 1}: ");
            names[i] = Console.ReadLine();

            for (int g = 0; g < 5; g++)
            {
                Console.Write($"Enter grade {g + 1} for {names[i]}: ");
                grades[i, g] = int.Parse(Console.ReadLine());
            }
        }

        // Menu loop
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

            if (choice == "1")
            {
                Console.WriteLine("\nAll students and their 5 grades:");
                for (int i = 0; i < studentCount; i++)
                {
                    Console.Write($"{names[i]} - ");
                    for (int g = 0; g < 5; g++)
                    {
                        Console.Write(grades[i, g]);
                        if (g < 4) Console.Write(", ");
                    }
                    Console.WriteLine();
                }
            }
            else if (choice == "2")
            {
                Console.WriteLine("\nAverage grade of each student:");
                for (int i = 0; i < studentCount; i++)
                {
                    int sum = 0;
                    for (int g = 0; g < 5; g++)
                        sum += grades[i, g];

                    double avg = sum / 5.0;
                    Console.WriteLine($"{names[i]} - {avg:F2}");
                }
            }
            else if (choice == "3")
            {
                Console.Write("\nEnter student name to search: ");
                string searchName = Console.ReadLine();
                bool found = false;

                for (int i = 0; i < studentCount; i++)
                {
                    if (names[i].Equals(searchName, StringComparison.OrdinalIgnoreCase))
                    {
                        Console.Write($"{names[i]} - ");
                        for (int g = 0; g < 5; g++)
                        {
                            Console.Write(grades[i, g]);
                            if (g < 4) Console.Write(", ");
                        }
                        Console.WriteLine();
                        found = true;
                        break;
                    }
                }
                if (!found) Console.WriteLine("Student not found.");
            }
            else if (choice == "4")
            {
                Console.Write("\nEnter grade to search: ");
                int searchGrade = int.Parse(Console.ReadLine());
                bool found = false;

                for (int i = 0; i < studentCount; i++)
                {
                    for (int g = 0; g < 5; g++)
                    {
                        if (grades[i, g] == searchGrade)
                        {
                            Console.WriteLine($"{searchGrade} found for {names[i]}");
                            found = true;
                        }
                    }
                }
                if (!found) Console.WriteLine("Grade not found.");
            }
            else if (choice == "5")
            {
                Console.WriteLine("Exiting program...");
                break;
            }
            else
            {
                Console.WriteLine("Invalid choice, try again.");
            }
        }
    }
}
