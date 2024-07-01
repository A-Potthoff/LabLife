using UnityEngine;

public class Holder : MonoBehaviour
{
    [SerializeField] public bool filled;

    private void Start()
    {
        filled = false;
    }
}