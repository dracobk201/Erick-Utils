using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneHandler : MonoBehaviour
{
    [Header("Data Variables")]
    [SerializeField]
    private StringReference SceneToChange;
    [SerializeField]
    private FloatReference SceneChangeProgress;
    [SerializeField]
    private FloatReference SceneChangeDelay;
    [SerializeField]
    private GameEvent ShowSceneLoading;

    private bool isChangingSceneNow;
    private AsyncOperation sceneOperation;

    public void SwitchScene()
    {
        sceneOperation = SceneManager.LoadSceneAsync(SceneToChange.Value, LoadSceneMode.Single);
        isChangingSceneNow = true;
        sceneOperation.allowSceneActivation = false;
        ShowSceneLoading.Raise();
    }

    private void Update()
    {
        if (isChangingSceneNow)
        {
            SceneChangeProgress.Value = sceneOperation.progress;
            if (sceneOperation.progress >= 0.9f)
            {
                isChangingSceneNow = false;
                StartCoroutine(HideOldScene());
            }
        }
    }

    private IEnumerator HideOldScene()
    {
        yield return new WaitForSecondsRealtime(SceneChangeDelay.Value);
        sceneOperation.allowSceneActivation = true;
        //ShowSceneLoading.Raise();
        sceneOperation = null;
    }
}
