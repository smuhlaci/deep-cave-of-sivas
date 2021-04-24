using UnityEngine;

public class CharacterTrigger : MonoBehaviour
{
    public Interactable CurrentInteractable;

    private void Update()
    {
        if (CurrentInteractable != null && Input.GetKeyDown(KeyCode.E))
        {
            GameManager.Instance.ShowDialog(CurrentInteractable.Dialog);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        CurrentInteractable = other.gameObject.GetComponent<Interactable>();
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        CurrentInteractable = null;
    }
}
