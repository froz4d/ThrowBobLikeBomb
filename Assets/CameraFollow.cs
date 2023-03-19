using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform defaultTarget;

    public Vector3 offset;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (FindObjectOfType(typeof(BulletBehavior)))
        {
            BulletBehavior bullet = FindObjectOfType(typeof(BulletBehavior)) as BulletBehavior;
            GameObject bulletGameObject = bullet.gameObject;
            
            transform.position = bulletGameObject.transform.position + offset;
            
        }
        else
        {
            transform.position = defaultTarget.position;
        }
    }
}
