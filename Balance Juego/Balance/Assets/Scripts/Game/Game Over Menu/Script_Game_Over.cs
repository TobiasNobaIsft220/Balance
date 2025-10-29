using UnityEngine;
using UnityEngine.SceneManagement;

public class Script_Game_Over : MonoBehaviour
{

    public GameObject gameOverPanel;

    public void MostrarGameOver()
    {
        Time.timeScale = 0f;
        gameOverPanel.SetActive(true);
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
