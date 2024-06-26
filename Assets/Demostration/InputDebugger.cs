using UnityEngine;
using UnityEngine.InputSystem;

namespace Demostration
{
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

        private static void Interact(InputAction.CallbackContext ctx)
        {
            Debug.LogWarning("Hallo");
        }
    
        private void Update()
        {
            Debug.Log(moveAction.action.ReadValue<Vector2>());
        
            //Altes System
            if (interactAction.action.WasPerformedThisFrame())
            {
                Interact(new InputAction.CallbackContext());
            }
        }
    }
}
