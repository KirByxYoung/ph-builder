using System.Collections.Generic;
using UnityEngine;
using IJunior.TypedScenes;
using System;
using System.Collections;
using System.Linq;

[RequireComponent(typeof(SphereCollider))]
public class Castle : MonoBehaviour, ISceneLoadHandler<ICastleLevel>
{
    private Inventory _inventory = new Inventory();
    private WaitForSeconds _delay = new WaitForSeconds(0.3f);
    private SphereCollider _collider;

    private ICastleLevel _level;
    private Queue<LevelItemsStorage> _levelItemsStorage;

    public IReadOnlyInventory Inventory => _inventory;

    public event Action<Cell> WritedCells;
    public event Action Finished;
    public event Action Upgraded;

    private void Start()
    {
        _collider = GetComponent<SphereCollider>();
        CallAction();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Player player))
        {
            StartCoroutine(TakeItem(player));
        }
    }

    public IEnumerator TakeItem(Player player)
    { 
        foreach (var cell in _inventory.Cells.ToArray())
        {
            while (cell.Items.Count > 0 && player.TrySendItem(cell.ItemType))
            {
                yield return _delay;
                player.RemoveItem(cell.ItemType, transform.position);
                RemoveItem(cell.ItemType);
            }
        }
    }

    public void OnSceneLoaded(ICastleLevel level)
    {
        _level = level;
        _levelItemsStorage = new Queue<LevelItemsStorage>(level.LevelItemsStorages);

        WriteCells(_levelItemsStorage.Dequeue());
    }

    public void CallAction()
    {
        foreach (var cell in _inventory.Cells)
            WritedCells?.Invoke(cell);
    }

    public ICastleLevel GetCastleLevel()
    {
        return _level;
    }

    private void WriteCells(LevelItemsStorage levelSettings)
    {
        _inventory.Capacity = levelSettings.Items.Count;

        foreach (var item in levelSettings.Items)
            _inventory.AddItem(item);
    }

    public bool TryUpgrade()
    {
        if (_inventory.IsEmpty)
        {
            if (_levelItemsStorage.Count <= 0)
            {
                Finished?.Invoke();
            }
            else
            {
                _collider.enabled = false;
                WriteCells(_levelItemsStorage.Dequeue());
                CallAction();
                Upgraded?.Invoke();
                _collider.enabled = true;
            }

            return true;
        }
        else
        {
            return false;
        }
    }

    private void RemoveItem(Type itemType)
    {
        _inventory.RemoveItem(itemType);
    }
}