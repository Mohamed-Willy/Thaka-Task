using UnityEngine;
public class ZoneHandler : MonoBehaviour
{
    [SerializeField] PlayerData playerData;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            DataManager.Instance.playerData.AddData(playerData);
            FindAnyObjectByType<ScoreViewer>().UpdateScore();
            Destroy(gameObject);
        }
    }
}
