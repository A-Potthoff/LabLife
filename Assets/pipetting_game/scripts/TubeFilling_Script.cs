using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class TubeFilling_Script : MonoBehaviour
{

    private Coroutine fillingCoroutine = null;
    [SerializeField] private float fillRate = 5;


    public void StartFilling(Image tubeImage)
    {
        if (fillingCoroutine == null)   // Should ensure that only one Coroutine runs at the same time
        {
            Debug.Log("Coroutine started");
            fillingCoroutine = StartCoroutine(FillingCoroutine(tubeImage));
        }
    }

    public void StopFilling()
    {
        Debug.Log("Filling stoped");
        StopCoroutine(fillingCoroutine);
        fillingCoroutine = null;
        
    }

    private IEnumerator FillingCoroutine(Image tubeImage)
    {
        while (true)
        {
            /*if (Input.GetKeyUp(KeyCode.Space))  // For savety, to prevent infinite loops
            {
                StopFilling();
                yield break;
            }*/
            Debug.Log("Filling started");
            tubeImage.fillAmount += Time.deltaTime / fillRate; // Adjust the divisor for desired fill rate

            if (tubeImage.fillAmount > 1f)
            {
                tubeImage.fillAmount = 1f; // Ensure the fill amount does not exceed 1
            }
            yield return null; // Wait for the next frame
        }
    }
}