using UnityEngine;

public class HayBallController : MonoBehaviour
{
    public float moveForce = 10f; 
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
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
