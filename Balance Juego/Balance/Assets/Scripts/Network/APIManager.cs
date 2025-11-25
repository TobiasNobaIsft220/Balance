using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using System;

public class APIManager : MonoBehaviour
{
    public static APIManager instancia;

    private string URL_BASE = "http://localhost:3000/api/";

    [Header("Usuario Logeado")]
    public int id;
    public string email;
    public string name;
    public int bestScore;
    public int lastScore;
    public int gamesPlayed;

    void Awake()
    {
        if (instancia == null)
        {
            instancia = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    /* ===========================================================
       LOGIN
     =========================================================== */
    public IEnumerator Login(string email, string password, Action<bool, string> callback)
    {
        WWWForm form = new WWWForm();
        form.AddField("email", email);
        form.AddField("password", password);

        UnityWebRequest www = UnityWebRequest.Post(URL_BASE + "login", form);

        yield return www.SendWebRequest();

        if (www.result != UnityWebRequest.Result.Success)
        {
            callback(false, "Error al conectar con el servidor");
        }
        else
        {
            var json = www.downloadHandler.text;
            UsuarioResponse data = JsonUtility.FromJson<UsuarioResponse>(json);

            if (data == null || data.usuario == null)
            {
                callback(false, "Credenciales incorrectas");
            }
            else
            {
                id = data.usuario.id;
                name = data.usuario.name;
                email = data.usuario.email;
                bestScore = data.usuario.bestScore;
                lastScore = data.usuario.lastScore;
                gamesPlayed = data.usuario.gamesPlayed;

                // Guardar sesión en PlayerPrefs
                PlayerPrefs.SetInt("usuarioActivo", id);

                callback(true, "Login exitoso");
            }
        }
    }

    /* ===========================================================
       OBTENER INFO DEL USUARIO
     =========================================================== */
    public IEnumerator ObtenerDatosUsuario(Action<bool> callback)
    {
        UnityWebRequest www = UnityWebRequest.Get(URL_BASE + idUsuario);

        yield return www.SendWebRequest();

        if (www.result != UnityWebRequest.Result.Success)
        {
            callback(false);
        }
        else
        {
            var json = www.downloadHandler.text;
            Usuario data = JsonUtility.FromJson<Usuario>(json);

            nombreUsuario = data.name;
            emailUsuario = data.email;
            mejorPuntaje = data.bestScore;
            ultimoPuntaje = data.lastScore;
            partidasJugadas = data.gamesPlayed;

            callback(true);
        }
    }

    /* ===========================================================
       SUMAR PARTIDA JUGADA
     =========================================================== */
    public IEnumerator SumarPartida(Action<bool> callback)
    {
        WWWForm form = new WWWForm();
        form.AddField("id", idUsuario);

        UnityWebRequest www = UnityWebRequest.Post(URL_BASE + "sumarPartida", form);

        yield return www.SendWebRequest();

        callback(www.result == UnityWebRequest.Result.Success);
    }

    /* ===========================================================
       GUARDAR ÚLTIMO PUNTAJE
     =========================================================== */
    public IEnumerator GuardarUltimoPuntaje(int score, Action<bool> callback)
    {
        WWWForm form = new WWWForm();
        form.AddField("id", idUsuario);
        form.AddField("ultimoPuntaje", score);

        UnityWebRequest www = UnityWebRequest.Post(URL_BASE + "ultimoPuntaje", form);

        yield return www.SendWebRequest();

        callback(www.result == UnityWebRequest.Result.Success);
    }

    /* ===========================================================
       ACTUALIZAR MEJOR PUNTAJE
     =========================================================== */
    public IEnumerator ActualizarMejorPuntaje(int nuevoScore, Action<bool> callback)
    {
        WWWForm form = new WWWForm();
        form.AddField("id", id);
        form.AddField("mejorPuntaje", nuevoScore);

        UnityWebRequest www = UnityWebRequest.Post(URL_BASE + "mejorPuntaje", form);

        yield return www.SendWebRequest();

        callback(www.result == UnityWebRequest.Result.Success);
    }
}

/* ============================================
   CLASES PARA RECIBIR JSON
============================================ */
[Serializable]
public class UsuarioResponse
{
    public string message;
    public Usuario usuario;
}

[Serializable]
public class Usuario
{
    public int id;
    public string name;
    public string email;
}

