using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveRB : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    [SerializeField] private float moveSpeed = 15f;
    [SerializeField] private float rotateSpeed = 90f;

    void Start()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            rb.AddForce(rb.transform.forward * moveSpeed * Time.deltaTime);
        }

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
