using UnityEngine;

[RequireComponent(typeof(Animator))]
public class CastleAnimation : MonoBehaviour
{
    [SerializeField] private ParticleSystem _particle;

    private Animator _animator;
    private int _loopHash;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _loopHash = Animator.StringToHash("Loop");
    }

    public void Play()
    {
        _animator.SetTrigger(_loopHash);
        _particle.Play();
    }
}