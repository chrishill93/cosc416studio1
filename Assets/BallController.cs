using Unity.VisualScripting.InputSystem;
using UnityEngine;

public class BallController : MonoBehaviour
{
    [SerializeField] private Rigidbody sphereRigidBody;
    [SerializeField] float ballSpeed;
    [SerializeField] float jumpForce = 5f;
    private bool isGrounded = true;
    public void MoveBall(Vector2 input)
    {
        Vector3 inputXZPlane = new(input.x, 0, input.y);
        sphereRigidBody.AddForce(inputXZPlane * ballSpeed);
    }

    public void JumpBall()
    {
        if(isGrounded)
        {
            sphereRigidBody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    void Start()
    {
        Debug.Log("Calling the Start method");
    }

    void Update()
    {
        Vector2 inputVector = Vector2.zero;
        if(Input.GetKey(KeyCode.W))
        {
            inputVector += Vector2.up;
        }
        if(Input.GetKey(KeyCode.A))
        {
            inputVector += Vector2.left;
        }
        if(Input.GetKey(KeyCode.S))
        {
            inputVector += Vector2.down;
        }
        if(Input.GetKey(KeyCode.D))
        {
            inputVector += Vector2.right;
        }

        Vector3 inputXZPlane = new Vector3(inputVector.x, 0, inputVector.y);
        sphereRigidBody.AddForce(inputXZPlane * ballSpeed);

        if(Input.GetKeyDown(KeyCode.Space))
        {
            JumpBall();
        }
        Debug.Log("Resultant Vector: " + inputVector);
        Debug.Log("Resultant Vector: " + inputXZPlane);
    }
}
