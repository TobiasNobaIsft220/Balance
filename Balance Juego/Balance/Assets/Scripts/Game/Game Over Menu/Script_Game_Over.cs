using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Script_Game_Over : MonoBehaviour
{

    private bool isGameOver = false; 
    public GameObject gameOverPanel;

    [SerializeField] private TextMeshProUGUI finalScoreText;

    [SerializeField] private GameObject scoreText;

    void Update()
    {
        if (isGameOver && Input.GetKeyDown(KeyCode.Space))
        {
            Reintentar();
        }
    }

    public void MostrarGameOver()
    {
        isGameOver = true;

        Time.timeScale = 0f;
        gameOverPanel.SetActive(true);

        //Verifica que el texto de puntuacion de la partida este activado, y si es asi, lo desactiva
        if (scoreText != null)
        {
            scoreText.SetActive(false);
        }


        //Muestra la puntuacion de la partida en el menu game over
        float finalScore = PlayerPrefs.GetFloat("FinalScore", 0f);
        finalScoreText.text = "Puntuación final: " + Mathf.FloorToInt(finalScore).ToString();
    }

    public void MenuPrincipal()
    {
        isGameOver = false;

        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu Scene");
    }

    public void Reintentar()
    {
        isGameOver = false;

        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
