using Celebra.BL.Controller;
using Celebra.BL.Model;
using System;
using System.Globalization;
using System.Resources;

namespace Celebra.CMD
{
    class Program
    {
        static void Main(string[] args)
        {
            
            var culture = CultureInfo.CreateSpecificCulture("ru-ru");
            var resourceManager = new ResourceManager("Celebra.CMD.Languages.Resource", typeof(Program).Assembly);

            Console.WriteLine(resourceManager.GetString("Hello", culture));
            Console.WriteLine(resourceManager.GetString("EnterUserName", culture));
            var name = Console.ReadLine();

            var userController = new UserController(name);
            var eatingController = new EatingController(userController.CurrentUser);

            if (userController.isNewUser)
            {
                Console.WriteLine("Введите ваш пол:");

                var gender = Console.ReadLine();
                var birthData = ParseDateTime();
                var weight = ParseDouble("вес");
                var height = ParseDouble("рост");

                userController.SetNewUserData(gender, birthData, weight, height);
            }

            Console.WriteLine("Что вы хотите сделать ? ");
            Console.WriteLine("E - ввести прием пищи ");

            var key = Console.ReadKey();
            Console.WriteLine();

            if (key.Key == ConsoleKey.E)
            {
                var foods = EnterEating();
                eatingController.Add(foods.Food, foods.Weight);

                foreach (var item in eatingController.Eating.Foods)
                {
                    Console.WriteLine($"\t{item.Key} - {item.Value}");
                }
            }

            Console.WriteLine(" ");

            Console.WriteLine(userController.CurrentUser);
            Console.ReadLine();
        }

        private static (Food Food, double Weight) EnterEating()
        {
            Console.Write("Введите имя продукта: ");
            var food = Console.ReadLine();
            var calories = ParseDouble("калорийность");
            var prots = ParseDouble("белки");
            var fats = ParseDouble("жиры");
            var carbs = ParseDouble("углеводы");
            var weight = ParseDouble("вес порции");
            var product = new Food(food, calories, prots, fats, carbs);

            return (Food: product, Weight: weight);
        }

        private static DateTime ParseDateTime()
        {
            DateTime birthData;
            while (true)
            {
                Console.WriteLine("Введите дату рождения (dd.MM.yyyy):");
                if (DateTime.TryParse(Console.ReadLine(), out birthData))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Ошибка! Введите дату рождения (dd.MM.yyyy):");
                }
            }

            return birthData;
        }

        private static double ParseDouble(string name)
        {
            while (true)
            {
                Console.Write($"Введите {name} : ");
                if (double.TryParse(Console.ReadLine(), out double value))
                {
                    return value;
                }
                else
                {
                    Console.WriteLine($"Ошибка! Введите {name}");
                }
            }
        }
    }
}
