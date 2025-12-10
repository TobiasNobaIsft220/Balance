using UnityEngine;

public class Script_Player_Movement : MonoBehaviour
{
    //Define la variable de fuerza de movimiento
    public float moveForce = 25f;

    //Define la variable del rigidbody
    private Rigidbody rb;

    //Funcion que se ejecuta al inicio
    void Start()
    {
        //Vuelve a hacer funcinar el tiempo en la pelota
        Time.timeScale = 1f;

        //Toma el rigidbody de la pelota y lo guarda en la variable rigidbody
        rb = GetComponent<Rigidbody>();

        //Despierta el rigidbody de la pelota por si no se mueve (si paso)
        rb.WakeUp();
        
        //Suaviza los movimientos de la pelota para que se vea correctamente sin importar los FPS
        rb.interpolation = RigidbodyInterpolation.Interpolate;

        //Reduce la velocidad lineal lentamente
        rb.linearDamping = 0.4f;

        //Reduce la rotación con el tiempo
        rb.angularDamping = 0.2f;

        //Le asigna masa a la pelota
        rb.mass = 8f;

        //Le asigna la ubicacion del centro de masa a la pelota
        rb.centerOfMass = new Vector3(0, -0.3f, 0);

        //Pequeña inclinación o impulso aleatorio al inicio
        Vector3 randomTorque = new Vector3(
            Random.Range(-1f, 1f),
            0f,
            Random.Range(-1f, 1f)
        ).normalized * 5f;

        rb.AddTorque(randomTorque, ForceMode.Impulse);
    }

    //Funcion que se ejecuta 50 veces por segundo, no depende de los fps
    void FixedUpdate()
    {
        //Asigna las teclas A y D para movimietos horizontales
        float moveX = Input.GetAxis("Horizontal");

        //Asigna las teclas W y S para movimientos verticales
        float moveZ = Input.GetAxis("Vertical");

        // Aplica torque para rodar la pelota
         if (Mathf.Abs(moveX) < 0.1f && Mathf.Abs(moveZ) < 0.1f)
        return;

        //Movimiento principal de la pelota. Utiliza torque para quela pelota ruede y no se deslice
        Vector3 torque = new Vector3(-moveZ, 0, moveX).normalized * moveForce;
        rb.AddTorque(torque, ForceMode.Force);

        
        //Impulso extra de desplazamiento
        Vector3 direccion = new Vector3(moveX, 0, moveZ).normalized;
        float impulsoExtra = moveForce * 0.4f;
        rb.AddForce(direccion * impulsoExtra, ForceMode.Acceleration);

        //Una pequeña fuerza vertical que mantiene la pelota “centrada” y evita que se caiga el caballo
        rb.AddForce(Vector3.up * 4f, ForceMode.Acceleration);

        //Detecta si la pelota está muy inclinada
        if (Vector3.Angle(Vector3.up, transform.up) > 20f)
        {
            //Aplica una pequeña corrección para estabilizar
            rb.AddTorque(Vector3.Cross(transform.up, Vector3.up) * 10f);
        }
    }
}
