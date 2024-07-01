using UnityEngine;

public class WeigthDetectionColliderScript : MonoBehaviour
{
    private WeightController parentWeight;

    private void Start()
    {
        parentWeight = GetComponentInParent<WeightController>();
        if (parentWeight == null)
        {
            Debug.Log("Parent weight NOT found");
        }
    }
}
