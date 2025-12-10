using UnityEngine;

public class Script_Horse_Balance : MonoBehaviour
{

    //Define un objeto de tipo game over para poder manipular funciones de ese menu
    public Script_Game_Over script_Game_Over_Caballo;

    //Funcion que se ejecuta al inicio
    void Start()
    {
        //Vuelve a hacer funcinar el tiempo en el caballo
        Time.timeScale = 1f;

        //Crea un objeto rigibody con el rigidbody del caballo
        Rigidbody rb = GetComponent<Rigidbody>();

        //Define un centro de masa para el caballo
        rb.centerOfMass = new Vector3(0, -0.5f, 0);

        //Define la masa del caballo
        rb.mass = 3f;

        //Suaviza los movimientos del caballo para que se vea correctamente sin importar los FPS
        rb.interpolation = RigidbodyInterpolation.Interpolate;

        //Despierta el rigidbody del caballo por si no se mueve (si paso)
        rb.WakeUp();
    }

    void Update()
    {
        //Verifica si el angulo del caballo es de 85 grados
        if(Vector3.Angle(transform.up, Vector3.up) > 85f)
        {
            
            //Si hay un menú de pausa, lo desactiva
            Script_Pause pause = FindAnyObjectByType<Script_Pause>();
            if (pause != null)
            {
                //Desactiva el script
                pause.enabled = false; 
                if (pause.pausePanel != null)
                {
                    //Oculta el panel si estaba visibles
                    pause.pausePanel.SetActive(false); 
                }
            }

            //Guarda la puntuacion cuando el caballo se cae
            PlayerPrefs.SetInt("FinalScore", Mathf.FloorToInt(Script_Score_Manager.instance.score));
            PlayerPrefs.Save();

            //Deja de contar el contador y muestra el menu game over
            Script_Score_Manager.instance.StopCounting();
            script_Game_Over_Caballo.MostrarGameOver();
        }

    }
}
