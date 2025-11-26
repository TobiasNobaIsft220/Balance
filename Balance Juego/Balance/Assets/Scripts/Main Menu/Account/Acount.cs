using UnityEngine;
using TMPro;

public class Acount : MonoBehaviour
{
    public TMP_Text nombre;

    public TMP_Text mejorPuntaje;

    public TMP_Text ultimoPuntaje;

    public TMP_Text partidasJugadas;

    public void cargarPerfilCuenta()
    {
        StartCoroutine(APIManager.instancia.CargarPerfil( (resp) =>
        {
            if(resp != null && resp.name != null)
            {
                nombre.text = $"Nombre: {resp.name}";

                mejorPuntaje.text = $"Mejor puntaje: {resp.bestScore}";

                ultimoPuntaje.text = $"Ultimo puntaje: {resp.lastScore}";

                partidasJugadas.text = $"Partidas jugadas: {resp.gamesPlayed}";
            }
            else
            {
                Debug.Log("No funco");
            }
        }));
    }
}
