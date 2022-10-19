using System;
using System.Collections;
using System.Linq;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Backpack _backpack;

    private Inventory _inventory = new Inventory(20);
    private WaitForSeconds _delay = new WaitForSeconds(.3f);

    private bool _inCastle = false;

    public Inventory Inventory => _inventory;
 
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Item item))
        {
            if (_inventory.IsFull == false)
            {
                _inventory.AddItem(item);
                _backpack.InitItem(item);
            }
            else
            {

            }
        }

        if (other.TryGetComponent(out Castle castle))
        {
            _inCastle = true;
            StartCoroutine(GiveItems(castle));
        }
    }

    private Type GetItemType(IRemoveOnlyInventory castleInventory)
    {
        if (castleInventory.Cells.Count <= 0)
            return null;

        foreach (var castleCell in castleInventory.Cells)
        {
            Type CastleItemType = castleCell.ItemType;

            foreach (var cell in _inventory.Cells)
            {
                if (cell.ItemType == CastleItemType)
                    return cell.ItemType;
            }
        }

        return null;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out Castle castle))
        {
            _inCastle = false;
        }
    }

    private IEnumerator GiveItems(Castle castle)
    {
        while (_inCastle)
        {
            yield return _delay;

            Type itemType = GetItemType(castle.Inventory);

            if (itemType == null)
                continue;

            _inventory.RemoveItem(itemType);
            castle.Inventory.RemoveItem(itemType);
            castle.TryUpgrade();

            Vector3 newPosition = castle.transform.position;

            newPosition.y = 3;

            _backpack.RemoveItem(itemType, newPosition);
        }
    }
}