using GameLogic;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    static int level = 1;
    static int maxLevel = 2;
    public static int lives = 5;
    public static float timer = 0;

    private void Awake()
    {
        Instance = this;
    }

    private void Update()
    {
        if(GameModeManager.GameMode == GameMode.Time)
        {
            if (timer > 0)
            {
                timer -= Time.deltaTime;
            }
            else
            {
                SceneManager.LoadScene("GameOver");
            }
        }else if (GameModeManager.GameMode == GameMode.Survival)
        {
            if(lives <= 0)
            {
                SceneManager.LoadScene("GameOver");
            }
        }
    }

    public static void StartPlay(GameMode mode)
    {
        if(mode == GameMode.Time)
        {
            timer = 30;
        }else if(mode == GameMode.Survival)
        {
            lives = 5;
        }
    }

    public static void GoToNextLevel()
    {
        level++;
        timer += 30;
        if(level > maxLevel)
        {
            SceneManager.LoadScene("GameOver");
        }
        else
        {
            SceneManager.LoadScene("Level" + level);
        }
    }
}
