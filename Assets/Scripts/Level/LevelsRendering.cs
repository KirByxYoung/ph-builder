using System.Collections.Generic;
using UnityEngine;

public class LevelsRendering : MonoBehaviour
{
    [SerializeField] private LevelsConfig _levelConfig;
    [SerializeField] private LevelView _template;
    [SerializeField] private Transform _container;

    private void Start()
    {
        Render();
    }

    private void Render()
    {
        foreach (var level in _levelConfig.Levels)
        {
            var levelView = Instantiate(_template, _container);

            levelView.Render(level);
        }
    }
}
