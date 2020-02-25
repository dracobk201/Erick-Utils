using Basic_Variables;
using UnityEngine;
using UnityEngine.UI;

public class GameCanvasActions : MonoBehaviour
{
    [SerializeField] private FloatReference remainingTime;
    [SerializeField] private Text timeText;

    private void Update()
    {
        UpdateLevelTimer();
    }

    private void UpdateLevelTimer()
    {
        var minutes = Mathf.FloorToInt(remainingTime.Value / 60f);
        var seconds = Mathf.RoundToInt(remainingTime.Value % 60f);

        if (seconds == 60)
        {
            seconds = 0;
            minutes += 1;
        }
        timeText.text = minutes.ToString("00") + ":" + seconds.ToString("00");
    }
}
