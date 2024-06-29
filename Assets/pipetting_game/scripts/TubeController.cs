using Unity.VisualScripting;
using UnityEngine;

public class TubeController : MonoBehaviour
{
    [SerializeField] public float fill; //purposefully left as float to allow continuous filling of the tube in the future
    [SerializeField] public Sprite sprite_tube_empty;
    [SerializeField] public Sprite sprite_tube_bacteria;

    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        //detectionCollider = GetComponent<BoxCollider>();
    }

    // Example of handling detection events
    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Something entered the tube");
        if (other.CompareTag("Pipette"))
        {
            Debug.Log("Pipette detected above the tube");
        }
    }


    public void update_sprite()
    {
        if (fill == 1) { spriteRenderer.sprite = sprite_tube_bacteria; }
        else { spriteRenderer.sprite = sprite_tube_empty; }
    }
}


