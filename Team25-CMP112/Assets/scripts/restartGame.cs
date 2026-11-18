using UnityEngine;
using UnityEngine.SceneManagement;

public class restartGame : MonoBehaviour
{
    public void LoadCurrentScene()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("GameScene");
    }
}
