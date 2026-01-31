using UnityEngine;

public class Dropper : MonoBehaviour
{
    [SerializeField] float dropForce = 10f;
    
    MeshRenderer meshRenderer;
    Rigidbody rigidBody;
    bool hasDropped = false;
    bool hasLanded = false;

    void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        rigidBody = GetComponent<Rigidbody>();

        meshRenderer.enabled = false;
        rigidBody.useGravity = false;
    }

    public void Drop()
    {
        if (hasDropped) return;
        hasDropped = true;
        
        meshRenderer.enabled = true;
        rigidBody.useGravity = true;
        rigidBody.AddForce(Vector3.down * dropForce, ForceMode.Impulse);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground") && !hasLanded)
        {
            hasLanded = true;
            rigidBody.constraints = RigidbodyConstraints.FreezePosition
                                  | RigidbodyConstraints.FreezeRotation;
        }
    }
}