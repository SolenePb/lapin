using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public float restartDelay = 0.2f;
    bool gameHasEnded = false;
    public GameObject completeLevelUI;
    public GameObject tutoUI;

    public void CompleteLevel()
    {
        completeLevelUI.SetActive(true);
        tutoUI.SetActive(false);

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
