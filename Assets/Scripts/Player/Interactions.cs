using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactions : MonoBehaviour
{
    [SerializeField] float _distance;
    [SerializeField] LayerMask _interactions;
    [SerializeField] GameObject _uiText;

    private void Update()
    {
        RaycastHit hit;

        if (Physics.Raycast(transform.position, transform.forward, out hit, _distance, _interactions))
        {
            _uiText.SetActive(true);

            if (Input.GetKeyDown(KeyCode.E))
            {
                var door = hit.transform.GetComponent<Doors>();

                if (door != null)
                    door.ChangeTarget();

                var inter = hit.transform.GetComponent<Interactible>();

                if (inter != null)
                    inter.ChangeTarget();
            }

            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.blue);
        }
        else
            _uiText.SetActive(false);
    }
}
