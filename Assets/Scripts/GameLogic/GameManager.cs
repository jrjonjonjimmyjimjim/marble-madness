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
    public static int maxLevel = 2;
    public static int lives = 5;
    public static float timer = 30;
    public static float music_time = 0;

    private void Awake()
    {
        Instance = this;
    }

    public static void CheckStatus()
    {
        if (GameModeManager.GameMode == GameMode.Time)
        {
            if (timer > 0.0)
            {
                timer -= Time.deltaTime;
            }
            else
            {
                SceneManager.LoadScene("GameOver");
            }
        }
        else if (GameModeManager.GameMode == GameMode.Survival)
        {
            if (lives <= 0)
            {
                SceneManager.LoadScene("GameOver");
            }
        }
    }

    public static void StartPlay(GameMode mode)
    {
        level = 1;
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
        music_time = PlayMusic.audio.time;
        if(level > maxLevel)
        {
            SceneManager.LoadScene("GameOver");
        }
        else
        {
            timer += 30;
            SceneManager.LoadScene("Level" + level);
        }
    }
}
