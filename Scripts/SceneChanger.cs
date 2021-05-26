using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public GameManager gameManger;

    // Start is called before the first frame update
    void Start()
    {
        gameManger = GameObject.FindGameObjectWithTag("ManagerGame").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if (gameManger.currentFloor == 5)
        {
            SceneManager.LoadScene(3);
            gameManger.currentFloor++;
        }

        if (gameManger.currentFloor == 10)
        {
            SceneManager.LoadScene(4);
            gameManger.currentFloor++;
        }

        if (gameManger.currentFloor == 15)
        {
            SceneManager.LoadScene(5);
            gameManger.currentFloor++;
        }

        if (gameManger.currentFloor == 20)
        {
            SceneManager.LoadScene(6);
            gameManger.currentFloor++;
        }

        if (gameManger.currentFloor == 25)
        {
            SceneManager.LoadScene(7);
            gameManger.currentFloor++;
        }

        if (gameManger.currentFloor == 30)
        {
            SceneManager.LoadScene(9);
            gameManger.currentFloor++;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            SceneManager.LoadScene(2);
            gameManger.currentFloor++;
        }
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
        gameManger.playerHealth = 20;
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
