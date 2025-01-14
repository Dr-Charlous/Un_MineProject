using UnityEngine;

public class Belt : MonoBehaviour
{
    [SerializeField] float _force = 1;

    private void OnTriggerStay(Collider other)
    {
        var rb = other.GetComponent<Rigidbody>();

        if (rb != null)
            rb.AddForce((transform.position - rb.transform.position) * _force, ForceMode.Force);
    }
}