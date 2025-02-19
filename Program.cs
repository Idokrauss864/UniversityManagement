namespace UniversityManagement;

public class Program
{
    static void Main(string[] args)
    {
        University university = new University();

        try
        {
            List<string> computerScienceCourses = new List<string> { "Programming 101", "Data Structures", "Algorithms" };
            List<string> biologyClassCourses = new List<string> { "Cell Biology", "Genetics", "Microbiology" };
            List<string> businessCourses = new List<string> { "Accounting", "Management", "Marketing" };
            List<string> engineeringCourses = new List<string> { "Physics", "Calculus", "Electronics" };

            Student student1 = new Student("123456789", "John Smith", 20, 3.7, computerScienceCourses);
            Student student2 = new Student("234567890", "Emily Johnson", 19, 3.9, biologyClassCourses);
            Student student3 = new Student("345678901", "Michael Williams", 22, 3.2, businessCourses);
            Student student4 = new Student("456789012", "Sarah Davis", 21, 3.5, engineeringCourses);

            university.AddPerson(student1);
            university.AddPerson(student2);
            university.AddPerson(student3);
            university.AddPerson(student4);

            List<string> computerScienceSubjects = new List<string> { "Machine Learning", "Artificial Intelligence", "Database Systems" };
            List<string> biologySubjects = new List<string> { "Molecular Biology", "Evolutionary Biology", "Ecology" };

            Professor professor1 = new Professor("567890123", "Dr. Robert Brown", 45, 95000m, computerScienceSubjects);
            Professor professor2 = new Professor("678901234", "Dr. Jennifer Lee", 38, 85000m, biologySubjects);

            university.AddPerson(professor1);
            university.AddPerson(professor2);

            Console.WriteLine("Pre-built university data loaded successfully.");
            Console.WriteLine("\nCurrent University Members:");
            university.DisplayAllPeople();
            Console.WriteLine("\nPress any key to continue to menu...");
            Console.ReadKey();

        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error initializing university data: {ex.Message}");
        }

        bool running = true;

        while (running)
        {
            DisplayMenu();
            running = HandleUserChoice(Console.ReadLine()!, university);
        }
    }

    static void DisplayMenu()
    {
        Console.Clear();
        Console.WriteLine("1. Add a student");
        Console.WriteLine("2. Add a professor");
        Console.WriteLine("3. Enroll student in a course");
        Console.WriteLine("4. Assign subject to a professor");
        Console.WriteLine("5. Display all people");
        Console.WriteLine("6. Exit");
        Console.Write("Choose an option: ");
    }

    static bool HandleUserChoice(string option, University university)
    {
        switch (option)
        {
            case "1":
                AddStudent(university);
                break;
            case "2":
                AddProfessor(university);
                break;
            case "3":
                EnrollStudentInCourse(university);
                break;
            case "4":
                AssignSubjectToProfessor(university);
                break;
            case "5":
                DisplayAllPeople(university);
                break;
            case "6":
                return false;
            default:
                Console.WriteLine("Invalid option.");
                break;
        }
        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();
        return true;
    }

    static void AddStudent(University university)
    {
        try
        {
            string id = InputValidation.GetIdInput("Enter Student ID: ");
            string name = InputValidation.GetFullName("Enter Name: ");
            int age = InputValidation.GetIntInput("Enter Age: ");
            double gpa = InputValidation.GetDoubleInput("Enter GPA: ");

            List<string> courses = new List<string>();

            Student student = new Student(id, name, age, gpa, courses);
            university.AddPerson(student);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    static void AddProfessor(University university)
    {
        try
        {
            string id = InputValidation.GetIdInput("Enter Professor ID: ");
            string name = InputValidation.GetFullName("Enter Name: ");
            int age = InputValidation.GetIntInput("Enter Age: ");
            decimal salary = InputValidation.GetDecimalInput("Enter Salary: ");
            List<string> subjectsTaught = new List<string>();

            Professor professor = new Professor(id, name, age, salary, subjectsTaught);
            university.AddPerson(professor);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    static void EnrollStudentInCourse(University university)
    {
        try
        {
            string studentId = InputValidation.GetIdInput("Enter Student ID: ");
            Student student = (Student)university.FindPerson(studentId);
            if (student != null)
            {
                string courseName = InputValidation.GetFullName("Enter Course Name: ");
                student.EnrollCourse(courseName);
            }
            else
            {
                Console.WriteLine("Student not found.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
    static void AssignSubjectToProfessor(University university)
    {
        try
        {
            string professorId = InputValidation.GetIdInput("Enter Professor ID: ");
            Professor professor = (Professor)university.FindPerson(professorId);
            if (professor != null)
            {
                string subject = InputValidation.GetFullName("Enter Subject: ");
                professor.AssignSubject(subject);
            }
            else
            {
                Console.WriteLine("Professor not found.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
    static void DisplayAllPeople(University university)
    {
        university.DisplayAllPeople();
    }
}