using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Dialog _firstDialog;
    
    [SerializeField] private DialogPanel _dialogPanel;

    public static GameManager Instance;
    
    private void Awake()
    {
        Instance = this;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _dialogPanel.Next();
        }
    }

    public void ShowDialog(Dialog dialog)
    {
        if (dialog == null)
        {
            Debug.LogError("You tried show a dialog that does not exists?");
            return;
        }
        
        _dialogPanel.Setup(dialog);
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
