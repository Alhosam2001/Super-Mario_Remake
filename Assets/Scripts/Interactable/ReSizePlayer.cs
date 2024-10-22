using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class ReSizePlayer : MonoBehaviour
{
    private GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (GameObject.Find("Player").gameObject.transform.localScale == new Vector3(3, 3, 3))
            {
            GameObject.Find("Player").gameObject.transform.localScale += new Vector3(1, 1, 1);
            gameManager.SetScoreCount(15);
            gameManager.UpdateScore(gameManager.GetScoreCount());
            Destroy(gameObject);
            }
            else
            {
                gameManager.SetScoreCount(15);
                gameManager.UpdateScore(gameManager.GetScoreCount());
                Destroy(gameObject);
            }

        }
    }
}
