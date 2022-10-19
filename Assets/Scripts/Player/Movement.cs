using UnityEngine;
using UnityEngine.Events;

public class Movement : MonoBehaviour
{
    [SerializeField] private FloatingJoystick _joystick;
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _rotationSpeed;

    private Vector3 _direction;

    public event UnityAction Move;
    public event UnityAction Stopped;

    public bool IsStopped { get; private set; } = true;

    private void Update()
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