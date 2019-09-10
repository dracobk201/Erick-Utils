using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadingBehaviour : MonoBehaviour
{
    [Header("Script Variables")]
    public GameObject loadingPanel;
    private bool isShowing;

    public void ShowingLoading()
    {
        isShowing = !isShowing;
        loadingPanel.SetActive(isShowing);
    }
}
