using UnityEngine;
using TMPro;

public class LoginUI : MonoBehaviour
{
    public TMP_InputField emailInput;
    public TMP_InputField passwordInput;
    public TMP_Text mensaje;

    public void OnLoginButton()
    {
        string email = emailInput.text;
        string password = passwordInput.text;

        StartCoroutine(APIManager.instancia.Login(email, password, (ok, msg) =>
        {
            mensaje.text = msg;

            if (ok)
            {
                UnityEngine.SceneManagement.SceneManager.LoadScene("Menu Scene");
            }
        }));
    }
}
