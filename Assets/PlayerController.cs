using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    
    public float speed = 5.0f;

    private Transform playerTransform;
    
    private Collider col;
    
    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        playerTransform = transform;
        
        col = GetComponent<Collider>();
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
    }

    private void MovePlayer()
    {
        float horizontal = Input.GetAxis("Horizontal");
        //float vertical = Input.GetAxis("Vertical");
        
        Vector3 moveDirection = new Vector3(horizontal, 0.0f, 0.0f);
        playerTransform.Translate(moveDirection*speed*Time.deltaTime,Space.World);
    }
}
