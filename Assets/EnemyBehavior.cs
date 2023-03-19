using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemyBehavior : MonoBehaviour
{
    private Transform enemyTransform;

    private float speedId;
    // Start is called before the first frame update
    void Start()
    {
        enemyTransform = transform;
        
    }

    private void Awake()
    {
        speedId = Random.Range(1, 7);
        
    }

    // Update is called once per frame
    void Update()
    {
        StupidMove(speedId);
    }

    void StupidMove(float speed)
    {
        Vector3 moveDirection = new Vector3(0.0f, 0.0f, -speed);
        enemyTransform.rotation = new Quaternion(0f,180f,0f,0f);
        enemyTransform.localScale = new Vector3(speed * 10, speed * 10, speed * 10);
        enemyTransform.Translate(moveDirection * speed * Time.deltaTime,Space.World);
    }
}
