using System;
using UnityEngine;

public class ItemDisableZone : MonoBehaviour
{
    [SerializeField] private Castle _castle;

    public event Action ItemInside; 

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Item item))
        {
            ItemInside?.Invoke();
            _castle.TryUpgrade();
        }
    }
}