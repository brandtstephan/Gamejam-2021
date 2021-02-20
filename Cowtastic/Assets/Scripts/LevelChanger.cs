using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelChanger : MonoBehaviour
{
    public Animator animator;
    private int levelToLoad;

    private void Start()
    {
        GameEvents.current.OnNextLevelCalled += FadeToLevel;
    }

    public void FadeToLevel()
    {
        levelToLoad = SceneManager.GetActiveScene().buildIndex + 1;
        animator.SetTrigger("FadeOut");
    }

    public void OnFadeComplete()
    {
        try
        {
            SceneManager.LoadScene(levelToLoad);
        }
        catch (Exception e)
        {

        }
    }
}
