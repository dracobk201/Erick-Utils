using Basic_Variables;
using Events;
using UnityEngine;
using Utils;

public class PauseActions : MonoBehaviour
{
    [Header("Data Variables")]
    [SerializeField] private BoolReference gamePaused;
    [SerializeField] private StringReference sceneToChange;
    [SerializeField] private GameEvent changeSceneEvent;

    [Header("Panel Variable")]
    [SerializeField] private GameObject pauseHolder;

    private bool lastTimeGamePaused;

    private void Start()
    {
        TriggerPause(false);
    }

    private void Update()
    {
        if (gamePaused.Value == lastTimeGamePaused)
            return;

        pauseHolder.SetActive(gamePaused.Value);
        lastTimeGamePaused = gamePaused.Value;
    }

    public void TriggerPause()
    {
        gamePaused.Value = !gamePaused.Value;
        Time.timeScale = (gamePaused.Value) ? 0 : 1;
    }

    public void TriggerPause(bool isPaused)
    {
        gamePaused.Value = isPaused;
        Time.timeScale = (gamePaused.Value) ? 0 : 1;
    }

    public void ResumeButtonPressed()
    {
        TriggerPause();
    }

    public void RestartButtonPressed()
    {
        sceneToChange.Value = Global.FirstLevelScene;
        changeSceneEvent.Raise();
    }

    public void OptionsButtonPressed()
    {
        //Nothing for now
    }

    public void QuitButtonPressed()
    {
        sceneToChange.Value = Global.MainMenuScene;
        changeSceneEvent.Raise();
    }
}
