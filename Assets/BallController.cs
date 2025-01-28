using Unity.VisualScripting.InputSystem;
using UnityEngine;

public class BallController : MonoBehaviour
{
    [SerializeField] private Rigidbody sphereRigidBody;
    [SerializeField] float ballSpeed;
    public void MoveBall(Vector2 input)
    {
        Vector3 inputXZPlane = new(input.x, 0, input.y);
        sphereRigidBody.AddForce(inputXZPlane * ballSpeed);
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
        Debug.Log("Resultant Vector: " + inputVector);
        Debug.Log("Resultant Vector: " + inputXZPlane);
    }
}
