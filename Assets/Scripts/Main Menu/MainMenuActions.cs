using Basic_Variables;
using Events;
using UnityEngine;
using Utils;

namespace Main_Menu
{
    public class MainMenuActions : MonoBehaviour
    {
        [Header("Data Variables")]
        [SerializeField] private StringReference sceneToChange;
        [SerializeField] private GameEvent changeSceneEvent;

        public void StartLevel()
        {
            sceneToChange.Value = Global.FirstLevelScene;
            changeSceneEvent.Raise();
        }

        public void QuitGame()
        {
            #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
            #else
            Application.Quit();
            #endif
        }
    }
}
