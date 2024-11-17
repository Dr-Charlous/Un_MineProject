using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MouseLook : MonoBehaviour
{
    [Header("Ui :")]
    [SerializeField] Transform _uiMenu;
    [SerializeField] TextMeshProUGUI _uiText;
    [SerializeField] Slider _slider;
    [Header("Values :")]
    [Range(100, 1000)]
    [SerializeField] float _mouseSensitivity = 200f;
    [SerializeField] Transform _playerBody;

    float _xRotation = 0f;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        _uiMenu.gameObject.SetActive(false);
        _xRotation = transform.localRotation.x;
        _slider.value = _mouseSensitivity;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            _uiMenu.gameObject.SetActive(!_uiMenu.gameObject.activeSelf);
        }

        if (_uiMenu.gameObject.activeSelf)
        {
            Ui();

            if (Cursor.lockState != CursorLockMode.None)
                Cursor.lockState = CursorLockMode.None;
        }
        else
        {
            float mouseX = Input.GetAxis("Mouse X") * _mouseSensitivity * Time.deltaTime;
            float mouseY = Input.GetAxis("Mouse Y") * _mouseSensitivity * Time.deltaTime;

            _xRotation -= mouseY;
            _xRotation = Mathf.Clamp(_xRotation, -90f, 90f);

            transform.localRotation = Quaternion.Euler(_xRotation, 0f, 0f);
            _playerBody.Rotate(Vector3.up * mouseX);

            if (Cursor.lockState != CursorLockMode.Locked)
                Cursor.lockState = CursorLockMode.Locked;
        }
    }

    void Ui()
    {
        _mouseSensitivity = _slider.value;
        _uiText.text = _slider.value + "/" + _slider.maxValue;
    }
}
