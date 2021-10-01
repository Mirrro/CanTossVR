using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Gameplay
{
    /// <summary>
    /// Spawns and removes the Cans the User has to throw.
    /// It is also fires an event once all cans are thrown off the table
    /// </summary>
    public class CanTableMananger : MonoBehaviour
    {
        [SerializeField] private GameObject canContainerPrefab;
        [SerializeField] private Transform canSpawnPosition;
    
        public UnityEvent AllCansRemoved = new UnityEvent();
    
        private List<GameObject> cans = new List<GameObject>();

        private void OnTriggerExit(Collider other)
        {
            Debug.Log(other.name);
            var can = other.GetComponentInParent<Can>();
            if (can)
            {
                Debug.Log(other.name);
                cans.Remove(can.gameObject);

                if (cans.Count == 0)
                {
                    AllCansRemoved?.Invoke();
                }
            }
        }

        public void SetUpCans()
        {
            ClearCans();
        
            var container = Instantiate(canContainerPrefab, canSpawnPosition.position, Quaternion.identity).GetComponent<CanContainer>();
            container.UnParentCans();
            cans = container.GetCansGameObjects();
        }

        public void ClearCans()
        {
            cans.ForEach(Destroy);
        }
    }
}
