using UnityEngine;

public class ScoreViewer : MonoBehaviour
{
    [SerializeField] TMPro.TMP_Text scoreText;
    private void Start()
    {
        UpdateScore();
    }
    public void ResetScore()
    {
        DataManager.Instance.playerData.EraseData(DataManager.Instance.playerData);
        UpdateScore();
    }
    public void UpdateScore()
    {
        scoreText.text = "Points: " + DataManager.Instance.playerData.Points.ToString("000");
    }
}
