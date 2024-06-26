using UnityEngine;
using UnityEngine.InputSystem;

public class InputDebugger : MonoBehaviour
{
    [SerializeField] private InputActionReference moveAction;
    [SerializeField] private InputActionReference interactAction;
    
    private void Awake()
    {
        moveAction.action.Enable();
        interactAction.action.Enable();
        interactAction.action.performed += Interact;
    }

    private void Interact(InputAction.CallbackContext ctx)
    {
        Debug.LogWarning("Hallo");
    }
    
    private void Update()
    {
        Debug.Log(moveAction.action.ReadValue<Vector2>());
    }
}
