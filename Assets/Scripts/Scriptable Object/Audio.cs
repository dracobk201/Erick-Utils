using UnityEngine;

[CreateAssetMenu(menuName = "Gameplay/Audio")]
public class Audio : ScriptableObject
{
    public string audioName;
    public AudioClip clip;
    public AudioType type;
    public bool canLoop;
}

public enum AudioType
{
    None, BGM, SFX
}