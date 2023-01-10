using System;
using System.Collections.Generic;

public interface IReadOnlyInventory
{
    public IReadOnlyList<Cell> Cells { get; }
    public event Action<Cell> CreatedCell;
}