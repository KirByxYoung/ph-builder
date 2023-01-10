using UnityEngine;

public class SoundHandler : MonoBehaviour
{
    [SerializeField] private Castle _castle;
    [SerializeField] private Sound _sound;
    [SerializeField] private Backpack _backpack;
    [SerializeField] private Player _player;

    private void OnEnable()
    {
        _castle.Finished += OnFinished;
        _castle.Upgraded += OnUpgraded;
        _backpack.ItemTransferred += OnItemTransferred;
        _player.ItemPickUped += OnItemPickUped;
    }

    private void OnDisable()
    {
        _castle.Finished -= OnFinished;
        _backpack.ItemTransferred -= OnItemTransferred;
        _player.ItemPickUped -= OnItemPickUped;
        _castle.Upgraded -= OnUpgraded;
    }

    private void OnFinished()
    {
        _sound.PlayFinal();
    }

    private void OnItemTransferred()
    {
        _sound.PlayGivenAwayItem();
    }

    private void OnItemPickUped()
    {
        _sound.PlayPickUpItem();
    }

    private void OnUpgraded()
    {
        _sound.PlayUpgrade();
    }
}