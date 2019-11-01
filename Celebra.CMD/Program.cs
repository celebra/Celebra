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
            var exerciseController = new ExerciseController(userController.CurrentUser);

            if (userController.isNewUser)
            {
                Console.WriteLine("Введите ваш пол:");

                var gender = Console.ReadLine();
                var birthData = ParseDateTime("датa рождения");
                var weight = ParseDouble("вес");
                var height = ParseDouble("рост");

                userController.SetNewUserData(gender, birthData, weight, height);
            }

            while (true)
            {
                Console.WriteLine("Что вы хотите сделать ? ");
                Console.WriteLine("E - ввести прием пищи ");
                Console.WriteLine("A - ввести упражнение ");
                Console.WriteLine("Q - Exit ");

                var key = Console.ReadKey();
                Console.WriteLine();

                switch (key.Key)
                {
                    case ConsoleKey.E:
                        var foods = EnterEating();
                        eatingController.Add(foods.Food, foods.Weight);

                        foreach (var item in eatingController.Eating.Foods)
                        {
                            Console.WriteLine($"\t{item.Key} - {item.Value}");
                        }
                        break;

                    case ConsoleKey.A:
                        var exe = EnterExercise();
                        exerciseController.Add(exe.Activity, exe.Begin, exe.End);

                        foreach (var item in exerciseController.Exercises)
                        {
                            Console.WriteLine($"\t{item.Activity} с {item.Start.ToShortTimeString()} до {item.Finish.ToShortTimeString()}");
                        }
                        break;

                    case ConsoleKey.Q:
                        Environment.Exit(0);
                        break;
                }
            }
            //Console.WriteLine(" ");
            //Console.WriteLine(userController.CurrentUser);
            Console.ReadLine();
        }

        private static (DateTime Begin, DateTime End, Activity Activity) EnterExercise()
        {
            Console.Write("Введите название упражнения: ");
            var name = Console.ReadLine();
            var energy = ParseDouble("расход энергии в минуту ");
            var begin = ParseDateTime("начало упражнения");
            var end = ParseDateTime("окончание упражнения");
            var activity = new Activity(name, energy);
            return (begin, end, activity);
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
        private static DateTime ParseDateTime(string value)
        {
            DateTime birthData;
            while (true)
            {
                Console.WriteLine($"Введите {value} (dd.MM.yyyy):");
                if (DateTime.TryParse(Console.ReadLine(), out birthData))
                {
                    break;
                }
                else
                {
                    Console.WriteLine($"Ошибка! Введите {value} (dd.MM.yyyy):");
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
