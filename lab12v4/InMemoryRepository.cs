namespace lab7v4;

public class InMemoryRepository<T> : IRepository<T> where T : IEntity
{
    private readonly List<T> _items = new();

    public T? GetById(int id)
    {
        return _items.FirstOrDefault(x => x.Id == id);
    }

    public IEnumerable<T> GetAll()
    {
        return _items.ToList();
    }

    public void Add(T item)
    {
        ArgumentNullException.ThrowIfNull(item);
        if (_items.Any(x => x.Id == item.Id))
        {
            throw new ArgumentException($"Елемент з ID {item.Id} вже існує.");
        }
        _items.Add(item);
    }

    public void Update(T item)
    {
        ArgumentNullException.ThrowIfNull(item);
        var existingIndex = _items.FindIndex(x => x.Id == item.Id);
        if (existingIndex == -1)
        {
            throw new KeyNotFoundException($"Елемент з ID {item.Id} не знайдено.");
        }
        _items[existingIndex] = item;
    }

    public void Delete(int id)
    {
        var existing = GetById(id);
        if (existing == null)
        {
            throw new KeyNotFoundException($"Елемент з ID {id} не знайдено.");
        }
        _items.Remove(existing);
    }
}
