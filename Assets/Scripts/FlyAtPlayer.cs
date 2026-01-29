using UnityEngine;

public class FlyAtPlayer : MonoBehaviour
{
    public float speed = 10f;
    public Transform player;

    Vector3 target;

    void OnEnable()
    {
        if (player == null) return;
        target = player.position;
    }

    void Update()
    {
        transform.position = Vector3.MoveTowards(
            transform.position,
            target,
            speed * Time.deltaTime
        );
    }
}
