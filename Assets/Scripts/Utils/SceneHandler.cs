using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneHandler : MonoBehaviour
{
    [Header("Data Variables")]
    [SerializeField]
    private StringReference SceneToChange;
    [SerializeField]
    private GameEvent ShowSceneLoading;

    [Header("Script Variables")]
    private bool isChangingSceneNow;
    private float sceneChangingProgress;

    private AsyncOperation sceneProgress;

    public void SwitchScene()
    {
        sceneProgress = SceneManager.LoadSceneAsync(SceneToChange.Value, LoadSceneMode.Single);
        isChangingSceneNow = true;
        ShowSceneLoading.Raise();
    }

    private void Update()
    {
        if (isChangingSceneNow)
        {
            if (sceneProgress.isDone)
                Hide();
        }
    }

    public void Hide()
    {
        ShowSceneLoading.Raise();
        sceneProgress.allowSceneActivation = true;
        sceneProgress = null;
        isChangingSceneNow = false;
    }
}
