using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gameplay
{
    /// <summary>
    /// Spawns and destroys balls 
    /// </summary>
    public class BallSpawner : MonoBehaviour
    {
        [SerializeField] private GameObject ballPrefab;
    
        private List<GameObject> allBalls = new List<GameObject>();

        public void SpawnBalls(int amount)
        {
            StartCoroutine(SpawnBallsWithDelay(amount, 0.2f));
        }

        public void ClearBalls()
        {
            allBalls.ForEach(Destroy);
        }

        private IEnumerator SpawnBallsWithDelay(int amount, float delay)
        {
            for (int i = 0; i < amount; i++)
            {
                SpawnBall();
                yield return new WaitForSeconds(delay);
            }
        }
        
        private void SpawnBall()
        {
            allBalls.Add(Instantiate(ballPrefab, transform.position, Quaternion.identity));
        }
    }
}
