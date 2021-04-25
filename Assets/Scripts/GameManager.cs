using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Dialog _firstDialog;
    
    [SerializeField] private DialogPanel _dialogPanel;

    [SerializeField] private Image _fade;

    public Vector2 DestroyPosition;
    
    public static GameManager Instance;
    
    private void Awake()
    {
        _fade.color = new Color(0, 0, 0, 1);
        Instance = this;
    }

    private void Start()
    {
        _fade.DOFade(0, .5F);
        AudioManager.Instance.Play("VillageIdle");
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
