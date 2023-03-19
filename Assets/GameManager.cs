using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI lifepoint;

    private void Update()
    {
        if (int.Parse(lifepoint.text) <= 0)
        {
            lifepoint.text = "gameOver";
        }
        
        if(Input.GetKey(KeyCode.Escape))
        {
            SceneManager.LoadScene(0);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            int currentValue = int.Parse(lifepoint.text);
            lifepoint.text = (currentValue - 1).ToString();
            Destroy(collision.gameObject);
        }
        
    }
}
