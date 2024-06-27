using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object_specific_manager : MonoBehaviour
{

    [Header("Petri dish attributes")] //to make the unity scene more readable

    [SerializeField] public bool is_empty;
    [SerializeField] public string contains;
    [SerializeField] public bool culture_has_grown = false;
    [SerializeField] public bool coverage;



    public void Start_minigame()
    {
        // Define the logic for starting the minigame here
        Debug.Log("Minigame started!");
    }
}
