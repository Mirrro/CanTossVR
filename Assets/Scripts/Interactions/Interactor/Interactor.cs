using System.Collections.Generic;
using System.Linq;
using InputMananger;
using UnityEngine;

namespace Interactions
{
    /// <summary>
    /// Can hover and select Interactables. Selected Interactables will be attached to the hand by a FixedJoint once the
    /// User has pressed the Trigger.
    /// </summary>
    [RequireComponent(typeof(Rigidbody))]
    public class Interactor : MonoBehaviour
    {
        [SerializeField] private List<Interactable> hoveredInteractables = new List<Interactable>();
        [SerializeField] private Interactable selectedInteractable;
        [SerializeField] private ControllerInput input;
        [SerializeField] private FixedJoint joint;

        [SerializeField] private Rigidbody handBody;

        private void OnEnable()
        {
            input.TriggerPressed.AddListener(OnTriggerPressed);
            input.TriggerReleased.AddListener(OnTriggerReleased);
        }

        private void OnDisable()
        {
            input.TriggerPressed.RemoveListener(OnTriggerPressed);
            input.TriggerReleased.RemoveListener(OnTriggerReleased);
        }
    
        private void OnTriggerEnter(Collider other)
        {
            var interactable = other.GetComponent<Interactable>();
            if (interactable != null && !hoveredInteractables.Contains(interactable))
            {
                Hover(interactable);
            }
        }

        private void OnTriggerExit(Collider other)
        {
            var interactable = other.GetComponent<Interactable>();
            if (interactable != null)
            {
                UnHover(interactable);
            }
        }

        private void OnTriggerPressed()
        {
            if (hoveredInteractables.Count > 0)
            {
                Select(hoveredInteractables.Last());
            }
        }
        
        private void OnTriggerReleased()
        {
            UnSelect(selectedInteractable);
        }

        private void Hover(Interactable interactable)
        {
            interactable.RegisterHoverBy(this);
            hoveredInteractables.Add(interactable);
        }

        private void UnHover(Interactable interactable)
        {
            interactable.RegisterUnHoverBy();
            hoveredInteractables.Remove(interactable);
        }

        private void Select(Interactable interactable)
        {
            if (selectedInteractable || !interactable.CanBeSelected)
            {
                return;
            }

            selectedInteractable = interactable;
            interactable.RegisterSelectBy(this);
            Attach(interactable.GetComponent<Rigidbody>());
        }
    
        private void UnSelect(Interactable interactable)
        {
            if (!selectedInteractable)
            {
                return;
            }

            interactable.RegisterUnSelectBy();
            Detach();
            selectedInteractable = null;
        }

        private void Attach(Rigidbody rigidbody)
        {
            joint.connectedBody = rigidbody;
        }

        private void Detach()
        {
            joint.connectedBody = null;
            selectedInteractable.GetComponent<Rigidbody>().velocity = handBody.velocity;
            selectedInteractable.GetComponent<Rigidbody>().angularVelocity = handBody.angularVelocity;
        }
    
    }
}
