using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactible : MonoBehaviour
{
    public GameObject ActiveObjectInteract;

    [SerializeField] Vector3 _openRot;
    [SerializeField] Vector3 _closeRot;
    [SerializeField] Vector3 _actualTarget;
    [SerializeField] float _speed;
    [SerializeField] bool _isactive = false;

    private void Start()
    {
        if (_isactive)
        {
            _actualTarget = _openRot;
            _isactive = true;
        }
        else
        {
            _actualTarget = _closeRot;
            _isactive = false;
        }
    }

    private void Update()
    {
        if (ActiveObjectInteract != null)
        {
            if (_isactive)
            {
                ActiveObjectInteract.SetActive(true);
            }
            else
            {
                ActiveObjectInteract.SetActive(false);
            }
        }
    }

    private void FixedUpdate()
    {
        transform.localRotation = Quaternion.Lerp(transform.localRotation, Quaternion.Euler(_actualTarget), _speed);
    }

    public void ChangeTarget()
    {
        if (_actualTarget != _openRot)
        {
            _actualTarget = _openRot;
            _isactive = true;
        }
        else
        {
            _actualTarget = _closeRot;
            _isactive = false;
        }
    }
}
