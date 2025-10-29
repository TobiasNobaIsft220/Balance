using UnityEngine;

public class Script_Player_Movement : MonoBehaviour
{
    public float moveForce = 25f; 
    private Rigidbody rb;

    void Start()
    {
        Time.timeScale = 1f;
        rb = GetComponent<Rigidbody>();
        rb.WakeUp();
        
        rb.interpolation = RigidbodyInterpolation.Interpolate;
        rb.linearDamping = 0.4f;
        rb.angularDamping = 0.2f;
        rb.mass = 8f;

        rb.centerOfMass = new Vector3(0, -0.3f, 0);

        // 🎲 Pequeña inclinación o impulso aleatorio al inicio
        Vector3 randomTorque = new Vector3(
            Random.Range(-1f, 1f),
            0f,
            Random.Range(-1f, 1f)
        ).normalized * 5f; // ajustá la fuerza a gusto

        rb.AddTorque(randomTorque, ForceMode.Impulse);
    }

    void FixedUpdate()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        // Aplica torque para rodar la pelota
         if (Mathf.Abs(moveX) < 0.1f && Mathf.Abs(moveZ) < 0.1f)
        return;

        // --- MOVIMIENTO BASE ---
        Vector3 torque = new Vector3(-moveZ, 0, moveX).normalized * moveForce;
        rb.AddTorque(torque, ForceMode.Force);

        
        // --- IMPULSO DE DESPLAZAMIENTO ---
        Vector3 direccion = new Vector3(moveX, 0, moveZ).normalized;
        float impulsoExtra = moveForce * 0.4f; // podés subir este valor si querés más movimiento
        rb.AddForce(direccion * impulsoExtra, ForceMode.Acceleration);

        // --- ESTABILIZADOR ---
        // Una pequeña fuerza vertical que mantiene la pelota “centrada” y evita que se caiga el caballo
        rb.AddForce(Vector3.up * 4f, ForceMode.Acceleration);

        // Detecta si la pelota está muy inclinada
        if (Vector3.Angle(Vector3.up, transform.up) > 20f)
        {
            // Aplica una pequeña corrección para estabilizar
            rb.AddTorque(Vector3.Cross(transform.up, Vector3.up) * 10f);
        }
    }
}
