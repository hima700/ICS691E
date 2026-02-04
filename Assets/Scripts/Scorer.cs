using TMPro;
using UnityEngine;

public class Scorer : MonoBehaviour
{
    int hits = 0;
    [SerializeField] TextMeshProUGUI hitText;
    
    public AudioClip obstacleHitSound;
    public AudioClip projectileHitSound;
    private AudioSource audioSource;

    // ── Public getter so GameManager / WinZone can read it ──
    public int Hits => hits;

    void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
        UpdateUI();
    }

    // ENVIRONMENT: player walks into obstacle
    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.CompareTag("Obstacle"))
        {
            hits++;
            UpdateUI();
            NotifyGameManager();

            // Play obstacle hit sound
            if (obstacleHitSound != null)
                audioSource.PlayOneShot(obstacleHitSound);

            MeshRenderer mr = hit.gameObject.GetComponent<MeshRenderer>();
            if (mr) mr.material.color = Color.black;

            hit.gameObject.tag = "Hit";
        }
    }

    // PROJECTILE: projectile hits player
    public void RegisterProjectileHit()
    {
        hits++;
        UpdateUI();
        NotifyGameManager();
        
        // Play projectile hit sound
        if (projectileHitSound != null)
            audioSource.PlayOneShot(projectileHitSound);
    }

    void UpdateUI()
    {
        int maxHits = GameManager.Instance != null ? GameManager.Instance.MaxHits : 0;
        hitText.text = "Hits: " + hits + "/" + maxHits;
    }

    // ── NEW: tell GameManager about the hit ──
    void NotifyGameManager()
    {
        if (GameManager.Instance != null)
            GameManager.Instance.OnHitRegistered(hits);
    }
}