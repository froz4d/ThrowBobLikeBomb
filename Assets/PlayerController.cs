using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    
    public float startspeed = 5.0f;

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
        MovePlayer(startspeed);

        if (Input.GetKey(KeyCode.LeftShift))
        {
            MovePlayer(startspeed * 2.5f);
        }
    }

    private void MovePlayer(float speed)
    {
        float horizontal = Input.GetAxis("Horizontal");
        //float vertical = Input.GetAxis("Vertical");
        
        Vector3 moveDirection = new Vector3(horizontal, 0.0f, 0.0f);
        playerTransform.Translate(moveDirection * speed * Time.deltaTime,Space.World);
    }
}
