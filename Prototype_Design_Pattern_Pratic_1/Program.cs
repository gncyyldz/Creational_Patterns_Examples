
Person person1 = new("Gençay", "Yıldız", Department.C, 100, 10);
//Person person2 = new("Ahmet", "Yıldız", Department.C, 100, 10);


Person person2 = person1.Clone();
person2.Name = "Ahmet";

Console.WriteLine();

//Abstract Prototype
interface IPersonCloneable
{
    Person Clone();
}

//Concrete Prototype
class Person : IPersonCloneable
{
    public Person(string name, string surname, Department department, int salary, int premium)
    {
        Name = name;
        Surname = surname;
        Department = department;
        Salary = salary;
        Premium = premium;
        Console.WriteLine("Person nesnesi oluşturuldu.");
    }

    public string Name { get; set; }
    public string Surname { get; set; }
    public Department Department { get; set; }
    public int Salary { get; set; }
    public int Premium { get; set; }

    public Person Clone()
    {
        return (Person)base.MemberwiseClone();
    }
}

enum Department
{
    A, B, C
}