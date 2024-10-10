using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class Movement_Script : MonoBehaviour
{


    public Camera Camera;
    public float speed;

    private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.rotation = new Quaternion(transform.rotation.x, Camera.transform.rotation.y, transform.rotation.z, transform.rotation.w).normalized;
        Camera.transform.position = rb.position;
        rb.transform.GetChild(0).rotation = Camera.transform.rotation;
    }

    private void OnMove(InputValue value)
    {
        rb.velocity = rb.rotation * new Vector3(value.Get<Vector2>().x * speed, rb.velocity.y, value.Get<Vector2>().y * speed);
    }
}
