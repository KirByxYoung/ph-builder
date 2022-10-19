using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Cell
{
    private List<IItem> _items;

    public Cell(IItem item)
    {
        _items = new List<IItem>();
        _items.Add(item);
    }

    public IReadOnlyList<IItem> Items => _items;
    public Type ItemType => _items.First().Type;
    public Sprite IconItem => _items.First().Icon;
    public int Count => _items.Count;
    public bool IsEmpty => Count == 0;

    public event Action Empty;
    public event Action ChangedCount;

    public void AddItem(IItem item)
    {
        _items.Add(item);

        ChangedCount?.Invoke();
    }

    public void RemoveItem(Type itemType)
    {
        IItem item = _items.First(item => item.Type == itemType);

        _items.Remove(item);

        if (IsEmpty)
            Empty?.Invoke();
        else
            ChangedCount?.Invoke();
    }
}