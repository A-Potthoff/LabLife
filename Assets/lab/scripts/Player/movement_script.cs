
using UnityEngine;

public class movement_script : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private Transform carryPosition; // The position where the Sample will be carried
    private Vector3 originalScale;

    private SpriteRenderer spriteRenderer;
    private Vector2 movement;
    public static movement_script Instance;
    [SerializeField] private GameObject Sample;
    private Sample_script sampleScript;
    public bool isCarrying = false;
    private bool SampleDetected = false;

    private void Awake()
    {
        // Make sure that the object is unique and not destroyed when loading a new scene
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        originalScale = transform.localScale;
        sampleScript = Sample.GetComponent<Sample_script>();
    }

    private void Update()
    {
        // Get input from WASD and arrow keys
        movement.x = Input.GetAxis("Horizontal");
        movement.y = Input.GetAxis("Vertical");

        // Update player position
        transform.Translate(movement * speed * Time.deltaTime);

        // Change sprite based on movement direction
        UpdateSprite();

        if (Input.GetKeyDown(KeyCode.E))
        {
            if (SampleDetected)
            {
                Debug.Log("Picking up sample");
                sampleScript.Pickup(carryPosition);
                isCarrying = true;
            }
            else if(isCarrying)
            {
                Debug.Log("Dropping sample");
                sampleScript.Drop();
                isCarrying = false;
            }
            else
            {
                Debug.Log("No sample detected");
            }
        }
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Sample"))
        {
            SampleDetected = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Sample"))
        {
            SampleDetected = false;
        }
    }




    private void UpdateSprite()
    {
        //use the transform to flip the sprite
        if (movement.x > 0)
        {
            transform.localScale = new Vector3(-originalScale.x, originalScale.y, originalScale.z);
        }
        else if (movement.x < 0)
        {
            transform.localScale = originalScale;
        }
    }
}