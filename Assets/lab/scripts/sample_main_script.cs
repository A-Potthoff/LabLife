using UnityEngine;

public class Sample : MonoBehaviour
{
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


    public void TransferToTestTube()
    {
        if (content == "None")
        {
            // Implement the logic for transferring to a test tube
            // call the new scene (?) or minigame (here or from object ??????????????????)
            content = "bacteria";
            isConcentrated = true;
            Debug.Log("Transferred to test tube.");
        }
        else
        {
            //call tutorial and explanation
        }
    }

    public void Centrifuge()
    {
        if (!isCentrifuged)
        {
            // Implement the logic for centrifugation
            Debug.Log("Centrifuging...");
            isCentrifuged = true;
            Debug.Log("Centrifugation complete.");
        }
        else
        {
            //call tutorial and explanation
        }
    }

    public void PipetteSupernatant()
    {
        if (isCentrifuged)
        {
            // Implement the logic for pipetting supernatant
            content = "DNA";
            isConcentrated = false;
            Debug.Log("Supernatant pipetted. Sample content is now DNA.");
        }
        else
        {
            //call tutorial and explanation
        }
    }

    public void StartPCR()
    {
        if (content == "DNA" && !isConcentrated)
        {
            // Implement the logic for PCR and golden gate primer design
            content = "plasmid";
            Debug.Log("PCR complete. Sample content is now plasmid.");
        }
        else
        {
            //call tutorial and explanation
        }
    }

    public void TransformCells()
    {
        if (content == "plasmids")
        {
            // Implement the logic for transformation
            content = "cells+plasmids";
            Debug.Log("Transformation complete. Sample content is now cells+plasmids.");
        }
        else
        {
            //call tutorial and explanation
        }
    }

    public void PCRCycler()
    {
        if (content == "cells+plasmids")
        {
            // Implement the logic for PCR cycling
            content = "transformed plasmids";
            Debug.Log("PCR cycling complete. Sample content is now transformed plasmids.");
        }
        else
        {
            //call tutorial and explanation
        }
    }

    public void Control()
    {
        if (content == "transformed cells")
        {
            // Implement the logic for control
            Debug.Log("Control complete. End of game.");
        }
        else
        {
            //call tutorial and explanation
        }
    }
}
