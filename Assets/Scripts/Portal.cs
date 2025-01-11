using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    public Transform Gate;

    [SerializeField] Portal _connectPortal;

    private void OnTriggerEnter(Collider other)
    {
        other.transform.position += _connectPortal.Gate.position - Gate.position;
    }
}
