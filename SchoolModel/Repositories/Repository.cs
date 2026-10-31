using System.Collections.Generic;

using System.Linq;

public class Repository<T> where T : class, IEntity

{
    private readonly List<T> _items = new();
    public IEnumerable<T> GetAll() => _items;
    public T? GetById(int id) => _items.FirstOrDefault(x => x.Id == id);
    public void Add(T item) => _items.Add(item);

    public void Update(T item)
    {
        var existing = GetById(item.Id);
        if (existing != null)
        {
            var index = _items.IndexOf(existing);
            _items[index] = item;
        }
    }

    public void Delete(int id)
    {
        var item = GetById(id);
        if (item != null)
        {
            _items.Remove(item);
        }
    }
}