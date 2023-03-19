using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestThrow : MonoBehaviour
{
    public float throwForce = 10f;
    public float throwAngle = 45f;
    public float torqueForce = 5f; // added torqueForce variable
    public GameObject objectToThrow;
    public Vector3 direction;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ThrowObject();
        }
        
    }

    private Vector3 GetMouseDirection()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = Camera.main.transform.position.z - transform.position.z;
        return (Camera.main.ScreenToWorldPoint(mousePos) - transform.position).normalized;
    }

    private void ThrowObject()
    {
        GameObject newObject = Instantiate(objectToThrow, transform.position, Quaternion.identity);
        Rigidbody rb = newObject.GetComponent<Rigidbody>();
        rb.useGravity = true;
        rb.velocity = CalculateThrowVelocity();
        torqueForce = torqueForce * throwForce * 3;
        rb.AddTorque(new Vector3(Random.value, Random.value, Random.value) * torqueForce); // add torque to the rigidbody
    }

    private Vector3 CalculateThrowVelocity()
    {
        float radians = throwAngle * Mathf.Deg2Rad;
        Vector3 initialVelocity = new Vector3(Mathf.Cos(radians), Mathf.Sin(radians), 0) * throwForce;
        return Quaternion.LookRotation(direction) * initialVelocity;
    }

}
