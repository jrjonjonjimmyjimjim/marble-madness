using GameLogic;
using TMPro;
using UnityEngine;

public class GameOverController : MonoBehaviour
{
    public TMP_Text message;

    // Start is called before the first frame update
    private void Start()
    {
        switch (GameModeManager.GameMode)
        {
            case GameMode.Survival:
                message.text = GameManager.lives > 0 ? "Congratulations! You Won!" : "You ran out of lives. Try Again";
                break;
            case GameMode.Time:
                message.text = GameManager.timer > 0 ? "Congratulations! You Won!" : "You ran out of time. Try Again";
                break;
            case GameMode.Tutorial:
            case GameMode.Level:
            case GameMode.Menu:
            default:
                message.text = "";
                break;
        }
    }
}