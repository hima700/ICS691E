using UnityEngine;

public class ObjectHit : MonoBehaviour
{
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Object hit the player!: " + other.gameObject.name);
            GetComponent<MeshRenderer>().material.color = Color.black;
        }
    }
}
