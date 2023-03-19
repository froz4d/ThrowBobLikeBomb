using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI lifepoint;
    public GameObject gameover;

    private void Update()
    {
        if (int.Parse(lifepoint.text) <= 0)
        {
            gameover.SetActive(true);
            
            Destroy(FindObjectOfType(typeof(PlayerController)).GameObject());
        }
        
        if(Input.GetKeyDown(KeyCode.Escape))
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
