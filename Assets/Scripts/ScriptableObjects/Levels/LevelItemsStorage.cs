using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "_0_Level", menuName = "ItemsStorage", order = 51)]
public class LevelItemsStorage : ScriptableObject
{
    [SerializeField] private Item[] _items;

    public IReadOnlyList<IItem> Items => _items;
}