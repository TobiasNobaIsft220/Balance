using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Script_Menu : MonoBehaviour
{

    public void Jugar(string empezarPartida)
    {
        SceneManager.LoadScene(empezarPartida);
    }
    
    public void Salir()
    {
        Debug.Log("Se salio del juego");
        Application.Quit();
    }
}