using System;
using UnityEngine;

public class PipetteController : MonoBehaviour
{
    private Vector3 offset;
    [SerializeField] public float fill; //purposefully left as float to allow continuous filling of the tube in the 
    [SerializeField] private TubeController currentTube = null;

    private SpriteRenderer spriteRenderer;
    [SerializeField] public Sprite pipette_empty;
    [SerializeField] public Sprite pipette_filled;
    [SerializeField] public ContentsEnum.Enum content;

    private Instructor Instructor;

    //private Image tubeImage;
    //private Image currentTube_filled;
    //private TubeFilling_Script TubeFilling_Script;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        update_sprite();
        Instructor = Instructor.Instance;
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
            /*TubeFilling_Script = other.GetComponent<TubeFilling_Script>();
            tubeImage = other.GetComponentInChildren<Image>();

            if (tubeImage != null)
            {
                currentTube_filled = tubeImage;
            }*/
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("TubeOpening"))
        {
            Debug.Log("Pipette is out of tube");
            currentTube = null;
            /*if (tubeImage != null && currentTube_filled == tubeImage)
            {
                currentTube_filled= null;
                TubeFilling_Script.StopFilling();
                TubeFilling_Script = null;
            }*/
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (fill != 0) //if the pipette is filled, empty it
            {
                if (currentTube != null)
                {
                    if (currentTube.fill <= 0.98f)
                    {
                        Debug.Log("pipette emptied");
                        // Drop the liquid into the tube and empty the pipette
                        fill = 0;
                        currentTube.fill_tube(content);
                        content = ContentsEnum.Enum.None;
                        update_sprite();

                        currentTube.CheckIfMinigameEnds();
                    }
                    else
                    {
                        Debug.Log("Instructor: PipettingIntoFullTube");
                        Instructor.gameObject.SetActive(true);
                        Instructor.PipettingIntoFullTube();
                    }
                }
            }
            else if (fill == 0) //if the pipette is empty, fill it
            {
                if (currentTube != null && currentTube.fill >= 0.1) //if the tube is not empty, fill the pipette
                {
                    // Fill the pipette from the tube and empty the tube
                    content = currentTube.returnContents();
                    if (content == ContentsEnum.Enum.Mixture) //this is returned if the tube has several liquids mixed in it
                    {
                        Debug.Log("Instructor: PipetteTubeWithMixture");
                        Instructor.gameObject.SetActive(true);
                        Instructor.PipetteTubeWithMixture();
                    }
                    else
                    {
                        fill = 1;
                        currentTube.empty_tube(content);
                        update_sprite();
                        Debug.Log("pipette filled");
                    }
                }
            }
        }
    }

    /*void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Space is pressed");
            TubeFilling_Script.StartFilling(currentTube_filled);
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            Debug.Log("Space is unpressed");
            TubeFilling_Script.StopFilling();
        }
        
    }*/

    private void update_sprite()
    {
        if (fill != 0) { spriteRenderer.sprite = pipette_filled; }
        else { spriteRenderer.sprite = pipette_empty; }
    }

}
