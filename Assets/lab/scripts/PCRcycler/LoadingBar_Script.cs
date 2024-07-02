using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadingBar_Script : MonoBehaviour
{
    [SerializeField] private Image fillingLoadingBar;
    [SerializeField] private Image LoadingBar_background;

    private void Start()
    {
        // Ensure the loading bar is initially inactive
        gameObject.SetActive(false);
    }

    // Function to initialize loading bar by other objects
    public void Loading(float duration)
    {
        StartCoroutine(LoadingCoroutine(duration));
    }

    // Function that fills loading bar
    private IEnumerator LoadingCoroutine(float duration)
    {
        float currentTime = 0f;
        fillingLoadingBar.fillAmount = 0f; // Reset the fill amount to start from empty
        

        while (currentTime < duration)
        {
            currentTime += Time.deltaTime;
            fillingLoadingBar.fillAmount = currentTime / duration;
            yield return null; // Wait for the next frame
        }

        fillingLoadingBar.fillAmount = 1f; // Ensure it's fully filled at the end
        OnLoadingComplete();
    }

    private void OnLoadingComplete()
    {
        Debug.Log("Loading Complete");
        gameObject.SetActive(false); // Hide the loading bar again
    }

    private void Update()
    {   

    }
}
