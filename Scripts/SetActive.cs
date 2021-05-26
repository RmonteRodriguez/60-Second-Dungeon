using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetActive : MonoBehaviour
{
    public GameManager gameManager;
    public GameObject sharkLauncher;
    public GameObject boneFace;

    public int boneFaceNum;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("ManagerGame").GetComponent<GameManager>();
        boneFaceNum = Random.Range(0, 2);
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManager.currentFloor >= 5)
        {
            sharkLauncher.SetActive(true);
        }

        if (gameManager.currentFloor >= 10)
        {
            if (boneFaceNum >= 1)
            {
                boneFace.SetActive(true);
            }
        }
    }
}
