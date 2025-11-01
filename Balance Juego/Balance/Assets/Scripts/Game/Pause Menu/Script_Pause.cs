using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Script_Pause : MonoBehaviour
{

    private bool isPaused;
    public GameObject pausePanel;

    [SerializeField] private TextMeshProUGUI currentlyScoreText;

    [SerializeField] private GameObject scoreText;
    
    void Update()
    {
        // Al presionar Escape → alternar pausa
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                Reanudar();
            }
            else
            {
                MostrarPausa();
            }
        }
        
        if (isPaused && Input.GetKeyDown(KeyCode.Space))
        {
            Reintentar();
        }
        
    }

    public void MostrarPausa()
    {
        isPaused = true;

        Time.timeScale = 0f;
        pausePanel.SetActive(true);

        //Verifica que el texto de puntuacion de la partida este activado, y si es asi, lo desactiva
        if (scoreText != null)
        {
            scoreText.SetActive(false);
        }

        //Guarda la puntuacion cuando entramos al menu de pausa
        PlayerPrefs.SetFloat("currentlyScore", Script_Score_Manager.instance.score);
        PlayerPrefs.Save();
        Script_Score_Manager.instance.StopCounting();

        //Muestra la puntuacion de la partida en el menu de pausa
        float currentlyScore = PlayerPrefs.GetFloat("currentlyScore", 0f);
        currentlyScoreText.text = "Puntuación actual: " + Mathf.FloorToInt(currentlyScore).ToString();

    }

    public void Reanudar()
    {
        isPaused = false;

        Time.timeScale = 1f;
        pausePanel.SetActive(false);
        scoreText.SetActive(true);
        Script_Score_Manager.instance.Counting();
    }

    public void MenuPrincipal()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu Scene");
    }

    public void Reintentar()
    {
        isPaused = false;

        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    
}
