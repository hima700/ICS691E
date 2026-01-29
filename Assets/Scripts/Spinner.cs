using UnityEngine;

public class Spinner : MonoBehaviour
{
    public float speed = 100f;
    public float xAngle = 0f;
    public float yAngle = 0f;
    public float zAngle = 0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(xAngle, yAngle, zAngle);
    }
}
