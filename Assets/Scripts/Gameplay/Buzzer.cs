using Interactions;
using UnityEngine;
using UnityEngine.Events;

namespace Gameplay
{
    /// <summary>
    /// Registers hover events and fires a Button.Pressed event when the user hovers over it. 
    /// </summary>
    [RequireComponent(typeof(Interactable))]
    public class Buzzer : MonoBehaviour
    {
        [SerializeField] private GameObject lightSource;
    
        public UnityEvent Pressed;
    
        private Interactable interactable;

        private void Awake()
        {
            lightSource.SetActive(false);
            interactable = GetComponent<Interactable>();
        }

        private void OnEnable()
        {
            interactable.Hovered.AddListener(OnHover);
            interactable.UnHovered.AddListener(OnUnHover);
        }

        private void OnDisable()
        {
            interactable.Hovered.RemoveListener(OnHover);
            interactable.UnHovered.RemoveListener(OnUnHover);
        }

        private void OnHover()
        {
            Pressed?.Invoke();
            lightSource.SetActive(true);
        }
    
        private void OnUnHover()
        {
            lightSource.SetActive(false);
        }
    }
}
