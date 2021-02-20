using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEvents : MonoBehaviour
{
    public static GameEvents current;

    void Awake()
    {
        current = this;
    }

    public event Action OnDogGatheredEvent;
    public void GatherDog()
    {
        if (OnDogGatheredEvent != null)
        {
            OnDogGatheredEvent();
        }
    }

    public event Action OnGameFinished;
    public void FinishGame()
    {
        if (OnGameFinished != null)
        {
            OnGameFinished();
        }
    }

    public event Action OnNextLevelCalled;
    public void NextLevel()
    {
        if (OnNextLevelCalled != null)
        {
            OnNextLevelCalled();
        }
    }
}
