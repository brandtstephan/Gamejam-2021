using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManageState : MonoBehaviour
{

    private bool gameWon = false;
    private bool gameLost = false;
    private int amountDogsGathered = 0;
    public Text textCanvas;

    private void Start()
    {
        GameEvents.current.OnDogGatheredEvent += GatherDoggo;
        GameEvents.current.OnGameFinished += GameFinished;     
    }
    void Update()
    {
        if(gameWon && !gameLost)
        {
            textCanvas.text = "Good Boy";
        }else if (gameLost && !gameWon)
        {
            textCanvas.text = "Bad Boy";
        }
    }

    void GameFinished()
    {
        if (amountDogsGathered >= 2)
        {
            gameLost = false;
            gameWon = true;
            GameEvents.current.NextLevel();
        }
        else
        {
            gameLost = true;
            gameWon = false;
        }
        
    }

    void GatherDoggo()
    {
        amountDogsGathered += 1;
    }
}
