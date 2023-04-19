
[System.Serializable]
public class PlayerData
{
    public int _level;
    public bool _tutorialWasEnd;

    public PlayerData (Player player)
    {
        _level = Player._lvlNumber;
        _tutorialWasEnd = Player._tutorialComplete;
    }
}
