using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patroling : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private Transform rightCheck;
    [SerializeField] private Transform leftCheck;

    int dir = 1;

    void FixedUpdate()
    {
        transform.Translate(Vector2.right * speed * Time.fixedDeltaTime * dir);
        if (Physics2D.Raycast(rightCheck.position, Vector2.right, 2) == true)
        {
            dir = -1;
        }

        if (Physics2D.Raycast(leftCheck.position, Vector2.right, 2) == true)
        {
            dir = 1;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.transform.SetParent(transform);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.transform.SetParent(null);
        }
    }
}
