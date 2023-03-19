using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class TestThrow : MonoBehaviour
{
    public float throwAngle;
    
    public GameObject objectToThrow;

    public GameObject positionToThrow;

    public Slider powerBar;
    
    public Vector3 direction;

    public float chargeRate = 10.0f; // How fast the power charges per second
    public float maxCharge = 70.0f; // Maximum charge level
    private float currentCharge = 20.0f; // Current charge level

    private void Start()
    {
        powerBar.maxValue = maxCharge;
        powerBar.minValue = 20.0f;
    }

    void Update()
    {
        //Debug.Log(currentCharge);

        if (!FindObjectOfType(typeof(BulletBehavior)))
        {
            if (Input.GetKey(KeyCode.Space))
            {
                currentCharge += chargeRate * Time.deltaTime;
                currentCharge = Mathf.Clamp(currentCharge, 20.0f, maxCharge);

                powerBar.value = currentCharge;
            }

            if (Input.GetKeyUp(KeyCode.Space))
            {
                ThrowObject(currentCharge);
                currentCharge = 20f;
                
                powerBar.value = currentCharge;
            }

            
        }
        
        
        
        //ThrowObject();
        
        
    }

    private Vector3 GetMouseDirection()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = Camera.main.transform.position.z - transform.position.z;
        return (Camera.main.ScreenToWorldPoint(mousePos) - transform.position).normalized;
    }

    private void ThrowObject(float force)
    {
        GameObject newObject = Instantiate(objectToThrow, positionToThrow.transform.position, Quaternion.identity);
        Rigidbody rb = newObject.GetComponent<Rigidbody>();
        rb.useGravity = true;
        rb.velocity = CalculateThrowVelocity(force);
        float torqueForce = force * force * 5;
        rb.AddTorque(new Vector3(0, Random.value, 0) * torqueForce); // add torque to the rigidbody
    }

    private Vector3 CalculateThrowVelocity(float force)
    {
        float radians = throwAngle * Mathf.Deg2Rad;
        Vector3 initialVelocity = new Vector3(0, Mathf.Sin(radians), Mathf.Cos(radians)) * force;
        return Quaternion.LookRotation(direction) * initialVelocity;
    }

}
