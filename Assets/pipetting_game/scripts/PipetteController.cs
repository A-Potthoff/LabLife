using System.Data.SqlTypes;
using UnityEngine;

public class PipetteController : MonoBehaviour
{
    private Vector3 offset;
    public float fill; //purposefully left as float to allow continuous filling of the tube in the future
    private TubeController currentTube = null;

    private SpriteRenderer spriteRenderer;
    [SerializeField] public Sprite pipette_empty;
    [SerializeField] public Sprite pipette_filled;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        update_sprite();
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
        if (other.CompareTag("TubeOpening")) 
        {
            Debug.Log("Pipette is above a tube");
            currentTube = other.GetComponentInParent<TubeController>();
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("TubeOpening"))
        {
            //Debug.Log("Pipette left the tube");
            currentTube = null;
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Space key was pressed");
            if (fill != 0)
            {
                if (currentTube != null)
                {
                    // Drop the liquid into the tube and empty the pipette
                    fill = 0;
                    currentTube.fill_tube();
                    update_sprite();
                }
            }
            else if (fill == 0)
            {
                Debug.Log("Pipette is not filled");
                if (currentTube != null && currentTube.fill != 0)
                {
                    Debug.Log("Tube is filled");
                    // Fill the pipette from the tube and empty the tube
                    fill = 1;
                    currentTube.empty_tube();
                    update_sprite();
                }
            }
        }
    }

    private void update_sprite()
    {
        if (fill != 0) { spriteRenderer.sprite = pipette_filled; }
        else { spriteRenderer.sprite = pipette_empty; }
    }

}
