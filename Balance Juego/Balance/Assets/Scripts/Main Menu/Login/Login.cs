using UnityEngine;
using TMPro;


public class LoginUI : MonoBehaviour
{
    public TMP_InputField emailInput;
    public TMP_InputField passwordInput;
    public TMP_Text mensaje;

    public GameObject accountButton;

    public GameObject loginButton;

    public void OnLoginButton()
    {
        string email = emailInput.text;
        string password = passwordInput.text;

        StartCoroutine(APIManager.instancia.Login(email, password, (resp) =>
        {
            if(resp != null && resp.usuario != null)
            {
                mensaje.text = "¡Inicio de sesion exitoso! ¡Bienvenido " + resp.usuario.nombreDeUsuario + "!";

                accountButton.SetActive(true);

                loginButton.SetActive(false);

            }
            else
            {
                mensaje.text = "Error al iniciar sesion: Email o contraseña incorrectos." ;
            }
        }));
    }

    public void LogOut()
    {
        PlayerPrefs.DeleteKey("token");
        PlayerPrefs.DeleteKey("username");
        PlayerPrefs.Save();
        Debug.Log("Sesion cerrada correctamente.");
        loginButton.SetActive(true);
        accountButton.SetActive(false);
    }
}
