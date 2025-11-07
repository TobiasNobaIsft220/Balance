using UnityEngine;
using TMPro;

public class Script_Splash_Text : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI splashText;

    // Lista de frases
    [SerializeField] private string[] mensajes = new string[]
    {
        "¡Hecho con amor!",
        "No te confundas",
        "Son la una y media",
        "Momo = la clave",
        "DANDADANDANDADANDANDADAN",
        "Minecraft > terraria",
        "Emir mi papá",
        "Conoces la tragedia de Darth Plagueis el sabio?",
        "No le diremos a Simon, esta bien?",
        "ju ji",
        "Eña",
        "Versión 1.0.0 – estable... más o menos",
        "Despite everything, it's still you",
        "2016 casi 7",
        "IM OLD",
        "Kris get the Banana",
        "Tu siguiente frase sera... BALANCE",
        "Find her",
        "And last, was the girl. At last, was the girl.",
        "Your vision narrows. ... Your head is spinning."
    };

    void Start()
    {
        if (splashText == null)
            splashText = GetComponent<TextMeshProUGUI>();

        // Elige un mensaje aleatorio al iniciar
        string mensajeRandom = mensajes[Random.Range(0, mensajes.Length)];
        splashText.text = mensajeRandom;
    }
}
