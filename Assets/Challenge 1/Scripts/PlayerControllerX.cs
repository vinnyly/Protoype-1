using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControllerX : MonoBehaviour
{
    [Header("Flight Parameters")]
    public float speed;
    public float rotationSpeed;
    public InputAction MoveAction;

    public Vector2 verticalInput;

    public float deadzone = 0.08f;
    public float inputSmoothing = 8f;
    private float smoothedVerticalInput;

    // Start is called before the first frame update
    void Start()
    {
        MoveAction.Enable();
    }

    // Update is called once per frame
    void Update()
    {
        //NEW ANALOG INPUT
        // Read continuous analog values (-1.0 to 1.0)
        Vector2 input = MoveAction.ReadValue<Vector2>();
        float rawVertical = input.y;

        // Deadzone filtering
        if (Mathf.Abs(rawVertical) < deadzone)
        {
            rawVertical = 0f;
        }

        transform.Translate(Vector3.forward * speed * Time.deltaTime);
        transform.Rotate(Vector3.left * rawVertical * rotationSpeed * Time.deltaTime);


        //OLD KEYBOARD INPUT
        //// get the user's vertical input
        //verticalInput = MoveAction.ReadValue<Vector2>();

        //// move the plane forward at a constant rate
        //transform.Translate(Vector3.forward * speed);

        //// tilt the plane up/down based on up/down arrow keys
        //transform.Rotate(Vector3.left * rotationSpeed * Time.deltaTime * verticalInput.y);
    }
}
