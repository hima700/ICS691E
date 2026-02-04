using UnityEngine;

public class WinZone : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;

        // Grab the player's hit count from Scorer
        Scorer scorer = other.GetComponent<Scorer>();
        int currentHits = scorer != null ? scorer.Hits : 0;

        // Tell GameManager the player made it
        if (GameManager.Instance != null)
            GameManager.Instance.PlayerReachedEnd(currentHits);
    }
}