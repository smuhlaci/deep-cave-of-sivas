using System.Text.RegularExpressions;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Canvas), typeof(GraphicRaycaster))]
public class DialogPanel : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private string _buttonChar = "%";

    [Header("Dependencies")]
    [SerializeField] private TextMeshProUGUI _dialogText;
    [SerializeField] private Transform _interactionButtonsParent;
    
    [Header("Prefabs")]
    [SerializeField] private GameObject _interactionButtonPrefab;

    private Dialog _currentDialog;
    private int _currentDialogIndex = 0;
    private bool _waitingForInteraction = false;
    
    private Canvas _canvas;
    private GraphicRaycaster _graphicRaycaster;
    
    private void Awake()
    {
        _canvas = GetComponent<Canvas>();
        _graphicRaycaster = GetComponent<GraphicRaycaster>();
        
        SetActive(false);
    }

    public void Setup(Dialog dialog)
    {
        _currentDialog = dialog;
        _currentDialogIndex = -1;
        _waitingForInteraction = false;

        SetActive(_currentDialog != null);
    }

    private void Hide()
    {
        _currentDialog = null;

        SetActive(false);
    }

    public void Next()
    {
        if (_waitingForInteraction || _currentDialog == null) return;
        
        _currentDialogIndex++;

        if (_currentDialog.Messages.Length == _currentDialogIndex)
        {
            Hide();
        }
        
        var dialogText = _currentDialog.Messages[_currentDialogIndex];

        if (dialogText.Contains(_buttonChar))
        {
            var match = Regex.Matches(dialogText, $@"{_buttonChar}(.+?){_buttonChar}");

            for (var i = 0; i < match.Count; i++)
            {
                var text = match[i].Groups[1].Value;
                
                if (i == 0)
                {
                    _dialogText.text = text;
                    continue;
                }

                var button = Instantiate(_interactionButtonPrefab, _interactionButtonsParent).GetComponent<DialogButton>();
                button.Setup(text, _currentDialog.ActionName[i - 1], ClickedAnyButton);
            }

            _waitingForInteraction = true;
        }
        else
        {
            _dialogText.text = dialogText;
        }
    }

    private void ClickedAnyButton()
    {
        _waitingForInteraction = false;
        
        Hide();
    }

    private void SetActive(bool active)
    {
        _canvas.enabled = active;
        _graphicRaycaster.enabled = active;

        if (active)
        {
            Next();
        }
    }
}
