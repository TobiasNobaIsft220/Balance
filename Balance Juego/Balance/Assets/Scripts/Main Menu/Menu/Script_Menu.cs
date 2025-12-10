using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Script_Menu : MonoBehaviour
{
    
    //Inicializa los objetos de la escena que utilizara
    public GameObject accountButton;

    public GameObject loginButton;

    //Funcion que se ejecuta al iniciar
    void Start()
    {
        //Verifica si el boton de cuenta y el boton login existen
        if(accountButton != null && loginButton)
        {
            //Ejecuta la funcion para iniciar sesion automaticamente
            AutoLogin();
        }
    }

    //Funcion que se ejecuta todo el tiempo
    void Update()
    {
        //Verifica si se presionan la tecla espacio o enter
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Return))
        {
            //Ejecuta la funcion para empezar el juego
            Jugar();
        }

        //Verifica si se presiona la tecla escape
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            //Ejecuta la funcion para salir del juego
            Salir();
        }
    }

    //Funcion para empezar el juego
    public void Jugar()
    {
        //Empieza la coroutine SumarPartida que viene del script APIMAnager
        StartCoroutine(APIManager.instancia.SumarPartida((nuevoValor) =>
        {
            //Verifica que la respuesta de la coroutine sea diferente a -1
            if (nuevoValor != -1)
            {
                //Muestra el mensaje de partidas jugadas en consola
                Debug.Log("Partidas jugadas ahora: " + nuevoValor);
            }
        }));

        //Carga la escena del juego
        SceneManager.LoadScene("Game Scene");
    }

    //Funcion para salir del juego
    public void Salir()
    {
        //Muestra el mensaje de que se salio del juego en la consola
        Debug.Log("Se salio del juego");

        //Cierra la aplicacion
        Application.Quit();
    }

    //Funcion para iniciar sesion automaticamente si ya hay una cuenta iniciada
    public void AutoLogin()
    {
        //Guarda el token del usuario en una variable
        string token = PlayerPrefs.GetString("token", "");

        //Verifica que la variable sea diferente a ""
        if(token != "")
        {
            //Muestra mensaje en consola
            Debug.Log("Usuario logeado: " + PlayerPrefs.GetString("username"));

            //Activa el boton de cuenta y desactiva el boton login
            loginButton.SetActive(false);
            accountButton.SetActive(true);
        }
        else
        {
            //Muestra el mensaje
            Debug.Log("No hay sesion guardada");
        }
    }
}