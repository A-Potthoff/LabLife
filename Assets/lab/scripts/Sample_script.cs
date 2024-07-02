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
    public static Sample_script Instance;

    void Awake()
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

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>(); //to change the sprites of this object
    }

    public void Pickup(Transform carryPosition)
    {
        transform.SetParent(carryPosition);
        transform.localPosition = Vector3.zero;
        transform.localRotation = Quaternion.identity;
    }

    public void Drop()
    {
        transform.SetParent(null);
        transform.position += new Vector3(1, 0, 0); //pop the sample a bit to the right
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
