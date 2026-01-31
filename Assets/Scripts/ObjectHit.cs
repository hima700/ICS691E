using UnityEngine;

public class ObjectHit : MonoBehaviour
{
    public AudioClip hitPlayerSound;
    private AudioSource audioSource;

    void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Object hit the player!: " + other.gameObject.name);
            GetComponent<MeshRenderer>().material.color = Color.black;
            
            // Play hit sound
            if (hitPlayerSound != null)
                audioSource.PlayOneShot(hitPlayerSound);
        }
    }
}