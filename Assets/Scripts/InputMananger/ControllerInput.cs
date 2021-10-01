using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

namespace InputMananger
{
    /// <summary>
    /// Reads the Users Input and fires corresponding Events
    /// </summary>
    public class ControllerInput : MonoBehaviour
    {
        [SerializeField] private InputActionProperty TriggerButton;

        public UnityEvent TriggerPressed = new UnityEvent();
        public UnityEvent TriggerReleased = new UnityEvent();

        private void Awake()
        {
            TriggerButton.action.Enable();
            TriggerButton.action.performed += OnTriggerPressed;
            TriggerButton.action.canceled += OnTriggerReleased;
        }

        private void OnTriggerReleased(InputAction.CallbackContext obj)
        {
            TriggerReleased?.Invoke();
        }

        private void OnTriggerPressed(InputAction.CallbackContext ctx)
        {
            TriggerPressed?.Invoke();
        }
    }
}