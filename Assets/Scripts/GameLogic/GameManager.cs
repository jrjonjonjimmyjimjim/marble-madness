using System.Runtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public static GameMode gameMode;

    //public static event Action<GameMode> OnGameModeChanged;

    void Awake()
    {
        Instance = this;
    }
    

    public static void UpdateGameMode(GameMode newMode)
    {
        gameMode = newMode;

        //switch(gameMode) {
        //    case GameMode.Tutorial:
        //        break;
        //    case GameMode.Level:
        //        break;
        //    case GameMode.Menu:
        //        break;
        //    case GameMode.Time:
        //        break;
        //    case GameMode.Survival:
        //        break;
        //}

        //OnGameModeChanged?.Invoke(newMode);
    }

}

public enum GameMode{
    Tutorial,
    Level,
    Time,
    Survival,
    Menu
}
