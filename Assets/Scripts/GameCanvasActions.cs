using TMPro;
using UnityEngine;

public class GameplayCanvasActions : MonoBehaviour
{
    [SerializeField] private FloatReference remainingTime = null;
    [SerializeField] private TextMeshProUGUI remainingTimeText = null;

    private void Update()
    {
        UpdateLevelTimer();
    }

    private void UpdateLevelTimer()
    {
        remainingTimeText.text = Global.ReturnTimeToString(remainingTime.Value);
    }
}