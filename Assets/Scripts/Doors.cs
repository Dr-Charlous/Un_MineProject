using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doors : MonoBehaviour
{
    [SerializeField] Vector3 _openPos;
    [SerializeField] Vector3 _closePos;
    [SerializeField] Vector3 _actualTarget;
    [SerializeField] float _doorSpeed;

    private void Start()
    {
        _closePos = transform.localPosition;
        _actualTarget = _closePos;
    }

    private void FixedUpdate()
    {
        transform.localPosition = Vector3.Lerp(transform.localPosition, _actualTarget, _doorSpeed);
    }

    public void ChangeTarget()
    {
        if (_actualTarget != _openPos)
            _actualTarget = _openPos;
        else
            _actualTarget = _closePos;
    }
}
