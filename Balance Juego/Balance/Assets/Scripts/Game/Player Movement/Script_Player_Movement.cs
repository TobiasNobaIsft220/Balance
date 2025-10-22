using UnityEngine;

public class Script_Player_Movement : MonoBehaviour
{
    public float moveForce = 10f; 
    private Rigidbody rb;

    void Start()
    {
        Time.timeScale = 1f;
        rb = GetComponent<Rigidbody>();
        rb.WakeUp();
    }

    void FixedUpdate()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        // Aplica torque para rodar la pelota
        Vector3 torque = new Vector3(-moveZ, 0, moveX) * moveForce;
        rb.AddTorque(torque);
    }
}
