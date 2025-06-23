[System.Serializable]
public class PlayerData
{
    public int Points;
    public PlayerData()
    {
        Points = 0;
    }
    public void AddData(PlayerData data)
    {
        Points += data.Points;
    }
    public void EraseData(PlayerData data)
    {
        Points -= data.Points;
    }
}
