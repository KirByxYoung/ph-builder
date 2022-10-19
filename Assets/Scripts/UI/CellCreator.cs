using UnityEngine;

public abstract class CellCreator : MonoBehaviour
{
    [SerializeField] protected CellView Tamplate;

    protected abstract void Init();

    private void Start()
    {
        Init();
    }

    protected void OnCreatedCell(Cell cell)
    {
        var cellView = Instantiate(Tamplate, transform);

        cellView.SetCell(cell);
    }
}