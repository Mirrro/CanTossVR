using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Gameplay
{
    /// <summary>
    /// This class is used to make spawning of cans a little easier
    /// </summary>
    public class CanContainer : MonoBehaviour
    {
        private List<Can> cans = new List<Can>();
        private void Awake()
        {
            cans = GetComponentsInChildren<Can>().ToList();
        }

        public List<GameObject> GetCansGameObjects()
        {
            var canObjects = new List<GameObject>();
        
            cans.ForEach(can => canObjects.Add(can.gameObject));
        
            return canObjects;
        }
        public void UnParentCans()
        {
            cans.ForEach(can => can.gameObject.transform.SetParent(null));
        }
    }
}
