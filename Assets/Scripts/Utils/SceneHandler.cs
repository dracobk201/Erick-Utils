using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneHandler : MonoBehaviour
{
    [Header("Data Variables")]
    [SerializeField] private StringReference SceneToChange;
    [SerializeField] private GameEvent ShowSceneLoading;

    [Header("Script Variables")]
    private bool isChangingSceneNow;
    private float SceneChangingProgress;

    private AsyncOperation sceneProgress;

    public void SwitchScene()
    {
        StartCoroutine(ChangingScene());
    }

    private IEnumerator ChangingScene()
    {
        if (SceneManager.GetActiveScene().name.Equals(SceneToChange.Value))
        {
            SceneManager.LoadScene(SceneToChange.Value);
        }
        else
        {
            ShowSceneLoading.Raise();
            yield return new WaitForSeconds(0.2f);

            sceneProgress = SceneManager.LoadSceneAsync(SceneToChange.Value, LoadSceneMode.Single);
            sceneProgress.allowSceneActivation = false;

            while (!sceneProgress.isDone)
            {
                SceneChangingProgress = sceneProgress.progress;
                if (sceneProgress.progress >= 0.9f)
                {
                    ShowSceneLoading.Raise();

                    SceneChangingProgress = 0;
                    sceneProgress.allowSceneActivation = true;
                }
                yield return null;
            }
        }
    }
}
