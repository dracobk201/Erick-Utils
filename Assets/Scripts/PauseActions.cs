using UnityEngine;

public class PauseActions : MonoBehaviour
{
    [Header("Data Variables")]
    [SerializeField] private BoolReference gamePaused = null;
    [SerializeField] private StringReference sceneToChange = null;

    [Header("Panel Variable")]
    [SerializeField] private GameObject pauseHolder = null;

    private bool _lastTimeGamePaused;

    private void Start()
    {
        gamePaused.Value = false;
        Time.timeScale = 1;
    }

    private void Update()
    {
        if (gamePaused.Value == _lastTimeGamePaused)
            return;

        pauseHolder.SetActive(gamePaused.Value);
        _lastTimeGamePaused = gamePaused.Value;
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
    }

    public void OptionsButtonPressed()
    {
        //Nothing for now
    }

    public void QuitButtonPressed()
    {
        sceneToChange.Value = Global.MainMenuScene;
    }
}
