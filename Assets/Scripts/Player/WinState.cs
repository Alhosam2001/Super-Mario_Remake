using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinState : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            GameObject.Find("UI Manager").GetComponent<UIManager>().SetMoveVisibility(false);
            GameObject.Find("Player").GetComponent<CharacterController2D>().Move(1, false, false);
            gameManager.PlayWinSound();
            gameManager.SetWin(true);
            gameManager.SetPauseTimer(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            //GameObject.Find("Player").GetComponent<CharacterController2D>().Move(0, false, false);
            GameObject.Find("Player").gameObject.SetActive(false);
            gameManager.SetCountDownTime(0.01f);
            gameManager.SetPauseTimer(false);
        }
    }
}
