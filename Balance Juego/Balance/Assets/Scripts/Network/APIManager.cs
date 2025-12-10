using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using System;


public class APIManager : MonoBehaviour {

    //Crea una instancia con la que los demas scripts podran acceder a funciones de este script
    public static APIManager instancia;

    //Define la variable de la url para que sea mas facil de cambiar en un futuro, ademas es privada
    private string URL_BASE = "http://localhost:3000/api/";

    //Funcion que se ejecuta solo una vez al inicio
    private void Awake()
    {
        //Verifica si no existe una instancia de APIManager
        if (instancia == null)
        {
            //Guarda la instancia para que pueda ser utilizada por los demas scripts
            instancia = this;

            //Evita que el objeto se destruya al cambiar la escena
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            //Si ya habia una instancia elimina la nueva
            Destroy(gameObject);
        }
    }


    //Clases y funcion para el Login

    //Clase para guardar los datos pedidos
    [Serializable]
    public class LoginRequest {
        public string email;
        public string password;
    }

    //Clase para guardar los datos del usuario
    [Serializable]
    public class UsuarioDTO {
        public int id;
        public string nombreDeUsuario;
        public string email;
    }

    //Clase para guardar los datos devueltos
    [Serializable]
    public class LoginResponse {
        public string message;
        public string token;
        public UsuarioDTO usuario;
    }

    //Funcion Login que envia email y password
    public IEnumerator Login(string email, string password, Action<LoginResponse> onDone) {

        //Pasar los datos a un objeto
        var reqObj = new LoginRequest
        {
            email = email,
            password = password 
        };

        //Pasar los datos del objeto a json
        string json = JsonUtility.ToJson(reqObj);

        //Configuracion de la peticion HTTP con el metodo POST
        var uwr = new UnityWebRequest(URL_BASE + "login", "POST") {
            //Envia JSON y recibe la respuesta
            uploadHandler = new UploadHandlerRaw(System.Text.Encoding.UTF8.GetBytes(json)),
            downloadHandler = new DownloadHandlerBuffer()
        };
        
        //Defino que le estoy enviando contenido de tipo JSON
        uwr.SetRequestHeader("Content-Type","application/json");

        //Se envia y espera
        yield return uwr.SendWebRequest();

        //Verifica si la respuesta fue satisfactoria
        if (uwr.result == UnityWebRequest.Result.Success) {

            //Guarda la respuesta en una variable
            var resp = JsonUtility.FromJson<LoginResponse>(uwr.downloadHandler.text);

            //Verifica que la respuesta no sea nula
            if (resp != null && resp.usuario != null)
            {
                //Cambia la configurcion del usuario y la guarda
                PlayerPrefs.SetString("token", resp.token);
                PlayerPrefs.SetString("username", resp.usuario.nombreDeUsuario);
                PlayerPrefs.Save();
            }

            onDone?.Invoke(resp);
            
        } else {
            //Muestra mensaje de error
            Debug.LogError("Login error: " + uwr.error + " - " + uwr.downloadHandler.text);


            onDone?.Invoke(null);
        }
    }

    //Clases y funcion para cargar el Perfil

    //Clase para guardar los datos del usuario
    [Serializable]
    public class UsuarioPerfil {
        public int id;
        public string name;
        public string email;
        public int bestScore;
        public int lastScore;
        public int gamesPlayed;

    }

    //Clase para guardar los datos devueltos
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

    //Clase y funcion para Actualizar puntaje

    //Clase para guardar los datos pedidos
    [Serializable]
    public class PuntajeRequest {
        public int puntaje;
    }

    public IEnumerator updateScore(int puntaje)
    {
        PuntajeRequest data = new PuntajeRequest { puntaje = puntaje };
        string token = PlayerPrefs.GetString("token", "");

        string json = JsonUtility.ToJson(data);

        using (UnityWebRequest uwr = new UnityWebRequest(URL_BASE + "updateScore", "POST"))
        {
            uwr.uploadHandler = new UploadHandlerRaw(System.Text.Encoding.UTF8.GetBytes(json));
            uwr.downloadHandler = new DownloadHandlerBuffer();
            uwr.SetRequestHeader("Content-Type", "application/json");
            uwr.SetRequestHeader("Authorization", "Bearer " + token);

            yield return uwr.SendWebRequest();

            if (uwr.result == UnityWebRequest.Result.Success)
            {
                Debug.Log("Puntaje actualizado correctamente");
            }
            else
            {
                Debug.LogError("Error enviando puntaje: " + uwr.error);
            }
        }
    }

    //Clase y funcion para Actualizar partidas jugadas

    //Clase para guardar los datos devueltos
    [Serializable]
    public class PartidaResponse {
        public string message;
        public int gamesPlayed;
    }

    public IEnumerator SumarPartida(Action<int> onDone)
    {
        string token = PlayerPrefs.GetString("token", "");

        using (UnityWebRequest uwr = UnityWebRequest.PostWwwForm(URL_BASE + "updateGamesPlayed", ""))
        {
            uwr.SetRequestHeader("Authorization", "Bearer " + token);

            yield return uwr.SendWebRequest();

            if (uwr.result == UnityWebRequest.Result.Success)
            {
                Debug.Log("Respuesta al sumar partida: " + uwr.downloadHandler.text);

                //Clase temporal para parsear el JSON
                PartidaResponse resp = JsonUtility.FromJson<PartidaResponse>(uwr.downloadHandler.text);

                onDone(resp.gamesPlayed);
            }
            else
            {
                Debug.LogError("Error al sumar partida: " + uwr.error);
                onDone(-1);
            }
        }
    }
}