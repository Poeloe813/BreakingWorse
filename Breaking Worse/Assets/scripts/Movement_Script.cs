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

    private Vector3 direction;
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
        rb.velocity = rb.rotation * direction;

    }

    private void OnMove(InputValue value)
    {
        direction = new Vector3(value.Get<Vector2>().x * speed, rb.velocity.y, value.Get<Vector2>().y * speed);
    }
}
