using UnityEngine;
using UnityEngine.SceneManagement;

public class Script_Game_Over : MonoBehaviour
{

    public GameObject gameOverPanel;

    public void MostrarGameOver()
    {
        gameOverPanel.SetActive(true);
        Time.timeScale = 0f;
    }

    public void Reintentar()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    
    public void MenuPrincipal()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu Scene");
    }
}
