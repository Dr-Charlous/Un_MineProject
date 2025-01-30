using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public TextMeshProUGUI NameText;
    public TextMeshProUGUI DialogText;

    [SerializeField] GameObject _canvas;
    [SerializeField] Dialogues _actualDialogue;
    [SerializeField] float _timerValue;

    Dialogues _dialogue;
    float _timer;

    private void Start()
    {
        _canvas.SetActive(false);
        //_actualDialogue.UpdateDialogue(NameText, DialogText);
        _dialogue = _actualDialogue;
    }

    private void Update()
    {
        if (_actualDialogue != null)
        {
            if (_timer < _timerValue)
                _timer += Time.deltaTime;

            if (_timer >= _timerValue && Input.GetMouseButtonDown(0))      //Input next line
            {
                NextDialogue();
            }
        }
        else if (Input.GetMouseButtonDown(1))     //Input exemple call dialog
        {
            UpdateDialogue(_dialogue);
        }
    }

    //Next line
    void NextDialogue()
    {
        if (_actualDialogue.NextDialogue != null)
        {
            _actualDialogue = _actualDialogue.NextDialogue;
            _actualDialogue.UpdateDialogue(NameText, DialogText);
        }
        else
        {
            _canvas.SetActive(false);
            _actualDialogue = null;
        }

        _timer = 0;
    }

    //Activate dialog box
    public void UpdateDialogue(Dialogues dialogue)
    {
        if (dialogue != null)
        {
            _canvas.SetActive(true);
            _actualDialogue = dialogue;
            _actualDialogue.UpdateDialogue(NameText, DialogText);
            _timer = 0;
        }
    }
}
