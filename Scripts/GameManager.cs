using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int currentFloor;
    
    //Player Health
    public int playerHealth = 5;
    public Text playerHealthText;
    public GameObject healthInfo;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        playerHealthText.text = "HP: " + playerHealth;

        if (playerHealth <= 0)
        {
            healthInfo.SetActive(false);
        }
    }
}
