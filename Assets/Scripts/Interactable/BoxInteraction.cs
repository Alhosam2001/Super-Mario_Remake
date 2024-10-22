using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxInteraction : MonoBehaviour
{
    [SerializeField] private GameObject reward;
    [SerializeField] private Animator boxAnim;
    [SerializeField] private GameObject respawnTransform;
    [SerializeField] private GameObject startMovingTransform;
    [SerializeField] private int numberOfHitsBeforeDisabled;

    private GameManager gameManager;

    private void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && numberOfHitsBeforeDisabled > 0)
        {
            boxAnim.SetBool("Box Hit", true);
            numberOfHitsBeforeDisabled--;
            if (gameObject.CompareTag("Coin"))
            {
                gameManager.UpdateCoin();
            }
            if (gameObject.CompareTag("Bigger"))
            {
                Instantiate(reward, startMovingTransform.transform);
            }

        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        boxAnim.SetBool("Box Hit", false);
        if (numberOfHitsBeforeDisabled == 0)
        {
            boxAnim.SetBool("Is Hit", true);
        }
        else
        {
            boxAnim.SetBool("Is Hit", false);
        }
    }
}
