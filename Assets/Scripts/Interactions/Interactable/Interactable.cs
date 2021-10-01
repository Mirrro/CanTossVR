using UnityEngine;
using UnityEngine.Events;

namespace Interactions
{
    /// <summary>
    /// Can be selected and hovered by Interactors.
    /// </summary>
    public class Interactable : MonoBehaviour
    {
        public UnityEvent Hovered = new UnityEvent();
        public UnityEvent UnHovered = new UnityEvent();

        [SerializeField] private bool OnlyHoverable;

        public bool CanBeSelected => selectingInteractor == null && !OnlyHoverable;
        public Interactor selectingInteractor;
        
        public Interactor hoveringInteractor;
    
        public void RegisterSelectBy(Interactor interactor)
        {
            if (CanBeSelected)
            {
                return;
            }
            
            selectingInteractor = interactor;
        }

        public void RegisterUnSelectBy()
        {
            selectingInteractor = null;
        }

        public void RegisterHoverBy(Interactor interactor)
        {
            hoveringInteractor = interactor;
            Hovered?.Invoke();
        }

        public void RegisterUnHoverBy()
        {
            hoveringInteractor = null;
            UnHovered?.Invoke();
        }
    }
}
