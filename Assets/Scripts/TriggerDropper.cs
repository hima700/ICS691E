using UnityEngine;

public class TriggerDropper : MonoBehaviour
{
    public Dropper[] droppers;

    void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;

        foreach (Dropper dropper in droppers)
        {
            if (dropper == null) continue;
            dropper.Drop();
        }
    }
}