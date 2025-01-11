using UnityEngine;

public class ObjectPlacement : MonoBehaviour
{
    public ObjectInfos.ObjectSubType SubType;
    public bool IsReplace = true;
    public bool IsBreak = false;

    [SerializeField] [Range(10f, 120f)] float _breakTimer = 60f;
    [SerializeField] GameObject _objectMeshReference;
    [SerializeField] GameObject _particuleEffect;

    float _timer = 0;

    private void Start()
    {
        _objectMeshReference.SetActive(true);
        _particuleEffect.SetActive(false);
    }

    private void Update()
    {
        if (_timer >= _breakTimer)
        {
            IsBreak = true;
            IsReplace = false;
            _objectMeshReference.SetActive(false);
            _particuleEffect.SetActive(true);
        }
        else
            _timer += Time.deltaTime;
    }

    public void Repair()
    {
        IsBreak = false;
        IsReplace = true;
        _timer = 0;
        _objectMeshReference.SetActive(true);
        _particuleEffect.SetActive(false);
    }
}