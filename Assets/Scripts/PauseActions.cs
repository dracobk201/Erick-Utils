using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseActions : MonoBehaviour
{
    [Header("Data Variables")]
    [SerializeField] private BoolReference GamePaused;
    [SerializeField] private StringReference SceneToChange;
    [SerializeField] private GameEvent ChangeSceneEvent;

    [Header("Panel Variable")]
    [SerializeField] private GameObject pauseHolder;

    private bool lastTimeGamePaused;

    private void Start()
    {
        TriggerPause(false);
    }

    private void Update()
    {
        if (GamePaused.Value == lastTimeGamePaused)
            return;

        pauseHolder.SetActive(GamePaused.Value);
        lastTimeGamePaused = GamePaused.Value;
    }

    public void TriggerPause()
    {
        GamePaused.Value = !GamePaused.Value;
        Time.timeScale = (GamePaused.Value) ? 0 : 1;
    }

    public void TriggerPause(bool isPaused)
    {
        GamePaused.Value = isPaused;
        Time.timeScale = (GamePaused.Value) ? 0 : 1;
    }

    public void ResumeButtonPressed()
    {
        TriggerPause();
    }

    public void RestartButtonPressed()
    {
        SceneToChange.Value = Global.FIRSTLEVELSCENE;
        ChangeSceneEvent.Raise();
    }

    public void OptionsButtonPressed()
    {
        //Nothing for now
    }

    public void QuitButtonPressed()
    {
        SceneToChange.Value = Global.MAINMENUSCENE;
        ChangeSceneEvent.Raise();
    }
}
