using UnityEngine;

public abstract class CellCreator : MonoBehaviour
{
    [SerializeField] protected CellView Tamplate;

    public void CreatedCell(Cell cell)
    {
        var cellView = Instantiate(Tamplate, transform);

        cellView.SetCell(cell);
    }
}