using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Script_Game_Over : MonoBehaviour
{

    private bool isGameOver = false;
    private bool scoreAlreadyUpdated = false;
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
        if (isGameOver)
        {
            return;
        }
        else
        {
            isGameOver = true;
        }

        Time.timeScale = 0f;
        gameOverPanel.SetActive(true);

        //Verifica que el texto de puntuacion de la partida este activado, y si es asi, lo desactiva
        if (scoreText != null)
        {
            scoreText.SetActive(false);
        }


        //Muestra la puntuacion de la partida en el menu game over
        int finalScore = PlayerPrefs.GetInt("FinalScore", 0);
        finalScoreText.text = "Puntuación final: " + Mathf.FloorToInt(finalScore).ToString();

        if(!scoreAlreadyUpdated)
        {
            scoreAlreadyUpdated = true;
            updateScoreGameOver(finalScore);
        }
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

        StartCoroutine(APIManager.instancia.SumarPartida((nuevoValor) =>
        {
            if (nuevoValor != -1)
            {
                Debug.Log("Partidas jugadas ahora: " + nuevoValor);
            }
        }));

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void updateScoreGameOver(int finalScoreFunction)
    {
        StartCoroutine(APIManager.instancia.updateScore(finalScoreFunction));
    }
}
