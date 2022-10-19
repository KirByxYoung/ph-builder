using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CellView : MonoBehaviour
{
    [SerializeField] private TMP_Text _countText;
    [SerializeField] protected Image _icon;

    private Cell _cell;

    private void OnDisable()
    {
        _cell.Empty -= OnEmpty;
        _cell.ChangedCount -= OnChangedCount;
    }

    public void SetCell(Cell cell)
    {
        _cell = cell;
        _icon.sprite = _cell.IconItem;
        _cell.Empty += OnEmpty;
        _cell.ChangedCount += OnChangedCount;

        OnChangedCount();
    }

    private void OnChangedCount()
    {
        _countText.text = _cell.Count.ToString();
    }

    private void OnEmpty()
    {
        Destroy(gameObject);
    }
}