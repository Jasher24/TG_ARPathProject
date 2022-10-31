using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    Image timeBar;
    public float maxTime = 25f;
    float timeLeft;
    private GameManager gameManager = null;

    private void Start()
    {
        gameManager = GameObject.FindObjectOfType<GameManager>(); 
        timeBar = GetComponent<Image>();
        timeLeft = maxTime;
    }

    private void Update()
    { 
        if (timeLeft > 0)
        {
            timeLeft -= Time.deltaTime;
            timeBar.fillAmount = timeLeft / maxTime;
        }
        else
        {
            gameManager.LineTimer();
            //Time.timeScale = 0;
            Restart();
        }
    }

    public void Restart()
    {
        timeLeft = maxTime;
    }



}
