using System.Collections.Generic;
using UnityEngine;
using IJunior.TypedScenes;

public class LevelsConfig : MonoBehaviour, ISceneLoadHandler<int>
{
    [SerializeField] private List<LevelItemsStorage> _levelStorage;

    private const string UNLOCKEDLEVEL = "UnlockedLevel";

    private List<Level> _levels = new List<Level>();
    private Queue<LevelItemsStorage> _tempLevelStorage = new Queue<LevelItemsStorage>();
    private int _lastLevel;

    public int UnlockedLevels { get; private set; }
    public int CountLevels { get; private set; }
    public IReadOnlyList<Level> Levels => _levels;


    private void Awake()
    {
        CountLevels = 10;

        UnlockedLevels = PlayerPrefs.GetInt(UNLOCKEDLEVEL, 1);
        TryUnlockLevel();

        Generate();
    }

    public void OnSceneLoaded(int argument)
    {
        WriteNumberLastLevel(argument);
    }

    private void WriteNumberLastLevel(int number)
    {
        _lastLevel = number;
    }

    private void TryUnlockLevel()
    {
        if (UnlockedLevels == _lastLevel)
        {
            int numberNextLevel = _lastLevel + 1;  

            PlayerPrefs.SetInt(UNLOCKEDLEVEL, numberNextLevel);
            UnlockedLevels = numberNextLevel;
        }
    }

    private void Generate()
    {
        int indexTransitionNextLevel = 4;
        int upgrades = 0;
        int entryLevel = 0;
        bool isUnlocked;

        for (int i = 1; i <= CountLevels; i++)
        {
            _tempLevelStorage.Clear();

            if (i % indexTransitionNextLevel == 0)
            {
                upgrades = 0;
                entryLevel++;  
            }

            isUnlocked = i <= UnlockedLevels;

            for (int j = 0; j <= upgrades; j++)
            {
                _tempLevelStorage.Enqueue(_levelStorage[j + entryLevel]);
            }

            _levels.Add(new Level(i, isUnlocked, _tempLevelStorage));

            upgrades++;
        }
    }
}