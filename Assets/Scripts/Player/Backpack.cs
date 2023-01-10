using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Backpack : MonoBehaviour
{
    [SerializeField] private Vector3 _offset;
    [SerializeField] private Transform _pool;

    private List<Vector3> _positions = new List<Vector3>();
    private List<Item> _items = new List<Item>();
    private WaitForSeconds _delay = new WaitForSeconds(.5f);

    private float timeMoveBackpack = .3f;
    private float timeMoveCastle = 1f;

    private bool IsEven => _items.Count % 2 == 0;

    public event Action ItemTransferred;

    public void InitItem(Item item)
    {
        item.transform.parent = transform;
        _items.Add(item);

        item.MoveLocal(GetPosition(IsEven), timeMoveBackpack);
        item.CanPickUp = false;
    }

    public void RemoveItem(Type itemType, Vector3 position)
    {
        Item item = GetItem(itemType);

        if (item == null)
            return;

        _items.Remove(item);

        item.Move(position, timeMoveCastle);

        GiveItem(item);
        ResetPosition();
    }

    private void GiveItem(Item item)
    {
        item.transform.parent = _pool.transform;
        ItemTransferred?.Invoke();
    }

    private void ResetPosition()
    {
        _positions = new List<Vector3>();

        for (int i = 0; i < _items.Count; i++)
        {
            if (i % 2 == 0)
                _items[i].MoveLocal(GetPosition(false), timeMoveBackpack);
            else
                _items[i].MoveLocal(GetPosition(true), timeMoveBackpack);
        }
    }

    private Item GetItem(Type itemType)
    {
        Item item = _items.FirstOrDefault(item => item.Type == itemType);

        return item;
    }

    private Vector3 GetPosition(bool isEven)
    {
        Vector3 position = new Vector3();

        int ratio = _positions.Count / 2;

        position.y = _offset.y * ratio;

        if (isEven)
            position.z = _offset.z;

        _positions.Add(position);

        return position;
    }
}