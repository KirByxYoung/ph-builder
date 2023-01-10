using UnityEngine;
using IJunior.TypedScenes;

public class LevelOpener : MonoBehaviour, ISceneLoadHandler<int>
{
    public ICastleLevel CastleLevel { get; set; }

    public void OnSceneLoaded(int argument)
    {
        MainMenu.Load(CastleLevel.Number);
    }
}