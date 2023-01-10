using System;
using UnityEngine;
using DG.Tweening;

public abstract class Item : MonoBehaviour, IItem
{
    [SerializeField] private Sprite _icon;

    private Vector3 _angleRotation = new Vector3(0, 90, 0);

    public bool CanPickUp { get; set; } = true;

    public Sprite Icon => _icon;
    public Type Type => GetType();

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out ItemDisableZone itemDisableZone))
        {
            gameObject.SetActive(false);
            CanPickUp = true;
        }
    }

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