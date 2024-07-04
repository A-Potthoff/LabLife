using System.Collections.Generic;
using System;
using Unity.VisualScripting;
using UnityEngine;
using System.Linq;
using System.Collections;

public class TubeController : MonoBehaviour
{
    [SerializeField] public float fill; //purposefully left as float to allow continuous filling of the tube in the future

    [Header("Sprites")]
    [SerializeField] public Sprite sprite_tube_empty;
    [SerializeField] public Sprite sprite_tube_filled;
    [SerializeField] public Sprite sprite_tube_filled_033;
    [SerializeField] public Sprite sprite_tube_filled_05;
    [SerializeField] public Sprite sprite_tube_filled_066;

    [Header("Contents")]
    [SerializeField] public List<ContentsEnum.Enum> contents;

    [Header("Scene specifics")]
    [SerializeField] public float onePipetteEquivalent = 0.33f;
    [SerializeField] public List<ContentsEnum.Enum> aim_of_minigame;

    private SpriteRenderer spriteRenderer;
    private Instructor Instructor;
    private logic_manager logic_Manager;

    private void Start()
    {
        Instructor = Instructor.Instance;
        logic_Manager = logic_manager.Instance;
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
        if (fill <= 0.2) {
            spriteRenderer.sprite = sprite_tube_empty;
        } else {
            spriteRenderer.sprite = sprite_tube_filled;
        }
    }

    public void fill_tube(ContentsEnum.Enum liquid)
    {
        fill += onePipetteEquivalent;
        if (contents.Count(item => item == liquid) == 0) //if the liquid is not in the list
        {
            contents.Add(liquid);
        }

        update_sprite();

        CheckIfMinigameEnds();
    }
    public void empty_tube(ContentsEnum.Enum liquid)
    {
        if (contents.Count(item => item != ContentsEnum.Enum.None) == 1)
        {
            fill -= onePipetteEquivalent;
            if (fill == 0) //only remove the liquid if it is empty, else there is liquid left.
            {
                contents.Remove(liquid);
            }
            //else do nothing
        }
        update_sprite();
    }

    public ContentsEnum.Enum returnContents()
    {
        if (contents.Count(item => item != ContentsEnum.Enum.None) == 0)
        {
            return ContentsEnum.Enum.None; //return None if the tube has no contents
        }
        if (contents.Count(item => item != ContentsEnum.Enum.None) >= 2)
        {
            return ContentsEnum.Enum.Mixture; //return Mixture if the tube has several liquids mixed in it
        }
        else
        {
            return contents[0]; //return the only element in the list
        }
    }

    private void CheckIfMinigameEnds()
    {
        if (contents.Count == aim_of_minigame.Count && contents.All(aim_of_minigame.Contains)) //if the tube has the same contents as the aim of the minigame
        {
            Instructor.gameObject.SetActive(true);
            Instructor.FinishedMinigame();

            StartCoroutine(EndMinigameAfterDelay());
        }
    }

    private IEnumerator EndMinigameAfterDelay()
    {
        yield return new WaitForSeconds(3);
        logic_Manager.return_to_lab(true);
    }
}


