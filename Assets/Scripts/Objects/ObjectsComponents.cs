using UnityEngine;

public class ObjectsComponents : MonoBehaviour
{
    public ObjectInfos ObjectInfos;

    Transform _originalParent;
    Rigidbody _rb;

    private void Start()
    {
        _originalParent = transform.parent;
        _rb = GetComponent<Rigidbody>();
    }

    public virtual void Use()
    {
        if (ObjectInfos.Type == ObjectInfos.WeaponType.Sword)
        {
            Debug.Log("Sword attack");
        }
        else if (ObjectInfos.Type == ObjectInfos.WeaponType.Gun)
        {
            Debug.Log("Gun attack");
        }
    }

    public void Grab(Transform tf)
    {
        if (tf != null)
        {
            Destroy(_rb);

            transform.SetParent(tf);
            transform.localPosition = Vector3.zero;
            transform.localRotation = Quaternion.Euler(Vector3.zero);
        }
        else
        {
            transform.SetParent(_originalParent);
            _rb = gameObject.AddComponent<Rigidbody>();
            _rb.AddForce(transform.forward * 10, ForceMode.Impulse);
        }
    }
}
