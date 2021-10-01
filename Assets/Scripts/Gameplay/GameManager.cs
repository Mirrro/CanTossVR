using Gameplay;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private CanTableMananger canTableMananger;
    [SerializeField] private BallSpawner ballSpawner;
    [SerializeField] private Buzzer restartBuzzer;
    [SerializeField] private GameObject activateOnVictory;

    private void OnEnable()
    {
        canTableMananger.AllCansRemoved.AddListener(Victory);
        restartBuzzer.Pressed.AddListener(StartNewGame);
    }

    private void Victory()
    {
        activateOnVictory.SetActive(true);
    }

    private void StartNewGame()
    {
        activateOnVictory.SetActive(false);
        canTableMananger.SetUpCans();
        ballSpawner.ClearBalls();
        ballSpawner.SpawnBalls(20);
    }
}
