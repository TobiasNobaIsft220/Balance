using UnityEngine;

//Archivo aparentemente innecesario

/*
public class AuthManager : MonoBehaviour
{
    public static AuthManager Instance;

    public static event System.Action OnLogout;

    public string Token { get; private set; }
    public UserData UsuarioActual { get; private set; }

    private const string TOKEN_KEY = "auth_token";

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            CargarSesion();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    //Se llama desde ApiManager cuando el login fue exitoso
    public void GuardarSesion(string token, UserData userData)
    {
        Token = token;
        UsuarioActual = userData;

        PlayerPrefs.SetString(TOKEN_KEY, token);
        PlayerPrefs.Save();

        Debug.Log("Sesión guardada correctamente");
    }

    //Busca si había un token guardado
    private void CargarSesion()
    {
        if (PlayerPrefs.HasKey(TOKEN_KEY))
        {
            Token = PlayerPrefs.GetString(TOKEN_KEY);
            Debug.Log("Sesión restaurada con token: " + Token);
        }
    }

    //Se puede usar para cerrar sesión
    public void CerrarSesion()
    {
        Token = null;
        UsuarioActual = null;

        PlayerPrefs.DeleteKey(TOKEN_KEY);
        PlayerPrefs.Save();

        OnLogout?.Invoke();

        Debug.Log("Sesión cerrada");
    }

    public bool HaySesionIniciada()
    {
        return !string.IsNullOrEmpty(Token);
    }
}

//Clase auxiliar que representa el usuario que viene desde la API
[System.Serializable]
public class UserData
{
    public int id;
    public string name;
    public string email;
    public int bestScore;
    public int lastScore;
    public int gamesPlayed;
}*/