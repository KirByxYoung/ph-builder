using System.Collections.Generic;
using UnityEngine;

public class Spawner : ObjectPool
{
    [SerializeField] private List<GameObject> _tamplates;
    [SerializeField] private float _spawnRange;
    [SerializeField] private int _quantityPerTamplate;

    private Vector3 _startPoint;

    private void Awake()
    {
        _startPoint = transform.position;

        Initialize(_tamplates, _quantityPerTamplate);
        Spawn();       
    }

    public void Spawn()
    {
        for (int i = 0; i < _quantityPerTamplate * _tamplates.Count; i++)
        {
            if (TryGetObject(out GameObject gameObject))
            {
                gameObject.SetActive(true);
                gameObject.transform.position = GetRandomSpawnPoint();
            }
        }
    }

    private Vector3 GetRandomSpawnPoint()
    {
        return new Vector3(Random.Range(_startPoint.x - _spawnRange, _startPoint.x + _spawnRange),
            _startPoint.y, Random.Range(_startPoint.z - _spawnRange, _startPoint.z + _spawnRange));
    }
}
