using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Inventory : IRemoveOnlyInventory
{
    private List<Cell> _cells = new List<Cell>();

    public IReadOnlyList<Cell> Cells => _cells;

    public bool IsFull => Capacity <= CountItems();
    public bool IsEmpty => Cells.Count <= 0;
    public int Capacity { get; set; }

    public event Action<Cell> CreatedCell;

    public Inventory(int capacity)
    {
        Capacity = capacity;
    }

    public Inventory() { }

    public bool ExistItem(Type itemType, out IItem item)
    {
        var cell = Cells.FirstOrDefault(cell => cell.ItemType == itemType);

        item = cell.Items.FirstOrDefault();

        return item == null ? false : true;
    }

    public void AddItem(IItem item)
    {
        Cell cell = Cells.FirstOrDefault(cell => cell.ItemType == item.Type);

        if (cell == null)
            CreateCell(item);
        else
            cell.AddItem(item);
    }

    public void RemoveItem(Type itemType)
    {
        Cell cell = Cells.FirstOrDefault(cell => cell.ItemType == itemType);

        if (cell == null)
            throw new UnityException("ArgumentNullException");

        cell.RemoveItem(itemType);

        if (cell.IsEmpty)
            RemoveCell(cell);
    }

    private int CountItems()
    {
        int resualt = 0;

        foreach (var cell in _cells)
            resualt += cell.Count;

        return resualt;
    }

    private void CreateCell(IItem item)
    {
        Cell cell = new Cell(item);

        _cells.Add(cell);
        CreatedCell?.Invoke(cell);
    }

    private void RemoveCell(Cell cell)
    {
        _cells.Remove(cell);
    }
}