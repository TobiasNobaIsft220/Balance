using UnityEngine;

public class MovimientoCaballo : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public float speed = 10f;
    Rigidbody rb;
    Vector3 movementInput;

    void Start()
    {

    }
    
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    private void Update()
    {
        movementInput = Vector3.zero;

        if (Input.GetKey(KeyCode.W))
        {
            movementInput.z = 1;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            movementInput.z = -1;
        }

        if (Input.GetKey(KeyCode.D))
        {
            movementInput.x = 1;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            movementInput.x = -1;
        }
    }

    protected void FixedUpdate()
    {
        Move(movementInput);
    }
    
    void Move(Vector3 direction)
    {
        rb.AddForce(direction.normalized * speed, ForceMode.Acceleration);
    }
}
