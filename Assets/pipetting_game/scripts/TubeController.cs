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
        update_sprite();
    }

    public void update_sprite()
    {
        if (fill == 1) { spriteRenderer.sprite = sprite_tube_bacteria; }
        else { spriteRenderer.sprite = sprite_tube_empty; }
    }

    public void fill_tube()
    {
        fill = 1;
        update_sprite();
    }

    public void empty_tube()
    {
        fill = 0;
        update_sprite();
    }
}


