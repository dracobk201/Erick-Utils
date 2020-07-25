public static class Global
{
    #region Tags
    public const string PlayerTag = "Player";
    public const string GoalTag = "Finish";
    #endregion

    #region Axis
    public const string HorizontalAxis = "Horizontal";
    public const string VerticalAxis = "Vertical";
    public const string JumpAxis = "Jump";
    public const string StartAxis = "Cancel";
    public const string FireAxis = "Fire1";
    #endregion

    #region Scene Names
    public const string MainMenuScene = "Main Menu";
    public const string FirstLevelScene = "Game";
    #endregion

    #region Animations
    public const string IdleAnimationTrigger = "Idle";
    public const string MoveAnimationTrigger = "Run";
    public const string DeathAnimationTrigger = "Rest";
    public const string CelebrateAnimationTrigger = "Jump";
    #endregion

    #region Constants

    public const double Tolerance = float.Epsilon;

    #endregion

    #region Functions

    public static string ReturnTimeToString(float time)
    {
        var minutes = UnityEngine.Mathf.FloorToInt(time / 60f);
        var seconds = UnityEngine.Mathf.RoundToInt(time % 60f);

        if (seconds == 60)
        {
            seconds = 0;
            minutes += 1;
        }

        if (seconds <= 0)
            seconds = 0;
        if (minutes <= 0)
            minutes = 0;

        return minutes.ToString("00") + ":" + seconds.ToString("00");
    }

    #endregion

    public enum Language
    {
        English, Spanish, Portuguese, Italian, French, German, Catalan
    }

    public enum AdsCompany
    {
        Admob, UnityAds, AudienceNetwork
    }
}
