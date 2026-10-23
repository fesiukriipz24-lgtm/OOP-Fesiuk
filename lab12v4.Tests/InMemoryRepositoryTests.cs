using Xunit;
using lab7v4;

namespace lab7v4.Tests;

public class InMemoryRepositoryTests
{
    private readonly InMemoryRepository<Category> _repository;

    public InMemoryRepositoryTests()
    {
        _repository = new InMemoryRepository<Category>();
    }

    [Fact]
    public void Add_ShouldAddElementSuccessfully()
    {
        var category = new Category { Id = 1, Name = "Електроніка", Description = "Опис" };
        _repository.Add(category);
        var result = _repository.GetById(1);
        Assert.NotNull(result);
        Assert.Equal("Електроніка", result.Name);
    }

    [Fact]
    public void GetById_ExistingId_ReturnsElement()
    {
        var category = new Category { Id = 1, Name = "Книги", Description = "Опис" };
        _repository.Add(category);
        var result = _repository.GetById(1);
        Assert.NotNull(result);
        Assert.Equal(1, result.Id);
    }

    [Fact]
    public void GetById_NonExistingId_ReturnsNull()
    {
        var result = _repository.GetById(99);
        Assert.Null(result);
    }

    [Fact]
    public void GetAll_ReturnsAllElements()
    {
        _repository.Add(new Category { Id = 1, Name = "Cat1", Description = "Desc1" });
        _repository.Add(new Category { Id = 2, Name = "Cat2", Description = "Desc2" });
        var list = _repository.GetAll();
        Assert.Equal(2, list.Count());
    }

    [Fact]
    public void Update_ExistingElement_UpdatesValues()
    {
        _repository.Add(new Category { Id = 1, Name = "Old Name", Description = "Old Desc" });
        var updated = new Category { Id = 1, Name = "New Name", Description = "New Desc" };
        _repository.Update(updated);
        var result = _repository.GetById(1);
        Assert.NotNull(result);
        Assert.Equal("New Name", result.Name);
    }

    [Fact]
    public void Update_NonExistingElement_ThrowsKeyNotFoundException()
    {
        var category = new Category { Id = 99, Name = "Ghost", Description = "Ghost" };
        Assert.Throws<KeyNotFoundException>(() => _repository.Update(category));
    }

    [Fact]
    public void Delete_ExistingElement_RemovesIt()
    {
        _repository.Add(new Category { Id = 1, Name = "Cat1", Description = "Desc1" });
        _repository.Delete(1);
        Assert.Null(_repository.GetById(1));
    }

    [Fact]
    public void Delete_NonExistingElement_ThrowsKeyNotFoundException()
    {
        Assert.Throws<KeyNotFoundException>(() => _repository.Delete(99));
    }
}
