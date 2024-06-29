using UnityEditor.PackageManager.UI;
using UnityEngine;

public class Sample_script : MonoBehaviour{
    public enum Content
    {
        None,
        DNA,
        plasmids,
        cells,
        cells_plasmids,
        transformed_cells
    }

    public enum Form
    {
        tube,
        petri_dish,
        box
    }

    [Header("Sample sprites")]
    [SerializeField] public Sprite sprite_tube_empty;
    [SerializeField] public Sprite sprite_tube_bacteria;
    //[SerializeField] public Sprite tube_DNA;

    [Header("Sample Attributes")]
    [SerializeField] public Form form;
    [SerializeField] public bool isCentrifuged;
    [SerializeField] public Content content;
    [SerializeField] public bool isConcentrated;

    private SpriteRenderer spriteRenderer;
    private static Sample_script instance;

    void Start()
    {
        // Make sure that the object is unique and not destroyed when loading a new scene
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
            spriteRenderer = GetComponent<SpriteRenderer>(); //to change the sprites of this object
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    public void bacteria_transferred()
    {
        // change the sprite of the object to the one with bacteria
        spriteRenderer.sprite = sprite_tube_bacteria;
    }





    public void Reset()
    {
        // reset the attributes of the object
        //form = "tube";
        //hasBacteria = false;
        //isEmpty = true;
        //isCentrifuged = false;
        //content = "None";
        //isConcentrated = false;
        spriteRenderer.sprite = sprite_tube_empty;
    }
}
