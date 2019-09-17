using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuActions : MonoBehaviour
{
    [Header("Data Variables")]
    [SerializeField] private StringReference SceneToChange;
    [SerializeField] private GameEvent ChangeSceneEvent;

    public void StartLevel()
    {
        SceneToChange.Value = Global.FIRSTLEVELSCENE;
        ChangeSceneEvent.Raise();
    }

    public void QuitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
