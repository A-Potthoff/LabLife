using UnityEngine;

public class WeightController : MonoBehaviour
{
    /*private Vector3 offset;
    private Transform currentHolder = null;

    //----------------------------- mouse movement ------------------------------------

    void OnMouseDown() //necessary to calculate the offset
    {
        // Convert mouse position to world position
        Vector3 mousePosition = Input.mousePosition;
        mousePosition.z = Camera.main.WorldToScreenPoint(transform.position).z;
        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(mousePosition);

        // Calculate the offset between the mouse position and the pipette's position
        offset = transform.position - worldPosition;
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

    //----------------------------- interaction with centrifuge ------------------------

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Holder"))
        {
            currentHolder = other.transform;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Holder"))
        {
            if (currentHolder == other.transform)
            {
                currentHolder = null;
            }
        }
    }
    */
    /*

    private bool isDragging = false;
    private Vector3 offset;
    [SerializeField] private Transform currentHolder = null;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if (GetComponent<Collider2D>().OverlapPoint(mousePos))
            {
                isDragging = true;
                offset = transform.position - mousePos;
                Debug.Log("Dragging started");
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            isDragging = false;
            if (currentHolder != null)
            {
                // Snap to the holder's position
                transform.position = currentHolder.position;
                transform.SetParent(currentHolder);
                Debug.Log("Snapped to holder: " + currentHolder.name);
            }
            else
            {
                Debug.Log("No holder to snap to");
            }
        }

        if (isDragging)
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition) + offset;
            transform.position = new Vector3(mousePos.x, mousePos.y, 0);
        }
    }

    public void OnChildTriggerEnter2D(Collider2D other)
    {
        Debug.Log("OnTriggerEnter2D");
        if (other.CompareTag("CentrifugeHolder"))
        {
            currentHolder = other.transform;
            Debug.Log("Entered holder: " + currentHolder.name);
        }
    }

    public void OnChildTriggerExit2D(Collider2D other)
    {
        Debug.Log("OnTriggerExit2D");
        if (other.CompareTag("CentrifugeHolder"))
        {
            if (currentHolder == other.transform)
            {
                Debug.Log("Exited holder: " + currentHolder.name);
                currentHolder = null;
            }
        }
    }*/


    private Vector3 offset;
    [SerializeField] private Transform CurrentHolder = null;

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
    }

    void OnMouseUp() //necessary to calculate the offset
    {
        if (CurrentHolder != null)
        {
            // Snap to the holder's position
            transform.position = CurrentHolder.position;
            transform.SetParent(CurrentHolder);
            Debug.Log("Snapped to holder: " + CurrentHolder.name);
        }
        else
        {
            transform.SetParent(null);
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

    //-----------------------------handling the pipette filling and emptying, and interaction with the tube ------------------------

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Trigger entered");
        if (other.CompareTag("CentrifugeHolder"))
        {
            Debug.Log("Holder detected!");
            CurrentHolder = other.transform;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("CentrifugeHolder"))
        {
            CurrentHolder = null;
        }
    }
}
