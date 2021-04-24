using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Dialog _firstDialog;
    
    [SerializeField] private DialogPanel _dialogPanel;
    
    private void Awake()
    {
        // _dialogPanel.Setup(_firstDialog);
    }

    private void Update()
    {
        if (Input.anyKeyDown)
        {
            _dialogPanel.Next();
        }
    }

    public void ButtonPressed(string text)
    {
        switch (text)
        {
            case "It's Bullshit":
            case "They are right":
                Debug.Log(text);
                break;
                // break;
        }
    }
}
