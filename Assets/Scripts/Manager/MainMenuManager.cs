using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour
{
    [SerializeField] private GameObject chooseLevelMenu;
    [SerializeField] private GameObject settingsMenu;
    [SerializeField] private GameObject mainMenu;
    [SerializeField] private Button playButton;
    [SerializeField] private Button settingsButton;
    [SerializeField] private Button quitButton;
    [SerializeField] private Button backButton;

    private Animator uiAnimator;

    // Start is called before the first frame update
    void Start()
    {
        mainMenu.SetActive(true);
    }

    public void ShowLevelMenu()
    {
        chooseLevelMenu.SetActive(true);
        mainMenu.SetActive(false);
        backButton.gameObject.SetActive(true);
    }

    public void ShowSettingsMenu()
    {
        mainMenu.SetActive(false);
        settingsMenu.SetActive(true);
        backButton.gameObject.SetActive(true);
    }

    public void ShowMainMenu()
    {
        mainMenu.SetActive(true);
        settingsMenu.SetActive(false);
        chooseLevelMenu.SetActive(false);
        backButton.gameObject.SetActive(false);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
