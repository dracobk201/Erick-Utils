using System.Collections;
using Basic_Variables;
using Events;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Utils
{
    public class SceneHandler : MonoBehaviour
    {
        [Header("Data Variables")]
        [SerializeField] private StringReference sceneToChange;
        [SerializeField] private FloatReference sceneChangeProgress;
        [SerializeField] private FloatReference sceneChangeDelay;
        [SerializeField] private GameEvent showSceneLoading;

        private bool isChangingSceneNow;
        private AsyncOperation sceneOperation;

        public void SwitchScene()
        {
            sceneOperation = SceneManager.LoadSceneAsync(sceneToChange.Value, LoadSceneMode.Single);
            isChangingSceneNow = true;
            sceneOperation.allowSceneActivation = false;
            showSceneLoading.Raise();
        }

        private void Update()
        {
            if (!isChangingSceneNow) return;
            sceneChangeProgress.Value = sceneOperation.progress;
            if (!(sceneOperation.progress >= 0.9f)) return;
            isChangingSceneNow = false;
            StartCoroutine(HideOldScene());
        }

        private IEnumerator HideOldScene()
        {
            yield return new WaitForSecondsRealtime(sceneChangeDelay.Value);
            sceneOperation.allowSceneActivation = true;
            //ShowSceneLoading.Raise();
            sceneOperation = null;
        }
    }
}
