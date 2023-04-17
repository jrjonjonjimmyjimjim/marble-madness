using GameLogic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HUDController : MonoBehaviour
{
    public TMP_Text Scene_Text;
    public TMP_Text GameMode_Text;
    public TMP_Text Gameplay_Text;
    public TMP_Text Powerup_Text;

    // Start is called before the first frame update
    private void Start()
    {
        Scene_Text.text = SceneManager.GetActiveScene().name;
        GameMode_Text.text = GameModeManager.GameMode switch
        {
            GameMode.Survival => "Survival",
            GameMode.Time => "Time Attack",
            GameMode.Tutorial => "Tutorial",
            GameMode.Level => "Single Level"
        };
        if (GameModeManager.GameMode == GameMode.Time)
            Gameplay_Text.text = "Time: " + GameManager.timer;
        else if (GameModeManager.GameMode == GameMode.Survival)
            Gameplay_Text.text = "Lives: " + GameManager.lives;
        else
            Gameplay_Text.text = "";
    }

    // Update is called once per frame
    private void Update()
    {
        GameManager.CheckStatus();
        if (GameModeManager.GameMode == GameMode.Time)
            //float timer = GameManager.timer;
            //timer -= Time.deltaTime;
            Gameplay_Text.text = "Time: " + GameManager.timer.ToString("F2");
        //GameManager.timer = timer;
        else if (GameModeManager.GameMode == GameMode.Survival) Gameplay_Text.text = "Lives: " + GameManager.lives;
    }
}