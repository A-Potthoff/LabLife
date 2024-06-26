using UnityEngine;

public class InteractiveObject : MonoBehaviour
{
    private Vector3 originalScale;
    private Vector3 enlargedScale;
    private bool isPlayerInContact = false;

    private void Start()
    {
        originalScale = transform.localScale;
        enlargedScale = originalScale * 1.1f; // Increase scale by 10%
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            transform.localScale = enlargedScale;
            isPlayerInContact = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            transform.localScale = originalScale;
            isPlayerInContact = false;
        }
    }

    private void OnMouseDown()
    {
        Debug.Log("Object clicked");
        if (isPlayerInContact)
        {
            start_minigame();
        }
    }

    private void start_minigame()
    {
        // Define the logic for starting the minigame here
        Debug.Log("Minigame started!");
    }
}
