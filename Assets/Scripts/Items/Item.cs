using System;
using UnityEngine;
using DG.Tweening;

public abstract class Item : MonoBehaviour, IItem
{
    [SerializeField] private Sprite _icon;

    private Vector3 _angleRotation = new Vector3(0, 90, 0);

    public Sprite Icon => _icon;
    public Type Type => GetType();

    public void MoveLocal(Vector3 position, float timeMove)
    {
        transform.DOLocalMove(position, timeMove);
        transform.DOLocalRotate(_angleRotation, timeMove);
    }

    public void Move(Vector3 position, float timeMove)
    {
        transform.DOMove(position, timeMove);
    }
}