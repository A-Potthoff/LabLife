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
    [SerializeField] public Sprite sp_petri_dish;
    [SerializeField] public Sprite sp_tube_filled;
    [SerializeField] public Sprite sp_tube_centrifuged;

    [Header("Symbol sprites")]
    [SerializeField] public Sprite sp_bacteria;
    [SerializeField] public Sprite sp_lysed_bacteria;
    [SerializeField] public Sprite sp_DNA_PCR_Solution;
    [SerializeField] public Sprite sp_purified_gene;
    [SerializeField] public Sprite sp_GGA_mix;
    [SerializeField] public Sprite sp_plasmids;
    [SerializeField] public Sprite sp_plasmids_cells;
    [SerializeField] public Sprite sp_transformedCells;

    [Header("Sample Attributes")]
    [SerializeField] public ContentsEnum.Enum content;

    private SpriteRenderer spriteRenderer;
    private SpriteRenderer SymbolRenderer;
    private Transform symbolTransform;
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
        SymbolRenderer = transform.GetChild(0).GetComponent<SpriteRenderer>(); //to change the sprites of the symbol
        symbolTransform = transform.GetChild(0).GetComponent<Transform>();
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



    //-------------------------------------update the Sample after Minigames--------------------------------------------


    public void LysedBacteria()
    {
        content = ContentsEnum.Enum.LysedBacteria;
        SymbolRenderer.sprite = sp_lysed_bacteria;
        symbolTransform.localScale = new Vector3(.5f, .5f, 0);
    }

    public void isCentrifuged()
    {
        spriteRenderer.sprite = sp_tube_centrifuged;
        content = ContentsEnum.Enum.CellPellet_DNASupernatant;
        SymbolRenderer.sprite = null;
    }

    public void DNA_PCR_Solution()
    {
        spriteRenderer.sprite = sp_tube_filled;
        content = ContentsEnum.Enum.DNA_PCR_Solution;
        SymbolRenderer.sprite = sp_DNA_PCR_Solution;
        symbolTransform.localScale = new Vector3(1.2f, 1.2f, 0);
    }

    public void PurifiedGene()
    {
        content = ContentsEnum.Enum.PurifiedGene;
        SymbolRenderer.sprite = sp_purified_gene;
        symbolTransform.localScale = new Vector3(1.2f, 1.2f, 0);
    }

    public void GGA_mix()
    {
        content = ContentsEnum.Enum.GGA_mix;
        SymbolRenderer.sprite = sp_GGA_mix;
        symbolTransform.localScale = new Vector3(.6f, .6f, 0);
    }

    public void Plasmids()
    {
        content = ContentsEnum.Enum.Plasmids;
        SymbolRenderer.sprite = sp_plasmids;
        symbolTransform.localScale = new Vector3(.6f, .6f, 0);
    }

    public void Plasmids_Cells()
    {
        content = ContentsEnum.Enum.Plasmids_Cells;
        SymbolRenderer.sprite = sp_plasmids_cells;
        symbolTransform.localScale = new Vector3(.3f, .3f, 0);
    }

    public void TransformedCells()
    {
        content = ContentsEnum.Enum.TransformedCells;
        SymbolRenderer.sprite = sp_transformedCells;
        symbolTransform.localScale = new Vector3(.3f, .3f, 0);
    }

    public void PetriDish()
    {
        spriteRenderer.sprite = sp_petri_dish;
        content = ContentsEnum.Enum.PetriDish;
        SymbolRenderer.sprite = null;
    }


    public void Reset()
    {
        Start();
    }
}
