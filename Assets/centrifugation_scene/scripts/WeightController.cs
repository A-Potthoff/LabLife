using UnityEngine;

public class WeightController : MonoBehaviour
{
    private Vector3 offset;
    [SerializeField] private Transform CurrentHolder = null;
    [SerializeField] private Holder CurrentHolderScript = null;
    [SerializeField] public bool IsInHolder = false;
    private Collider2D holderCollider;

    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    //-----------------------------------------handling the movement of the pipette by the mouse ------------------------------------

    void OnMouseDown() //necessary to calculate the offset
    {
        // Convert mouse position to world position
        Vector3 mousePosition = Input.mousePosition;
        mousePosition.z = Camera.main.WorldToScreenPoint(transform.position).z;
        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(mousePosition);

        // Calculate the offset between the mouse position and the pipette's position
        offset = transform.position - worldPosition;

        // Mark the current holder as empty because the tube is picked up now
        if (IsInHolder)
        {
            CurrentHolderScript.filled = false;
        }
    }

    void OnMouseUp()
    {
        // Check if mouse is over a holder collider
        holderCollider = GetHolderUnderMouse();
        CurrentHolderScript = holderCollider?.GetComponent<Holder>(); // Get the Holder script component of the holder collider

        if (holderCollider != null && !CurrentHolderScript.filled)
        {
            // Snap to the holder's position
            CurrentHolder = holderCollider.transform;
            transform.position = CurrentHolder.position;

            Vector3 holderEulerAngles = CurrentHolder.rotation.eulerAngles;    // Get the current holder's rotation
            transform.rotation = Quaternion.Euler(holderEulerAngles.x, holderEulerAngles.y, 180f + holderEulerAngles.z); // Set the rotation to 180 + holder's z rotation

            transform.SetParent(CurrentHolder);
            Debug.Log("Weight Snapped to holder: " + CurrentHolder.name);

            // Set the current holder to filled
            CurrentHolderScript.filled = true;

            IsInHolder = true;
        }
        else
        {
            transform.SetParent(null);
            CurrentHolder = null;
            transform.rotation = Quaternion.identity;

            IsInHolder = false;
        }
    }

    void OnMouseDrag() // the actual movement of the pipette
    {
        // Convert mouse position to world position
        Vector3 mousePosition = Input.mousePosition;
        mousePosition.z = Camera.main.WorldToScreenPoint(transform.position).z;
        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(mousePosition);

        // Apply the offset to keep the pipette from jumping to the mouse position
        transform.position = worldPosition + offset;
    }

    //-----------------------------helper method to get holder under mouse ------------------------

    Collider2D GetHolderUnderMouse()
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition.z = Camera.main.WorldToScreenPoint(transform.position).z;
        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(mousePosition);

        // Check for colliders at the mouse position
        Collider2D[] colliders = Physics2D.OverlapPointAll(worldPosition);
        foreach (Collider2D collider in colliders)
        {
            if (collider.CompareTag("CentrifugeHolder"))
            {
                return collider;
            }
        }
        return null;
    }
}
