using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public float restartDelay = 1f;
    bool gameHasEnded = false;

    public void CompleteLevel()
    {
        Debug.Log("Gagné bravo");

    }

    public void GameOVER ()
    {
        if (gameHasEnded == false)
        {
            gameHasEnded = true;
            Debug.Log("Perdu ouinouin");
            Invoke("Restart", restartDelay);
        }
        
    }

    void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    }
}
