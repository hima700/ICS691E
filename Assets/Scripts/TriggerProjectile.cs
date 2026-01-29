using UnityEngine;

public class TriggerProjectile : MonoBehaviour
{
    public GameObject[] projectiles;

    void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;

        foreach (GameObject proj in projectiles)
        {
            if (proj == null) continue;
            if (proj.activeInHierarchy) continue;
            proj.SetActive(true);
        }
    }
}
