namespace UniversityManagement;

public class Student : Person
{
    public double GPA { get; private set; }

    public List<string> Courses { get; } = new List<string>();
    public Student(string id, string fullName, int age, double gpa, List<string> courses) : base(id, fullName, age)
    {
        if (gpa < 0.0 || gpa > 5.0)
        {
            throw new ArgumentOutOfRangeException(nameof(gpa), "GPA must be between 0.0 and 5.0.");
        }

        GPA = gpa;

        if (courses != null)
        {
            foreach (string course in courses)
            {
                if (string.IsNullOrWhiteSpace(course))
                {
                    throw new ArgumentException("Course names cannot be empty or whitespace.", nameof(courses));
                }
            }
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
        string personInfo = base.GetInfo();
        return $"Student: {personInfo}, GPA: {GPA}, Courses: {string.Join(", ", Courses)}";
    }


}
