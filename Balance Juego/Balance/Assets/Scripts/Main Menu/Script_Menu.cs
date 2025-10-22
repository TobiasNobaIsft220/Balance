using UnityEngine;
using UnityEngine.SceneManagement;

public class Script_Menu : MonoBehaviour
{

    public void Jugar(string empezarJuego)
    {
        SceneManager.LoadScene(empezarJuego);
    }
    public void Salir()
    {
        Application.Quit();

        Debug.Log("Se salio del juego");
    }
}
