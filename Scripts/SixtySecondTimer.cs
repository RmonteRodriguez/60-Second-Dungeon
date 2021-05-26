using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SixtySecondTimer : MonoBehaviour
{
    public Text timerText;
    public float currentTime;
    public float timeDecreasedPerSecond;
    public bool inTutorial;

    // Start is called before the first frame update
    void Start()
    {
        currentTime = 60;
        timeDecreasedPerSecond = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        if (inTutorial) return;

        timerText.text = (int)currentTime + " Seconds";
        currentTime -= timeDecreasedPerSecond * Time.deltaTime;

        if (currentTime <= 0)
        {
            SceneManager.LoadScene(8);
        }
    }
}
