using System;
using System.Collections.Generic;

public interface IRemoveOnlyInventory
{
    public IReadOnlyList<Cell> Cells { get; }
    public void RemoveItem(Type itemType);
}
