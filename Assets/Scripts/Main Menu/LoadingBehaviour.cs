using UnityEngine;
using UnityEngine.UI;

public class LoadingBehaviour : MonoBehaviour
{
    [Header("Script Variables")]
    [SerializeField] private FloatReference SceneChangeProgress = null;
    [SerializeField] private GameObject loadingPanel = null;
    [SerializeField] private Image loadingBarFiller = null;
    private bool isShowing;

    public void ShowingLoading()
    {
        isShowing = !isShowing;
        loadingPanel.SetActive(isShowing);
    }

    private void Update()
    {
        if (isShowing && gameObject.activeInHierarchy)
            loadingBarFiller.fillAmount = SceneChangeProgress.Value;
    }
}
