using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;

/*
public static class IntExtensions
{
    public static bool IsOdd(this int number)
    {
        return number % 2 != 0;
    }

    public static bool IsEven(this int number)
    {
        return number % 2 == 0;
    }
}

class Program
{
    static void Main()
    {
        int num1 = 5;
        int num2 = 10;

        Console.WriteLine($"{num1} є непарним: {num1.IsOdd()}");
        Console.WriteLine($"{num2} є парним: {num2.IsEven()}");
    }
}

*/
public record Person(string FirstName, string LastName, int Age);

public static class PersonExtensions
{
    public static int MinAge(this Person[] people)
    {
        if (people.Length == 0)
            return 0;

        return people.Min(person => person.Age);
    }

    public static int MaxAge(this Person[] people)
    {
        if (people.Length == 0)
            return 0;

        return people.Max(person => person.Age);
    }

    public static double AverageAge(this Person[] people)
    {
        if (people.Length == 0)
            return 0;

        return people.Average(person => person.Age);
    }
}

class Program
{
    static void Main()
    {
        Console.WriteLine("Введіть інформацію про людей. Для завершення введення введіть 'exit' у поле імені.");

        var people = new List<Person>();

        while (true)
        {
            Console.Write("Ім'я: ");
            string firstName = Console.ReadLine();
            if (firstName.ToLower() == "exit")
                break;

            Console.Write("Прізвище: ");
            string lastName = Console.ReadLine();

            Console.Write("Вік: ");
            if (int.TryParse(Console.ReadLine(), out int age))
            {
                people.Add(new Person(firstName, lastName, age));
            }
            else
            {
                Console.WriteLine("Некоректний вік. Введіть число.");
            }
        }

        int minAge = people.MinAge();
        int maxAge = people.MaxAge();
        double avgAge = people.AverageAge();

        Console.WriteLine($"Мінімальний вік: {minAge}");
        Console.WriteLine($"Максимальний вік: {maxAge}");
        Console.WriteLine($"Середній вік: {avgAge:F2}");
    }
}
