using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doors : MonoBehaviour
{
    public bool IsLocked = false;
    public bool IsAutoClose = true;

    [SerializeField] Vector3 _openPos;
    [SerializeField] Vector3 _closePos;
    [SerializeField] Vector3 _actualTarget;
    [SerializeField] float _doorSpeed;
    [SerializeField] float _timeDoorStayOpen = 10f;

    float _timer = 0;
    bool _isDoorOpen = false;

    private void Start()
    {
        _closePos = transform.localPosition;
        _actualTarget = _closePos;
    }
    private void Update()
    {
        if (IsAutoClose)
        {
            if (_isDoorOpen && !GameManager.Instance.Ui.IsGamePause)
            {
                _timer += Time.deltaTime;

                if (_timer >= _timeDoorStayOpen)
                {
                    _timer = 0;
                    ChangeTarget();
                }
            }
        }
    }

    private void FixedUpdate()
    {
        transform.localPosition = Vector3.Lerp(transform.localPosition, _actualTarget, _doorSpeed);
    }

    public void ChangeTarget()
    {
        if (!IsLocked)
        {
            if (_actualTarget != _openPos)
            {
                _actualTarget = _openPos;
                _isDoorOpen = true;
            }
            else
            {
                _actualTarget = _closePos;
                _isDoorOpen = false;
            }
        }
    }
}
