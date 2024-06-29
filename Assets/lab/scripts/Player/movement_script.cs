using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement_script : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private Sprite sideSprite;
    [SerializeField] private Sprite topSprite;
    [SerializeField] private Sprite downSprite;

    private SpriteRenderer spriteRenderer;
    private Vector2 movement;
    private static movement_script instance;

    private void Start()
    {
        // Make sure that the object is unique and not destroyed when loading a new scene
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
            spriteRenderer = GetComponent<SpriteRenderer>();
        }
        else
        {
            Destroy(this.gameObject);
        }
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
    }

    private void UpdateSprite()
    {
        if (movement.x != 0)
        {
            spriteRenderer.sprite = sideSprite;
            spriteRenderer.flipX = movement.x < 0; // Flip sprite based on direction
        }
        else if (movement.y > 0)
        {
            spriteRenderer.sprite = topSprite;
            spriteRenderer.flipX = false; // for up and down movement the flip should be disabled
        }
        else if (movement.y < 0)
        {
            spriteRenderer.sprite = downSprite;
            spriteRenderer.flipX = false; // see above
        }
    }
}