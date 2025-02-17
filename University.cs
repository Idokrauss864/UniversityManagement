namespace UniversityManagement;

public class University : IGraduatable
{
    private int MinGraduate = 3;
    private Dictionary<string, Person> people = new Dictionary<string, Person>();

    public void AddPerson(Person person)
    {
        if (people.ContainsKey(person.Id))
        {
            throw new InvalidOperationException($"Person with ID {person.Id} already exists.");
        }
        people[person.Id] = person;
    }

    public Person FindPerson(string id)
    {
        if (!people.ContainsKey(id))
        {
            throw new ArgumentException($"Person with ID {id} does not exist.");
        }
        return people[id];
    }

    public void DisplayAllPeople()
    {
        foreach (Person person in people.Values)
        {
            Console.WriteLine(person.GetInfo());
        }
    }

    public void Graduate()
    {
        List<Student> students = people.Values.OfType<Student>().Where(s => s.GPA >= MinGraduate).ToList();
        if (students.Count > 0)
        {
            foreach (Student student in students)
            {
                people.Remove(student.Id);
                Console.WriteLine($"{student.FullName} has graduate and has remove from the list.");
            }
        }
        else
        {
            Console.WriteLine("No students are eligible to graduate.");
        }
    }
}
