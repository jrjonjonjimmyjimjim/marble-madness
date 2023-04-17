using GameLogic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoalLevelController : MonoBehaviour
{
    // Update is called once per frame
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (GameModeManager.GameMode == GameMode.Survival || GameModeManager.GameMode == GameMode.Time)
                GameManager.GoToNextLevel();
            else if (GameModeManager.GameMode == GameMode.Tutorial)
                SceneManager.LoadScene("MainMenu");
            else if (GameModeManager.GameMode == GameMode.Level) SceneManager.LoadScene("LevelSelect");
        }
    }
}