using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityManagement;

public static class InputValidation
{
    public static string GetIdInput(string prompt)
    {
        Console.Write(prompt);
        string result = Console.ReadLine()!;
        if (result.Length != 9)
        {
            throw new ArgumentException("ID number must be 9 digits long.");
        }
        if(!result.All(char.IsDigit))
        {
            throw new ArgumentException("ID number must contain only digits.");
        }
        return result;
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
                throw new ArgumentException("Invalid input. Please enter a valid number.");
            }
        }
    }
    public static double GetDoubleInput(string prompt)
    {
        Console.Write(prompt);
        while (true)
        {
            if (double.TryParse(Console.ReadLine(), out double result))
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
            if (decimal.TryParse(Console.ReadLine(), out decimal result))
            {
                return result;
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a valid number.");
            }
        }
    }
}
