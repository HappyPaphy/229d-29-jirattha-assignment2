using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveRB : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    [SerializeField] private float moveSpeed = 15f;
    [SerializeField] private float rotateSpeed = 90f;
    [SerializeField] private float enginePowerThrust, liftBooster, drag, angularDrag;

    void Start()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            rb.AddForce(rb.transform.forward * enginePowerThrust * Time.deltaTime);
        }

        Vector3 lift = Vector3.Project(rb.velocity, transform.forward);
        rb.AddForce(transform.up * lift.magnitude * liftBooster);

        rb.drag = rb.velocity.magnitude * drag; 
        rb.angularDrag = rb.velocity.magnitude * angularDrag;

        rb.AddTorque(Input.GetAxis("Horizontal") * transform.forward * -1);
        rb.AddTorque(Input.GetAxis("Vertical") * transform.right);

        /*if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            rb.AddForce(rb.transform.forward * moveSpeed * Time.deltaTime);
        }*/

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            rb.MoveRotation(rb.rotation * Quaternion.Euler(Vector3.up * -rotateSpeed * Time.deltaTime));
        }

        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            rb.AddForce(rb.transform.forward * -moveSpeed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            rb.MoveRotation(rb.rotation * Quaternion.Euler(Vector3.up * rotateSpeed * Time.deltaTime));
        }
    }
}
