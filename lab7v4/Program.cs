using lab7v4;

Console.WriteLine("=== Демонстрація роботи InMemoryRepository ===");

IRepository<Category> repository = new InMemoryRepository<Category>();

// Add
repository.Add(new Category { Id = 1, Name = "Електроніка", Description = "Гаджети та пристрої" });
repository.Add(new Category { Id = 2, Name = "Книги", Description = "Художня та наукова література" });

// GetAll
Console.WriteLine("\nВсі категорії:");
foreach (var cat in repository.GetAll())
{
    Console.WriteLine($"ID: {cat.Id}, Name: {cat.Name}, Description: {cat.Description}");
}

// Update
repository.Update(new Category { Id = 1, Name = "Цифрова електроніка", Description = "Оновлений опис" });

// GetById
var updatedCat = repository.GetById(1);
Console.WriteLine($"\nОновлено ID 1: {updatedCat?.Name} - {updatedCat?.Description}");

// Delete
repository.Delete(2);
Console.WriteLine("\nПісля видалення ID 2:");
foreach (var cat in repository.GetAll())
{
    Console.WriteLine($"ID: {cat.Id}, Name: {cat.Name}");
}
