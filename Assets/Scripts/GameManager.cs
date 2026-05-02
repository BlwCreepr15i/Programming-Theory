using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour
{   
    public static bool gameOver { get; private set; }
    public Canvas canvas;
    public int score;

    private GameUIHandler gameUIHandler;
    private SpawnManager spawnManager;
    private float scoreIncreaseDelay = 4.0f;
    private float scoreIncreaseTime = 2.0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameUIHandler = canvas.GetComponent<GameUIHandler>();
        spawnManager = GameObject.Find("Spawn Manager").GetComponent<SpawnManager>();

        StartGame();
    }

    public void StartGame()
    {
        gameOver = false;
        score = 0;
        gameUIHandler.DisableGameOverScreen();
        spawnManager.Initiate();
        InvokeRepeating("IncreaseScore", scoreIncreaseDelay, scoreIncreaseTime); // score increases for every x seconds passed
    }

    private void IncreaseScore()
    {
        score++;
        gameUIHandler.UpdateScore(); // UI will reflect changes on score
    }

    public void EndGame()
    {
        gameOver = true;
        gameUIHandler.ShowGameOverScreen();
        spawnManager.DespawnAllVehicles();
        CancelInvoke(); // Cancels all InvokeRepeating schedules (stops increasing scores)
    }
}
