using UnityEngine;

public class Script_Horse_Balance : MonoBehaviour
{

    public Script_Game_Over script_Game_Over_Caballo;

    void Start()
    {
        Time.timeScale = 1f;

        Rigidbody rb = GetComponent<Rigidbody>();
        rb.centerOfMass = new Vector3(0, -0.5f, 0);
        rb.mass = 3f;

        rb.interpolation = RigidbodyInterpolation.Interpolate;

        rb.WakeUp();
    }

    void Update()
    {
        
        if(Vector3.Angle(transform.up, Vector3.up) > 85f)
        {
            
            // Si hay un menú de pausa, lo desactiva
            Script_Pause pause = FindAnyObjectByType<Script_Pause>();
            if (pause != null)
            {
                pause.enabled = false; // desactiva el script
                if (pause.pausePanel != null)
                {
                    pause.pausePanel.SetActive(false); // oculta el panel si estaba visibles
                }
            }

            //Guarda la puntuacion cuando el caballo se cae
            PlayerPrefs.SetInt("FinalScore", Mathf.FloorToInt(Script_Score_Manager.instance.score));
            PlayerPrefs.Save();
            Script_Score_Manager.instance.StopCounting();
            script_Game_Over_Caballo.MostrarGameOver();
        }

    }
}
