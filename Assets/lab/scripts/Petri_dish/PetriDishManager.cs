using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Object_specific_manager : MonoBehaviour
{

    [Header("Petri dish attributes")] //to make the unity scene more readable

    [SerializeField] public bool is_empty;
    [SerializeField] public string contains;
    [SerializeField] public bool culture_has_grown = false;
    [SerializeField] public bool coverage;

    public void Start_minigame()
    {
        // Set the data in the static class
        MinigameData.IsEmpty = is_empty;
        MinigameData.Contains = contains;
        MinigameData.CultureHasGrown = culture_has_grown;
        MinigameData.Coverage = coverage;

        // Load the new scene
        SceneManager.LoadScene("MinigameScene"); // Replace with your scene name
        Debug.Log("Minigame started!");
    }
}

public static class MinigameData
{
    public static bool IsEmpty { get; set; }
    public static string Contains { get; set; }
    public static bool CultureHasGrown { get; set; }
    public static bool Coverage { get; set; }
}

