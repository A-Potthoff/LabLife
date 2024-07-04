using System.Collections.Generic;
using System;
using Unity.VisualScripting;
using UnityEngine;
using System.Linq;

public class TubeController : MonoBehaviour
{
    [SerializeField] public float fill; //purposefully left as float to allow continuous filling of the tube in the future
    [SerializeField] public Sprite sprite_tube_empty;
    [SerializeField] public Sprite sprite_tube_filled;
    [SerializeField] public Sprite sprite_tube_filled_033;
    [SerializeField] public Sprite sprite_tube_filled_05;
    [SerializeField] public Sprite sprite_tube_filled_066;
    [SerializeField] public List<ContentsEnum.Enum> contents;
    [SerializeField] public float onePipetteEquivalent = 0.33f;

    private SpriteRenderer spriteRenderer;
    private Instructor Instructor;

    private void Start()
    {
        Instructor = Instructor.Instance;
        spriteRenderer = GetComponent<SpriteRenderer>();
        update_sprite();
    }

    public void update_sprite()
    {
        /*switch (fill)
        {
            case 0f:
                spriteRenderer.sprite = sprite_tube_empty;
                break;
            case 0.33f:
                spriteRenderer.sprite = sprite_tube_filled_033;
                break;
            case 0.5f:
                spriteRenderer.sprite = sprite_tube_filled_05;
                break;
            case 0.66f:
                spriteRenderer.sprite = sprite_tube_filled_066;
                break;
            case 0.99f:
                spriteRenderer.sprite = sprite_tube_filled;
                break;
            case 1f:
                spriteRenderer.sprite = sprite_tube_filled;
                break;
        }*/
        if (fill == 0) {
            spriteRenderer.sprite = sprite_tube_empty;
        } else {
            spriteRenderer.sprite = sprite_tube_filled;
        }
    }

    public void fill_tube(ContentsEnum.Enum liquid)
    {
        fill += onePipetteEquivalent;
        contents.Add(liquid);

        update_sprite();
    }
    public void empty_tube(ContentsEnum.Enum liquid)
    {
        //if there are several liquids mixed in this tube, Instructor recommends to not do it
        if (contents.Count(item => item != ContentsEnum.Enum.None) == 1)
        {
            fill -= onePipetteEquivalent;
            contents.Remove(liquid);
            update_sprite();
        }
        else //in this case the tube is empty. Do nothing
        {
        }
    }

    public ContentsEnum.Enum returnContents()
    {
        if (contents.Count(item => item != ContentsEnum.Enum.None) == 0)
        {
            return ContentsEnum.Enum.None;
        }
        if (contents.Count(item => item != ContentsEnum.Enum.None) >= 2)
        {
            return ContentsEnum.Enum.Mixture;
        }
        else
        {
            return contents[0]; //return the only element in the list
        }
    }
}


