namespace UniversityManagement;

public class Student : Person
{
    public double GPA { get; private set; }

    public List<string> Courses { get; } = new List<string>();
    public Student(string id, string fullName, int age, double gpa, List<string> courses) : base(id, fullName, age)
    {
        GPA = gpa;
        if (courses != null)
        {
            Courses.AddRange(courses);
        }
    }

    public void EnrollCourse(string course)
    {
        if (string.IsNullOrWhiteSpace(course))
        {
            throw new ArgumentException("Course name cannot be empty or whitespace.");
        }
        Courses.Add(course);
    }



    public override string GetInfo()
    {
        return $"Student: {FullName}, ID: {Id}, Age: {Age}, GPA: {GPA}, Courses: {string.Join(", ", Courses)}";
    }


}
