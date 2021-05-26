using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteGameManager : MonoBehaviour
{
    public GameObject gameManger;

    // Start is called before the first frame update
    void Start()
    {
        gameManger = GameObject.FindGameObjectWithTag("ManagerGame");
    }

    // Update is called once per frame
    void Update()
    {
        gameManger.SetActive(false);
    }
}
