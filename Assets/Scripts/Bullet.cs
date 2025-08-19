using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float lifetime = 5f;
    void Start()
    {
        Destroy(gameObject, lifetime);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }
}
