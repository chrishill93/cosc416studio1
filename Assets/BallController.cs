using Unity.VisualScripting.InputSystem;
using UnityEngine;

public class BallController : MonoBehaviour
{
    public Rigidbody spherRigidBody;

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

        Debug.Log("Resultant Vector: " + inputVector);
    }
}
