using UnityEngine;
using DG.Tweening;

public class CameraPosition : MonoBehaviour
{
    [SerializeField] private Transform _target;

    private Vector3 _offset;
    private Vector3 _finishOffset = new Vector3(0, 3, -3);
    private float _time = 2f;
    private float _RotationX = 33f;

    private bool _isFlag = true;

    private void Start()
    {
        _offset = transform.position - _target.position;
    }

    private void Update()
    {
        if (_isFlag)
            transform.position = _target.position + _offset;
    }

    public void MoveToPlayer()
    {
        Vector3 cameraRotation = transform.rotation.eulerAngles;
        cameraRotation.x = _RotationX;

        _isFlag = false;
        transform.DOMove(_target.position + _finishOffset, _time);
        transform.DOLookAt(_target.position, _time);
        transform.DOLocalRotate(cameraRotation, _time);
    }
}