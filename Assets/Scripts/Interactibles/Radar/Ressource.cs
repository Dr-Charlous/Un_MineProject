using UnityEngine;

public class Ressource : MonoBehaviour
{
    public RadarMining.RessourcesType Type;
    public GameObject Mesh;
    public float RessourcesAmount = 10;
    public float DistanceShow = 1;

    private void Start()
    {
        Mesh.SetActive(false);
    }

    private void Update()
    {
        if ((GameManager.Instance.Mining.transform.position - transform.position).magnitude < DistanceShow && !Mesh.activeSelf)
            Mesh.SetActive(true);
        else if ((GameManager.Instance.Mining.transform.position - transform.position).magnitude > DistanceShow && Mesh.activeSelf)
            Mesh.SetActive(false);
    }
}
