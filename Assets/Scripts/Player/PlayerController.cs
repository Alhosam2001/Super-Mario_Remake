using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed = 40;
    [SerializeField] private BoxInteraction boxInteraction;
    [SerializeField] private CharacterController2D controller;
    [SerializeField] private Transform projectilePos;
    [SerializeField] private GameObject projectilePrefs;
    private Renderer playerRenderer;

    private Rigidbody2D playerRB;
    private Animator playerAnim;
    private GameManager gameManager;
    private float horizontal;
    private bool jump;


    private void Start()
    {
        playerAnim = GetComponent<Animator>();
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        playerRB = GetComponent<Rigidbody2D>();
        playerRenderer = GetComponent<Renderer>();
    }

    void Update()
    {
        playerAnim.SetFloat("Speed", Mathf.Abs(horizontal));
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if (gameManager.GetIsGameActive())
        {
            controller.Move(horizontal * Time.fixedDeltaTime * speed, false, jump); // false for crouch the variable will made later
            jump = false;
        }
        else
        {
            controller.Move(0, false, false);
        }
    }
    public void MoveForward(int dir)
    {
        horizontal = dir;
    }
    public void Jump()
    {
        jump = true;
    }
    public void OnLanding()
    {
        playerAnim.SetBool("Jump", false);
    }


    public void Shoot()
    {
        if (gameObject.transform.localScale != new Vector3(3, 3, 3))
        {
            Instantiate(projectilePrefs, projectilePos.position, projectilePos.rotation);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Fall"))
        {
            gameManager.GameOver();
            playerRB.AddForce(Vector3.down, ForceMode2D.Impulse);

            playerAnim.SetBool("Die", true);
            gameObject.SetActive(false);

        }

        if (collision.CompareTag("Traps"))
        {
            DieState();
        }

        if (collision.CompareTag("Enemy"))
        {
            float playerY = transform.position.y;
            float enemyY = collision.transform.position.y;
            if (playerY > enemyY + .5f)
            {
                Destroy(collision.gameObject);
            }
            else
            {
                DieState();
            }
        }
    }

    private void DieState()
    {
        if (gameObject.transform.localScale == new Vector3(3, 3, 3) && gameManager.GetInvincible() == false)
        {
            gameManager.GameOver();
            playerRB.AddForce(Vector3.down, ForceMode2D.Impulse);

            gameObject.SetActive(false);
        }
        else if (gameObject.transform.localScale == new Vector3(4, 4, 4))
        {
            gameObject.transform.localScale -= new Vector3(1, 1, 1);
            gameManager.SetInvincible(true);
            StartCoroutine(InvincibleTime());
            StartCoroutine(InvincibleEffect());
        }
    }

    IEnumerator InvincibleTime()
    {
        yield return new WaitForSeconds(3);
        gameManager.SetInvincible(false);
        StopCoroutine(InvincibleTime());
    }

    IEnumerator InvincibleEffect()
    {

        while (gameManager.GetInvincible() == true)
        {
            playerRenderer.enabled = false;
            yield return new WaitForSeconds(0.3f);
            playerRenderer.enabled = true;
            yield return new WaitForSeconds(0.7f);
        }
        playerRenderer.enabled = true;
        StopCoroutine(InvincibleEffect());
    }
}
