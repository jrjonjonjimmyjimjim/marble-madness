using GameLogic;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    static int level = 1;
    static int maxLevel = 2;
    private void Awake()
    {
        Instance = this;
    }

    public static void GoToNextLevel()
    {
        level++;
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
