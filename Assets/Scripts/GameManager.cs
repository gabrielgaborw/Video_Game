using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject gameOverText;
    private bool gameOver = false;

    public void EndGame()
    {
        if (gameOver == false)
        {
            gameOverText.SetActive(true);
            gameOver = true;
            Invoke("Restart", 5f);
        }
    }

    void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
