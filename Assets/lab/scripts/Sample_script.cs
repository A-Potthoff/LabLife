using UnityEditor.PackageManager.UI;
using UnityEngine;

public class Sample_script : MonoBehaviour{

    [Header("Sample sprites")]
    [SerializeField] public Sprite tube_empty;
    [SerializeField] public Sprite tube_bacteria;
    //[SerializeField] public Sprite tube_empty;


    [Header("Sample Attributes")]
    [SerializeField] public string form; // e.g., "petri-dish", "tube"
    [SerializeField] public bool hasBacteria;
    [SerializeField] public bool isEmpty;
    [SerializeField] public bool isCentrifuged;
    [SerializeField] public string content; // e.g., "DNA", "plasmids", "cells", "cells+plasmids", "transformed cells", "None"
    [SerializeField] public bool isConcentrated;
    private SpriteRenderer spriteRenderer;


    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>(); //to change the sprites of 
    }

    public void bacteria_transferred()
    {
        // change the sprite of the object to the one with bacteria
        if (tube_bacteria != null)
        {
            spriteRenderer.sprite = tube_bacteria;
        }
        else
        {
            Debug.LogError("Sprite not found in Resources folder.");
        }


    }

    private void Reset()
    {
        // reset the attributes of the object
        //form = "tube";
        //hasBacteria = false;
        //isEmpty = true;
        //isCentrifuged = false;
        //content = "None";
        //isConcentrated = false;
        spriteRenderer.sprite = Resources.Load<Sprite>("Assets/lab/spirtes/sample/tube_empty.jpg");
    }

}
