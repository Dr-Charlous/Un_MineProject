using UnityEngine;

public class Hand : MonoBehaviour
{
    public GameObject[] ObjectsInPocket;
    public Transform HandTransform;

    [SerializeField] Transform _armMeshTransform;
    [SerializeField] Transform _handTransform;
    [SerializeField] GameObject _objectInHand;
    [SerializeField] float _lerpDelay = 0.9f;
    [SerializeField] KeyCode _key;

    private void Start()
    {
        HandTransform = _handTransform;

        if (ObjectsInPocket[0] != null)
            ChangeHand(ObjectsInPocket[0]);

        //if (_objectInHand != null)
        //    Instantiate(_objectInHand, _handTransform);
    }

    private void Update()
    {
        _armMeshTransform.position = Vector3.Lerp(_armMeshTransform.position, transform.position, _lerpDelay);
        _armMeshTransform.rotation = Quaternion.Lerp(_armMeshTransform.rotation, transform.rotation, _lerpDelay);

        if (Input.GetKeyDown(_key) && _objectInHand != null)
        {
            var objectComponent = _objectInHand.GetComponent<ObjectsComponents>();

            if (objectComponent != null)
            {
                objectComponent.Use();
            }
        }
    }

    void ChangeHand(GameObject obj)
    {
        if (_objectInHand != obj)
        {
            if (_objectInHand != null)
                Destroy(_objectInHand);

            if (obj != null)
                _objectInHand = Instantiate(obj, _handTransform);
        }
    }
}
