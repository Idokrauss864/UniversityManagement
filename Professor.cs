﻿namespace UniversityManagement;

public class Professor : Person
{
    public decimal Salary { get; private set; }
    public List<string> SubjectsTaught { get; } = new List<string>();
    public Professor(string id, string fullName, int age, decimal salary, List<string> subjectsTaught) : base(id, fullName, age)
    {
        if (salary <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(salary), "Salary must be greater than zero.");
        }

        Salary = salary;
        if (subjectsTaught != null)
        {
            foreach (string subject in subjectsTaught)
            {
                if (string.IsNullOrWhiteSpace(subject))
                {
                    throw new ArgumentException("Subject names cannot be empty or whitespace.", nameof(subjectsTaught));
                }
            }
            SubjectsTaught.AddRange(subjectsTaught);
        }
    }
    public void AssignSubject(string subject)
    {
        if (string.IsNullOrWhiteSpace(subject))
        {
            throw new ArgumentException("Subject name cannot be empty or whitespace.");
        }
        SubjectsTaught.Add(subject);
    }

    public override string GetInfo()
    {
        string professorInfo = base.GetInfo();
        return $"Professor: {professorInfo},Salary: {Salary}, Subjects Taught: {string.Join(", ", SubjectsTaught)}";
    }
}
