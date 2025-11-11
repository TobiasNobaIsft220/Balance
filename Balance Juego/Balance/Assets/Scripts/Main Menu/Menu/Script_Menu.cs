using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Script_Menu : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Return))
        {
            Jugar();
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Salir();
        }
    }

    public void Jugar()
    {
        SceneManager.LoadScene("Game Scene");
    }

    public void Salir()
    {
        Debug.Log("Se salio del juego");
        Application.Quit();
    }
}