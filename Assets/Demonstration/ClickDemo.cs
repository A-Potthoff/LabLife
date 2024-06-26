using UnityEngine;

namespace Demonstration
{
    public class ClickDemo : ClickableBase
    {
        public override void OnClick()
        {
            Debug.LogWarning($"{name} wurde geklickt");
        }
    }
}