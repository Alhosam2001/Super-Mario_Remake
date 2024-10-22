using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesPatroling : MonoBehaviour
{
    [SerializeField] private Transform leftChceck;
    [SerializeField] private Transform rightCheck;

    private float speed = 3;
    private int dir = 1;



    void FixedUpdate()
    {
        transform.Translate(Vector2.right * speed * Time.fixedDeltaTime * dir);
        if (Physics2D.Raycast(rightCheck.position, Vector2.down, 2) == false)
        {
            dir = -1;
            transform.Rotate(new Vector3(0, 180, 0));
        }
        else if (Physics2D.Raycast(rightCheck.position, Vector2.down, 2))
        {
            dir = 1;
            transform.Rotate(new Vector3(0, 0, 0));
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Tilemap"))
        {
            if (dir == 1)
            {
                dir = -1;
                transform.Rotate(new Vector3(0, 180, 0));
            }
            else
            {
                dir = 1;
                transform.Rotate(new Vector3(0, 0, 0));
            }
        }
    }
}
