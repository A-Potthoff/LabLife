using UnityEngine;
using UnityEngine.EventSystems;

namespace Demonstration
{
    /// <summary>
    /// Achtung, nutzen dieser Klasse setzt vorraus, dass die Aktive Kamera einen 2D PhysicsRaycaster hat und ein EventSystem Objekt in der Szene existiert.
    /// Sollten Kinderklassen eigene Awake Methoden nutzen, bitte zuerst base.Awake() aufrufen.
    /// </summary>
    [RequireComponent(typeof(SpriteRenderer), typeof(Collider2D))]
    public abstract class ClickableBase : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
    { 
        private SpriteRenderer _sr;
        private Color _baseColor;
        private Color _tintColor;

        private void Awake()
        {
            _sr = GetComponent<SpriteRenderer>();
            _baseColor = _sr.color;
            _tintColor = _baseColor * 0.7f;
            _tintColor.a = _baseColor.a;
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            OnClick();
        }

        public abstract void OnClick();
        
        public void OnPointerEnter(PointerEventData eventData)
        {
            _sr.color = _tintColor;
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            _sr.color = _baseColor;
        }
    }
}