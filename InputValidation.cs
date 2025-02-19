namespace UniversityManagement;

public static class InputValidation
{
    private static HashSet<string> usedIds = new HashSet<string>();

    public static string GetIdInput(string prompt, bool checkUnique = true)
    {
        while (true)
        {
            Console.Write(prompt);
            string result = Console.ReadLine()!;

            if (result.Length != 9)
            {
                throw new ArgumentException("ID number must be 9 digits long.");
            }

            if (!result.All(char.IsDigit))
            {
                throw new ArgumentException("ID number must contain only digits.");
            }

            if (checkUnique && usedIds.Contains(result))
            {
                throw new ArgumentException("This ID is already taken. Please enter a different ID.");
            }

            if (checkUnique)
            {
                usedIds.Add(result);
            }

            return result;
        }
    }
    public static string GetFullName(string prompt)
    {
        Console.Write(prompt);
        string result = Console.ReadLine()!;
        if(string.IsNullOrWhiteSpace(result))
        {
            throw new ArgumentException("Full name cannot be empty or whitespace.");
        }
        if(result.Length < 2)
        {
            throw new ArgumentException("Full name must be at least 2 characters long.");
        }
        if(result.Length > 100)
        {
            throw new ArgumentException("Full name must be at most 100 characters long.");
        }
        if (!System.Text.RegularExpressions.Regex.IsMatch(result, @"^[a-zA-Z\s-]+$"))
        {
            throw new ArgumentException("Full name must contain only letters, spaces, and hyphens.");
        }
        return result;
    }

    public static int GetIntInput(string prompt)
    {
        Console.Write(prompt);
        while (true)
        {
            if (int.TryParse(Console.ReadLine(), out int result) && result>16) //added condition to check if age is greater than 16
            {
                return result;
            }
            else
            {
                throw new ArgumentException("Invalid input. Please enter a valid age for the university. (16 and above)");
            }
        }
    }
    public static double GetDoubleInput(string prompt)
    {
        Console.Write(prompt);
        while (true)
        {
            if (double.TryParse(Console.ReadLine(), out double result) && result > 0)
            {
                return result;
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a valid number.");
            }
        }
    }
    public static decimal GetDecimalInput(string prompt)
    {
        Console.Write(prompt);
        while (true)
        {
            if (decimal.TryParse(Console.ReadLine(), out decimal result) && result > 0)
            {
                return result;
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a valid salary.");
            }
        }
    }
}
