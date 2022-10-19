using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public abstract class ObjectPool : MonoBehaviour
{
    private List<GameObject> _pool = new List<GameObject>();

    protected void Initialize(List<GameObject> prefabs, int count)
    {
        foreach (var prefab in prefabs)
        {
            for (int i = 0; i < count; i++)
            {
                GameObject spawned = Instantiate(prefab, transform);
                spawned.SetActive(false);

                _pool.Add(spawned);
            }
        }
    }

    protected bool TryGetObject(out GameObject result)
    {
        result = _pool.First(p => p.activeSelf == false);

        return result != null;
    }
}
