using UnityEngine;
using TMPro;

public class Script_Score_Manager : MonoBehaviour
{
 
    public static Script_Score_Manager instance;

    public float score = 0f;
    public float pointsPerSecond = 10f; // podés ajustar cuántos puntos da por segundo
    private bool isCounting = true;

    [SerializeField] private TextMeshProUGUI scoreText;

    void Awake()
    {
        instance = this;
    }

    void Update()
    {
        if (isCounting)
        {
            score += pointsPerSecond * Time.deltaTime;
            if (scoreText != null)
                scoreText.text = "Puntuación: " + Mathf.FloorToInt(score).ToString();
        }
    }

    public void StopCounting()
    {
        isCounting = false;
    }

    public void ResetScore()
    {
        score = 0;
        isCounting = true;
    }

    public void Counting()
    {
        isCounting = true;
    }
}
