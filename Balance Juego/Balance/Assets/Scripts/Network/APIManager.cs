using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using System;


public class APIManager : MonoBehaviour {

    public static APIManager instancia;
    private string URL_BASE = "http://localhost:3000/api/";

    private void Awake()
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


    //Login

    [Serializable]
    public class LoginRequest {
        public string email;
        public string password;
    }

    [Serializable]
    public class UsuarioDTO {
        public int id;
        public string nombreDeUsuario;
        public string email;
    }

    [Serializable]
    public class LoginResponse {
        public string message;
        public string token;
        public UsuarioDTO usuario;
    }
    public IEnumerator Login(string email, string password, Action<LoginResponse> onDone) {

        //Pasar los datos a un objeto
        var reqObj = new LoginRequest
        {
            email = email,
            password = password 
        };

        //Pasar los datos del objeto a json
        string json = JsonUtility.ToJson(reqObj);

        var uwr = new UnityWebRequest(URL_BASE + "login", "POST") {
            uploadHandler = new UploadHandlerRaw(System.Text.Encoding.UTF8.GetBytes(json)),
            downloadHandler = new DownloadHandlerBuffer()
        };
        
        uwr.SetRequestHeader("Content-Type","application/json");

        yield return uwr.SendWebRequest();

        if (uwr.result == UnityWebRequest.Result.Success) {

            var resp = JsonUtility.FromJson<LoginResponse>(uwr.downloadHandler.text);

            if (resp != null && resp.usuario != null)
            {
                PlayerPrefs.SetString("token", resp.token);
                PlayerPrefs.SetString("username", resp.usuario.nombreDeUsuario);
                PlayerPrefs.Save();
            }

            onDone?.Invoke(resp);
            
        } else {
            Debug.LogError("Login error: " + uwr.error + " - " + uwr.downloadHandler.text);
            onDone?.Invoke(null);
        }
    }

    //Perfil
    [Serializable]
    public class UsuarioPerfil {
        public int id;
        public string name;
        public string email;
        public int bestScore;
        public int lastScore;
        public int gamesPlayed;

    }

    [Serializable]
    public class PerfilResponse {
        public UsuarioPerfil usuario;
    }

    public IEnumerator CargarPerfil(System.Action<UsuarioPerfil> onDone)
    {
        string token = PlayerPrefs.GetString("token", "");

        using (UnityWebRequest uwr = UnityWebRequest.Get(URL_BASE + "perfil"))
        {
            uwr.SetRequestHeader("Authorization", "Bearer " + token);
            yield return uwr.SendWebRequest();

            if (uwr.result == UnityWebRequest.Result.Success)
            {
                var data = JsonUtility.FromJson<PerfilResponse>(uwr.downloadHandler.text);

                onDone(data.usuario);
            }
            else
            {
                Debug.LogError("Error cargando perfil: " + uwr.error);
                onDone(null);
            }
        }
    }
}