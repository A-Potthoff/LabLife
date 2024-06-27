using UnityEngine;

public class InteractiveObject : MonoBehaviour
{
    private Vector3 originalScale;
    private Vector3 enlargedScale;
    private bool isPlayerInContact = false;
    [SerializeField] private Object_specific_manager object_specific_manager;

    [Header("Petri dish attributes")] //to make the unity scene more readable

    [SerializeField] public bool is_empty;
    [SerializeField] public string contains;
    [SerializeField] public bool culture_has_grown = false;
    [SerializeField] public bool coverage;

    private void Start()
    {
        originalScale = transform.localScale;
        enlargedScale = originalScale * 1.1f; // Increase scale by 10%

        //get component of the object specific manager
        object_specific_manager = GetComponent<Object_specific_manager>();
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
            object_specific_manager.Start_minigame();
        }
    }
}
