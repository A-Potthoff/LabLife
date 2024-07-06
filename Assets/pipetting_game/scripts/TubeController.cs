using System.Collections.Generic;
using System;
using Unity.VisualScripting;
using UnityEngine;
using System.Linq;
using System.Collections;

public class TubeController : MonoBehaviour
{
    [SerializeField] public float fill; //purposefully left as float to allow continuous filling of the tube in the future

    [Header("Contents")]
    [SerializeField] public List<ContentsEnum.Enum> contents;

    [Header("Scene specifics")]
    [SerializeField] public float onePipetteEquivalent = 0.33f;
    [SerializeField] public List<ContentsEnum.Enum> aim_of_minigame;
    [SerializeField] public bool is_PetriDish = false;

    [Header("Sprites")]
    [SerializeField] public Sprite sprite_tube_empty;
    [SerializeField] public Sprite sprite_tube_filled;
    [SerializeField] public Sprite sprite_tube_filled_033;
    [SerializeField] public Sprite sprite_tube_filled_05;
    [SerializeField] public Sprite sprite_tube_filled_066;

    [Header("Symbols")]
    [SerializeField] public Sprite sp_bacteria;
    [SerializeField] public Sprite sp_lysing_solution;
    [SerializeField] public Sprite sp_CellPellet_DNASupernatant;
    [SerializeField] public Sprite sp_PCR_Master_solution;
    [SerializeField] public Sprite sp_backbone;
    [SerializeField] public Sprite sp_GGAMasterSolution;
    [SerializeField] public Sprite sp_PurifiedGene;
    [SerializeField] public Sprite sp_Plasmids;
    [SerializeField] public Sprite sp_E_coli;

    private SpriteRenderer spriteRenderer;
    private SpriteRenderer SymbolRenderer;
    private Transform childTransform;
    private Instructor Instructor;
    private logic_manager logic_Manager;

    private void Start()
    {
        Instructor = Instructor.Instance;
        logic_Manager = logic_manager.Instance;
        spriteRenderer = GetComponent<SpriteRenderer>();
        childTransform = transform.Find("symbol");
        SymbolRenderer = childTransform.GetComponent<SpriteRenderer>();
        update_sprite();
    }

    public void update_sprite()
    {
        if (!is_PetriDish)
        {
            if (Mathf.Abs(fill - 0f) <= 0.07f)
            {
                spriteRenderer.sprite = sprite_tube_empty;
            }
            else if (Mathf.Abs(fill - 0.33f) <= 0.07f)
            {
                spriteRenderer.sprite = sprite_tube_filled_033;
            }
            else if (Mathf.Abs(fill - 0.5f) <= 0.07f)
            {
                spriteRenderer.sprite = sprite_tube_filled_05;
            }
            else if (Mathf.Abs(fill - 0.66f) <= 0.07f)
            {
                spriteRenderer.sprite = sprite_tube_filled_066;
            }
            else if (Mathf.Abs(fill - 0.99f) <= 0.07f || Mathf.Abs(fill - 1f) <= 0.07f)
            {
                spriteRenderer.sprite = sprite_tube_filled;
            }

            //-------------------------Symobl rendering-------------------------

            if (contents.Count(item => item != ContentsEnum.Enum.None) == 0)
            {
                SymbolRenderer.sprite = null;
            }
            else if (contents.Count(item => item != ContentsEnum.Enum.None) >= 2)
            {
                SymbolRenderer.sprite = null; //if Mixture take away the symbol
            }
            else if (contents[0] == ContentsEnum.Enum.Bacteria)
            {
                SymbolRenderer.sprite = sp_bacteria;
                childTransform.localScale = new Vector3(2, 2, 0);
            }
            else if (contents[0] == ContentsEnum.Enum.LysingSolution)
            {
                SymbolRenderer.sprite = sp_lysing_solution;
                childTransform.localScale = new Vector3(.8f, .8f, 0);
            }
            else if (contents[0] == ContentsEnum.Enum.CellPellet_DNASupernatant)
            {
                SymbolRenderer.sprite = sp_CellPellet_DNASupernatant;
                childTransform.localScale = new Vector3(0.7f, 0.635f, 0);
            }
            else if (contents[0] == ContentsEnum.Enum.PCRMasterSoluion)
            {
                SymbolRenderer.sprite = sp_PCR_Master_solution;
                childTransform.localScale = new Vector3(1.5f, 1.5f, 0);
            }
            else if (contents[0] == ContentsEnum.Enum.Backbone)
            {
                SymbolRenderer.sprite = sp_backbone;
                childTransform.localScale = new Vector3(0.6f, 0.6f, 0);
            }
            else if (contents[0] == ContentsEnum.Enum.GGAMasterSolution)
            {
                SymbolRenderer.sprite = sp_GGAMasterSolution;
                childTransform.localScale = new Vector3(0.4f, 0.4f, 0);
            }
            else if (contents[0] == ContentsEnum.Enum.PurifiedGene)
            {
                SymbolRenderer.sprite = sp_PurifiedGene;
                childTransform.localScale = new Vector3(1.5f, 1.5f, 0);
            }
            else if (contents[0] == ContentsEnum.Enum.Plasmids)
            {
                SymbolRenderer.sprite = sp_Plasmids;
                childTransform.localScale = new Vector3(0.6f, .6f, 0);
            }
            else if (contents[0] == ContentsEnum.Enum.E_coli)
            {
                SymbolRenderer.sprite = sp_E_coli;
                childTransform.localScale = new Vector3(.3f, .3f, 0);
            }
        }
        else
        {
            if (fill == 1)
            {
                spriteRenderer.sprite = sprite_tube_filled;
            }
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

    public void CheckIfMinigameEnds()
    {
        if (contents.Count == aim_of_minigame.Count && contents.All(aim_of_minigame.Contains)) //if the tube has the same contents as the aim of the minigame
        {
            Debug.Log("Minigame ended");
            logic_Manager.return_to_lab();
        }
    }
}


