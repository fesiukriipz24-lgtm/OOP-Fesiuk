using System;
using System.Collections.Generic;

namespace lab14v4
{
    // Клас Продукт для демонстрації роботи ForEach з об'єктами
    public class Product
    {
        public string Name { get; set; }
        public decimal Price { get; set; }

        public Product(string name, decimal price)
        {
            Name = name;
            Price = price;
        }

        public override string ToString()
        {
            return $"Продукт: {Name}, Ціна: {Price:C}";
        }
    }

    // Узагальнений клас-утиліта CollectionHelper<T>
    public static class CollectionHelper<T>
    {
        // Варіант 4: Реалізація власного методу ForEach за допомогою Action<T>
        public static void ForEach(IEnumerable<T> collection, Action<T> action)
        {
            if (collection == null)
                throw new ArgumentNullException(nameof(collection), "Колекція не може бути null.");
            
            if (action == null)
                throw new ArgumentNullException(nameof(action), "Делегат action не може бути null.");

            // Власна логіка обходу колекції без LINQ
            foreach (var item in collection)
            {
                action(item);
            }
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.WriteLine("=== Лабораторна робота №8 (Варіант 4) ===");
            Console.WriteLine("=== Демонстрація CollectionHelper<T>.ForEach ===\n");

            // -------------------------------------------------------------
            // Демонстрація 1: Проста колекція типів string (List<string>)
            // -------------------------------------------------------------
            List<string> cities = new List<string> { "Київ", "Львів", "Одеса", "Харків", "Дніпро" };

            Console.WriteLine("1. Виведення елементів List<string> у верхньому регістрі:");
            // Передаємо лямбда-вираз як параметр Action<string>
            CollectionHelper<string>.ForEach(cities, city => Console.WriteLine($" - Місто: {city.ToUpper()}"));

            Console.WriteLine("\n---------------------------------------------------\n");

            // -------------------------------------------------------------
            // Демонстрація 2: Колекція об'єктів (List<Product>)
            // -------------------------------------------------------------
            List<Product> products = new List<Product>
            {
                new Product("Ноутбук", 25000m),
                new Product("Смартфон", 15000m),
                new Product("Навушники", 3000m)
            };

            Console.WriteLine("2. Початковий список продуктів:");
            CollectionHelper<Product>.ForEach(products, p => Console.WriteLine($" - {p}"));

            Console.WriteLine("\n3. Збільшення ціни кожного продукту на 10%:");
            // Модифікуємо об'єкти за допомогою лямбда-виразу у ForEach
            CollectionHelper<Product>.ForEach(products, p => p.Price *= 1.10m);

            Console.WriteLine("\n4. Оновлений список продуктів (після підвищення цін):");
            CollectionHelper<Product>.ForEach(products, p => Console.WriteLine($" - {p}"));

            Console.WriteLine("\n=== Виконання завершено успішно ===");
        }
    }
}