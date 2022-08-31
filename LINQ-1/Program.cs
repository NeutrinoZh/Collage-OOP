using Faker;
using System;

class Person {
    private string name,
                   adress;
    private uint age;
    private Guid id;

    public string Name { get { return name; } }
    public string Adress { get { return adress; } }
    public uint Age { get { return age; } }
    public Guid Id { get { return id; } }

    public Person(string name, string adress, uint age) {
        id = Guid.NewGuid();
        this.name = name;
        this.adress = adress;
        this.age = age;
    }

    public static Person Random() {
        return new Person(
            Faker.Name.First(),
            Faker.Address.Country(),
            (uint)Faker.RandomNumber.Next(100)
        );
    }
}

class Program {
    static string border = new string('=', 100);

    public static void PrintPeople(IEnumerable<Person> collection, string title) {
        Console.WriteLine(title + ":");
        foreach (var person in collection)
            Console.WriteLine($"Name: {person.Name}, Age: {person.Age}, Country: {person.Adress}");
        Console.WriteLine(border);
    }

    public static void TaskOne(List<Person> people) {
        var query = from person in people
                        where person.Age > 60
                        orderby person.Age
                        select person;
        PrintPeople(query, "People with age > 60");
    }

    public static void TaskTwo(List<Person> people) {
        var query = from person in people
                        where person.Age > 12
                        where person.Age < 18
                        orderby person.Age
                        select person;

        PrintPeople(query, "People with age > 12 and < 18");
    }

    public static void TaskThree(List<Person> people) {
        double age = people.Average(person => person.Age);

        Console.WriteLine("Average Age all people:" + age);
        Console.WriteLine(border);
    }

    public static void TaskFour(List<Person> people, string name) {
        var query = people.Select((p, i) => new { p, i })
                           .Where(item => item.p.Name == name)
                           .Select(p => p.i);

        Console.WriteLine(name + ":");
        foreach (var person in query)
            Console.WriteLine($"Name: {name}, position: {person}");
        Console.WriteLine(border);
    }

    public static void TaskFifth(List<Person> people) {
        var query = from item in people
                    orderby item.Age
                    select item;
        var person = query.Last();

        Console.WriteLine($"Max age person: {person.Name}, Age: {person.Age}, Country: {person.Adress}");
        Console.WriteLine(border);
    }

    public static void TaskSixth(List<Person> people) {
        var query = people.SkipWhile(item => item.Age < 60);

        PrintPeople(query, "People with age < 60 (SkipWhile)");
    }

    public static void TaskSeventh(List<Person> people, char firstLetter) {
        var query = from person in people
                    where person.Name[0] == firstLetter
                    select person;

        PrintPeople(query, $"People with '{firstLetter}' first letter in name");
    }

    public static void TaskEighth(List<Person> people, string name) {
        var query = from item in people
                    where item.Name != name
                    select item;

        List<Person> new_peoples = new List<Person>();
        foreach (var person in query)
            new_peoples.Add(person);

        PrintPeople(new_peoples, $"People after removing people with name {name}");
    }

    public static void Main(string[] args) {
        List<Person> people = new List<Person>();
        for (var i = 0; i < 100; ++i) // 5000
            people.Add(Person.Random());

        PrintPeople(people, "all people");

        TaskOne(people);
        TaskTwo(people);
        TaskThree(people);
        TaskFour(people, people[0].Name);
        TaskFifth(people);
        TaskSixth(people);
        TaskSeventh(people, 'J');
        TaskEighth(people, people[0].Name);
    }
}