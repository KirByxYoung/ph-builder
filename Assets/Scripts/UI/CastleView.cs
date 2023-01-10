using UnityEngine;

public class CastleView : CellCreator
{
    [SerializeField] private Castle _castle;

    private void Update()
    {
        transform.position = Camera.main.WorldToScreenPoint(_castle.transform.position);
    }
}