using UnityEngine;

public class Script_Horse_Balance : MonoBehaviour
{
    void Start()
    {
        Time.timeScale = 1f;

        Rigidbody rb = GetComponent<Rigidbody>();
        rb.centerOfMass = new Vector3(0, -0.5f, 0);
        rb.mass = 3f;

        rb.interpolation = RigidbodyInterpolation.Interpolate;

        rb.WakeUp();
    }

    public Script_Game_Over script_Game_Over_Caballo;

    void Update()
    {
        
        if(Vector3.Angle(transform.up, Vector3.up) > 80f){
            script_Game_Over_Caballo.MostrarGameOver();
        }

    }
}
