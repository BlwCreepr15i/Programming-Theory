using UnityEngine;

public class GameManager : MonoBehaviour
{   
    public static bool gameOver { get; private set; }
    public Canvas canvas;
    private GameUIHandler gameUIHandler;
    private SpawnManager spawnManager;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameUIHandler = canvas.GetComponent<GameUIHandler>();
        spawnManager = GameObject.Find("Spawn Manager").GetComponent<SpawnManager>();

        StartGame();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame()
    {
        gameOver = false;
        gameUIHandler.DisableGameOverScreen();
        spawnManager.Initiate();
        
    }

    public void EndGame()
    {
        gameOver = true;
        gameUIHandler.ShowGameOverScreen();
        spawnManager.DespawnAllVehicles();
    }
}
