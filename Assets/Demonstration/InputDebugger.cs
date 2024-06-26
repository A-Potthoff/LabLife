using UnityEngine;
using UnityEngine.InputSystem;

namespace Demonstration
{
    [RequireComponent(typeof(Rigidbody2D), typeof(Collider2D), typeof(SpriteRenderer))]
    public class InputDebugger : MonoBehaviour
    {
        [Header("Components")]
        [SerializeField] private InputActionReference moveAction;
        [SerializeField] private InputActionReference interactAction;
        // Intern Components
        private Rigidbody2D _rb;
        private SpriteRenderer _sr;
        
        [Header("Parameter")]
        [SerializeField] private float speed;
        [SerializeField] private Color interactColor;
        
        //Temps
        private Color _defaultColor;
        
        private void Awake()
        {
            _rb = GetComponent<Rigidbody2D>();
            _sr = GetComponent<SpriteRenderer>();
            _defaultColor = _sr.color;
            
            // Input Aktivieren
            moveAction.action.Enable();
            interactAction.action.Enable();
            interactAction.action.started += _ => Interact(true);
            interactAction.action.canceled += _ => Interact(false);
        }

        private void Interact(bool state)
        {
            _sr.color = state ? interactColor: _defaultColor;
        }
    
        private void Update()
        {
            _rb.velocity = moveAction.action.ReadValue<Vector2>() * speed;
        
            // Altes System
            // if (interactAction.action.WasPerformedThisFrame())
            // {
            //     Interact(new InputAction.CallbackContext());
            // }
        }
    }
}
