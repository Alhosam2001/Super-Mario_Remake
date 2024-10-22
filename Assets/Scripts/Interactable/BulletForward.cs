using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BulletForward : MonoBehaviour
{
    [SerializeField] private ParticleSystem bulletHitParticle;

    private float speed = 35;
    private Rigidbody2D bulletRB;

    void Start()
    {
        bulletRB = GetComponent<Rigidbody2D>();
        bulletRB.velocity = transform.right * speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Player") || !collision.CompareTag("Coin") || !collision.CompareTag("Traps"))
        {
            if (collision.CompareTag("Enemy"))
            {
                Destroy(collision.gameObject);
                Instantiate(bulletHitParticle, transform.position, bulletHitParticle.transform.rotation);
                Destroy(gameObject);
            }else if (collision.CompareTag("Tilemap"))
            {
                Instantiate(bulletHitParticle, transform.position, bulletHitParticle.transform.rotation);
                Destroy(gameObject);
            }
        }
    }
    private void OnBecameInvisible()
    {
        Debug.Log("S");
        Destroy(gameObject);
    }
}
