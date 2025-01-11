using UnityEngine;

public class ObjectPlacement : MonoBehaviour
{
    public ObjectInfos.ObjectSubType SubType;
    public bool IsReplace = true;
    public bool IsBreak = false;

    [SerializeField] [Range(10f, 120f)] float _breakTimer = 60f;
    [SerializeField] [Tooltip("Min/Max range random")] Vector2 _breakTimerRandomRange = new Vector2(-10, 10);
    [SerializeField] GameObject _objectMeshReference;
    [SerializeField] GameObject _particuleEffect;

    float _timer = 0;
    float _timerTarget = 0;

    private void Start()
    {
        _objectMeshReference.SetActive(true);
        _particuleEffect.SetActive(false);
        _timerTarget = _breakTimer + Random.Range(_breakTimerRandomRange.x, _breakTimerRandomRange.y);
    }

    private void Update()
    {
        if (!GameManager.Instance.Ui.IsGamePause)
        {
            if (_timer >= _timerTarget)
            {
                IsBreak = true;
                IsReplace = false;
                _objectMeshReference.SetActive(false);
                _particuleEffect.SetActive(true);
            }
            else
                _timer += Time.deltaTime;
        }
    }

    public void Repair()
    {
        IsBreak = false;
        IsReplace = true;
        _timer = 0;
        _timerTarget = _breakTimer + Random.Range(_breakTimerRandomRange.x, _breakTimerRandomRange.y);
        _objectMeshReference.SetActive(true);
        _particuleEffect.SetActive(false);
    }
}