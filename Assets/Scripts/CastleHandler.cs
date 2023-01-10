using UnityEngine;

public class CastleHandler : MonoBehaviour 
{
    [SerializeField] private Castle _castle;
    [SerializeField] private Movement _movement;
    [SerializeField] private CastleView _castleView;
    [SerializeField] private PlayerAnimation _playerAnimation;
    [SerializeField] private CameraPosition _camera;
    [SerializeField] private GameObject _panel;
    [SerializeField] private InventoryView _inventoryView;
    [SerializeField] private LevelOpener _levelOpener;
    [SerializeField] private CastleAnimation _castleAnimation;

    private void OnEnable()
    {
        _castle.Finished += OnFinished;
        _castle.WritedCells += OnWritedCells;
        _castle.Upgraded += OnUpgraded;
    }

    private void OnDisable()
    {
        _castle.Finished -= OnFinished;
        _castle.WritedCells -= OnWritedCells;
        _castle.Upgraded -= OnUpgraded;
    }

    private void OnFinished()
    {
        _movement.Stop();
        _movement.RotateBack();
        _playerAnimation.Dance();
        _camera.MoveToPlayer();
        _panel.SetActive(true);
        _inventoryView.gameObject.SetActive(false);
        _levelOpener.CastleLevel = _castle.GetCastleLevel();
    }

    private void OnWritedCells(Cell cell)
    {
        _castleView.CreatedCell(cell);
    }

    private void OnUpgraded()
    {
        _castleAnimation.Play();
    }
}