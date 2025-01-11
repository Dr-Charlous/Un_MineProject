using UnityEngine;

public class ConveyorBelt : MonoBehaviour
{
    [SerializeField] Vector3 _direction;
    [SerializeField] float _speed;

    private void OnTriggerStay(Collider other)
    {
        other.transform.position += _direction.normalized * _speed * Time.deltaTime;
    }
}
