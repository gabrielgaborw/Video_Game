using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject gameOverText;
    private bool gameOver = false;

    public void EndGame()
    {
        // Game Over screen
        if (gameOver == false)
        {
            gameOverText.SetActive(true);
            gameOver = true;
            // Restarting the game with a 5 second delay
            Invoke("Restart", 5f);
        }
    }

    void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
