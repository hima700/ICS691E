using TMPro;
using UnityEngine;

public class Scorer : MonoBehaviour
{
    int hits = 0;
    [SerializeField] TextMeshProUGUI hitText;

    void Start()
    {
        UpdateUI();
    }

    // ENVIRONMENT: player walks into obstacle
    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.CompareTag("Obstacle"))
        {
            hits++;
            UpdateUI();

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
    }

    void UpdateUI()
    {
        hitText.text = "Hits: " + hits;
    }
}
