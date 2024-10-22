using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveTest : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;

    public void SavePrefs()
    {
        PlayerPrefs.SetInt("Lifes", gameManager.GetLifes());
    }

    public void LoadPrefs()
    {
        gameManager.SetLifes(PlayerPrefs.GetInt("Lifes"));
    }
}
