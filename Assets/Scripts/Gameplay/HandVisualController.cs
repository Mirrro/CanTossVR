using InputMananger;
using UnityEngine;

namespace Gameplay
{
    /// <summary>
    /// Handles animations on the Hand according to the users input
    /// </summary>
    public class HandVisualController : MonoBehaviour
    {
        [SerializeField] private ControllerInput input;
        [SerializeField] private Animator animator;

        private void OnEnable()
        {
            input.TriggerPressed.AddListener(SetAnimatorTrigger);
            input.TriggerReleased.AddListener(SetAnimatorTrigger);
        }
    
        private void OnDisable()
        {
            input.TriggerPressed.RemoveListener(SetAnimatorTrigger);
            input.TriggerReleased.RemoveListener(SetAnimatorTrigger);
        }
        private void SetAnimatorTrigger()
        {
            animator.SetTrigger("OpenAndClose");
        }
    }
}
