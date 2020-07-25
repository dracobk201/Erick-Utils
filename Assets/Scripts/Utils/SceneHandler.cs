using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneHandler : MonoBehaviour
{
    [Header("Data Variables")]
    [SerializeField] private StringReference sceneToChange = null;
    [SerializeField] private FloatReference sceneChangeProgress = null;
    [SerializeField] private FloatReference sceneChangeDelay = null;
    [SerializeField] private GameEvent showSceneLoading = null;
    private bool _isChangingSceneNow;
    private AsyncOperation _sceneOperation;

    private void Awake()
    {
        _isChangingSceneNow = false;
    }

    private void Update()
    {
        if (!_isChangingSceneNow) return;
        sceneChangeProgress.Value = _sceneOperation.progress;
        if (!(_sceneOperation.progress >= 0.9f)) return;
        _isChangingSceneNow = false;
        StartCoroutine(HideOldScene());
    }

    public void SwitchScene()
    {
        _sceneOperation = SceneManager.LoadSceneAsync(sceneToChange.Value, LoadSceneMode.Single);
        _isChangingSceneNow = true;
        _sceneOperation.allowSceneActivation = false;
        showSceneLoading.Raise();
    }

    private IEnumerator HideOldScene()
    {
        yield return new WaitForSecondsRealtime(sceneChangeDelay.Value);
        _sceneOperation.allowSceneActivation = true;
        _sceneOperation = null;
    }
}
