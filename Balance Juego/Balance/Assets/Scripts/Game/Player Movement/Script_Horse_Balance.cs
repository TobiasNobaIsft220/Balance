using UnityEngine;

public class Script_Horse_Balance : MonoBehaviour
{

    public Script_Game_Over script_Game_Over_Caballo;

    void Update()
    {
        
        if(Vector3.Angle(transform.up, Vector3.up) > 90f){
            script_Game_Over_Caballo.MostrarGameOver();
        }

    }
}
