using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private Image _fade;

    private void Awake()
    {
        _fade.color = new Color(0, 0, 0, 0);
    }

    public void StartButtonClicked()
    {
        AudioManager.Instance.Stop("Menu");
        _fade.DOFade(1, .5F).OnComplete(() =>
        {
            SceneManager.LoadScene(sceneBuildIndex: 1);
        });
    }

    private void Start()
    {
        AudioManager.Instance.Play("Menu");
    }
}
