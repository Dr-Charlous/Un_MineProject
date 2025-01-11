using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UiManager : MonoBehaviour
{
    public bool IsGamePause = false;

    [Header("Ui :")]
    [SerializeField] Transform _uiMenu;
    [SerializeField] TextMeshProUGUI _uiText;
    [SerializeField] Slider _slider;

    private void Start()
    {
        _uiMenu.gameObject.SetActive(false);
        _slider.value = GameManager.Instance.Player.Look.MouseSensitivity;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            _uiMenu.gameObject.SetActive(!_uiMenu.gameObject.activeSelf);
            IsGamePause = _uiMenu.gameObject.activeSelf;

            if (Cursor.lockState != CursorLockMode.Locked)
                Cursor.lockState = CursorLockMode.Locked;
            else
                Cursor.lockState = CursorLockMode.None;
        }

        if (_uiMenu.gameObject.activeSelf)
        {
            Ui();
        }
    }

    void Ui()
    {
        GameManager.Instance.Player.Look.MouseSensitivity = _slider.value;
        _uiText.text = _slider.value + "/" + _slider.maxValue;
    }
}
