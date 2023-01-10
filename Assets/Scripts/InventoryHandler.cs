using UnityEngine;

public class InventoryHandler : MonoBehaviour
{
    [SerializeField] private InventoryView _inventoryView;
    [SerializeField] private Player _player;

    private IReadOnlyInventory _inventory;

    private void OnEnable()
    {
        _inventory = _player.Inventory;

        _inventory.CreatedCell += OnCreatedCell;
    }

    private void OnDisable()
    {
        _inventory.CreatedCell -= OnCreatedCell;
    }

    private void OnCreatedCell(Cell cell)
    {
        _inventoryView.CreatedCell(cell);
    }
}