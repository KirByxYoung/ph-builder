using TMPro;
using UnityEngine;
using UnityEngine.UI;
using IJunior.TypedScenes;

public class LevelView : MonoBehaviour
{
    [SerializeField] private Button _button;
    [SerializeField] private Image _lock;
    [SerializeField] private TMP_Text _number;

    private Level _level;

    public void Render(Level level)
    {
        _level = level;
        _number.text = _level.Number.ToString();

        if (_level.IsUnlocked)
        {
            Destroy(_lock.gameObject);
            _button.interactable = true;
        }
    }

    public void StartGame()
    {
        Game.Load(_level);
    }
}