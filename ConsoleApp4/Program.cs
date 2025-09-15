using System;
using System.Linq;

class Program
{
    static void Main()
    {
        Console.WriteLine("Введите количество операций (от 2 до 40):");
        int n = int.Parse(Console.ReadLine());
        if (n < 2 || n > 40)
        {
            Console.WriteLine("Ошибка: количество операций должно быть от 2 до 40.");
            return;
        }

        string[] names = new string[n];
        double[] amounts = new double[n];

        for (int i = 0; i < n; i++)
        {
            Console.WriteLine($"Введите операцию {i + 1} в формате: Название;Сумма");
            string input = Console.ReadLine();
            string[] parts = input.Split(';');
            names[i] = parts[0].Trim();
            amounts[i] = double.Parse(parts[1].Trim());
        }

        bool exit = false;
        while (!exit)
        {
            Console.WriteLine("\nМеню:");
            Console.WriteLine("1. Вывод данных");
            Console.WriteLine("2. Статистика");
            Console.WriteLine("3. Сортировка по цене");
            Console.WriteLine("4. Конвертация валюты");
            Console.WriteLine("5. Поиск по названию");
            Console.WriteLine("0. Выход");
            Console.Write("Выберите пункт: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    PrintData(names, amounts);
                    break;
                case "2":
                    PrintStats(amounts);
                    break;
                case "3":
                    BubbleSort(names, amounts);
                    Console.WriteLine("Данные отсортированы по цене.");
                    break;
                case "4":
                    ConvertCurrency(amounts);
                    break;
                case "5":
                    SearchByName(names, amounts);
                    break;
                case "0":
                    exit = true;
                    break;
                default:
                    Console.WriteLine("Некорректный выбор.");
                    break;
            }
        }
    }

    static void PrintData(string[] names, double[] amounts)
    {
        for (int i = 0; i < names.Length; i++)
        {
            Console.WriteLine($"{names[i]} - {amounts[i]} руб.");
        }
    }

    static void PrintStats(double[] amounts)
    {
        Console.WriteLine($"Сумма: {amounts.Sum()} руб.");
        Console.WriteLine($"Среднее: {amounts.Average():F2} руб.");
        Console.WriteLine($"Максимум: {amounts.Max()} руб.");
        Console.WriteLine($"Минимум: {amounts.Min()} руб.");
    }

    static void BubbleSort(string[] names, double[] amounts)
    {
        for (int i = 0; i < amounts.Length - 1; i++)
        {
            for (int j = 0; j < amounts.Length - i - 1; j++)
            {
                if (amounts[j] > amounts[j + 1])
                {
                    double tempAmount = amounts[j];
                    amounts[j] = amounts[j + 1];
                    amounts[j + 1] = tempAmount;
                    string tempName = names[j];
                    names[j] = names[j + 1];
                    names[j + 1] = tempName;
                }
            }
        }
    }

    static void ConvertCurrency(double[] amounts)
    {
        Console.WriteLine("Введите курс валюты (например, 0.013 для доллара):");
        double rate = double.Parse(Console.ReadLine());
        for (int i = 0; i < amounts.Length; i++)
        {
            Console.WriteLine($"{amounts[i]} руб. = {amounts[i] * rate:F2} USD");
        }
    }

    static void SearchByName(string[] names, double[] amounts)
    {
        Console.WriteLine("Введите название для поиска:");
        string search = Console.ReadLine().Trim().ToLower();
        bool found = false;
        for (int i = 0; i < names.Length; i++)
        {
            if (names[i].ToLower().Contains(search))
            {
                Console.WriteLine($"{names[i]} - {amounts[i]} руб.");
                found = true;
            }
        }
        if (!found)
            Console.WriteLine("Ничего не найдено.");
    }
}
