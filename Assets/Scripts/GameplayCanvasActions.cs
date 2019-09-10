using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameplayCanvasActions : MonoBehaviour
{
    [SerializeField]
    private FloatReference RemainingTime;
    [SerializeField]
    private Text timeText;

    private void Update()
    {
        UpdateLevelTimer();
    }

    private void UpdateLevelTimer()
    {
        int minutes = Mathf.FloorToInt(RemainingTime.Value / 60f);
        int seconds = Mathf.RoundToInt(RemainingTime.Value % 60f);

        string formatedSeconds = seconds.ToString();

        if (seconds == 60)
        {
            seconds = 0;
            minutes += 1;
        }

        timeText.text = minutes.ToString("00") + ":" + seconds.ToString("00");
    }
}
