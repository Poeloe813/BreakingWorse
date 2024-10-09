using System.ComponentModel.Design;
using UnityEngine;
using UnityEngine.InputSystem;

public class Movement1 : MonoBehaviour
{
    public InputAction moveRight;
    public InputAction moveLeft;
    public InputAction moveUp;
    public InputAction moveDown;

    private Rigidbody rb;

    public float SpeedLeftRight;
    public float SpeedUp;
    public float SpeedDown;
    public float SpeedSink;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        rb.velocity = new Vector3(0, 0, 0);

        if (moveLeft.ReadValue<float>() == 1)
        {
            rb.velocity += new Vector3(-SpeedLeftRight, 0, 0);
        }

        else if (moveRight.ReadValue<float>() == 1)
        {
            rb.velocity += new Vector3(SpeedLeftRight, 0, 0);
        }



        if (moveUp.ReadValue<float>() == 1)
        {
            rb.velocity += new Vector3(0, SpeedUp, 0);
        }

        else if (moveDown.ReadValue<float>() == 1)
        {
            rb.velocity += new Vector3(0, -SpeedDown, 0);
        }
        else if (moveUp.ReadValue<float>() == 0)
        {
            rb.velocity += new Vector3(0, -SpeedSink, 0);
        }
    }

    private void OnEnable()
    {
        moveRight.Enable();
        moveLeft.Enable();
        moveUp.Enable();
        moveDown.Enable();
    }
    private void OnDisable()
    {
        moveRight.Disable();
        moveLeft.Disable();
        moveUp.Disable();
        moveDown.Disable();
    }
}