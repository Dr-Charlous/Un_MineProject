using UnityEngine;

public class Interactions : MonoBehaviour
{
    [SerializeField] float _distance;
    [SerializeField] LayerMask _interactions;
    [SerializeField] GameObject _uiText;

    public Hand[] Hands;
    public ObjectsComponents[] Objects;

    private void Update()
    {
        RaycastHit hit;

        if (Input.GetKeyDown(KeyCode.Q) && Objects[0] != null)
        {
            Objects[0].Grab(null);
            Objects[0] = null;
        }

        if (Physics.Raycast(transform.position, transform.forward, out hit, _distance, _interactions))
        {
            _uiText.SetActive(true);

            if (Input.GetKeyDown(KeyCode.E))
            {
                //Doors
                var door = hit.transform.GetComponent<Doors>();

                if (door != null)
                {
                    if (Objects[0] != null && door.IsLocked)
                        door.IsLocked = !Objects[0].Use();

                    if (!door.IsLocked)
                        door.ChangeTarget();
                    else
                        Debug.Log("Door close");
                }

                //Interactibles
                var inter = hit.transform.GetComponent<Interactible>();

                if (inter != null)
                    inter.ChangeTarget();

                //Objects
                var obj = hit.transform.GetComponent<ObjectsComponents>();

                if (obj != null && Objects[0] == null)
                {
                    obj.Grab(Hands[0].HandTransform);
                    Objects[0] = obj;
                }
            }
        }
        else
            _uiText.SetActive(false);

        //Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.blue);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;

        Gizmos.DrawLine(transform.position, transform.position + transform.TransformDirection(Vector3.forward) * _distance);
    }
}
