using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemySpawn : MonoBehaviour
{
    public int difficulty = 1;

    public GameObject spawnpoint0;
    public GameObject spawnpoint1;
    public GameObject spawnpoint2;
    public GameObject spawnpoint3;

    public GameObject enemy;
    
    // Start is called before the first frame update
    void Start()
    {
        FirstWave();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void FirstWave()
    {
        difficulty = difficulty * 1;
        
        
        for (int i = 0; i < 10*difficulty; i++)
        {
            int spawnpoint = Random.Range(0, 3);
            Vector3 position = new Vector3();

            if (spawnpoint == 0)
            {
                position = spawnpoint0.transform.position;
            }
            if (spawnpoint == 1)
            {
                position = spawnpoint1.transform.position;
            }
            if (spawnpoint == 2)
            {
                position = spawnpoint2.transform.position;
            }
            if (spawnpoint == 3)
            {
                position = spawnpoint3.transform.position;
            }
            
            
            Instantiate(enemy, position,quaternion.identity);
            
        }
    }
}
