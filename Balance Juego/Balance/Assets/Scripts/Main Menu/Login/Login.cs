using UnityEngine;
using TMPro;


public class LoginUI : MonoBehaviour
{
    //Inicializa los objetos de la escena que utilizara
    public TMP_InputField emailInput;
    public TMP_InputField passwordInput;
    public TMP_Text mensaje;

    public GameObject accountButton;

    public GameObject loginButton;

    //Funcion que sirve inicia sesion
    public void OnLoginButton()
    {
        //Agarra lo escrito en los inputs y lo guarda en una variable a cada uno
        string email = emailInput.text;
        string password = passwordInput.text;

        //Empieza la coroutine Login que viene del script APIManager
        StartCoroutine(APIManager.instancia.Login(email, password, (resp) =>
        {
            //Verifica que la respuesta de la funcion no sea nula
            if(resp != null && resp.usuario != null)
            {
                //Muestra el mensaje de exito
                mensaje.text = "¡Inicio de sesion exitoso! ¡Bienvenido " + resp.usuario.nombreDeUsuario + "!";

                //Se activa el boton de cuenta
                accountButton.SetActive(true);

                //Se desactiva el boton login
                loginButton.SetActive(false);

            }
            else
            {
                //Muestra el mensaje de error
                mensaje.text = "Error al iniciar sesion: Email o contraseña incorrectos." ;
            }
        }));
    }

    //Funcion que sirve para cerrar sesion
    public void LogOut()
    {
        //Borra las configuraciones del usuario y luego guarda
        PlayerPrefs.DeleteKey("token");
        PlayerPrefs.DeleteKey("username");
        PlayerPrefs.Save();

        //Muestra el mensaje de sesion cerrada en consola
        Debug.Log("Sesion cerrada correctamente.");

        //Activa el boton login y desactiva el boton cuenta
        loginButton.SetActive(true);
        accountButton.SetActive(false);
    }
}
