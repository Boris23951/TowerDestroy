
[System.Serializable]
public class PlayerData
{
    public int _level;

    public PlayerData (Player player)
    {
        _level = Player._lvlNumber;
    }
}
