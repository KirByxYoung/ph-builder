using System;
using System.Linq;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Backpack _backpack;

    private Inventory _inventory = new Inventory(20);

    public bool InCastle { get; private set; }

    public Inventory Inventory => _inventory;

    public event Action ItemPickUped;
 
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Item item))
        {
            if (_inventory.IsFull == false && item.CanPickUp)
            {
                ItemPickUped?.Invoke();
                _inventory.AddItem(item);
                _backpack.InitItem(item);
            }
        }
    }
    
    public bool TrySendItem(Type itemType)
    {
        Cell cell = _inventory.Cells.FirstOrDefault(cell => cell.ItemType == itemType);

        return cell == null ? false : true;
    }

    public void RemoveItem(Type itemType, Vector3 position)
    {
        _inventory.RemoveItem(itemType);
        _backpack.RemoveItem(itemType, position);
    }
}