using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Script_Menu : MonoBehaviour
{
    public GameObject botonLogin;
    public GameObject botonCuenta;

    void Start()
    {
        ActualizarUI();
        
        // Subscribirnos al evento de cierre de sesión
        AuthManager.OnLogout += ActualizarUI;
    }

    void OnDestroy()
    {
        AuthManager.OnLogout -= ActualizarUI;
    }

    public void ActualizarUI()
    {
        bool logeado = AuthManager.Instance.HaySesionIniciada();

        botonLogin.SetActive(!logeado);
        botonCuenta.SetActive(logeado);
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
}