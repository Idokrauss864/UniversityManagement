namespace UniversityManagement;

public abstract class Person
{
    public string Id { get; private set; }
    public string FullName { get; private set; }
    public int Age { get; private set; }

    public Person(string id, string fullName, int age)
    {
        Id = id;
        FullName = fullName;
        Age = age;
    }

    public virtual string GetInfo()
    {
        return $"{FullName}, ID: {Id}, Age: {Age}";

    }
}

