using UnityEngine;

public class Dropper : MonoBehaviour
{
    [SerializeField] float timeToWait = 3.0f;

    MeshRenderer meshRenderer;
    Rigidbody rigidBody;

    bool hasLanded = false;

    void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        rigidBody = GetComponent<Rigidbody>();

        meshRenderer.enabled = false;
        rigidBody.useGravity = false;
    }

    void Update()
    {
        if (Time.time > timeToWait)
        {
            meshRenderer.enabled = true;
            rigidBody.useGravity = true;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        // Optional: check tag
        if (collision.gameObject.CompareTag("Ground") && !hasLanded)
        {
            hasLanded = true;

            // Freeze All positions AFTER hitting ground
            rigidBody.constraints = RigidbodyConstraints.FreezePosition
                                  | RigidbodyConstraints.FreezeRotation;
        }
    }
}
