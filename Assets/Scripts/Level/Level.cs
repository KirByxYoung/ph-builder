using System;
using System.Collections.Generic;

[Serializable]
public class Level : ICastleLevel
{
    private Queue<LevelItemsStorage> _levelStorage;

    public IReadOnlyCollection<LevelItemsStorage> LevelItemsStorages => _levelStorage;
    public int Number { get; private set; }
    public bool IsUnlocked { get; private set; }

    public Level(int number, bool isUnlocked, Queue<LevelItemsStorage> levelStorage)
    {
        Number = number;
        IsUnlocked = isUnlocked;
        _levelStorage = new Queue<LevelItemsStorage>(levelStorage);
    }

    public void Unlock()
    {
        IsUnlocked = true;
    }
}