using UnityEngine;
using System.Collections;

public class ProjectileHit : MonoBehaviour
{
    bool armed = false;
    bool hasHit = false;

    void OnEnable()
    {
        hasHit = false;
        armed = false;
        StartCoroutine(ArmAfterDelay());
    }

    IEnumerator ArmAfterDelay()
    {
        yield return new WaitForSeconds(0.1f); // 100 ms safety window
        armed = true;
    }

    void OnTriggerEnter(Collider other)
    {
        if (!armed || hasHit) return;

        if (other.CompareTag("Player"))
        {
            hasHit = true;

            Scorer scorer = other.GetComponent<Scorer>();
            if (scorer != null)
                scorer.RegisterProjectileHit();

            Destroy(gameObject);
        }
        else if (other.CompareTag("Ground")  || other.CompareTag("TriggerZone"))
        {
            hasHit = true;
            Destroy(gameObject);
        }
    }
}
