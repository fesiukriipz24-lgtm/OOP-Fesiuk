using System;
using System.Collections.Generic;
using System.Text;

namespace Lab15v4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            Console.WriteLine("==================================================");
            Console.WriteLine("Лабораторна робота №9");
            Console.WriteLine("Студент: Фесюк Роман");
            Console.WriteLine("Група: ІПЗ 3/2");
            Console.WriteLine("Варіант 4: Обробка веб-запитів");
            Console.WriteLine("==================================================\n");

            Console.WriteLine("=== 1. HashSet<string> — Унікальні URL ===");
            HashSet<string> uniqueUrls = new HashSet<string>();

            Console.WriteLine("Додаємо URL адреси у HashSet...");
            uniqueUrls.Add("https://example.com/home");
            uniqueUrls.Add("https://example.com/about");
            uniqueUrls.Add("https://example.com/products");

            bool isAddedDuplicate = uniqueUrls.Add("https://example.com/home");
            Console.WriteLine($"Спроба повторно додати 'https://example.com/home': {(isAddedDuplicate ? "Успішно" : "Відхилено (дублікат)")}");

            Console.WriteLine("\nПоточний список унікальних URL у HashSet:");
            foreach (var url in uniqueUrls)
            {
                Console.WriteLine($" - {url}");
            }

            string searchUrl = "https://example.com/about";
            Console.WriteLine($"\nПеревірка Contains('{searchUrl}'): {uniqueUrls.Contains(searchUrl)}");

            Console.WriteLine($"Видаляємо '{searchUrl}' з HashSet...");
            uniqueUrls.Remove(searchUrl);
            Console.WriteLine($"Перевірка Contains після видалення: {uniqueUrls.Contains(searchUrl)}");
            Console.WriteLine("--------------------------------------------------\n");


            Console.WriteLine("=== 2. Queue<string> — Черга запитів для обробки (FIFO) ===");
            Queue<string> requestQueue = new Queue<string>();

            // Додавання до черги (Enqueue)
            Console.WriteLine("Додаємо веб-запити в чергу...");
            requestQueue.Enqueue("GET /api/users");
            requestQueue.Enqueue("POST /api/login");
            requestQueue.Enqueue("GET /api/products/105");

            Console.WriteLine($"\nПерший запит у черзі (Peek): '{requestQueue.Peek()}'");
            Console.WriteLine($"Кількість елементів у черзі: {requestQueue.Count}");

            Console.WriteLine("\nОбробка запитів за принципом FIFO (First In, First Out):");
            while (requestQueue.Count > 0)
            {
                string currentRequest = requestQueue.Dequeue();
                Console.WriteLine($" [Оброблено]: {currentRequest} | Залишилось у черзі: {requestQueue.Count}");
            }
            Console.WriteLine("--------------------------------------------------\n");


            Console.WriteLine("=== 3. Stack<string> — Історія навігації / Back Button (LIFO) ===");
            Stack<string> navigationHistory = new Stack<string>();

            Console.WriteLine("Користувач переходить по сторінках (Push):");
            navigationHistory.Push("https://site.com/main");
            Console.WriteLine(" Перейшли на: https://site.com/main");
            navigationHistory.Push("https://site.com/catalog");
            Console.WriteLine(" Перейшли на: https://site.com/catalog");
            navigationHistory.Push("https://site.com/item/42");
            Console.WriteLine(" Перейшли на: https://site.com/item/42");

            Console.WriteLine($"\nПоточна сторінка на вершині стека (Peek): '{navigationHistory.Peek()}'");

            Console.WriteLine("\nКористувач натискає кнопку 'Назад' (Pop) — принцип LIFO (Last In, First Out):");
            while (navigationHistory.Count > 0)
            {
                string currentPage = navigationHistory.Pop();
                Console.WriteLine($" Повернення зі сторінки: {currentPage}");
            }

            Console.WriteLine("\n==================================================");
            Console.WriteLine("Демонстрацію роботи колекцій успішно завершено!");
            Console.WriteLine("==================================================");
        }
    }
}