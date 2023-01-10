using UnityEngine;
using UnityEngine.Events;
using DG.Tweening;

public class Movement : MonoBehaviour
{
    [SerializeField] private FloatingJoystick _joystick;
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _rotationSpeed;

    private Vector3 _direction;
    private float _time = 1f;
    private float _rotateRatio = 180;

    public event UnityAction Move;
    public event UnityAction Stopped;

    public bool IsStopped { get; private set; } = true;
    public bool IsEndGame { get; private set; } = false;

    private void Update()
    {
        if (IsEndGame == false)
        {
            _direction = new Vector3(_joystick.Horizontal, 0, _joystick.Vertical);

            if (_direction != Vector3.zero)
            {
                if (IsStopped)
                {
                    IsStopped = false;
                    Move?.Invoke();
                }

                transform.Translate(_direction * _moveSpeed * Time.deltaTime, Space.World);

                Quaternion toRotation = Quaternion.LookRotation(_direction, Vector3.up);

                transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, _rotationSpeed * Time.deltaTime);
            }
            else if (IsStopped == false)
            {
                IsStopped = true;
                Stopped?.Invoke();
            }
        }
    }

    public void RotateBack()
    {
        transform.DORotate(Vector3.up * _rotateRatio, _time);
    }

    public void Stop()
    {
        _joystick.gameObject.SetActive(false);
        IsEndGame = true;
    }
}