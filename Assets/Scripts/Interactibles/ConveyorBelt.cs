using UnityEngine;

public class ConveyorBelt : MonoBehaviour
{
    [SerializeField] ObjectPlacement _furnase;
    [SerializeField] Vector3 _direction;
    [SerializeField] float _speed;

    float _actualSpeed;

    private void Update()
    {
        if (!GameManager.Instance.IsGamePause)
        {
            if (_furnase.IsBreak && _actualSpeed > 0)
            {
                _actualSpeed -= Time.deltaTime;

                if (_actualSpeed < 0)
                    _actualSpeed = 0;
            }
            else if (_actualSpeed < _speed && GameManager.Instance.PanelControl.Power.IsActive)
            {
                _actualSpeed += Time.deltaTime;

                if (_actualSpeed > _speed)
                    _actualSpeed = _speed;
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (!GameManager.Instance.IsGamePause)
        {
            if (other.GetComponent<Belt>() != null && !GameManager.Instance.IsGamePause)
                other.transform.position += _direction.normalized * _actualSpeed * Time.deltaTime;
        }
    }
}
