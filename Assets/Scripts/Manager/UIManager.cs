using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI coinText;
    [SerializeField] private TextMeshProUGUI worldText;
    [SerializeField] private TextMeshProUGUI timeText;
    [SerializeField] private TextMeshProUGUI lifesText;
    [SerializeField] private GameObject moveButtons;
    [SerializeField] private GameObject gameOverMenu;
    [SerializeField] private Button pauseButton;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetScoreText(int score, int numberOfDigits)
    {
        scoreText.text = score.ToString("D" + numberOfDigits);
    }

    public void SetCoinText(int coinCount)
    {
        coinText.text = coinCount.ToString();
        if (coinCount == 100)
        {
            coinCount = 0;
            //gameManager.lifes++;
            coinText.text = coinCount.ToString();
        }
    }

    public void SetWorldlevelText()
    {
        worldText.text += SceneManager.sceneCount + " : " + SceneManager.GetActiveScene().name;
    }

    public void SetTimeText(int timeToCompleteMission)
    {
        timeText.text = "Time\n" + timeToCompleteMission;
    }

    public void SetMoveVisibility(bool visibility)
    {
        moveButtons.SetActive(visibility);
    }
    public void SetGameOverVisibility(bool visibility)
    {
        gameOverMenu.SetActive(visibility);
    }
    public void SetLifes(int lifes)
    {
        lifesText.text += lifes;
    }
    public void SetPauseButtonActivate(bool enable)
    {
        pauseButton.gameObject.SetActive(enable);
    }
}
