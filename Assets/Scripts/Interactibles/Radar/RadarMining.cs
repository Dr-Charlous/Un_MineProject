using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadarMining : MonoBehaviour
{
    public enum RessourcesType
    {
        Dirt,
        Rock,
        Coal
    }

    [SerializeField] Transform _ressourceParent;
    [SerializeField] List<Transform> _ressourcesLocation = new();

    private void OnTriggerStay(Collider other)
    {
        Ressource ressource = other.GetComponent<Ressource>();

        if (ressource != null)
            Mine(ressource);
    }

    void Mine(Ressource ressource)
    {
        if (ressource.Type == RessourcesType.Dirt)
        {
            Debug.Log("Mine dirt");
        }
        else if (ressource.Type == RessourcesType.Rock)
        {
            Debug.Log("Mine rocks");
        }
        else if (ressource.Type == RessourcesType.Coal)
        {
            Debug.Log("Mine coal");
        }
        else
            return;

        ressource.RessourcesAmount -= Time.deltaTime;

        if (ressource.RessourcesAmount <= 0)
        {
            _ressourcesLocation.Remove(ressource.transform);
            Destroy(ressource.gameObject);
        }
    }

    public void Move(Vector3 move, Quaternion rotate)
    {
        for (int i = 0; i < _ressourcesLocation.Count; i++)
        {
            _ressourcesLocation[i].position -= move;
        }

        _ressourceParent.rotation *= rotate;
    }
}
