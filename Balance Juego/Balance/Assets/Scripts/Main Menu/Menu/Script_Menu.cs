using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Script_Menu : MonoBehaviour
{
    
    public GameObject accountButton;

    public GameObject loginButton;

    void Start()
    {
        if(accountButton != null && loginButton)
        {
            AutoLogin();
        }
    }

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

    public void AutoLogin()
    {
        string token = PlayerPrefs.GetString("token", "");

        if(token != "")
        {
            Debug.Log("Usuario logeado: " + PlayerPrefs.GetString("username"));
            loginButton.SetActive(false);
            accountButton.SetActive(true);
        }
        else
        {
            Debug.Log("No hay sesion guardada");
        }
    }
}