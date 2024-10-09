using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement_Script : MonoBehaviour
{


    public Camera Camera;
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
    }
}
