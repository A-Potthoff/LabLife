using UnityEditor.PackageManager.UI;
using UnityEngine;

public class Sample_script : MonoBehaviour{
    
    public enum Form
    {
        tube,
        petri_dish,
        box
    }

    [Header("Sample sprites")]
    [SerializeField] public Sprite sprite_tube_empty;
    [SerializeField] public Sprite sprite_tube_bacteria;
    [SerializeField] public Sprite sprite_tube_centrifuged;
    //[SerializeField] public Sprite tube_DNA;

    [Header("Sample Attributes")]
    [SerializeField] public Form form;
    [SerializeField] public ContentsEnum.Enum content;

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
        content = ContentsEnum.Enum.Bacteria;
        spriteRenderer.sprite = sprite_tube_empty;     // TO BE CHANGED!
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

    public void BacteriaLysed()
    {
        // change the sprite of the object to the one with bacteria
        spriteRenderer.sprite = sprite_tube_bacteria;
        content = ContentsEnum.Enum.LysedBacteria;
    }

    public void isCentrifuged()
    {
        // change the sprite of the object to the one with bacteria
        spriteRenderer.sprite = sprite_tube_centrifuged;
        content = ContentsEnum.Enum.CellPellet_DNASupernatant;
    }


    public void Reset()
    {
        Start();
    }
}
