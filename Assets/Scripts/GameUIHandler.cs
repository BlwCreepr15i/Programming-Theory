using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameUIHandler : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameOverText;
    public Button restartButton;
    private GameManager gameManager;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        UpdateScore();
    }

    public void UpdateScore()
    {
        scoreText.text = "Score: " + gameManager.score;
    }

    public void DisableGameOverScreen()
    {
        gameOverText.gameObject.SetActive(false);
        restartButton.gameObject.SetActive(false);
    }

    public void ShowGameOverScreen()
    {
        gameOverText.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(true);
    }

    public void RestartGame()
    {
        gameManager.StartGame();
        UpdateScore();
    }

    public void LoadMenu()
    {
        // TBI: loads menu scene using SceneManager.LoadScene();
    }

}
