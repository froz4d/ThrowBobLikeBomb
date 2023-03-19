using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemyBehavior : MonoBehaviour
{
    private Transform enemyTransform;
    
    private Rigidbody enemyRigidbody;

    private float force;
    private float mass;

    // Start is called before the first frame update
    void Start()
    {
        enemyTransform = transform;
        enemyRigidbody = GetComponent<Rigidbody>();
    }
    

    private void Awake()
    {
        force = Random.Range(1, 3);
        mass = Random.Range(2,6);
    }

    // Update is called once per frames
    void FixedUpdate()
    {
        StupidMove(force,mass);
    }

    void StupidMove(float force,float mass)
    {
        force = force * 10;
        mass = mass * 10;
        
        Vector3 moveDirection = new Vector3(0.0f, 0.0f, -force);
        
        enemyTransform.localScale = new Vector3(mass, mass, mass);
        enemyTransform.rotation = new Quaternion(0f, 180f, 0f, 0f);

        //Friction
        float acceleration = force / mass;
        
        
        enemyRigidbody.MovePosition(enemyRigidbody.position + moveDirection * acceleration * Time.deltaTime);
        
    }



    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Destory"))
        {
            Destroy(this.gameObject);
        }

        

    }

}