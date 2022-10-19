using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "First", menuName = "Levels", order = 51)]
public class LevelSettings : ScriptableObject
{
    [SerializeField] private Item[] _items;

    public IReadOnlyList<IItem> Items => _items;
}