using GameLogic;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameOverController : MonoBehaviour
{
    public TMP_Text message;
    
    // Start is called before the first frame update
    void Start()
    {
        switch(GameModeManager.GameMode)
        {
            case GameMode.Survival:
                if(GameManager.lives > 0)
                {
                    message.text = "Congradulations! You Won!";
                }
                else
                {
                    message.text = "You ran out of lives. Try Again";
                }
                break;
            case GameMode.Time:
                if (GameManager.timer > 0)
                {
                    message.text = "Congradulations! You Won!";
                }
                else
                {
                    message.text = "You ran out of time. Try Again";
                }
                break;
            default:
                message.text = "";
                break;
        }
    }
}
