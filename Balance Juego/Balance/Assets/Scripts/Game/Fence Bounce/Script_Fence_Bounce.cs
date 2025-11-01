using UnityEngine;

public class Script_Fence_Bounce : MonoBehaviour
{
    public float pushForce = 400f; // fuerza con la que empuja hacia el centro
    private Vector3 corralCenter = new Vector3(5, 0, -5); // centro del corral

    private void OnCollisionEnter(Collision collision)
    {
        // Solo empuja objetos con Rigidbody (como la pelota)
        Rigidbody rb = collision.rigidbody;
        if (rb != null)
        {
            // Calcula dirección desde la pared hacia el centro
            Vector3 directionToCenter = (corralCenter - rb.position).normalized;

            // Aplica impulso hacia el centro
            rb.AddForce(directionToCenter * pushForce, ForceMode.Impulse);
        }
    }
}
