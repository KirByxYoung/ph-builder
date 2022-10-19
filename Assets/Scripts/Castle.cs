using System.Collections.Generic;
using UnityEngine;

public class Castle : MonoBehaviour
{
    [SerializeField] private List<LevelSettings> _levels;

    private Inventory _inventory = new Inventory();

    private int _currentLevel;
    private int _needUpgrades;

    public IRemoveOnlyInventory Inventory => _inventory;

    private void Awake()
    {
        //OnScenLoad
         _currentLevel = 0;
        _needUpgrades = 2;

        WriteCells(GetNextLevel(_currentLevel));
    }

    public void TryUpgrade()
    {
        if (_inventory.IsEmpty)
        {
            if (_needUpgrades <= 0)
            {
                Debug.Log("Completed");
            }
            else
            {
                Debug.Log("I'am upgrading");
                WriteCells(GetNextLevel(_currentLevel));
            }
        }
    }

    private void WriteCells(LevelSettings levelSettings)
    {
        _inventory.Capacity = levelSettings.Items.Count;

        foreach (var item in levelSettings.Items)
            _inventory.AddItem(item);
    }

    private LevelSettings GetNextLevel(int numberCurrentLevel)
    {
        if (_levels.Count <= numberCurrentLevel)
            throw new UnityException("Index was out range");

        _currentLevel++;
        _needUpgrades--;

        return _levels[numberCurrentLevel];
    }
}