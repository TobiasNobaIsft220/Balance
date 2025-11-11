using UnityEngine;
using UnityEngine.UI;

public class Script_Music_Manager : MonoBehaviour
{
    public AudioSource musicSource;
    private bool isMuted = false;

    public Image icon;
    public Sprite soundOnIcon;
    public Sprite soundOffIcon;

    void Start()
    {
        // Recupera el estado anterior del mute (por si el jugador lo cambió antes)
        isMuted = PlayerPrefs.GetInt("MusicMuted", 0) == 1;
        musicSource.mute = isMuted;

        
    }


    public void CambiarMusica()
    {
        isMuted = !isMuted;
        musicSource.mute = isMuted;

        // Guarda la preferencia
        PlayerPrefs.SetInt("MusicMuted", isMuted ? 1 : 0);
        PlayerPrefs.Save();
        
        icon.sprite = isMuted ? soundOffIcon : soundOnIcon;
    }
}
