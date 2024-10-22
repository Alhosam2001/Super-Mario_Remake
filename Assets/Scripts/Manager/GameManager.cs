using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip backgroundMusic;
    [SerializeField] private AudioClip dieMusic;
    [SerializeField] private AudioClip deathMusic;
    [SerializeField] private AudioClip winMusic;
    [SerializeField] private SaveTest saveTest;
    [SerializeField] private UIManager uiManager;
    [SerializeField] private bool isGameActive;
    [SerializeField] private GameObject pauseMenu;

    private int scoreCounter;
    private int timeToCompleteMission = 400;
    private float countDownTime = 1;
    private int coinCount;
    private int lifes;
    private bool win = false;
    private bool pauseTimer = false;
    private int numberOfDigits = 6;
    private bool invincible = false;
    private AudioClip pickupCoinSound;

    private void Awake()
    {
        if (PlayerPrefs.GetInt("Lifes") <= 0)
        {
            lifes = 3;
            saveTest.SavePrefs();
        }
        else
        {
            lifes = PlayerPrefs.GetInt("Lifes");
        }
        isGameActive = true;
        StartCoroutine(StartTimer());
        uiManager.SetWorldlevelText();
        uiManager.SetLifes(lifes);
        Time.timeScale = 1;
    }

    private void Start()
    {
        PlayBackgroundSound();
    }

    public void PlayBackgroundSound()
    {
        audioSource.clip = backgroundMusic;
        audioSource.Play();
    }

    public void PlayDieSound()
    {
        audioSource.clip = dieMusic;
        audioSource.PlayOneShot(audioSource.clip);
    }

    public void PlayDeathSound()
    {
        audioSource.clip = deathMusic;
        audioSource.PlayOneShot(audioSource.clip);
    }

    public void PlayWinSound()
    {
        audioSource.clip = winMusic;
        audioSource.PlayOneShot(audioSource.clip);
    }

    IEnumerator StartTimer()
    {
        while (isGameActive)
        {
            while (pauseTimer)
            {
                yield return null;
            }

            if (timeToCompleteMission == 0)
            {
                timeToCompleteMission = 0;
                yield return new WaitForSeconds(3);
                MainMenuScene();
            }
            else
            {
                uiManager.SetTimeText(timeToCompleteMission);
                timeToCompleteMission--;
                if (win)
                {
                    PlaySound();
                    scoreCounter += 5;
                    UpdateScore(scoreCounter);
                }
                yield return new WaitForSeconds(countDownTime);
            }
        }
    }

    public void PlaySound()
    {
        audioSource.PlayOneShot(pickupCoinSound, 0.1f);
    }

    public void GetSound(AudioClip clip)
    {
        pickupCoinSound = clip;
    }

    public void UpdateCoin()
    {
        coinCount++;
        uiManager.SetCoinText(coinCount);
        PlaySound();
        scoreCounter += 8;
        UpdateScore(scoreCounter);
    }

    public void UpdateScore(int score)
    {
        uiManager.SetScoreText(score, numberOfDigits);
    }

    public void PauseGame()
    {
        pauseMenu.SetActive(true);
        uiManager.SetPauseButtonActivate(false);
        Time.timeScale = 0;
    }

    public void ResumeGame()
    {
        pauseMenu.SetActive(false);
        uiManager.SetPauseButtonActivate(true);
        Time.timeScale = 1;
    }
    public void RestartLevel()
    {
        if (lifes > 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            isGameActive = true;
        }
        else
        {
            GameOver();
            lifes = 3;
            saveTest.SavePrefs();
        }
        StopCoroutine(AutoRestartAfterDie());
    }

    public void GameOver()
    {
        if (lifes > 0)
        {
            PlayDieSound();
            isGameActive = false;
            lifes -= 1;
            saveTest.SavePrefs();
            uiManager.SetMoveVisibility(false);
            StartCoroutine(AutoRestartAfterDie());
        }
        else
        {
            isGameActive = false;
            PlayDeathSound();
            uiManager.SetGameOverVisibility(true);
        }
    }

    public void MainMenuScene()
    {
        SceneManager.LoadScene(0);
    }

    IEnumerator AutoRestartAfterDie()
    {
        yield return new WaitForSeconds(3);
        RestartLevel();
    }

    public void SetCountDownTime(float time)
    {
        countDownTime = time;
    }

    public void SetWin(bool win)
    {
        this.win = win;
    }

    public void SetPauseTimer(bool pause)
    {
        pauseTimer = pause;
    }

    public bool GetIsGameActive()
    {
        return isGameActive;
    }

    public int GetTimeToCompleteMission()
    {
        return timeToCompleteMission;
    }

    public void SetScoreCount(int score)
    {
        scoreCounter += score;
    }
    public int GetScoreCount()
    {
        return scoreCounter;
    }

    public void SetInvincible(bool invincible)
    {
        this.invincible = invincible;
    }
    public bool GetInvincible()
    {
        return invincible;
    }

    public void SetLifes(int lifes)
    {
        this.lifes = lifes;
    }

    public int GetLifes()
    {
        return lifes;
    }
}