using UnityEngine;

[RequireComponent(typeof(Animator), typeof(Movement))]
public class PlayerAnimation : MonoBehaviour
{
    private Movement _movement;
    private Animator _animator;

    private int _runHash;
    private int _stopHash;
    private int _danceHash;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _movement = GetComponent<Movement>();

        _runHash = Animator.StringToHash("Run");
        _stopHash = Animator.StringToHash("Stop");
        _danceHash = Animator.StringToHash("Dance");
    }

    private void OnEnable()
    {
        _movement.Move += OnMove;
        _movement.Stopped += OnStopped;
    }

    private void OnDisable()
    {
        _movement.Move -= OnMove;
        _movement.Stopped -= OnStopped;
    }

    public void Dance()
    {
        _animator.SetTrigger(_danceHash);
    }

    private void OnMove()
    {
        _animator.SetTrigger(_runHash);
    }

    private void OnStopped()
    {
        _animator.SetTrigger(_stopHash);
    }
}