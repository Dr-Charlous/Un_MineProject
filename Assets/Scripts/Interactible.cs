using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactible : MonoBehaviour
{
    [SerializeField] Vector3 _openRot;
    [SerializeField] Vector3 _closeRot;
    [SerializeField] Vector3 _actualTarget;
    [SerializeField] float _speed;

    private void Start()
    {
        _actualTarget = _closeRot;
    }

    private void FixedUpdate()
    {
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(_actualTarget), _speed);
    }

    public void ChangeTarget()
    {
        if (_actualTarget != _openRot)
            _actualTarget = _openRot;
        else
            _actualTarget = _closeRot;
    }
}
