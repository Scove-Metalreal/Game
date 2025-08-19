
using System;
using UnityEditor;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public float speed = 1.0f;
    public Transform targetA;
    public Transform targetB;

    private bool _movingToTargetA = true;

    void Update()
    {
        if (_movingToTargetA)
        {
            MoveTowardsTarget(targetA.position);
        }
        else
        {
            MoveTowardsTarget(targetB.position);
        }
    }

    private void MoveTowardsTarget(Vector3 target)
    {
        // Move the platform towards the target
        transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);

        // Calculate the distance to the target
        var distance = Vector3.Distance(transform.position, target);

        // Debugging logs
        Debug.Log($"Moving towards: {target}, Current Position: {transform.position}, Distance: {distance}");

        // Switch direction if close enough to the target
        if (distance <= 0.2f) // Adjusted threshold
        {
            _movingToTargetA = !_movingToTargetA;
            Debug.Log($"Switching direction: Moving to Target A? {_movingToTargetA}");
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player Hit");
            collision.transform.SetParent(transform);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.transform.SetParent(null);
        }
    }
}
