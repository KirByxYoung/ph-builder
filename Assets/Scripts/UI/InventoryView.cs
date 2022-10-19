using UnityEngine;

public class InventoryView : CellCreator
{
    [SerializeField] private Player _player;

    private Inventory _inventory;

    private void OnDisable()
    {
        _inventory.CreatedCell -= OnCreatedCell;
    }

    protected override void Init()
    {
        _inventory = _player.Inventory;

        _inventory.CreatedCell += OnCreatedCell;
    }
}