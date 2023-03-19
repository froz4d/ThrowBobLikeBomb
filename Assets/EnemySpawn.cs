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

    private int wave = 1;
    
    // Start is called before the first frame update
    void Start()
    {
        Wave(wave);
    }

    // Update is called once per frame
    void Update()
    {
        if (!FindObjectOfType(typeof(EnemyBehavior)))
        {
            wave += 1;
            Wave(wave);
        }
    }

    public void Wave(int wave)
    {
        difficulty = difficulty * wave;

        StartCoroutine(SpawnEnemies(10 * difficulty));
    }

    IEnumerator SpawnEnemies(int numEnemies)
    {
        for (int i = 0; i < numEnemies; i++)
        {
            int spawnpoint = Random.Range(0, 4);
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

            Instantiate(enemy, position, Quaternion.identity);

            if (i <= 3)
            {
                yield return new WaitForSeconds(0);
            }

            else
            {
                yield return new WaitForSeconds(2);
            } // delay between enemy spawns
        }
    }
    
    
}
