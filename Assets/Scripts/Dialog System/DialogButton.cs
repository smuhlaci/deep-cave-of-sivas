using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class DialogButton : MonoBehaviour
{
    [SerializeField] private Button _button;
    [SerializeField] private TextMeshProUGUI _text;

    private void Awake()
    {
        _button.interactable = false;
    }

    public void Setup(string buttonText, string buttonEvent, UnityAction buttonClickedCallback)
    {
        _text.text = buttonText;
        _button.onClick.AddListener(() => {GameManager.Instance.ButtonPressed(buttonEvent); });
        _button.onClick.AddListener(buttonClickedCallback);

        _button.interactable = true;
    }

    private void OnDisable()
    {
        _button.onClick.RemoveAllListeners();
    }
}
